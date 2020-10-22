using f21sc_courswork_1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f21sc_courswork_1.Controller
{
    class BrowserApplicationContext : ApplicationContext
    {
        /// <summary>
        /// Main form
        /// </summary>
        private FormMain formMain;

        /// <summary>
        /// Main constructor and real starting point of the application
        /// </summary>
        public BrowserApplicationContext()
        {
            formMain = new FormMain();
            formMain.FormClosed += new FormClosedEventHandler(OnFormClosed);
            formMain.Show();
        }

        /// <summary>
        /// Exit the whole application if the <see cref="formMain"/> is closed
        /// </summary>
        /// <param name="sender">Should be <see cref="formMain"/></param>
        /// <param name="e">Event arguments</param>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            ExitThread();
        }

        /// <summary>
        /// Get user data smh
        /// </summary>
        private void OnApplicationStartup()
        {

        }

        /// <summary>
        /// Save user data smh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplicationExit(object sender, EventArgs e)
        {

        }
    }
}
