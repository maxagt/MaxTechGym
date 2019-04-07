using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MaxTechGym
{
    public partial class HistorialPagos : Form
    {
        public Form_Main _sender;
        public int idAlumno;
        public string nombreAlumno;

        public HistorialPagos()
        {
            InitializeComponent();
        }

        private void HistorialPagos_Load(object sender, EventArgs e)
        {
            //Borramos los datos al abrir
            listaVisitasBox.Items.Clear();

            //Cargamos el nombre del asociado
            nombreAsociado.Text = nombreAlumno;

            // Nos traemos los datos
            MySqlDataReader lReader = Form_Main.sqlExec("select * from pagos where idAlumno = " + idAlumno);
            DataTable dt = new DataTable();
            dt.Load(lReader);


            // LLenamos el listbox con las visitas
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                string pago = dt.Rows[i]["concepto"] + ", " + dt.Rows[i]["pagado"] + ", " +
                              dt.Rows[i]["formaPago"] + ", " + Convert.ToDateTime(dt.Rows[i]["fecha"]).ToString("dd-MM-yyyy")
                              + ", " + dt.Rows[i]["comentarios"];

                listaVisitasBox.Items.Add(pago);
            }
        }
    }
}
