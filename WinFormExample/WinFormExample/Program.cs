using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormExample
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
            WelcomeForm fm = new WelcomeForm();
            fm.ShowDialog();
            Application.Run(new MainForm());
        }
    }
}
