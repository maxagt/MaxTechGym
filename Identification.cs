using System;
using System.Windows.Forms;
using DPUruNet;
using System.Data;
using System.Drawing;
using System.Net.Http;

namespace MaxTechGym
{
    public partial class Identification : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;

        private const int DPFJ_PROBABILITY_ONE = 0x7fffffff;
        private static Fmd[] allDBFMDs;

        public Identification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Identification_Load(object sender, EventArgs e)
        {
            // populate all fmds
            allDBFMDs = new Fmd[Program.fingerprints.Rows.Count];
            int i = 0;

            if (Program.fingerprints.Rows.Count > 0)
            {
                foreach (DataRow dr in Program.fingerprints.Rows)
                {
                    allDBFMDs[i] = Fmd.DeserializeXml(dr["fingerprint"].ToString());     
                    i++;
                }
            }

            if (!_sender.OpenReader())
            {
                Close();
            }

            if (!_sender.StartCaptureAsync(OnCaptured))
            {
                Close();
            }
        }


        /// <summary>
        /// Handler for when a fingerprint is captured.
        /// </summary>
        /// <param name="captureResult">contains info and data on the fingerprint capture</param>
        private async void OnCaptured(CaptureResult captureResult)
        {

            try
            {
                // Check capture quality and throw an error if bad.
                if (!_sender.CheckCaptureResult(captureResult)) return;


                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, _sender.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // See the SDK documentation for an explanation on threshold scores.
                int thresholdScore = DPFJ_PROBABILITY_ONE * 1 / 100000;

                IdentifyResult identifyResult = Comparison.Identify(resultConversion.Data, 0, allDBFMDs, thresholdScore, 1);

                if (identifyResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(identifyResult.ResultCode.ToString());
                }
                
                // If we cant find a match
                if (identifyResult.Indexes.Length == 0)
                {
                    SendMessage(Action.NotFound, null);
                }
                else
                {
                    // If we find a match
                    if (identifyResult.Indexes.Length > 0)
                    {
                        // Position returned inside de FMD list
                        int index = identifyResult.Indexes[0][0];

                        // Get the member Id identified from the fingerprint capture
                        string memberId = Program.fingerprints.Rows[index]["id"].ToString();

                        // Call the API
                        DataTable member = await GymAPI.getMemberById(memberId);
                        DataRow memberData = member.Rows[0];

                        Double offset = Convert.ToDouble(Properties.Settings.Default["HourOffset"]);
                        string name = (string)memberData["name"];
                        DateTime expDate = ((DateTime)memberData["expDate"]).AddHours(offset);
                        int totalVisits = Convert.ToInt32(memberData["totalVisits"]);
                        DateTime lastVisit = ((DateTime)memberData["lastVisit"]).AddHours(offset);
                        string owed = memberData["owed"].ToString();

                        // Comparar fechas
                        if ((expDate - DateTime.Now).TotalDays < 0)
                            SendMessage(Action.Vencido, Color.Red);
                        else
                            if ((expDate - DateTime.Now).TotalDays <= 7)
                                SendMessage(Action.PorVencer, Color.Yellow);
                            else
                                SendMessage(Action.NoVencido, default(Color));

                        if (Convert.ToInt32(owed) > 0) 
                            SendMessage(Action.adeudoPositivo, Color.Yellow);
                        else
                            SendMessage(Action.NoAdeudo, default(Color));


                        // Update labels
                        SendMessage(Action.Name, name);
                        SendMessage(Action.memberNumber, memberId);
                        SendMessage(Action.nextPayment, expDate.ToString("MMMM dd, yyyy", new System.Globalization.CultureInfo("es-MX")));
                        SendMessage(Action.totalVisits, totalVisits.ToString());
                        SendMessage(Action.lastVisit, lastVisit);
                        SendMessage(Action.owed, owed);

                        // Update visits from member
                        HttpResponseMessage UpdateMessage = await GymAPI.updateMemberById(memberId);

                        // Add a visit to the table
                        HttpResponseMessage InsertMessage = await GymAPI.insertVisitById(memberId);


                    }
                    
                }   
                
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                MessageBox.Show(ex.Message);               
            }
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void Identification_Closed(object sender, EventArgs e)
        {
            _sender.CancelCaptureAndCloseReader(OnCaptured);
        }

        #region SendMessage
        private enum Action
        {
            Name,
            owed,
            memberNumber,
            nextPayment,
            totalVisits,
            lastVisit,
            NotFound,
            SendBitmap,
            PorVencer,
            Vencido,
            adeudoPositivo,
            NoVencido,
            NoAdeudo
            
        }
        private delegate void SendMessageCallback(Action action, object payload);
        private void SendMessage(Action action, object payload)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { action, payload });
                }
                else
                {
                    switch (action)
                    {
                        case Action.Name:
                            nombreDesc.Text = (string)payload;
                            asistencia.Text = "Asistencia registrada";
                            asistencia.ForeColor = System.Drawing.Color.DarkGreen;
                            asistencia.Visible = true;                           
                            break;
                        case Action.adeudoPositivo:
                            adeudo.BackColor = (Color)payload;
                            break;
                        case Action.NoVencido:
                            vencimientoDesc.BackColor = (Color)payload;
                            break;
                        case Action.NoAdeudo:
                            adeudo.BackColor = (Color)payload;
                            break;
                        case Action.owed:
                            adeudo.Text = (string)payload;
                            break;
                        case Action.memberNumber:
                            noAsociadoDesc.Text = (string)payload;
                            break;
                        case Action.nextPayment:
                            vencimientoDesc.Text = (string)payload;
                            break;
                        case Action.totalVisits:
                            totalVisitasDesc.Text = (string)payload;
                            break;
                        case Action.lastVisit:
                            ultimaVisitaDesc.Text = Convert.ToString(payload);
                            break;
                        case Action.PorVencer:
                            vencimientoDesc.BackColor = (Color)payload;
                            break;
                        case Action.Vencido:
                            vencimientoDesc.BackColor = (Color)payload;
                            break;
                        case Action.NotFound:
                            nombreDesc.Text = "";
                            adeudo.Text = "";
                            noAsociadoDesc.Text = "";
                            totalVisitasDesc.Text = "";
                            ultimaVisitaDesc.Text = "";
                            vencimientoDesc.Text = "";
                            asistencia.Text = "Alumno no encontrado";
                            asistencia.Visible = true;
                            asistencia.ForeColor = System.Drawing.Color.Red;
                            break;
                        case Action.SendBitmap:
                            this.Show();
                            this.WindowState = FormWindowState.Normal;
                            this.Focus();
                            pbFingerprint.Image = (Bitmap)payload;
                            pbFingerprint.Refresh();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    }
}