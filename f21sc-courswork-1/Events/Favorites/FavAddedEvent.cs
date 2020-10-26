using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Events.Favorites
{
    /// <summary>
    /// Should be raised when the user wants to create a favorite
    /// This is a proto-favorite, only ment to be a DTO 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    public delegate void FavAddedEvent(object source, FavAddedEventArgs e);

    /// <summary>
    /// <see cref="EventArgs"/>-inherited class for the <see cref="FavAddedEvent"/>
    /// </summary>
    public class FavAddedEventArgs : EventArgs
    {
        /// <summary>
        /// URI of the favorite
        /// </summary>
        public string Uri { get; }
        /// <summary>
        /// Name of the favorite
        /// </summary>
        public string Name { get; }

        public FavAddedEventArgs(string uri, string name)
        {
            this.Uri = uri;
            this.Name = name;
        }
    }
}
