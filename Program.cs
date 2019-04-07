using System;
using System.Windows.Forms;
using System.Drawing;

//! @cond
namespace MaxTechGym
{
    static class Program
    {
        //GLOBAL VARIABLES
        public static String READER_SERIAL_NUMBER = "";
        public static String CLIENTE = "testclient";
        public static bool DEBUG_MODE = false;
        public static bool USING_READER = true;
        public static String TEST_CLIENT = "testclient";

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