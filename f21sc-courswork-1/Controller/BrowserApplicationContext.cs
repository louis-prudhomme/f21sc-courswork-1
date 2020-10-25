using f21sc_coursework_1.Controller.FavoritesPanel;
using f21sc_coursework_1.Controller.HistoryPanel;
using f21sc_coursework_1.Controller.InputHomeUrl;
using f21sc_coursework_1.Controller.Main;
using f21sc_coursework_1.Event;
using f21sc_coursework_1.Model;
using f21sc_coursework_1.Model.Favorites;
using f21sc_coursework_1.Model.History;
using f21sc_coursework_1.View;
using f21sc_coursework_1.View.FavoritesPanel;
using f21sc_coursework_1.View.HistoryPanel;
using f21sc_coursework_1.View.InputHomeUrl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace f21sc_coursework_1.Controller
{
    class BrowserApplicationContext : ApplicationContext
    {
        /// <summary>
        /// Main form controller
        /// Is readonly because it is always present
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
        /// Controller for the favorites panel 
        /// </summary>
        private IFavoritesPanelController favoritesController;

        /// <summary>
        /// Represents the user data
        /// </summary>
        private readonly UserProfile user;

        /// <summary>
        /// Main constructor and real starting point of the application
        /// </summary>
        public BrowserApplicationContext()
        {
            this.user = new UserProfile(new GlobalHistory(), new Uri("http://www.lingscars.com"), new List<Fav>());

            this.mainController = new MainController(new FormMain(), this.user.History, this.user.HomePage);

            this.mainController.MainFormClosedEvent += this.MainFormClosedEventHandler;
            this.mainController.HomeUrlInputAskedEvent += this.HomeUrlInputAskedEventHandler;
            this.mainController.HistoryPanelAskedEvent += this.HistoryPanelAskedEventHandler;
            this.mainController.FavoritesPanelAskedEvent += this.FavoritesPanelAskedEventHandler;

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

        /* ==================================
         * INPUT HOME URL CONTROLLER
         * ==================================*/

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
            this.urlController = null;
            this.mainController.ShouldBeEnabled(true);
        }

        private void HomeUrlSubmittedEventHandler(object sender, UrlInputFormSubmittedEventArgs e)
        {
            this.user.HomePage = e.Uri;
            this.mainController.UpdateHomeUri(this.user.HomePage);
            this.mainController.ShouldBeEnabled(true);
        }

        /* ==================================
         * FAVORITES PANEL CONTROLLER
         * ==================================*/

        private void FavoritesPanelAskedEventHandler(object sender, EventArgs e)
        {
            this.mainController.ShouldBeEnabled(false);

            this.favoritesController = new FavoritesPanelController(new FormFavoritesPanel(), this.user.Favorites);
            this.favoritesController.FavoritesPanelFormClosedEvent += this.FavoritesPanelClosedEventHandler;
            this.favoritesController.FavoritesUpdatedEvent += this.FavoritesUpdateEventHandler;

            this.favoritesController.Show();
        }

        private void FavoritesPanelClosedEventHandler(object sender, EventArgs e)
        {
            this.favoritesController = null;
            this.mainController.ShouldBeEnabled(true);
        }

        /* ==================================
         * HISTORY PANEL CONTROLLER
         * ==================================*/

        private void HistoryPanelAskedEventHandler(object sender, EventArgs e)
        {
            this.mainController.ShouldBeEnabled(false);

            this.historyController = new HistoryPanelController(new FormHistoryPanel(), this.user.History);
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

        /* ==================================
         * USER FILES UPDATES
         * ==================================*/

        private void HistoryUpdatedEventHandler(object sender, EventArgs e)
        {
            // todo
        }

        private void FavoritesUpdateEventHandler(object sender, EventArgs e)
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
