using f21sc_coursework_1.Events.Favorites;
using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.View.FavoritesPanel
{
    interface IFavoritesPanelView
    {
        /// <summary>
        /// Raised when the view is closed
        /// </summary>
        event EventHandler FavoritesPanelFormClosedEvent;
        /// <summary>
        /// Raised when user asks for the deletion of one or more favorites
        /// </summary>
        event FavoritesDeletedEvent FavoritesDeletedEvent;

        /// <summary>
        /// Updates the view's list of <see cref="Fav"/>
        /// </summary>
        /// <param name="favorites">New list to display</param>
        void UpdateFavoriteItems(List<Fav> favorites);
        /// <summary>
        /// Displays an error dialog using <see cref="MessageBox"/>
        /// </summary>
        /// <param name="error">Error description to display</param>
        void ErrorDialog(string error);

        /// <summary>
        /// Order the view to show itself
        /// </summary>
        void Show();
        /// <summary>
        /// Order the view to close
        /// </summary>
        void Close();
    }
}
