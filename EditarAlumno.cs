using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DPUruNet;
using System.Data;
using System.Text.RegularExpressions;



namespace MaxTechGym
{
    public partial class EditarAlumno : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;

        List<Fmd> preenrollmentFmds;
        DataResult<Fmd> resultEnrollment;
        int count;
        bool huellaCapturada;
        public int idAlumno;
        private DataTable datosAlumno = new DataTable();


        public EditarAlumno()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditarAlumno_Load(object sender, System.EventArgs e)
        {

            MySqlDataReader reader = Form_Main.sqlExec("select * from asociado where id = '"+ idAlumno +"'");
            datosAlumno.Load(reader);

            nombreBox.Text = Convert.ToString(datosAlumno.Rows[0]["nombre"]);
            fechaNacimientoBox.Value = Convert.ToDateTime(datosAlumno.Rows[0]["fechaNacimiento"]);
            emailBox.Text = Convert.ToString(datosAlumno.Rows[0]["email"]);
            direccion.Text = Convert.ToString(datosAlumno.Rows[0]["direccion"]);
            municipioBox.Text = Convert.ToString(datosAlumno.Rows[0]["municipio"]);
            telefonoBox.Text = Convert.ToString(datosAlumno.Rows[0]["telefono"]);
            generoBox.Text = Convert.ToString(datosAlumno.Rows[0]["genero"]);
            comoBox.Text = Convert.ToString(datosAlumno.Rows[0]["comoSeEntero"]);
            fechaCortePicker.Value = Convert.ToDateTime(datosAlumno.Rows[0]["fechaVencimiento"]);

            txtEnroll.Text = string.Empty;

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
            // No necesitamos capturar huella
            if (!checkBox1.Checked) return;

            try
            {
                // Check capture quality and throw an error if bad.
                if (!_sender.CheckCaptureResult(captureResult)) return;

                count++;

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);

                SendMessage(Action.SendMessage, "Huella #" + count + " capturada");

                if (resultConversion.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(resultConversion.ResultCode.ToString());
                }

                preenrollmentFmds.Add(resultConversion.Data);

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
        private void EditarAlumno_Closed(object sender, System.EventArgs e)
        {
            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
            BuscarAlumnos parent = (BuscarAlumnos)this.Owner;
            parent.setupForCapture();
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
            if(generoBox.SelectedItem == null) genero = ""; else genero = generoBox.SelectedItem.ToString();
            string comoSeEntero;
            if (comoBox.SelectedItem == null) comoSeEntero = ""; else comoSeEntero = comoBox.SelectedItem.ToString();
            
            string email = emailBox.Text;
            string direccion2 = direccion.Text;
            string municipio = municipioBox.Text;
            string telefono = telefonoBox.Text;
            DateTime fechaVencimiento = fechaCortePicker.Value;


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
            if (!reg.IsMatch(email))
            {
                MessageBox.Show("El correo electronico no es valido!");
                emailBox.Select();
                return;
            }

            // Genero
            if (genero == "")
            {
                MessageBox.Show("Debes seleccionar el genero!");
                return;
            }

            // Verificar si ya existe huella
            if (existeHuella(resultEnrollment))
            {
                MessageBox.Show("La huella ya existe en el sistema");
                return;
            }

            // Actualizar datos
            if (checkBox1.Checked)
            {
                Form_Main.sqlExec("UPDATE asociado SET nombre = '" + nombre + "', fechaNacimiento = '" + fechaNacimiento.ToString("yyyy-MM-dd") + "', genero = '" + genero + "', email = '" + email + "', comoSeEntero = '" + comoSeEntero + "', direccion='" + direccion2 + "', municipio='" + municipio + "', telefono='" + telefono + "', fechaVencimiento='" + fechaVencimiento.ToString("yyyy-MM-dd") + "', huella = '" + Fmd.SerializeXml(resultEnrollment.Data) + "' where id = " + idAlumno );
            }
            else
            {
                Form_Main.sqlExec("UPDATE asociado SET nombre = '" + nombre + "', fechaNacimiento = '" + fechaNacimiento.ToString("yyyy-MM-dd") + "', genero = '" + genero + "', email = '" + email + "', comoSeEntero = '" + comoSeEntero + "', direccion='" + direccion2 + "', municipio='" + municipio + "', telefono='" + telefono + "', fechaVencimiento='" + fechaVencimiento.ToString("yyyy-MM-dd") + "' where id = " + idAlumno);
            }


            MessageBox.Show("Informacion actualizada!");
            this.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && !huellaCapturada)
            {
                txtEnroll.Enabled = true;
                registrarAlumno.Enabled = false;
                return;
            }

            if (checkBox1.Checked && huellaCapturada)
            {
                txtEnroll.Enabled = true;
                registrarAlumno.Enabled = true;
                return;
            }

            if (!checkBox1.Checked && huellaCapturada)
            {
                txtEnroll.Enabled = false;
                registrarAlumno.Enabled = true;
                return;
            }

            if (!checkBox1.Checked && !huellaCapturada)
            {
                txtEnroll.Enabled = false;
                registrarAlumno.Enabled = true;
                return;
            }
           
        }

    }
}
