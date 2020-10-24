using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;

namespace f21sc_courswork_1.View
{
    interface IMainView
    {
        event EventHandler MainFormClosedEvent;
        event EventHandler HomeUrlInputAskedEvent;

        event UrlSentEvent UrlSentEvent;
        event EventHandler ReloadAskedEvent;
        
        event EventHandler DeleteAllHistoryEvent;

        event EventHandler BackwardAskedEvent;
        event EventHandler ForwardAskedEvent;

        void DisplayErrorDialog(string text);
        void SetHttpAnswer(HttpAnswer answer);
        void UpdateUrl(string url);
        void UpdateRecent(List<HttpQuery> recent);
        void ShouldBeEnabled(bool should);
        void ShouldEnableRecent(bool should);
        void ShouldEnableReload(bool should);
        void ShouldEnableBackward(bool should);
        void ShouldEnableForward(bool should);

        void Show();
    }
}
