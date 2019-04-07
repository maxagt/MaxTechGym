using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;



namespace MaxTechGym
{
    public partial class DetalleAlumno : Form
    {
        private string idAsociado;

        /// <summary>
        /// Holds the main form with many functions common to all of SDK actions.
        /// </summary>

        public DetalleAlumno(string _idAsociado)
        {
            InitializeComponent();
            idAsociado = _idAsociado;
        }

        /// <summary>
        /// Initialize the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditarAlumno_Load(object sender, System.EventArgs e)
        {

            MySqlDataReader reader = Form_Main.sqlExec("select * from asociado where id = '"+ idAsociado + "'");
            DataTable datosAlumno = new DataTable();
            datosAlumno.Load(reader);

            name.Text = Convert.ToString(datosAlumno.Rows[0]["nombre"]);
            dateBirth.Text = Convert.ToString(datosAlumno.Rows[0]["fechaNacimiento"]);
            email.Text = Convert.ToString(datosAlumno.Rows[0]["email"]);
            address.Text = Convert.ToString(datosAlumno.Rows[0]["direccion"]);
            city.Text = Convert.ToString(datosAlumno.Rows[0]["municipio"]);
            phone.Text = Convert.ToString(datosAlumno.Rows[0]["telefono"]);
            gender.Text = Convert.ToString(datosAlumno.Rows[0]["genero"]);
            howFound.Text = Convert.ToString(datosAlumno.Rows[0]["comoSeEntero"]);
            deadline.Text = Convert.ToString(datosAlumno.Rows[0]["fechaVencimiento"]);
            debt.Text = Convert.ToString(datosAlumno.Rows[0]["adeudo"]);

            //Get the total amount of visits
            reader = Form_Main.sqlExec("select count(*) from visitas where idAsociado = '" + idAsociado + "'");
            DataTable data = new DataTable();
            data.Load(reader);
            totalVisits.Text = data.Rows[0][0].ToString();

            //Get last visit
            reader = Form_Main.sqlExec("SELECT MAX(fecha) FROM visitas where idAsociado = '" + idAsociado + "'");
            data = new DataTable();
            data.Load(reader);
            lastVisit.Text = data.Rows[0][0].ToString();


        }

        private void listaVisitas_Click(object sender, EventArgs e)
        {
            Visitas visitas = new Visitas();
            visitas.idAlumno = Convert.ToInt32(idAsociado);
            visitas.nombreAlumno = name.Text;
            visitas.ShowDialog();
        }

        private void historialPagos_Click(object sender, EventArgs e)
        {
            HistorialPagos historial = new HistorialPagos();
            historial.idAlumno = Convert.ToInt32(idAsociado);
            historial.nombreAlumno = name.Text;
            historial.ShowDialog();
        }
    }
}
