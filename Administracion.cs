using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MaxTechGym
{
    public partial class Administracion : Form
    {
        //Global data adapter
        MySqlDataAdapter DataAdapter = null;
        private DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        //Flag to know if the mouse is pointing a row
        bool rightClickOnRow = false;

        public Administracion()
        {
            InitializeComponent();     
        }


        private void Administracion_Load(object sender, EventArgs e)
        {
            // Populate the datagrid
            listaPrecios.DataSource = BindSource();

            //Hide the key and the client
            listaPrecios.Columns[0].Visible = false;
            listaPrecios.Columns[6].Visible = false;


            offsetPicker.Value = Convert.ToDecimal(Properties.Settings.Default["HourOffset"]); 



        }

        public DataTable BindSource()
        {
            DataAdapter = Form_Main.ConnectDBAdapter("select * from precios where cliente = '" + Program.CLIENT + "' ORDER BY Orden");
            ds.Clear();
            DataAdapter.Fill(ds);

            return ds.Tables[0];  
        }

        private void listaPrecios_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(NumericColumns_KeyPress);
            if (listaPrecios.CurrentCell.ColumnIndex == 2 ||
                listaPrecios.CurrentCell.ColumnIndex == 3 ||
                listaPrecios.CurrentCell.ColumnIndex == 4)    //Desired Columns
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(NumericColumns_KeyPress);
                }
            } else if (listaPrecios.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(AlphabetColumn_KeyPress);
                }
            }
        }

        private void NumericColumns_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AlphabetColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) 
                && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Whatever changes on the client, update the backend Database
        private void commitChanges()
        {
            DataTable changes = ((DataTable)listaPrecios.DataSource).GetChanges();

            if (changes != null)
            {
                MySqlCommandBuilder mcb = new MySqlCommandBuilder(DataAdapter);
                DataAdapter.UpdateCommand = mcb.GetUpdateCommand();
                DataAdapter.Update(changes);
                ((DataTable)listaPrecios.DataSource).AcceptChanges();
            }
        }

        //Insert a new row and update the client with the backend data
        private void agregarElementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "insert into precios(cliente) values ('" + Program.CLIENT + "')";
            MySqlDataReader reader = Form_Main.sqlExec(sql);

            listaPrecios.DataSource = BindSource();    
        }

        private void borrarElementoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listaPrecios.SelectedRows[0].Index;
            listaPrecios.Rows.RemoveAt(index);
        }

        private void listaPrecios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                rightClickOnRow = true;
                listaPrecios.Rows[e.RowIndex].Selected = true;
            }
        }


        private void listaPrecios_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            commitChanges();
        }

        private void listaPrecios_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            commitChanges();
        }

        //If the user right clicks on anything not being a row, hide the element "Delete element"
        private void contextMenuPrecios_Opening(object sender, CancelEventArgs e)
        {
            contextMenuPrecios.Items["deleteElement"].Visible = rightClickOnRow;
            rightClickOnRow = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            color = new ColorDialog();
            color.ShowDialog();
            Properties.Settings.Default["BackgroundColor"] = (Color)color.Color;
            Properties.Settings.Default.Save();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                //pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                richTextBox2.Text = open.FileName;
            }
        }

        private void hourOffset_Click(object sender, EventArgs e)
        {           
            Properties.Settings.Default["HourOffset"] = offsetPicker.Value.ToString();
            Properties.Settings.Default.Save();
        }

        private void Envioemail_Click(object sender, EventArgs e)
        {

        }
    }
}
