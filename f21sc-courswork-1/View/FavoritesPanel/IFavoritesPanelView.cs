using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.View.FavoritesPanel
{
    interface IFavoritesPanelView
    {
        event EventHandler FavoritesPanelFormClosedEvent;

        event FavoritesDeletedEvent FavoritesDeletedEvent;

        void UpdateFavoriteItems(List<Fav> favorites);

        void Show();
    }
}
