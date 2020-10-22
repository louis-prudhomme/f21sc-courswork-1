using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Event
{
    public delegate void UrlQueriedEvent(object source, UrlQueriedEventArgs e);
    
    public class UrlQueriedEventArgs : EventArgs
    {
        public string Url { get; }
        public DateTime queried { get; }

        public UrlQueriedEventArgs(string url)
        {
            Url = url;
            queried = DateTime.Now;
        }
    }
}
