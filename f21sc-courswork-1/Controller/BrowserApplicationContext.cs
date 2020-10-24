using f21sc_courswork_1.Controller.InputHomeUrl;
using f21sc_courswork_1.Controller.Main;
using f21sc_courswork_1.Event;
using f21sc_courswork_1.View;
using f21sc_courswork_1.View.InputHomeUrl;
using System;
using System.Windows.Forms;

namespace f21sc_courswork_1.Controller
{
    class BrowserApplicationContext : ApplicationContext
    {
        /// <summary>
        /// Main form controller
        /// </summary>
        private MainController mainController;
        /// <summary>
        /// Controller for the home url input 
        /// </summary>
        private InputHomeUrlController urlController;

        //todo move history here

        /// <summary>
        /// Main constructor and real starting point of the application
        /// </summary>
        public BrowserApplicationContext()
        {
            mainController = new MainController(new FormMain());

            mainController.MainFormClosedEvent += this.MainFormClosedEventHandler;
            mainController.HomeUrlInputAskedEvent += this.HomeUrlInputAskedEventHandler;
         
            mainController.Show();
        }

        /// <summary>
        /// Exit the whole application if the <see cref="formMain"/> is closed
        /// </summary>
        /// <param name="sender">Should be <see cref="formMain"/></param>
        /// <param name="e">Event arguments</param>
        private void MainFormClosedEventHandler(object sender, EventArgs e)
        {
            ExitThread();
        }

        private void HomeUrlInputAskedEventHandler(object sender, EventArgs e)
        {
            this.mainController.ShouldBeEnabled(false);

            this.urlController = new InputHomeUrlController(new FormInputHomeUrl());
            this.urlController.UrlInputFormCanceledEvent += this.HomeUrlCancelledEventHandler;
            this.urlController.UrlInputFormSubmittedEvent += this.HomeUrlSubmittedEventHandler;
            
            this.urlController.Show();
        }

        private void HomeUrlCancelledEventHandler(object sender, EventArgs e)
        {
            this.mainController.ShouldBeEnabled(true);
        }

        private void HomeUrlSubmittedEventHandler(object sender, UrlSentEventArgs e)
        {
            this.mainController.ShouldBeEnabled(true);
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
