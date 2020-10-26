using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model.Favorites.Exceptions
{
    /// <summary>
    /// Thrown in <see cref="FavoritesRepository"/> when a favorite already exists in the repository upon begin added
    /// </summary>
    class FavAlreadyExistsException : Exception
    {
        public FavAlreadyExistsException() : base() { }
    }
}
