using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Events.Favorites
{
    public delegate void FavRemovedEvent(object source, FavRemovedEventArgs e);

    public class FavRemovedEventArgs : EventArgs
    {
        public string Uri { get; }

        public FavRemovedEventArgs(string uri)
        {
            Uri = uri;
        }
    }
}
