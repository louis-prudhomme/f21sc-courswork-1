using f21sc_coursework_1.Events.Favorites;
using System;

namespace f21sc_coursework_1.Controller.Main
{
    interface IMainController
    {
        /// <summary>
        /// Raised when the main form is closed
        /// </summary>
        event EventHandler MainFormClosedEvent;

        /// <summary>
        /// Raised when the user asks to alter the home url
        /// </summary>
        event EventHandler HomeUrlInputAskedEvent;
        /// <summary>
        /// Raised when the user asks to see the history panel
        /// </summary>
        event EventHandler HistoryPanelAskedEvent;
        /// <summary>
        /// Raised when the user asks to see the favorites panel
        /// </summary>
        event EventHandler FavoritesPanelAskedEvent;
        /// <summary>
        /// Raised when the user asks to create a new favorite
        /// </summary>
        event FavInputAskedEvent FavInputAskedEvent;

        /// <summary>
        /// Raised when the history is updated
        /// </summary>
        event EventHandler GlobalHistoryUpdatedEvent;
        /// <summary>
        /// Raised when the favorites are updated
        /// </summary>
        event EventHandler FavoritesUpdatedEvent;

        void ShouldBeEnabled(bool should);
        /// <summary>
        /// Orders the controller to prompt an error dialog
        /// </summary>
        void ErrorDialog(string error);
        /// <summary>
        /// Orders the controller to update the history
        /// </summary>
        void UpdateHistory();
        /// <summary>
        /// Orders the controller to update the favorites
        /// </summary>
        void UpdateFavorites();
        /// <summary>
        /// Orders the controller to show its view
        /// </summary>
        void Show();
    }
}
