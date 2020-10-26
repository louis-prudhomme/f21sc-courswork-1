using f21sc_coursework_1.Controller.FavoritesPanel;
using f21sc_coursework_1.Controller.HistoryPanel;
using f21sc_coursework_1.Controller.InputFavInfos;
using f21sc_coursework_1.Controller.InputHomeUrl;
using f21sc_coursework_1.Controller.Main;
using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using f21sc_coursework_1.Model;
using f21sc_coursework_1.Model.History;
using f21sc_coursework_1.View;
using f21sc_coursework_1.View.FavoritesPanel;
using f21sc_coursework_1.View.HistoryPanel;
using f21sc_coursework_1.View.InputHomeUrl;
using f21sc_courswork_1.Model.Favorites;
using f21sc_courswork_1.View.InputFavInfos;
using System;
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
        /// Controller for the favorites input
        /// </summary>
        private IInputFavInfosController favInputController;

        /// <summary>
        /// Represents the user data
        /// </summary>
        private readonly UserProfile user;

        /// <summary>
        /// Main constructor and real starting point of the application
        /// </summary>
        public BrowserApplicationContext()
        {
            this.user = new UserProfile(new GlobalHistory(), new Uri("http://www.lingscars.com"), new FavoritesRepository());

            this.mainController = new MainController(new FormMain(), this.user);
            this.mainController.MainFormClosedEvent += this.MainFormClosedEventHandler;
            this.mainController.GlobalHistoryUpdatedEvent += this.HistoryUpdatedEventHandler;
            this.mainController.FavoritesUpdatedEvent += this.FavoritesUpdateEventHandler;

            // handlers for new form demands
            this.mainController.HomeUrlInputAskedEvent += this.HomeUrlInputAskedEventHandler;
            this.mainController.HistoryPanelAskedEvent += this.HistoryPanelAskedEventHandler;
            this.mainController.FavoritesPanelAskedEvent += this.FavoritesPanelAskedEventHandler;
            this.mainController.FavInputAskedEvent += this.FavInputAskedEventHandler;

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

        /// <summary>
        /// Creates a new <see cref="IInputHomeUrlController"/> to answer the demand
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void HomeUrlInputAskedEventHandler(object sender, EventArgs e)
        {
            this.mainController.ShouldBeEnabled(false);

            this.urlController = new InputHomeUrlController(new FormInputHomeUrl());
            this.urlController.UrlInputFormCancelledEvent += this.HomeUrlCancelledEventHandler;
            this.urlController.UrlInputFormSubmittedEvent += this.HomeUrlSubmittedEventHandler;

            this.urlController.Show();
        }

        /// <summary>
        /// Handles the <see cref="IInputHomeUrlController"/> closure
        /// Gives back the focus to <see cref="IMainController"/> 
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void HomeUrlCancelledEventHandler(object sender, EventArgs e)
        {
            this.urlController = null;
            this.mainController.ShouldBeEnabled(true);
        }

        /// <summary>
        /// Handles the <see cref="IInputHomeUrlController"/> closure by home URL submission
        /// Updates the home URL
        /// Gives back the focus to <see cref="IMainController"/>  
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void HomeUrlSubmittedEventHandler(object sender, UrlSentEventArgs e)
        {
            this.user.HomePage = e.Uri;
            //this.mainController.UpdateHomeUrl();
            this.mainController.ShouldBeEnabled(true);
        }

        /* ==================================
         * FAVORITES INPUT CONTROLLER
         * ==================================*/

        /// <summary>
        /// Creates a new <see cref="IInputFavInfosController"/> to answer the demand
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void FavInputAskedEventHandler(object sender, FavInputAskedEventArgs e)
        {
            this.mainController.ShouldBeEnabled(false);

            this.favInputController = new InputFavInfosController(new FormInputFavInfos(), this.user.Favorites, e);
            this.favInputController.FavInputCanceledEvent += this.FavInputCancelledEventHandler;
            this.favInputController.FavInputSubmittedEvent += this.FavInputSubmittedEventHandler;

            this.favInputController.Show();
        }

        /// <summary>
        /// Handles the <see cref="IInputFavInfosController"/> closure
        /// Gives back the focus to <see cref="IMainController"/> 
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void FavInputCancelledEventHandler(object sender, EventArgs e)
        {
            this.favInputController = null;
            this.mainController.ShouldBeEnabled(true);
        }

        /// <summary>
        /// Handles the <see cref="IInputFavInfosController"/> closure by <see cref="Fav"/> submission
        /// Updates the favorites
        /// Gives back the focus to <see cref="IMainController"/>  
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void FavInputSubmittedEventHandler(object sender, EventArgs e)
        {
            this.mainController.UpdateFavorites();
            this.mainController.ShouldBeEnabled(true);
        }

        /* ==================================
         * HISTORY PANEL CONTROLLER
         * ==================================*/

        /// <summary>
        /// Creates a new <see cref="IHistoryPanelController"/> to answer the demand
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void HistoryPanelAskedEventHandler(object sender, EventArgs e)
        {
            this.mainController.ShouldBeEnabled(false);

            this.historyController = new HistoryPanelController(new FormHistoryPanel(), this.user.History);
            this.historyController.FormHistoryPanelClosedEvent += this.HistoryPanelClosedEventHandler;
            this.historyController.HistoryUpdatedEvent += this.HistoryUpdatedEventHandler;

            this.historyController.Show();
        }

        /// <summary>
        /// Handles the <see cref="IHistoryPanelController"/> closure
        /// Gives back the focus to <see cref="IMainController"/> 
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void HistoryPanelClosedEventHandler(object sender, EventArgs e)
        {
            this.historyController = null;
            this.mainController.ShouldBeEnabled(true);
            this.mainController.UpdateFavorites();
            this.mainController.UpdateHistory();
        }

        /* ==================================
         * FAVORITES PANEL CONTROLLER
         * ==================================*/

        /// <summary>
        /// Creates a new <see cref="IFavoritesPanelController"/> to answer the demand
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void FavoritesPanelAskedEventHandler(object sender, EventArgs e)
        {
            this.mainController.ShouldBeEnabled(false);

            this.favoritesController = new FavoritesPanelController(new FormFavoritesPanel(), this.user.Favorites);
            this.favoritesController.FavoritesPanelFormClosedEvent += this.FavoritesPanelClosedEventHandler;
            this.favoritesController.FavoritesUpdatedEvent += this.FavoritesUpdateEventHandler;

            this.favoritesController.Show();
        }

        /// <summary>
        /// Handles the <see cref="IFavoritesPanelController"/> closure
        /// Gives back the focus to <see cref="IMainController"/> 
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Emtpy</param>
        private void FavoritesPanelClosedEventHandler(object sender, EventArgs e)
        {
            this.favoritesController = null;
            this.mainController.ShouldBeEnabled(true);
            this.mainController.UpdateHistory();
            this.mainController.UpdateFavorites();
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
            this.mainController.UpdateFavorites();
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
