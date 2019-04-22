using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DPUruNet;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Http;
using MaxTechGym.Models;

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
        bool fingerprintCaptured;

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
            fingerprintCaptured = false;
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
                        fingerprintCaptured = true;
                        if (fingerprintCaptured)
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
                        fingerprintCaptured = false;
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
            int DPFJ_PROBABILITY_ONE = 0x7fffffff;
            
            // populate all fmds
            Fmd[] allFMDs = new Fmd[Program.fingerprints.Rows.Count];

            for (int i = 0; i<Program.fingerprints.Rows.Count; i++)
            {
                allFMDs[i] = Fmd.DeserializeXml(Program.fingerprints.Rows[i]["fingerprint"].ToString());
            }
            
            IdentifyResult identifyResult = Comparison.Identify(resultEnrollment.Data, 0, allFMDs, (DPFJ_PROBABILITY_ONE * 1 / 100000), 1);
            return ((identifyResult.Indexes != null) && (identifyResult.Indexes.Length > 0));
        }



        private async void registrarAlumno_Click(object sender, EventArgs e)
        {

            // Create new member objet
            Member member = new Member();

            // Obtain data
            member.name = nombreBox.Text;
            DateTime fechaNacimiento = fechaNacimientoBox.Value;
            member.birthDate = fechaNacimiento.ToString("yyyy-MM-dd");


            if (generoBox.SelectedItem == null)
            {
                member.gender = "";
            }
            else
            {
                member.gender = generoBox.SelectedItem.ToString();
            }
                 

            if (comoBox.SelectedItem == null)
            {
                member.howDidYouKnow = "";
            }
            else
            {
                member.howDidYouKnow = comoBox.SelectedItem.ToString();
            }

            member.email = emailBox.Text;
            member.address = calleBox.Text + " " + coloniaBox.Text;
            member.city = municipioBox.Text;
            member.phone = telefonoBox.Text;
            DateTime expDate = await GymAPI.GetDateTime();
            member.expDate = expDate.ToString("yyyy-MM-dd");
            member.lastVisit = member.expDate;

            // Validate mandatory data
            // Name
            if (nombreBox.Text == null || nombreBox.Text.Trim() == "")
            {
                MessageBox.Show("El nombre del alumno es obligatorio!");
                nombreBox.Text = "";
                nombreBox.Select();
                return;
            }

            // Email
            Regex reg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (requerido.Checked == true && !reg.IsMatch(member.email))
            {
                MessageBox.Show("El correo electronico no es valido!");
                emailBox.Select();
                return;
            }

            // How did you know
            if (member.howDidYouKnow == "")
            {
                MessageBox.Show("Debes seleccionar como se entero!");
                return;
            }

            // Gender
            if (member.gender == "")
            {
                MessageBox.Show("Debes seleccionar el genero!");
                return;
            }

            // For practicity we only check that the year introduced is lower than the actual.
            if (expDate.Year <= fechaNacimiento.Year)
            {
                MessageBox.Show("Debes introducir la fecha de nacimiento, verifica los datos");
                return;
            }

            // Check if the fingerprint has been captured
            if (!fingerprintCaptured)
            {
                MessageBox.Show("No se han capturado todas las huellas.");
                return;
            }

            // Verify if fingerprint already exists
            if (existeHuella(resultEnrollment))
            {
                MessageBox.Show("La huella ya existe en el sistema");
                return;
            } 
            else
            {
                member.fingerprint = Fmd.SerializeXml(resultEnrollment.Data);
            }

            // Insert data
            HttpResponseMessage message = await GymAPI.insertMember(member);

            if(message.IsSuccessStatusCode)
            {
                MessageBox.Show("Alumno registrado!");
                Close();
            }
            else
            {
                MessageBox.Show(message.ReasonPhrase);
            }


        }

    }
}
