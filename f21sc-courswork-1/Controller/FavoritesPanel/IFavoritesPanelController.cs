using System;

namespace f21sc_courswork_1.Controller.FavoritesPanel
{
    interface IFavoritesPanelController
    {
        event EventHandler FavoritesPanelFormClosedEvent;
        event EventHandler FavoritesUpdatedEvent;

        void Show();
    }
}
