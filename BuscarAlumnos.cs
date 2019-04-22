using System;
using System.Windows.Forms;
using DPUruNet;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace MaxTechGym
{
    public partial class BuscarAlumnos : Form
    {
        /// <summary>
        /// Holds the main form
        /// </summary>
        public Form_Main _sender;

        private const int DPFJ_PROBABILITY_ONE = 0x7fffffff;
        private static DateTime currentDate;
        private Task<DateTime> getCurrentDate;
        private Task<DataTable> getMembers;

        public BuscarAlumnos()
        {
            getCurrentDate = GymAPI.GetDateTime();
            getMembers = GymAPI.getMembers(string.Empty);
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        private async void  BuscarAlumnos_Load(object sender, EventArgs e)
        {
            // Delete elements from grid
            listaAlumnos.Rows.Clear();

            // Center all columns
            listaAlumnos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment

            listaAlumnos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment

            listaAlumnos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment  
                                                                                                            
            listaAlumnos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment 


            // Get 50 members from API call
            DataTable dt = await getMembers;

            // Get DateTime from server API call
            currentDate = await getCurrentDate;
              


            // Fill the datagrid with first 50 members
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime nacimiento = (DateTime)dt.Rows[i]["birthDate"];
                int edad = currentDate.Year - nacimiento.Year;

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(listaAlumnos);
                row.Cells[0].Value = dt.Rows[i]["id"];
                row.Cells[1].Value = dt.Rows[i]["name"];
                row.Cells[2].Value = edad;
                row.Cells[3].Value = dt.Rows[i]["email"];
                listaAlumnos.Rows.Add(row);
            }

            // Validate that the reader is open
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
        private async void OnCaptured(CaptureResult captureResult)
        {
            try
            {
                // Check capture quality and throw an error if bad.
                if (!_sender.CheckCaptureResult(captureResult)) return;

                DataResult<Fmd> capturedFingerprint = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Constants.Formats.Fmd.ANSI);
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // See the SDK documentation for an explanation on threshold scores.
                int thresholdScore = DPFJ_PROBABILITY_ONE * 1 / 100000;

                //Create an array of fmds
                Fmd[] allFMDs = new Fmd[Program.fingerprints.Rows.Count];

                //Populate all Fmds using Fmd.DeserializeXml()
                for (int i=0; i<Program.fingerprints.Rows.Count; i++)
                {
                    if (Program.fingerprints.Rows[i]["fingerprint"].ToString().Length > 0)
                    {
                        allFMDs[i] = Fmd.DeserializeXml(Program.fingerprints.Rows[i]["fingerprint"].ToString());
                    }
                }

                // This function compares the captured fingerprint to see if it matches one inside the FMD list.
                IdentifyResult identifyResult = Comparison.Identify(capturedFingerprint.Data, 0, allFMDs, thresholdScore, 1);

                // If we cant find a match
                if (identifyResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    _sender.Reset = true;
                    throw new Exception(identifyResult.ResultCode.ToString());
                }

                // If we find a match
                if (identifyResult.Indexes.Length > 0)
                {
                    // Position returned inside de FMD list
                    int index = identifyResult.Indexes[0][0];

                    // Get the member Id identified from the fingerprint capture
                    string memberId = Program.fingerprints.Rows[index]["id"].ToString();

                    // Call the API
                    DataTable member = await GymAPI.getMemberById(memberId);

                    // Add row
                    SendMessage(Action.AddRow, member.Rows[0]);
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
        private void btnBack_Click(Object sender, EventArgs e)
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
                            DateTime nacimiento = Convert.ToDateTime(datos["birthDate"]);
                            int edad = currentDate.Year - nacimiento.Year;

                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(listaAlumnos);
                            row.Cells[0].Value = datos["id"];
                            row.Cells[1].Value = datos["name"];
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



        private async void buscarAlumno_Click(object sender, EventArgs e)
        {
            int i = 0;
            listaAlumnos.Rows.Clear();

            //  Build the parameter list
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            //  Pass the memberFullName attribute.
            queryString["memberFullName"] = buscarBox.Text.ToLower();            

            // Call the API to get the members filtered
            DataTable membersDataTable = await GymAPI.getMembers(queryString.ToString());

            // Populte the datagrid
            foreach (DataRow dr in membersDataTable.Rows)
            {
                DateTime nacimiento = (DateTime)membersDataTable.Rows[i]["birthdate"];
                int edad = currentDate.Year - nacimiento.Year;

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(listaAlumnos);
                row.Cells[0].Value = membersDataTable.Rows[i]["id"];
                row.Cells[1].Value = membersDataTable.Rows[i]["name"];
                row.Cells[2].Value = edad;
                row.Cells[3].Value = membersDataTable.Rows[i]["email"];
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