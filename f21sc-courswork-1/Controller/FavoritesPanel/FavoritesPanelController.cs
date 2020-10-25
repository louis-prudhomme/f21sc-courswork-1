using f21sc_coursework_1.Events;
using f21sc_coursework_1.Model.Favorites;
using f21sc_coursework_1.View.FavoritesPanel;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Controller.FavoritesPanel
{
    class FavoritesPanelController : IFavoritesPanelController
    {
        private readonly List<Fav> favorites;
        private readonly IFavoritesPanelView view;

        public FavoritesPanelController(IFavoritesPanelView view, List<Fav> favorites)
        {
            this.view = view;
            this.favorites = favorites;

            this.view.UpdateFavoriteItems(favorites);
            this.view.FavoritesDeletedEvent += this.FavoritesDeletedEventHandler;

            this.view.FavoritesPanelFormClosedEvent += (s, e) => this.FavoritesPanelFormClosedEvent(this, EventArgs.Empty);
        }

        public event EventHandler FavoritesPanelFormClosedEvent;
        public event EventHandler FavoritesUpdatedEvent;

        private void FavoritesDeletedEventHandler(object sender, FavoritesDeletedEventArgs e)
        {
            e.DeletedFavorites.ForEach(favToDel => this.favorites.Remove(favToDel));
            this.FavoritesUpdatedEvent(this, EventArgs.Empty);
        }

        public void Show()
        {
            this.view.Show();
        }
    }
}
