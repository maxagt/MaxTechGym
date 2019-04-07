using System;
using System.Windows.Forms;
using DPUruNet;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace MaxTechGym
{
    public partial class BuscarAlumnos : Form
    {
        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>
        public Form_Main _sender;

        private const int DPFJ_PROBABILITY_ONE = 0x7fffffff;
        private static DateTime fechaActual;

        public BuscarAlumnos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarAlumnos_Load(object sender, System.EventArgs e)
        {
            // Borramos los elementos del grid
            listaAlumnos.Rows.Clear();

            // Centramos las celdas y encabezados
            listaAlumnos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment

            listaAlumnos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment

            listaAlumnos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment  
                                                                                                            
            listaAlumnos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment 


            // Nos traemos los datos
            MySqlDataReader lReader = Form_Main.sqlExec("select id, nombre, email, fechaNacimiento from asociado LIMIT 50");
            DataTable dt = new DataTable();
            dt.Load(lReader);

            // Obtenemos fecha del server
            MySqlDataReader reader = Form_Main.sqlExec("select NOW()");
            if (reader.Read())
            {
                fechaActual = reader.GetDateTime(0);
            }

            // LLenamos el datagrid con los primeros 50 alumnos
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime nacimiento = (DateTime)dt.Rows[i]["fechaNacimiento"];
                int edad = fechaActual.Year - nacimiento.Year;

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(listaAlumnos);
                row.Cells[0].Value = dt.Rows[i]["id"];
                row.Cells[1].Value = dt.Rows[i]["nombre"];
                row.Cells[2].Value = edad;
                row.Cells[3].Value = dt.Rows[i]["email"];
                listaAlumnos.Rows.Add(row);
            }

            // Validamos que el reader este abierto
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

                DataResult<Fmd> resultConversion = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // See the SDK documentation for an explanation on threshold scores.
                int thresholdScore = DPFJ_PROBABILITY_ONE * 1 / 100000;

                // Obtenemos los datos
                MySqlDataReader lReader = Form_Main.sqlExec("select huella, id, nombre, email, fechaNacimiento from asociado where huella is not null");
                DataTable dt = new DataTable();
                dt.Load(lReader);
                lReader.Close();

                Fmd[] allDBFmd1s = new Fmd[dt.Rows.Count];
                int[] allIdAsociados = new int[dt.Rows.Count];
                
                int i = 0;
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

                IdentifyResult identifyResult = Comparison.Identify(resultConversion.Data, 0, allDBFmd1s, thresholdScore, 1);

                if (identifyResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(identifyResult.ResultCode.ToString());
                }

                if (identifyResult.Indexes.Length > 0)
                {
                    SendMessage(Action.AddRow, dt.Rows[identifyResult.Indexes[0][0]]);
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
        private void BuscarAlumnos_Closed(object sender, System.EventArgs e)
        {
            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
  
        }

        #region SendMessage
        private enum Action
        {
            AddRow
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
                        case Action.AddRow:
                            listaAlumnos.Rows.Clear();

                            DataRow datos = (DataRow)payload;
                            DateTime nacimiento = Convert.ToDateTime(datos["fechaNacimiento"]);
                            int edad = fechaActual.Year - nacimiento.Year;

                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(listaAlumnos);
                            row.Cells[0].Value = datos["id"];
                            row.Cells[1].Value = datos["nombre"];
                            row.Cells[2].Value = edad;
                            row.Cells[3].Value = datos["email"];
                            listaAlumnos.Rows.Add(row);
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


        private void listaAlumnos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                listaAlumnos.Rows[e.RowIndex].Selected = true;
                Rectangle r = listaAlumnos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                contextMenu.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
            }
        }



        private void buscarAlumno_Click(object sender, EventArgs e)
        {
            int i = 0;
            listaAlumnos.Rows.Clear();
            string busquedaTxt = buscarBox.Text.ToLower();
            string busqueda = buscarBox.Text.ToLower();
            int busquedaNumero;
            int.TryParse(buscarBox.Text, out busquedaNumero);

            // Nos traemos los datos
            MySqlDataReader lReader = Form_Main.sqlExec("select id, nombre, email, fechaNacimiento from asociado where nombre LIKE '%" + busqueda + "%' or id = " + busquedaNumero + "");
            DataTable dt = new DataTable();
            dt.Load(lReader);

            foreach (System.Data.DataRow dr in dt.Rows)
            {
                DateTime nacimiento = (DateTime)dt.Rows[i]["fechaNacimiento"];
                int edad = fechaActual.Year - nacimiento.Year;

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(listaAlumnos);
                row.Cells[0].Value = dt.Rows[i]["id"];
                row.Cells[1].Value = dt.Rows[i]["nombre"];
                row.Cells[2].Value = edad;
                row.Cells[3].Value = dt.Rows[i]["email"];
                listaAlumnos.Rows.Add(row);
                i++;
            }
        }

        private void buscarBox_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = buscarAlumno;
        }

        private void realizarPago_Click(object sender, EventArgs e)
        {
            Pagos realizarPagos = new Pagos();
            // Id =  sub indice cero
            realizarPagos.idAlumno = Convert.ToInt32(listaAlumnos.SelectedRows[0].Cells[0].Value);        
            // nombre = sub indice 1 
            realizarPagos.nombreAlumnoString = listaAlumnos.SelectedRows[0].Cells[1].Value.ToString();
            realizarPagos.ShowDialog();
        }

        private void editar_Click(object sender, EventArgs e)
        {
            EditarAlumno editar = new EditarAlumno();

            editar.idAlumno = Convert.ToInt32(listaAlumnos.SelectedRows[0].Cells[0].Value); 

            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
            editar._sender = _sender;
            editar.Show(this);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        }

        public void setupForCapture()
        {
            if (!_sender.OpenReader())
            {
                this.Close();
            }

            if (!_sender.StartCaptureAsync(this.OnCaptured))
            {
                this.Close();
            }
        }

        private void verVisitas_Click(object sender, EventArgs e)
        {
            Visitas visitas = new Visitas();

            visitas.idAlumno = Convert.ToInt32(listaAlumnos.SelectedRows[0].Cells[0].Value);
            visitas.nombreAlumno = Convert.ToString(listaAlumnos.SelectedRows[0].Cells[1].Value);

            _sender.CancelCaptureAndCloseReader(this.OnCaptured);
            visitas._sender = _sender;
            visitas.ShowDialog(this); 
        }

        private void detalleDeAsociadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idAsociado = listaAlumnos.SelectedRows[0].Cells[0].Value.ToString();
            DetalleAlumno detalleAlumno = new DetalleAlumno(idAsociado);
            detalleAlumno.ShowDialog();
        }
    }
}