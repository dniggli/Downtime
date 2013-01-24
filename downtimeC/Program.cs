using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using downtime;

namespace downtimeC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartupLoginForm Login = new StartupLoginForm();
            Application.Run(Login);

            if (Login.valid)
            {
                GlobalMutableState.userName = Login.userName;
                Application.Run(new MainMenu(System.DateTime.Now));
            }           
        }
    }
}
