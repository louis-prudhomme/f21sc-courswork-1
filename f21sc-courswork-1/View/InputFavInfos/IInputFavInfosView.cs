using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using System;

namespace f21sc_courswork_1.View.InputFavInfos
{
    interface IInputFavInfosView : IView
    {
        /// <summary>
        /// Raised when a new <see cref="Fav"/> is submitted
        /// </summary>
        event FavSubmittedEvent FavInputSubmittedEvent;

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
    }
}
