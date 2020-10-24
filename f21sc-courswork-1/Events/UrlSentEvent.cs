using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Event
{
    public delegate void UrlSentEvent(object source, UrlSentEventArgs e);
    
    public class UrlSentEventArgs : EventArgs
    {
        public string Url { get; }
        public DateTime queried { get; }

        public UrlSentEventArgs(string url)
        {
            Url = url;
            queried = DateTime.Now;
        }
    }
}
