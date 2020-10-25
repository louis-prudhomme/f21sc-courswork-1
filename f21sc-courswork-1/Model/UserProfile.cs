using f21sc_coursework_1.Model.Favorites;
using f21sc_coursework_1.Model.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_coursework_1.Model
{
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
        public List<Fav> Favorites { get; }

        public UserProfile(GlobalHistory history, Uri homePage, List<Fav> favorites)
        {
            this.History = history;
            this.HomePage = homePage;
            this.Favorites = favorites;
        }
    }
}
