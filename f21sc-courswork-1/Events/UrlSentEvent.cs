using System;

namespace f21sc_courswork_1.Event
{
    public delegate void UrlSentEvent(object source, UrlSentEventArgs e);

    public class UrlSentEventArgs : EventArgs
    {
        public string Url { get; }
        public UrlSentEventArgs(string url)
        {
            Url = url;
        }
    }
}
