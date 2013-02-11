using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Automator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch (Exception exceptionGeneral)
            {
                //----------------------------------------------------------------------
                // Catch and display any errors
                //----------------------------------------------------------------------
                MessageBox.Show(exceptionGeneral.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}