using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Events.Favorites
{
    public delegate void FavAddedEvent(object source, FavAddedEventArgs e);

    public class FavAddedEventArgs : EventArgs
    {
        public Fav Fav { get; }

        public FavAddedEventArgs(Fav fav)
        {
            this.Fav = fav;
        }
    }
}
