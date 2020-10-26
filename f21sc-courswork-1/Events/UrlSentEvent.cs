using System;

namespace f21sc_coursework_1.Events
{
    public delegate void UrlSentEvent(object source, UrlSentEventArgs e);

    public class UrlSentEventArgs : EventArgs
    {
        public string Url { get; }
        public Uri Uri { get; }

        public UrlSentEventArgs(Uri uri)
        {
            Uri = uri;
        }

        public UrlSentEventArgs(string url)
        {
            Url = url;
        }
    }
}
