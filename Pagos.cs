using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;

namespace MaxTechGym
{
    public partial class Pagos : Form
    {
        private DataTable listaPrecios;
        public string nombreAlumnoString;
        public int idAlumno;
        private DateTime fechaCorte;

        public Pagos()
        {
            InitializeComponent();
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            nombreAlumno.Text = nombreAlumnoString;
            adeudo.Text = "0";
            cantidadAPagar.Text = "0";

            listaPrecios = new DataTable();
            MySqlDataReader reader = Form_Main.sqlExec("select * from precios order by orden asc");
            listaPrecios.Load(reader);

            foreach (DataRow row in listaPrecios.Rows)
            {
                concepto.Items.Add(row["concepto"]);
            }

            reader = Form_Main.sqlExec("select fechaVencimiento from asociado where id = '" + idAlumno + "'");
            if (reader.Read())
            {
                fechaCorte = fecha.Value = reader.GetDateTime(0);
            } 
            reader.Close(); 


        }


        private void cantidadAPagar_TextChanged(object sender, EventArgs e)
        {
            if (concepto.SelectedIndex == -1) return;
            int costo = Convert.ToInt32(listaPrecios.Rows[concepto.SelectedIndex]["total"]);
            int cantidadPagada = 0;

            if (cantidadAPagar.Text != "")
            {
                cantidadPagada = Convert.ToInt32(cantidadAPagar.Text);
            }
            
            adeudo.Text = (costo - cantidadPagada).ToString();
        }



        private void concepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int meses = Convert.ToInt32(listaPrecios.Rows[concepto.SelectedIndex]["Meses"]);
            int dias = Convert.ToInt32(listaPrecios.Rows[concepto.SelectedIndex]["Dias"]);
            cantidadAPagar.Text = listaPrecios.Rows[concepto.SelectedIndex]["Total"].ToString();

            fecha.Value = fechaCorte.AddMonths(meses).AddDays(dias);
            adeudo.Text = "0";
        }

        private void cantidadAPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void adeudo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void botonPago_Click(object sender, EventArgs e)
        {

            // Validar que datos esten completos
            if (concepto.SelectedIndex == -1)
            {
                MessageBox.Show("Debes de seleccionar un concepto!");
                return;
            }

            if (formaPagoCombo.SelectedIndex == -1)
            {
                MessageBox.Show("Debes de seleccionar una forma de pago!");
                return;
            }

            if (cantidadAPagar.Text == null || cantidadAPagar.Text.Trim() == "")
            {
                MessageBox.Show("La cantidad a pagar no puede estar en blanco!\nEscribir 0 (cero) si se debe el monto completo.");
                cantidadAPagar.Select();
                return;
            }

            if (adeudo.Text == null || adeudo.Text.Trim() == "" && adeudo.Enabled)
            {
                MessageBox.Show("El adeudo no puede estar en blanco!\nEscribir 0 (cero) si no se debe nada.");
                adeudo.Select();
                return;
            }

            // Obtener fecha de hoy
            DateTime fechaHoy = new DateTime();
            MySqlDataReader reader = Form_Main.sqlExec("select NOW()");
            if (reader.Read())
            {
               fechaHoy = reader.GetDateTime(0);
            } 

            // Obtener datos
            string id = idAlumno.ToString();
            string nombre = nombreAlumnoString;
            string concepto2 = Convert.ToString(listaPrecios.Rows[concepto.SelectedIndex]["concepto"]);
            int totalAPagar = Convert.ToInt32(listaPrecios.Rows[concepto.SelectedIndex]["total"]);
            string pagado = cantidadAPagar.Text;
            string comentarios2 = comentarios.Text;
            string formaPago = formaPagoCombo.Text;
            string firma = Guid.NewGuid().ToString("N");
            string values = "'" + id + "','" + nombre + "','" + concepto2 + "','" + totalAPagar + "','" + pagado + "','" + fechaHoy.ToString("yyyy-MM-dd") + "','" + comentarios2 + "','" + formaPago + "','" + Program.CLIENTE + "'";

            // Insertar datos
            string sqlCommand = "insert into pagos (idAlumno, nombre, concepto, totalAPagar, pagado, fecha, comentarios, formaPago, cliente) VALUES (" + values + ")";
            Form_Main.sqlExec(sqlCommand);

            // Actualizar adeudo, fecha de vencimiento y paquete contratado
            sqlCommand = "update asociado set adeudo = adeudo+" + adeudo.Text + " , fechaVencimiento = '" + fecha.Value.ToString("yyyy-MM-dd") + "' , paqueteContratado='" + concepto2 + "' where id = '" + id + "'";
            Form_Main.sqlExec(sqlCommand);






            // Enviar correo de pago realizado
            string emailBody = "Nombre: " + nombre + "\nTotal pagado: " + pagado + " por concepto de " + concepto2 + "\nAdeudo: " + adeudo.Text + "\nComentarios: " + comentarios.Text + "\nForma de pago: " + formaPago + "\nFecha de vencimiento: " + fecha.Value.ToShortDateString();
            MailMessage message = new MailMessage(EmailConfig.FROM, "max.agt@gmail.com", EmailConfig.SUBJECT, emailBody);

            SmtpClient client = new SmtpClient(EmailConfig.EMAIL_SERVER, Convert.ToInt32(EmailConfig.SMTP));   
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(EmailConfig.EMAIL_USERNAME, EmailConfig.EMAIL_PASSWORD);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Send(message);


            //// Enviamos recibo al asociado (usamos el mismo objeto mensaje)
            //message.To.Clear();
            //message.To.Add(email);
            //message.From = new System.Net.Mail.MailAddress("no-responder@boxacademylp.com");
            //message.Subject = "Recibo de pago";


            //message.IsBodyHtml = true;
            //message.Body = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd""><html xmlns=""http://www.w3.org/1999/xhtml""><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" /><style> .legend {font-size: 12px; font-weight:bold; text-align: right; font-family:Arial, Helvetica, sans-serif; }.description {font-size: 12px; text-align: left; font-family:Arial, Helvetica, sans-serif; padding-left: 20px;} </style><title>Untitled Document</title></head>";
            //message.Body += @"<table width=""450"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center""><tr><td colspan=""2""><a target=""_blank"" href=""http://www.boxacademylp.com/""><img border=""0"" src=""http://www.boxacademylp.com/images/logo.jpg"" width=""475"" height=""70"" alt=""logo"" /></a></td></tr><tr><td colspan=""2"">&nbsp;</td></tr><tr><td colspan=""2"" style=""text-align:center; font-family:Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold;"">Comprobante de pago</td></tr><tr><td colspan=""2"">&nbsp;</td></tr><tr><td width=""140"" class=""legend"">Nombre:</td><td width=""335"" class=""description"">" + nombre + @"</td></tr><tr><td class=""legend"">Total pagado:</td><td class=""description"">" + pagado + @"</td></tr>";
            //message.Body += @"<tr><td class=""legend"">Concepto:</td><td class=""description"">" + concepto2 + @"</td></tr><tr><td class=""legend"">Adeudo:</td><td class=""description"">" + adeudo.Text + @"</td></tr><tr><td class=""legend"">Comentarios:</td><td class=""description"">" + comentarios.Text + @"</td></tr><tr><td class=""legend"">Forma pago:</td><td class=""description"">" + formaPago + @"</td></tr><tr><td class=""legend"">Vencimiento:</td><td class=""description"">" + fecha.Value.ToShortDateString() + @"</td></tr><tr><td class=""legend"">Id electronico:</td><td class=""description"">" + firma.ToString() + @"</td></tr><tr><td colspan=""2"">&nbsp;";
            //message.Body += @"</td></tr><tr><td colspan=""2"" style=""text-align:center; font-family:Arial, Helvetica, sans-serif; font-size:10px;""><br /><hr>Box Academy la pastora, Av. Eloy Cavazos 2003, Col. Bosques del contry.<br />Tel. 1929 -1864<br />email: <a href=""mailto:boxacademylapastora@gmail.com"">boxacademylapastora@gmail.com</a><br />Pagina web: <a href=""http://www.boxacademylp.com"">http://www.boxacademylp.com</a><br />FaceBook: <a href=""http://www.facebook.com/boxacademylapastora"">BoxAcademyLaPastora</a></td></tr></table></body></html>";


            //client.Send(message);
            this.Close();
        }

    }
}
