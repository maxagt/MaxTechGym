using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DPUruNet;

namespace MaxTechGym
{
    public partial class Acceso : Form
    {
        public object SecureIt { get; private set; }

        public Acceso()
        {
            InitializeComponent();
        }


        private void Acceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            String test = EmailConfig.POP3;

            if(Program.READER_SERIAL_NUMBER.Length == 0)
            {
                Application.Exit();
            }
        }


        private static string EncryptDecrypt(string szPlainText, int szEncryptionKey)
        {
            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ szEncryptionKey);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }


        private void Acceder_Click(object sender, EventArgs e)
        {
            //Try to match user and password
            MySqlDataReader lReader = Form_Main.sqlExec("select * from clientes where cliente = '" + usuario.Text + "' and password = '" + contrasena.Text + "'");
            DataTable dt = new  DataTable();
            dt.Load(lReader);

            //If they dont match (no rows returned) we close the app.
            if (dt.Rows.Count == 0)
             {
                 MessageBox.Show("Usuario y/o contraseña incorrectos.");
             }
             else
             {
                //Get the serial number
                Program.CLIENT = dt.Rows[0]["cliente"].ToString();
                DateTime deadLineDate = Convert.ToDateTime(dt.Rows[0]["fechaVencimiento"]);
                lReader = Form_Main.sqlExec("select serialnumber from lectores where cliente = '" + Program.CLIENT + "'");
                dt = new DataTable();
                dt.Load(lReader);
                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro un lector para el usuario, la aplicacion se cerrara.");
                    Application.Exit();
                    return;
                }
                else
                {
                    //We have the serial number and we assign this to a global variable.
                    Program.READER_SERIAL_NUMBER = dt.Rows[0]["serialNumber"].ToString();
                    ReaderCollection readers = ReaderCollection.GetReaders();
                    Reader currentReader = readers[0];

                    if (currentReader.Description.SerialNumber != Program.READER_SERIAL_NUMBER)
                    {
                        MessageBox.Show("El numero de serie del lector no coincide, la aplicacion se cerrara.");
                        Application.Exit();
                        return;
                    }
                }



                //Finally we check if the user is up to date with the payments.
                DateTime today = new DateTime();

                // Get server date
                MySqlDataReader dataReader = Form_Main.sqlExec("SELECT NOW()");
                if (dataReader.Read())
                {
                    today = dataReader.GetDateTime(0);
                }

                if(today > deadLineDate)
                {
                    MessageBox.Show("La cuenta no esta al corriente con los pagos.\nFecha de vencimiento" + deadLineDate.ToString());
                    Application.Exit();
                    return;
                }

                Close();
             }
            
        }



        private void Acceso_Load(object sender, EventArgs e)
        {
            contrasena.Text = EncryptDecrypt(Properties.Settings.Default["Password"].ToString(), 3578);
            usuario.Text = Properties.Settings.Default["Username"].ToString();

            userCheckBox.Checked = usuario.Text != "" ? true : false;
            passCheckBox.Checked = contrasena.Text != "" ? true : false;
        }

        private void Acceso_FormClosed(object sender, FormClosedEventArgs e)
        {
            string Encryptpass = contrasena.Text != "" ? EncryptDecrypt(contrasena.Text, 3578) : "";

            Properties.Settings.Default["Username"] = userCheckBox.Checked ? usuario.Text : "";
            Properties.Settings.Default["Password"] = passCheckBox.Checked ? Encryptpass : "";
            Properties.Settings.Default.Save();
        }
    }
}

