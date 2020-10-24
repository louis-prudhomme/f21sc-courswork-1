using f21sc_courswork_1.Controller.HistoryPanel;
using f21sc_courswork_1.Controller.InputHomeUrl;
using f21sc_courswork_1.Controller.Main;
using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using f21sc_courswork_1.Model.History;
using f21sc_courswork_1.View;
using f21sc_courswork_1.View.HistoryPanel;
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
        private readonly IMainController mainController;
        /// <summary>
        /// Controller for the home url input 
        /// </summary>
        private IInputHomeUrlController urlController;
        /// <summary>
        /// Controller for the history panel 
        /// </summary>
        private IHistoryPanelController historyController;

        /// <summary>
        /// History of the user 
        /// </summary>
        private readonly GlobalHistory globalHistory;
        private Uri userHomePageUri;

        /// <summary>
        /// Main constructor and real starting point of the application
        /// </summary>
        public BrowserApplicationContext()
        {
            this.userHomePageUri = new Uri("http://www.lingscars.com");
            this.globalHistory = new GlobalHistory();

            this.mainController = new MainController(new FormMain(), this.globalHistory, this.userHomePageUri);

            this.mainController.MainFormClosedEvent += this.MainFormClosedEventHandler;
            this.mainController.HomeUrlInputAskedEvent += this.HomeUrlInputAskedEventHandler;
            this.mainController.HistoryPanelAskedEvent += this.HistoryPanelAskedEventHandler;
            this.mainController.GlobalHistoryUpdatedEvent += this.HistoryUpdatedEventHandler;

            this.mainController.Show();
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

        private void HistoryPanelAskedEventHandler(object sender, EventArgs e)
        {
            this.mainController.ShouldBeEnabled(false);

            this.historyController = new HistoryPanelController(new FormHistoryPanel(), this.globalHistory);
            this.historyController.FormHistoryPanelClosedEvent += this.HistoryPanelClosedEventHandler;
            this.historyController.HistoryUpdatedEvent += this.HistoryUpdatedEventHandler;

            this.historyController.Show();
        }

        private void HistoryPanelClosedEventHandler(object sender, EventArgs e)
        {
            this.historyController = null;
            this.mainController.ShouldBeEnabled(true);
            this.mainController.UpdateHistory();
        }

        private void HomeUrlCancelledEventHandler(object sender, EventArgs e)
        {
            this.urlController = null;
            this.mainController.ShouldBeEnabled(true);
        }

        private void HomeUrlSubmittedEventHandler(object sender, UrlInputFormSubmittedEventArgs e)
        {
            this.userHomePageUri = e.Uri;
            this.mainController.UpdateHomeUri(this.userHomePageUri);
            this.mainController.ShouldBeEnabled(true);
        }

        private void HistoryUpdatedEventHandler(object sender, EventArgs e)
        {
            // todo
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
