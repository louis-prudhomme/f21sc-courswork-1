using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Event
{
    public delegate void UrlInputFormSubmittedEvent(object source, UrlInputFormSubmittedEventArgs e);
    
    public class UrlInputFormSubmittedEventArgs : EventArgs
    {
        public Uri Uri { get; }
        public UrlInputFormSubmittedEventArgs(Uri homeUri)
        {
            this.Uri = homeUri;
        }
    }
}
