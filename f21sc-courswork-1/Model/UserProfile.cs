using f21sc_coursework_1.Model.History;
using f21sc_courswork_1.Model.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_coursework_1.Model
{
    [Serializable]
    class UserProfile
    {
        /// <summary>
        /// User’s <see cref="GlobalHistory"/> of navigation
        /// </summary>
        public GlobalHistory History { get; }

        /// <summary>
        /// <see cref="Uri"/> of the user’s home page
        /// </summary>
        public Uri HomePage { get; set; }

        /// <summary>
        /// User’s list of <see cref="Fav"/>
        /// </summary>
        public FavoritesRepository Favorites { get; }

        public UserProfile()
        {
            this.History = new GlobalHistory();
            this.Favorites = new FavoritesRepository();
            this.HomePage = null;
        }

        public UserProfile(GlobalHistory history, Uri homePage, FavoritesRepository favorites)
        {
            this.History = history;
            this.HomePage = homePage;
            this.Favorites = favorites;
        }
    }
}
