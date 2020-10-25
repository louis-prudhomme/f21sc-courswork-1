using f21sc_courswork_1.Event;
using System;

namespace f21sc_courswork_1.View
{
    interface IInputHomeUrlView
    {
        event EventHandler UrlInputFormCanceledEvent;
        event UrlInputFormSubmittedEvent UrlInputFormSubmittedEvent;

        event UrlSentEvent UrlSentEvent;

        void UpdateUrl(string url);
        void SetUrlFeedback(string feedback);
        void ShouldEnableOk(bool should);

        void Show();
    }
}
