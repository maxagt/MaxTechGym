using System;
using System.Windows.Forms;
using DPUruNet;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace MaxTechGym
{
    public partial class Identification : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;

        private const int DPFJ_PROBABILITY_ONE = 0x7fffffff;
        private static Fmd[] allDBFmd1s;
        private static int[] allIdAsociados;

        public Identification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Identification_Load(object sender, System.EventArgs e)
        {
            MySqlDataReader lReader = Form_Main.sqlExec("select id, huella from asociado where huella is not null");

            // populate all fmds
            DataTable dt = new DataTable();
            dt.Load(lReader);
            allDBFmd1s = new Fmd[dt.Rows.Count];
            allIdAsociados = new int[dt.Rows.Count];
            int i = 0;


            // allfingerIDs = new int[dt.Rows.Count];
            if (dt.Rows.Count != 0)
            {
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    if (dr["huella"].ToString().Length != 0)
                    {
                        allDBFmd1s[i] = Fmd.DeserializeXml(dr["huella"].ToString());
                        allIdAsociados[i] = Convert.ToInt32(dr["id"]);
                    }
                    i++;
                }
            }
            lReader.Close();

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

                // Create bitmap
                foreach (Fid.Fiv fiv in captureResult.Data.Views)
                {
                    SendMessage(Action.SendBitmap, _sender.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }
            }
            catch (Exception ex)
            {
                // Send error message, then close form
                MessageBox.Show(ex.Message);
            }


            try
            {
                // Check capture quality and throw an error if bad.
                if (!_sender.CheckCaptureResult(captureResult)) return;

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // See the SDK documentation for an explanation on threshold scores.
                int thresholdScore = DPFJ_PROBABILITY_ONE * 1 / 100000;

                IdentifyResult identifyResult = Comparison.Identify(resultConversion.Data, 0, allDBFmd1s, thresholdScore, 1);

                if (identifyResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(identifyResult.ResultCode.ToString());
                }
                
                if (identifyResult.Indexes.Length == 0)
                {
                    SendMessage(Action.NoEncontrado, null);
                }
                else
                {
                    // Obtener numero de asociado
                    int noAsociado = allIdAsociados[identifyResult.Indexes[0][0]];

                    // Obtener datos
                    MySqlDataReader dataReader = Form_Main.sqlExec("select * from asociado where id = " + noAsociado.ToString());

                    if (dataReader.Read())
                    {
                        Double offset = Convert.ToDouble(Properties.Settings.Default["HourOffset"]);
                        string nombre = dataReader.GetString("nombre");
                        DateTime vencimiento = dataReader.GetDateTime("fechaVencimiento").AddHours(offset);
                        int totalVisitas = dataReader.GetInt32("totalVisitas");
                        DateTime ultimaVisita = dataReader.GetDateTime("ultimaVisita").AddHours(offset);
                        string adeudo = dataReader.GetInt32("adeudo").ToString();

                        // Comparar fechas
                        if ((vencimiento - DateTime.Now).TotalDays < 0)
                            SendMessage(Action.Vencido, System.Drawing.Color.Red);
                        else
                            if ((vencimiento - DateTime.Now).TotalDays <= 7)
                                SendMessage(Action.PorVencer, System.Drawing.Color.Yellow);
                            else
                                SendMessage(Action.NoVencido, default(Color));

                        if (Convert.ToInt32(adeudo) > 0) 
                            SendMessage(Action.adeudoPositivo, System.Drawing.Color.Yellow);
                        else
                            SendMessage(Action.NoAdeudo, default(Color));


                        // Actualizar labels
                        SendMessage(Action.Nombre, nombre);
                        SendMessage(Action.NumeroAsociado, noAsociado.ToString());
                        SendMessage(Action.ProximoPago, vencimiento.ToString("MMMM dd, yyyy", new System.Globalization.CultureInfo("es-MX")));
                        SendMessage(Action.TotalVisitas, totalVisitas.ToString());
                        SendMessage(Action.UltimaVisita, ultimaVisita);
                        SendMessage(Action.Adeudo, adeudo);

                        // Actualizar asistencia de asociado
                        Form_Main.sqlExec("UPDATE asociado set totalVisitas = totalVisitas+1, ultimaVisita = NOW()  where id = " + noAsociado);

                        // Agregar visita a la tabla
                        Form_Main.sqlExec("INSERT into visitas (fecha, idAsociado, cliente) values ( NOW(), " + noAsociado + ",'" + Program.CLIENTE + "')");


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
        private void btnBack_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void Identification_Closed(object sender, System.EventArgs e)
        {
            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
        }

        #region SendMessage
        private enum Action
        {
            Nombre,
            Adeudo,
            NumeroAsociado,
            ProximoPago,
            TotalVisitas,
            UltimaVisita,
            NoEncontrado,
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
                        case Action.Nombre:
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
                        case Action.Adeudo:
                            adeudo.Text = (string)payload;
                            break;
                        case Action.NumeroAsociado:
                            noAsociadoDesc.Text = (string)payload;
                            break;
                        case Action.ProximoPago:
                            vencimientoDesc.Text = (string)payload;
                            break;
                        case Action.TotalVisitas:
                            totalVisitasDesc.Text = (string)payload;
                            break;
                        case Action.UltimaVisita:
                            ultimaVisitaDesc.Text = Convert.ToString(payload);
                            break;
                        case Action.PorVencer:
                            vencimientoDesc.BackColor = (Color)payload;
                            break;
                        case Action.Vencido:
                            vencimientoDesc.BackColor = (Color)payload;
                            break;
                        case Action.NoEncontrado:
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