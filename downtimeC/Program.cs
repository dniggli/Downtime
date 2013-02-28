using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CodeBase2.AutoItX;

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
                GlobalMutableState.StartupDate = System.DateTime.Now;
                Application.Run(new MainMenu(Login.hospital));
            }    
            
        }
    }
}
