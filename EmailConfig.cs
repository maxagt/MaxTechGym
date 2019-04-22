using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace MaxTechGym
{
    static class EmailConfig
    {
        //EMAIL CONFIGURATION
        public static String POP3 { get; }
        public static String IMAP { get; }
        public static String SMTP { get; }
        public static String EMAIL_SERVER { get; }
        public static String EMAIL_USERNAME { get; }
        public static String EMAIL_PASSWORD { get; }
        public static String SUBJECT { get; }
        public static String FROM { get; }
        public static String TO { get; }
        public static String SALE_MESSAGE { get; }
        public static String CLIENT_MESSAGE { get; }

        //Static constructor for the email configuration
        //It takes the client username as only parameter to pull the email config.
        static EmailConfig()
        {

            MySqlDataReader sqlReader = Form_Main.sqlExec("select * from emailConfig where cliente = '" + Program.CLIENT + "'");
            DataTable dataTable = new DataTable();
            dataTable.Load(sqlReader);

            DataRow row = dataTable.Rows[0];

            POP3 = row["pop3"].ToString();
            IMAP = row["imap"].ToString();
            SMTP = row["smtp"].ToString();
            EMAIL_SERVER = row["servidor"].ToString();
            EMAIL_USERNAME = row["de"].ToString();
            EMAIL_PASSWORD = row["password"].ToString();
            SUBJECT = row["asunto"].ToString();
            FROM = row["de"].ToString();
            TO = row["para"].ToString();
            SALE_MESSAGE = row["mensajeVenta"].ToString();
            CLIENT_MESSAGE = row["mensajeCliente"].ToString();

        } 


    }
}
