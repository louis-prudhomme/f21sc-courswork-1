using f21sc_coursework_1.Events;
using System;

namespace f21sc_coursework_1.View
{
    interface IInputHomeUrlView
    {
        event EventHandler HomeUrlCancelledEvent;
        event UrlSentEvent HomeUrlSubmittedEvent;

        event UrlSentEvent UrlSentEvent;

        void UpdateUrl(string url);
        void SetUrlFeedback(string feedback);
        void ShouldEnableOk(bool should);

        void ErrorDialog(string error);
        void Show();
    }
}
