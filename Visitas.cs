using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MaxTechGym
{
    public partial class Visitas : Form
    {
        public Form_Main _sender;
        public int idAlumno;
        public string nombreAlumno;

        public Visitas()
        {
            InitializeComponent();
        }

        private void Visitas_Load(object sender, EventArgs e)
        {
            //Borramos los datos al abrir
            listaVisitasBox.Items.Clear();

            //Cargamos el nombre del asociado
            nombreAsociado.Text = nombreAlumno;

            // Nos traemos los datos
            MySqlDataReader lReader = Form_Main.sqlExec("select * from visitas where idAsociado = " + idAlumno );
            DataTable dt = new DataTable();
            dt.Load(lReader);


            // LLenamos el listbox con las visitas
            for (int i = dt.Rows.Count-1; i >= 0; i--)
            {
                listaVisitasBox.Items.Add(dt.Rows[i]["fecha"]);
            }

        }

    }
}
