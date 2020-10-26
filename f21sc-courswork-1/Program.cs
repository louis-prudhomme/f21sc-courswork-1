using f21sc_coursework_1.Presenter;
using System;
using System.Windows.Forms;

namespace f21sc_coursework_1
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
            Application.Run(new BrowserApplicationContext());
        }
    }
}
