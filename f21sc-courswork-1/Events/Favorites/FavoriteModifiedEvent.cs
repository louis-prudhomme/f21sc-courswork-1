using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Events.Favorites
{
    /// <summary>
    /// Should be raised when the user wants to modify one favorite
    /// </summary>
    /// <param name="source">Not important</param>
    /// <param name="e">Contains the list of events</param>
    public delegate void FavoriteModifiedEvent(object source, FavoriteModifiedEventArgs e);

    /// <summary>
    /// <see cref="EventArgs"/>-inherited class for the <see cref="FavoriteModifiedEvent"/>
    /// </summary>
    public class FavoriteModifiedEventArgs : EventArgs
    {
        /// <summary>
        /// <see cref="Fav"/> to modify
        /// </summary>
        public Fav Modified { get; }

        public FavoriteModifiedEventArgs(Fav modified)
        {
            this.Modified = modified;
        }
    }
}
