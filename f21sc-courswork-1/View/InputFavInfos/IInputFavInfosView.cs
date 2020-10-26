using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using System;

namespace f21sc_courswork_1.View.InputFavInfos
{
    interface IInputFavInfosView
    {
        /// <summary>
        /// Raised when the form is closed without any new <see cref="Fav"/> being submitted
        /// </summary>
        event EventHandler FavInputCancelledEvent;
        /// <summary>
        /// Raised when a new <see cref="Fav"/> is submitted
        /// </summary>
        event FavAddedEvent FavInputSubmittedEvent;

        /// <summary>
        /// Raised when the user tests an URL
        /// </summary>
        event UrlSentEvent UrlSentEvent;

        /// <summary>
        /// Orders the view to preload the <paramref name="name"/> and <paramref name="url"/> of the favorite to create
        /// </summary>
        /// <param name="name">Preset name</param>
        /// <param name="url">Preset URL</param>
        void PresetFav(string name, string url);
        /// <summary>
        /// Updates the URL after a successful test ; will also enable the submission controls
        /// </summary>
        /// <param name="url"></param>
        void UpdateUrl(string url);
        /// <summary>
        /// Orders the view to display an error dialog with the specified text as description
        /// </summary>
        /// <param name="error">Description of the error</param>
        void ErrorDialog(string error);

        /// <summary>
        /// Orders the view to show itself
        /// </summary>
        void Show();
        /// <summary>
        /// Orders the view to close
        /// </summary>
        void Close();
    }
}
