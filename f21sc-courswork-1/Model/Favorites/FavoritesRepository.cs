using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model.Favorites
{
    class FavoritesRepository
    {
        private HashSet<Fav> favs;

        public FavoritesRepository()
        {
            this.favs = new HashSet<Fav>();
        }

        public bool Contains(string name)
        {
            return this.favs.Where(fav => fav.Name == name).Any();
        }

        public bool Contains(Uri uri)
        {
            return this.favs.Where(fav => fav.Uri == uri).Any();
        }

        public Fav Find(string name)
        {
            return this.Contains(name) ? this.favs.Where(fav => fav.Name == name).First() : null;
        }

        public Fav Find(Uri uri)
        {
            return this.Contains(uri) ? this.favs.Where(fav => fav.Uri == uri).First() : null;
        }

        public void Add(Fav fav)
        {
            this.favs.Add(fav);
        }

        public void Remove(Fav fav)
        {
            this.favs.Remove(fav);
        }

        public List<Fav> ToList()
        {
            return this.favs.Select(favs => favs).ToList();
        }
    }
}
