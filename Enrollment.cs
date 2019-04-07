using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DPUruNet;
using System.Data;
using System.Text.RegularExpressions;



namespace MaxTechGym
{
    public partial class Enrollment : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;

        List<Fmd> preenrollmentFmds;
        DataResult<Fmd> resultEnrollment;
        int count;
        bool huellaCapturada;

        public Enrollment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enrollment_Load(object sender, System.EventArgs e)
        {
            nombreBox.Text = string.Empty;
            fechaNacimientoBox.Value = DateTime.Now;
            generoBox.SelectedIndex = -1;
            emailBox.Text = string.Empty;
            comoBox.SelectedIndex = -1;
            txtEnroll.Text = string.Empty;
            calleBox.Text = string.Empty;
            coloniaBox.Text = string.Empty;
            municipioBox.Text = string.Empty;
            telefonoBox.Text = string.Empty;

            preenrollmentFmds = new List<Fmd>();
            count = 0;
            huellaCapturada = false;
            registrarAlumno.Enabled = true;
            preenrollmentFmds.Clear();

            SendMessage(Action.SendMessage, "Coloca el dedo indice derecho en el lector.\r\n");

            if (!_sender.OpenReader())
            {
                this.Close();
            }

            if (!_sender.StartCaptureAsync(this.OnCaptured))
            {
                this.Close();
            }

        }


        /// <summary>
        /// Handler for when a fingerprint is captured.
        /// </summary>
        /// <param name="captureResult">contains info and data on the fingerprint capture</param>
        private void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!_sender.CheckCaptureResult(captureResult)) return;

                count++;

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);

                if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(resultConversion.ResultCode.ToString());
                }

                preenrollmentFmds.Add(resultConversion.Data);
                SendMessage(Action.SendMessage, "Huella #" + count + " capturada");

                if (count >= 4)
                {
                    resultEnrollment = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.ANSI, preenrollmentFmds);

                    if (resultEnrollment.ResultCode == Constants.ResultCode.DP_SUCCESS)
                    {
                        SendMessage(Action.SendMessage, "\r\nLa huella digital ha sido registrada!");
                        huellaCapturada = true;
                        if (huellaCapturada)
                            SendMessage(Action.habilitarRegistro, null);

                        count = 0;
                        return;
                    }
                    else if (resultEnrollment.ResultCode == Constants.ResultCode.DP_ENROLLMENT_INVALID_SET)
                    {
                        SendMessage(Action.SendMessage, "Error, por favor intentalo de nuevo.");
                        SendMessage(Action.SendMessage, "Coloca el dedo indice derecho en el lector.");
                        preenrollmentFmds.Clear();
                        count = 0;
                        huellaCapturada = false;
                        return;
                    }
                }

                SendMessage(Action.SendMessage, "Coloca el mismo dedo de nuevo.");
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                SendMessage(Action.SendMessage, "Error:  " + ex.Message);
            }
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void Enrollment_Closed(object sender, System.EventArgs e)
        {
            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
        }

        #region SendMessage
        private enum Action
        {
            SendMessage,
            habilitarRegistro
        }

        private delegate void SendMessageCallback(Action action, string payload);
        private void SendMessage(Action action, string payload)
        {
            try
            {
                if (this.txtEnroll.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.SendMessage:
                            txtEnroll.Text += payload + "\r\n";
                            txtEnroll.SelectionStart = txtEnroll.TextLength;
                            txtEnroll.ScrollToCaret();
                            break;
                        case Action.habilitarRegistro:
                            registrarAlumno.Enabled = true;
                            break;

                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        private void noAsociado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private bool existeHuella(DataResult<Fmd> resultEnrollment)
        {
            if (!huellaCapturada) return false;

            int DPFJ_PROBABILITY_ONE = 0x7fffffff;
            MySqlDataReader lReader = Form_Main.sqlExec("select huella,id from asociado where huella is not null");
            // populate all fmds
            DataTable dt = new DataTable();
            dt.Load(lReader);
            Fmd[] allDBFmd1s = new Fmd[dt.Rows.Count];

            int i = 0;
            if (dt.Rows.Count != 0)
            {
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    if (dr["huella"].ToString().Length != 0)
                    {
                        allDBFmd1s[i] = Fmd.DeserializeXml(dr["huella"].ToString());
                    }
                    i++;
                }
            }
            lReader.Close();

            IdentifyResult identifyResult = Comparison.Identify(resultEnrollment.Data, 0, allDBFmd1s, (DPFJ_PROBABILITY_ONE * 1 / 100000), 1);

            if (identifyResult.Indexes == null)
                return false;
            else
                return (identifyResult.Indexes.Length > 0);
        }



        private void registrarAlumno_Click(object sender, EventArgs e)
        {

            // Obtener datos
            string nombre = nombreBox.Text;
            DateTime fechaNacimiento = fechaNacimientoBox.Value;

            string genero;
            if (generoBox.SelectedItem == null) genero = ""; else genero = generoBox.SelectedItem.ToString();
            string comoSeEntero;
            if (comoBox.SelectedItem == null) comoSeEntero = ""; else comoSeEntero = comoBox.SelectedItem.ToString();

            string email = emailBox.Text;
            string direccion = calleBox.Text + " " + coloniaBox.Text;
            string municipio = municipioBox.Text;
            string telefono = telefonoBox.Text;
            DateTime fechaVencimiento = DateTime.Today;


            // Validar datos obligatorios
            // Nombre
            if (nombreBox.Text == null || nombreBox.Text.Trim() == "")
            {
                MessageBox.Show("El nombre del alumno es obligatorio!");
                nombreBox.Text = "";
                nombreBox.Select();
                return;
            }

            // Email
            Regex reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (requerido.Checked == true && !reg.IsMatch(email))
            {
                MessageBox.Show("El correo electronico no es valido!");
                emailBox.Select();
                return;
            }

            // Como se entero
            if (comoSeEntero == "")
            {
                MessageBox.Show("Debes seleccionar como se entero!");
                return;
            }

            // Genero
            if (genero == "")
            {
                MessageBox.Show("Debes seleccionar el genero!");
                return;
            }

            // Obtener fecha del servidor
            MySqlDataReader dataReader = Form_Main.sqlExec("SELECT NOW()");
            if (dataReader.Read())
            {
                fechaVencimiento = dataReader.GetDateTime(0);
            }


            // For practicity we only check that the year introduced is lower than the actual.
            if (dataReader.GetDateTime(0).Year <= fechaNacimiento.Year)
            {
                MessageBox.Show("Debes introducir la fecha de nacimiento, verifica los datos");
                return;
            }



            // Verificar si ya existe huella
            if (existeHuella(resultEnrollment))
            {
                MessageBox.Show("La huella ya existe en el sistema");
                return;
            }

            // Insert data
            if (huellaCapturada)
            {
                Form_Main.sqlExec("INSERT INTO asociado (nombre, fechaNacimiento, genero, email, comoSeEntero, direccion, municipio, telefono, fechaVencimiento, ultimaVisita, huella, cliente) VALUES ('" + nombre + "','" + fechaNacimiento.ToString("yyyy-MM-dd") + "','" + genero + "','" + email + "','" + comoSeEntero + "','" + direccion + "','" + municipio + "','" + telefono + "','" + fechaVencimiento.ToString("yyyy-MM-dd") + "', NOW(), '" + Fmd.SerializeXml(resultEnrollment.Data) + "','"+ Program.CLIENTE +"')");
            }
            else
            {
                MessageBox.Show("No se han capturado todas las huellas.");
                return;
            }


            MessageBox.Show("Alumno registrado!");
            this.Close();

        }

    }
}
