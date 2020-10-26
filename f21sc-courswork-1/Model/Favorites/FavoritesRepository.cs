using f21sc_courswork_1.Model.Favorites.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace f21sc_courswork_1.Model.Favorites
{
    /// <summary>
    /// Represents a repository for user’s favorites.
    /// No <see cref="Fav"/> can be referenced twice.
    /// </summary>
    class FavoritesRepository
    {
        private readonly HashSet<Fav> favs;

        public FavoritesRepository()
        {
            this.favs = new HashSet<Fav>();
        }

        /// <summary>
        /// Returns true if the repository contains at least one <see cref="Fav"/> with the given <see cref="Uri"/>
        /// </summary>
        /// <param name="uri"><see cref="Uri"/> of the <see cref="Fav"/> ; cannot be null</param>
        /// <exception cref="ArgumentNullException"> when the parameter is null</exception>
        /// <returns>true if the repository a matching <see cref="Fav"/>, false otherwise</returns>
        public bool Contains(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException();
            }
            return this.favs.Where(fav => fav.Uri.AbsoluteUri == uri.AbsoluteUri).Any();
        }

        /// <summary>
        /// Returns true if the repository containsthe provided <see cref="Fav"/>
        /// </summary>
        /// <param name="target"><see cref="Fav"/> to find ; cannot be null</param>
        /// <exception cref="ArgumentNullException"> when the parameter is null</exception>
        /// <returns>true if the repository a matching <see cref="Fav"/>, false otherwise</returns>
        public bool Contains(Fav target)
        {
            if (target == null)
            {
                throw new ArgumentNullException();
            }
            return this.favs.Where(fav => fav.Name == target.Name && fav.Uri.AbsoluteUri == target.Uri.AbsoluteUri).Any();
        }

        /// <summary>
        /// Returns the first <see cref="Fav"/> with an <see cref="Uri"/> matching the provided one, or null if no record was found
        /// </summary>
        /// <param name="uri">Uri of the <see cref="Fav"/> to find ; cannot be null</param>
        /// <exception cref="ArgumentNullException"> when the parameter is null</exception>
        /// <returns>Matching <see cref="Fav"/> or null</returns>
        public Fav Find(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException();
            }
            return this.Contains(uri) ? this.favs.Where(fav => fav.Uri.AbsoluteUri == uri.AbsoluteUri).First() : null;
        }

        /// <summary>
        /// Return a <see cref="Fav"/> matching the provided one, or null if no record was found
        /// </summary>
        /// <param name="target"><see cref="Fav"/> to find ; cannot be null</param>
        /// <exception cref="ArgumentNullException"> when the parameter is null</exception>
        /// <returns>Matching <see cref="Fav"/> or null</returns>
        public Fav Find(Fav target)
        {
            if (target == null)
            {
                throw new ArgumentNullException();
            }
            return this.Contains(target) ? this.favs.Where(fav => fav.Name == target.Name && fav.Uri.AbsoluteUri == target.Uri.AbsoluteUri).Single() : null;
        }

        /// <summary>
        /// Adds a new <see cref="Fav"/> to the favorites repository
        /// Throws a <see cref="FavAlreadyExistsException"/> if the provided <see cref="Fav"/> already exists in the respository
        /// </summary>
        /// <exception cref="FavAlreadyExistsException"/>
        /// <exception cref="ArgumentNullException"> when the parameter is null</exception>
        /// <param name="fav"><see cref="Fav"/> to add to the repository ; cannot be null</param>
        public void Add(Fav fav)
        {
            if (fav == null)
            {
                throw new ArgumentNullException();
            }
            if (this.Contains(fav))
            {
                throw new FavAlreadyExistsException();
            }
            this.favs.Add(fav);
        }

        /// <summary>
        /// Removes a <see cref="Fav"/> from the repository
        /// Throws a <see cref="FavDoesntExistException"/> if the provided <see cref="Fav"/> doesn't exist in the repository
        /// </summary>
        /// <exception cref="FavDoesntExistException"/>
        /// <param name="fav"><see cref="Fav"/> to remove ; cannot be null</param>
        /// <exception cref="ArgumentNullException"> when the parameter is null</exception>
        public void Remove(Fav fav)
        {
            if (fav == null)
            {
                throw new ArgumentNullException();
            }
            if (!this.Contains(fav))
            {
                throw new FavDoesntExistException();
            }
            this.favs.Remove(fav);
        }

        /// <summary>
        /// Returns a list of the <see cref="Fav"/> in the repository
        /// </summary>
        /// <returns><see cref="List{Fav}"/> of all the favorites in the repository</returns>
        public List<Fav> ToList()
        {
            return this.favs.Select(favs => favs).ToList();
        }
    }
}
