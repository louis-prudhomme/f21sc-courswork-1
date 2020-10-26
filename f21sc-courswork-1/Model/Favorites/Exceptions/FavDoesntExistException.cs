using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model.Favorites.Exceptions
{
    /// <summary>
    /// Thrown in <see cref="FavoritesRepository"/> when a favorite does not exists in the repository upon begin deleted
    /// </summary>
    class FavDoesntExistException : Exception
    {
        public FavDoesntExistException() : base() { }
    }
}
