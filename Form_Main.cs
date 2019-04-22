using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using DPUruNet;
using System.Data;
using System.Threading.Tasks;

namespace MaxTechGym
{
    public partial class Form_Main : Form
    {

        //Tasks
        private Task<DataTable> getAllFingerPrints;


        /// <summary>
        /// Holds fmds enrolled by the enrollment GUI.
        /// </summary>
        public Dictionary<int, Fmd> Fmds
        {
            get { return fmds; }
            set { fmds = value; }
        }
        private Dictionary<int, Fmd> fmds = new Dictionary<int, Fmd>();
        
        /// <summary>
        /// Reset the UI causing the user to reselect a reader.
        /// </summary>
        public bool Reset
        {
            get { return reset; }
            set { reset = value; }
        }
        private bool reset;

        public Form_Main()
        {
            getAllFingerPrints = GymAPI.getAllFingerPrints();
            InitializeComponent();
        }

        // When set by child forms, shows s/n and enables buttons.
        public Reader CurrentReader
        {
            get { return currentReader; }
            set
            {
                currentReader = value;
            }
        }
        public Reader currentReader;

        #region Click Event Handlers


        private Identification _identification;
        private void btnIdentify_Click(System.Object sender, System.EventArgs e)
        {
            if (_identification == null)
            {
                _identification = new Identification();
                _identification._sender = this;
            }

            _identification.ShowDialog();

            _identification.Dispose();
            _identification = null;
        }

        private Enrollment _enrollment;
        private void btnEnroll_Click(System.Object sender, System.EventArgs e)
        {
            if (_enrollment == null)
            {
                _enrollment = new Enrollment();
                _enrollment._sender = this;
            }

            _enrollment.ShowDialog();
        }

        private BuscarAlumnos _buscarAlumnos;
        private void buscarAlumnos_Click(object sender, EventArgs e)
        {
            if (_buscarAlumnos == null)
            {
                _buscarAlumnos = new BuscarAlumnos();
                _buscarAlumnos._sender = this;
            }

            _buscarAlumnos.ShowDialog();
        }

        private Reportes _reportes;
        private void button1_Click(object sender, EventArgs e)
        {
            if (_reportes == null)
            {
                _reportes = new Reportes();

            }

            _reportes.ShowDialog();
        }


        private Administracion _administracion;
        private void button2_Click(object sender, EventArgs e)
        {

            if (_administracion == null)
            {
                _administracion = new Administracion();

            }

            _administracion.ShowDialog();

        }

        #endregion

        /// <summary>
        /// Open a device and check result for errors.
        /// </summary>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool OpenReader()
        {
            reset = false;
            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

            // Is the Reader connected?
            if (currentReader == null)
            {
                MessageBox.Show("Error: No Hay ningun lector conectado");
                reset = true;
                return false;
            }

            // Open reader
            result = currentReader.Open(Constants.CapturePriority.DP_PRIORITY_EXCLUSIVE);

            if (result != Constants.ResultCode.DP_SUCCESS)
            {
                MessageBox.Show("Error:  " + result);
                reset = true;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Hookup capture handler and start capture.
        /// </summary>
        /// <param name="OnCaptured">Delegate to hookup as handler of the On_Captured event</param>
        /// <returns>Returns true if successful; false if unsuccessful</returns>
        public bool StartCaptureAsync(Reader.CaptureCallback OnCaptured)
        {
            //TODO delete this line below
            //return true;

            // If the reader is null, most likely the reader is not connected
            if (currentReader == null) return false;

            // Activate capture handler
            currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

            // Call capture
            if (!CaptureFingerAsync())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Cancel the capture and then close the reader.
        /// </summary>
        /// <param name="OnCaptured">Delegate to unhook as handler of the On_Captured event </param>
        public void CancelCaptureAndCloseReader(Reader.CaptureCallback OnCaptured)
        {
            if (currentReader != null)
            {
                // Dispose of reader handle and unhook reader events.
                currentReader.Dispose();

                if (reset)
                {
                    CurrentReader = null;
                }
            }
        }

        /// <summary>
        /// Check the device status before starting capture.
        /// </summary>
        /// <returns></returns>
        public void GetStatus()
        {
            Constants.ResultCode result = currentReader.GetStatus();

            if ((result != Constants.ResultCode.DP_SUCCESS))
            {
                reset = true;
                throw new Exception("" + result);   
            }

            if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
            {
                Thread.Sleep(50);
            }
            else if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                currentReader.Calibrate();
            }
            else if ((currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                throw new Exception("Reader Status - " + currentReader.Status.Status);   
            }
        }
        
        /// <summary>
        /// Check quality of the resulting capture.
        /// </summary>
        public bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    throw new Exception("Quality - " + captureResult.Quality);
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// Function to capture a finger. Always get status first and calibrate or wait if necessary.  Always check status and capture errors.
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public bool CaptureFingerAsync()
        {
            try
            {
                GetStatus();

                Constants.ResultCode captureResult = currentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, currentReader.Capabilities.Resolutions[0]);
                if (captureResult != Constants.ResultCode.DP_SUCCESS)
                {
                    reset = true;
                    throw new Exception("" + captureResult);            
                }

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Create a bitmap from raw data in row/column format.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }

        #region SendMessage
        private enum Action
        {
           UpdateReaderState 
        }
        private delegate void SendMessageCallback(Action state, object payload);

        #endregion

        public static MySqlDataReader sqlExec(string Script)
        {
            MySqlDataReader dataReader = null;
            MySqlConnection conn = new MySqlConnection("server=23.229.189.34; port=3306; user=gym_client; database=gimnasio_maxtech; password=6u&apjV%; Convert Zero Datetime=True");
            //MySqlConnection conn = new MySqlConnection("server=localhost; port=3306; user=gym_client; database=gimnasio_maxtech; password=6u&apjV%; Convert Zero Datetime=True");

            try
            {
                conn.Open();
                MySqlCommand sqlCommand = new MySqlCommand(Script, conn);
                dataReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No fue posible establecer la conexion, verifica que haya acceso a internet. " + ex.Message);
            }

            return dataReader;
        }


        public static MySqlDataAdapter ConnectDBAdapter(string Script)
        {
            MySqlDataAdapter DataAdapter = null;
            MySqlConnection conn = new MySqlConnection("server=23.229.189.34; port=3306; user=gym_client; database=gimnasio_maxtech; password=6u&apjV%; Convert Zero Datetime=True");
            //MySqlConnection conn = new MySqlConnection("server=localhost; port=3306; user=gym_client; database=gimnasio_maxtech; password=6u&apjV%; Convert Zero Datetime=True");

            try
            {
                conn.Open();
                DataAdapter = new MySqlDataAdapter(Script, conn);     
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("No fue posible establecer la conexion, verifica que haya acceso a internet. " + ex.Message);
            }

            return DataAdapter;
        }



        private async void Form_Main_Load(object sender, EventArgs e)
        {

            this.BackColor = (Color)Properties.Settings.Default["BackgroundColor"];

            ReaderCollection readers = ReaderCollection.GetReaders();
            currentReader = readers[0];

            //If there is no reader connected. Close the app.
            if (currentReader == null)
            {
                MessageBox.Show("No se detecto ningun lector conectado, la aplicacion cerrara.");
                Application.Exit();
                return;
            }

            //get all the FMDs (fingerprints)
            Program.fingerprints = await getAllFingerPrints;
        }


        private void Form_Main_Shown(object sender, EventArgs e)
        {
            if(Program.DEBUG_MODE == true)
            {
                Program.CLIENT = Program.TEST_CLIENT;
            }
            else
            {
                Acceso Acceso = new Acceso();
                Acceso.ShowDialog();
            }

        }
    }
}