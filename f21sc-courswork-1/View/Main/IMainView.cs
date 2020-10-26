using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using f21sc_coursework_1.Model;
using f21sc_coursework_1.Model.HttpCommunications;
using f21sc_courswork_1.View;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.View
{
    interface IMainView : IView
    {
        /// <summary>
        /// Raised when the user asks for the favorites panel
        /// </summary>
        event EventHandler FavoritesPanelAskedEvent;
        /// <summary>
        /// Raised when the user asks to create a favorite
        /// </summary>
        event EventHandler HomeUrlInputAskedEvent;
        /// <summary>
        /// Raised when the user asks for the history panel
        /// </summary>
        event EventHandler HistoryPanelAskedEvent;

        /// <summary>
        /// Raised when the user sents an url
        /// </summary>
        event UrlSentEvent UrlSentEvent;
        /// <summary>
        /// Raised when the user asks for a reload of the current page
        /// </summary>
        event EventHandler ReloadAskedEvent;
        /// <summary>
        /// Raised when the user asks for the home page
        /// </summary>
        event EventHandler HomeAskedEvent;

        /// <summary>
        /// Raised when the user wipes the history
        /// </summary>
        event EventHandler WipeHistoryEvent;

        /// <summary>
        /// Raised when the user goes backwards in navigation
        /// </summary>
        event EventHandler BackwardAskedEvent;
        /// <summary>
        /// Raised when the user goes forwards in navigation
        /// </summary>
        event EventHandler ForwardAskedEvent;

        /// <summary>
        /// Raised when the user adds the current page to favorites
        /// </summary>
        event FavInputAskedEvent FavInputAskedEvent;
        /// <summary>
        /// Raised when the user removes the current page from favorites
        /// </summary>
        event EventHandler RemoveFavEvent;

        /// <summary>
        /// Will trigger an update of the view controls 
        /// </summary>
        /// <param name="answer">State of the HTML displayer</param>
        /// <param name="current">State of the navigation</param>
        void SetCurrentState(HttpAnswer answer, Node<HttpQuery> current);
        /// <summary>
        /// Updates the recent history toolstrip with the five last <see cref="HttpQuery"/> issued by the user
        /// </summary>
        /// <param name="recentQueries">Five last <see cref="HttpQuery"/> issued by the user</param>
        void UpdateRecent(List<HttpQuery> recent);
        /// <summary>
        /// Updates the view by telling it whether the current navigation is a favorite 
        /// </summary>
        /// <param name="isFav"></param>
        void IsCurrentAFav(bool isFav);
        /// <summary>
        /// Update the view regarding the home url
        /// </summary>
        /// <param name="hasHomeUrl"></param>
        void UpdateHomeUrl(bool hasHomeUrl);
    }
}
