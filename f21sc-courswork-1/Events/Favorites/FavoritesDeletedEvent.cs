using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Events.Favorites
{
    /// <summary>
    /// Should be raised when one or several events are deleted by the user
    /// </summary>
    /// <param name="source">Not important</param>
    /// <param name="e">Contains the list of events</param>
    public delegate void FavoritesDeletedEvent(object source, FavoritesDeletedEventArgs e);

    /// <summary>
    /// <see cref="EventArgs"/>-inherited class for the <see cref="FavoritesDeletedEvent"/>
    /// </summary>
    public class FavoritesDeletedEventArgs : EventArgs
    {
        /// <summary>
        /// <see cref="List{T}"/> of <see cref="Fav"/> to delete
        /// </summary>
        public List<Fav> DeletedFavorites { get; }

        public FavoritesDeletedEventArgs(List<Fav> deleted)
        {
            this.DeletedFavorites = deleted;
        }
    }
}
