using System;

namespace f21sc_coursework_1.Controller.FavoritesPanel
{
    interface IFavoritesPanelController
    {
        /// <summary>
        /// Raised when the view is closed
        /// </summary>
        event EventHandler FavoritesPanelFormClosedEvent;
        /// <summary>
        /// Raised when the favorites are updated by the panel
        /// </summary>
        event EventHandler FavoritesUpdatedEvent;

        /// <summary>
        /// Order the controller to show its view
        /// </summary>
        void Show();
    }
}
