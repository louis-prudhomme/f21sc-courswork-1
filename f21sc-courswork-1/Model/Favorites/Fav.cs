using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model.Favorites
{
    /// <summary>
    /// Represents a user favorite site
    /// </summary>
    public class Fav
    {
        /// <summary>
        /// URL of the site
        /// </summary>
        public Uri Uri { get; set; }
        /// <summary>
        /// Name of the favorite
        /// </summary>
        public string Name { get; set; }

        public Fav(Uri uri, string name)
        {
            Uri = uri;
            Name = name;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0} ({1})", this.Name, this.Uri.AbsoluteUri);
        }
    }
}
