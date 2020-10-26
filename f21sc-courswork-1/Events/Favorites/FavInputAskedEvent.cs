using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Events.Favorites
{
    /// <summary>
    /// Should be raised when the user wants to input a favorite through the specialized form
    /// </summary>
    /// <param name="source">Not important</param>
    /// <param name="e">Contains the favorite informations</param>
    public delegate void FavInputAskedEvent(object source, FavInputAskedEventArgs e);

    /// <summary>
    /// <see cref="EventArgs"/>-inherited class for the <see cref="FavInputAskedEvent"/>
    /// </summary>
    public class FavInputAskedEventArgs : EventArgs
    {
        /// <summary>
        /// URI of the favorite
        /// </summary>
        public string Url { get; }
        /// <summary>
        /// Name of the favorite
        /// </summary>
        public string Name { get; }

        public FavInputAskedEventArgs(FavInputAskedEventArgs previous, string name)
        {
            Url = previous.Url;
            Name = name;
        }

        public FavInputAskedEventArgs(string uri)
        {
            Url = uri;
        }
    }
}
