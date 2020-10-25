using System;

namespace f21sc_coursework_1.Model.Favorites
{
    public class Fav
    {
        public Uri Uri { get; set; }
        public string name { get; set; }

        public Fav(Uri uri, string name)
        {
            Uri = uri;
            this.name = name;
        }
    }
}
