using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model.Favorites
{
    public class Fav
    {
        public Uri Uri { get; set; }
        public string Name { get; set; }

        public Fav(Uri uri, string name)
        {
            Uri = uri;
            Name = name;
        }
    }
}
