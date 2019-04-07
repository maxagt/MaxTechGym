using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MaxTechGym
{
    public partial class Reportes : Form
    {
        DateTime fechaActual;

        public Reportes()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Reportes_Load(object sender, EventArgs e)
        {

            // Ponemos valores default en el combo.
            sexo.SelectedIndex = 0;
            estatus.SelectedIndex = 0;
            edad_de.SelectedIndex = 0;
            edad_hasta.SelectedIndex = 89;
            tipoPago.SelectedIndex = 0;
            

            // Borramos los elementos del grid
            listaAlumnos.Rows.Clear();

            // Centramos las celdas y encabezados
            listaAlumnos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment

            listaAlumnos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment

            listaAlumnos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaAlumnos.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment  

            listaPagos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaPagos.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment

            listaPagos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaPagos.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment

            listaPagos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaPagos.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment 

            listaPagos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //cells alignment
            listaPagos.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; //header alignment 

            //Invocamos el cambio de valor del calendario para que se ejecute al cargar
            visitaspicker_ValueChanged(null, null);

            //Inicializamos el primer date picker al primero del mes
            DateTime dFirstDayOfThisMonth = DateTime.Today.AddDays( - ( DateTime.Today.Day - 1 ) );
            dateInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, dFirstDayOfThisMonth.Day);


        }

        private void buscar_Click(object sender, EventArgs e)
        {

            // Borramos los elementos del grid
            listaAlumnos.Rows.Clear();


            string genero = "";
            string estado = "";
            int de = 1;
            int hasta = 80;

            // Obtenemos datos de filtrado
             genero = sexo.SelectedItem.ToString();
             estado = estatus.SelectedItem.ToString();
             de = Convert.ToInt32(edad_de.SelectedItem);
             hasta = Convert.ToInt32(edad_hasta.SelectedItem);

             // Obtenemos fecha del server
             MySqlDataReader reader = Form_Main.sqlExec("select NOW()");
             if (reader.Read())
             {
                 fechaActual = reader.GetDateTime(0);
             }


            // Nos traemos los datos
            MySqlDataReader lReader = Form_Main.sqlExec("select nombre, fechaVencimiento, genero, adeudo from asociado");
            DataTable dt = new DataTable();
            dt.Load(lReader);


            // LLenamos el datagrid
            Double offset = Convert.ToDouble(Properties.Settings.Default["HourOffset"]);
            int count = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // If gender does not match the search, we skip adding the element
                if (genero != "Todos" && dt.Rows[i]["genero"].ToString() != genero) continue;

                // Now that it matches the gender, if the state is not specific, we add the elemnt
                if (estado != "Todos")
                {
                    // However, if the state is specific, we skip depending on the paramenter
                    if (estado == "Vigente")
                        if (Convert.ToDateTime(dt.Rows[i]["fechaVencimiento"].ToString()) < fechaActual) continue;
                    if (estado == "Vencido")
                        if (Convert.ToDateTime(dt.Rows[i]["fechaVencimiento"].ToString()) >= fechaActual) continue;
                    if (estado == "Adeudo")
                        if ((int)dt.Rows[i]["adeudo"] == 0) continue;
                }


                
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(listaAlumnos);
                row.Cells[0].Value = count;
                row.Cells[1].Value = dt.Rows[i]["nombre"];
                row.Cells[2].Value = Convert.ToDateTime(dt.Rows[i]["fechaVencimiento"]).AddHours(offset).ToString();
                row.Cells[3].Value = dt.Rows[i]["adeudo"];
                listaAlumnos.Rows.Add(row);
                count++;
            }

            listaAlumnos.Sort(listaAlumnos.Columns[2], ListSortDirection.Descending);
        }

        private void buscaPagos_Click(object sender, EventArgs e)
        {

            // Borramos los elementos del grid
            listaPagos.Rows.Clear();
            int total = 0;
            int totalAPagar = 0;
            int adeudosNuevos = 0;
            int adeudosPagados = 0;

            string _tipoPago = "";
            DateTime inicio = dateInicio.Value;
            DateTime fin = dateFin.Value.AddDays(1);

            // Obtenemos datos de filtrado
            if(tipoPago.SelectedIndex != 0) _tipoPago = tipoPago.SelectedItem.ToString();


            // Nos traemos los datos
            MySqlDataReader lReader = Form_Main.sqlExec("select nombre, concepto, pagado, totalAPagar from pagos where fecha >= '" + inicio.ToString("yyyy-MM-dd") + "' and fecha <= '" + fin.ToString("yyyy-MM-dd") + "' and formaPago LIKE '%" + _tipoPago + "%'");
            DataTable dt = new DataTable();
            dt.Load(lReader);


            // LLenamos el datagrid
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(listaPagos);
                row.Cells[0].Value = dt.Rows[i]["nombre"];
                row.Cells[1].Value = dt.Rows[i]["totalAPagar"];
                row.Cells[2].Value = dt.Rows[i]["pagado"];
                row.Cells[3].Value = dt.Rows[i]["concepto"];
                listaPagos.Rows.Add(row);
                total += Convert.ToInt32(dt.Rows[i]["pagado"]);
                totalAPagar += Convert.ToInt32(dt.Rows[i]["totalAPagar"]);

                if (!row.Cells[3].Value.ToString().Equals("Liquidar adeudo"))
                {
                    adeudosNuevos += (int)row.Cells[1].Value - (int)row.Cells[2].Value;
                }
                else
                {
                    adeudosPagados += (int)row.Cells[2].Value;
                }
            }

            totalLabel.Text = "Total pagado: $" + total;
            adeudosPagadosLabel.Text = "Adeudos pagados: $" + adeudosPagados;
            totalAPagarLabel.Text = "Nuevos pagos: $" + totalAPagar;

        }






        private static int CalculaFechaVencimiento (int idAlumno, DataTable tabla)
        {

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if ((int)tabla.Rows[i]["id"] == idAlumno)
                {
                    return i;
                }
            }
            return 0;
        }

        private void visitaspicker_ValueChanged(object sender, EventArgs e)
        {

            DateTime fecha = visitaspicker.Value.Date;
            DateTime fecha2 = fecha.AddDays(1).Date;

            // Borramos los elementos del grid
            listaDeVisitas.Rows.Clear();

            // Nos traemos las visitas
            MySqlDataReader lReader = Form_Main.sqlExec("select * from visitas where fecha > '" + fecha.ToString("yyyy-MM-dd") + "' AND fecha < '" + fecha2.ToString("yyyy-MM-dd") + "'");
            DataTable dt = new DataTable();
            dt.Load(lReader);

            // Nos traemos los datos de los asociados
            MySqlDataReader lReader2 = Form_Main.sqlExec("select id, nombre, fechaVencimiento, adeudo from asociado");
            DataTable dt2 = new DataTable();
            dt2.Load(lReader2);

            Double offset = Convert.ToDouble(Properties.Settings.Default["HourOffset"]);
            // LLenamos el datagrid
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int renglon = CalculaFechaVencimiento((int)dt.Rows[i]["idAsociado"], dt2);

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(listaDeVisitas);
                row.Cells[0].Value = Convert.ToDateTime(dt.Rows[i]["fecha"]).AddHours(offset);
                row.Cells[1].Value = dt2.Rows[renglon]["fechaVencimiento"];
                row.Cells[2].Value = dt2.Rows[renglon]["nombre"];
                row.Cells[3].Value = dt2.Rows[renglon]["adeudo"];
                listaDeVisitas.Rows.Add(row);



                // If it's due to payment and it owes money
                if ((DateTime)row.Cells[0].Value > (DateTime)row.Cells[1].Value && (int)row.Cells[3].Value > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else  // If only is due to payment
                    if ((DateTime)row.Cells[0].Value > (DateTime)row.Cells[1].Value)
                {
                    row.DefaultCellStyle.BackColor = Color.Silver;
                }
                    else  // If Owes money to the gym
                        if ((int)row.Cells[3].Value > 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
            }

        }


        private void calculoUtilidades_Click(object sender, EventArgs e)
        {

            int total = Convert.ToInt32(RentaTextBox.Text == "" ? (RentaTextBox.Text = "0") : RentaTextBox.Text) +
                        Convert.ToInt32(SueldoCochTextBox.Text == "" ? (SueldoCochTextBox.Text = "0") : SueldoCochTextBox.Text) +
                        Convert.ToInt32(AguaTextBox.Text == "" ? (AguaTextBox.Text = "0") : AguaTextBox.Text) +
                        Convert.ToInt32(OtrosTextBox.Text == "" ? (OtrosTextBox.Text = "0") : OtrosTextBox.Text) +
                        Convert.ToInt32(AuxiliarCoachTextBox.Text == "" ? (AuxiliarCoachTextBox.Text = "0") : AuxiliarCoachTextBox.Text) +
                        Convert.ToInt32(LimpiezaTextBox.Text == "" ? (LimpiezaTextBox.Text = "0") : LimpiezaTextBox.Text) +
                        Convert.ToInt32(InterenetTextBox.Text == "" ? (InterenetTextBox.Text = "0") : InterenetTextBox.Text) +
                        Convert.ToInt32(RecepcionTextBox.Text == "" ? (RecepcionTextBox.Text = "0") : RecepcionTextBox.Text) +
                        Convert.ToInt32(LuzTextBox.Text == "" ? (LuzTextBox.Text = "0") : LuzTextBox.Text) +
                        Convert.ToInt32(PublicidadTextBox.Text == "" ? (PublicidadTextBox.Text = "0") : PublicidadTextBox.Text) +
                        Convert.ToInt32(NutriologaTextBox.Text == "" ? (NutriologaTextBox.Text = "0") : NutriologaTextBox.Text);

            totalDeGastos.Text = "Total de gastos: $" + total;
            utilidadesNetas.Text = "Utilidades netas: $" + 
                                        (Convert.ToInt32(totalLabel.Text.Replace("Total pagado: $", "")) - total);

        }

        private void RentaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void SueldoCochTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void AuxiliarCoachTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void RecepcionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void LuzTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void InterenetTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void LimpiezaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void PublicidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void NutriologaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void AguaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void OtrosTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void internet_Click(object sender, EventArgs e)
        {

        }
    }
}
