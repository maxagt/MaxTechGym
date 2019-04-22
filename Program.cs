using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

//! @cond
namespace MaxTechGym
{
    static class Program
    {
        //GLOBAL VARIABLES
        public static String READER_SERIAL_NUMBER = "";
        public static String CLIENT = "testclient";
        public static bool DEBUG_MODE = true;
        public static bool USING_READER = true;
        public static String TEST_CLIENT = "testclient";
        public static String USERNAME = "";
        public static String PASSWORD = "";
        public static DataTable fingerprints;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[MTAThread]
        [STAThread]
        static void Main()
        {
            #if (!WindowsCE)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            #endif
            Application.Run(new Form_Main());
        }
    }
}
//! @endcond