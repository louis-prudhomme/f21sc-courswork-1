using f21sc_courswork_1.Model;
using f21sc_courswork_1.Utils;
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
        /// Main controller
        /// </summary>
        private MainController mainController;

        /// <summary>
        /// Main constructor and real starting point of the application
        /// </summary>
        public BrowserApplicationContext()
        {
            mainController = new MainController(new FormMain());
            mainController.Show();
            mainController.MainFormClosedEvent += new EventHandler(OnFormClosed);
        }

        /// <summary>
        /// Exit the whole application if the <see cref="formMain"/> is closed
        /// </summary>
        /// <param name="sender">Should be <see cref="formMain"/></param>
        /// <param name="e">Event arguments</param>
        private void OnFormClosed(object sender, EventArgs e)
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
