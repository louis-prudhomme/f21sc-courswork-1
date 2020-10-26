using f21sc_coursework_1.Events.Favorites;
using f21sc_courswork_1.Presenter;
using System;

namespace f21sc_coursework_1.Presenter.Main
{
    interface IMainPresenter : IPresenter
    {
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

        /// <summary>
        /// Orders the presenter to load a page
        /// </summary>
        /// <param name="should"></param>
        void InitiateJump(Uri target);
        /// <summary>
        /// Orders the presenter to prompt an error dialog
        /// </summary>
        void ErrorDialog(string error);
        /// <summary>
        /// Orders the presenter to update the history
        /// </summary>
        void UpdateHistory();
        /// <summary>
        /// Orders the presenter to update the favorites
        /// </summary>
        void UpdateFavorites();
        /// <summary>
        /// Orders the presenter to update the home url
        /// </summary>
        void UpdateHomeUrl();
    }
}
