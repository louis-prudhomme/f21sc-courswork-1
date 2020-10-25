using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_courswork_1.Events
{
    public delegate void FavoritesDeletedEvent(object source, FavoritesDeletedEventArgs e);

    public class FavoritesDeletedEventArgs : EventArgs
    {
        public List<Fav> DeletedFavorites { get; }

        public FavoritesDeletedEventArgs(List<Fav> deleted)
        {
            this.DeletedFavorites = deleted;
        }
    }
}
