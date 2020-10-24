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
        event EventHandler HistoryPanelAskedEvent;

        event UrlSentEvent UrlSentEvent;
        event EventHandler ReloadAskedEvent;
        event EventHandler HomeAskedEvent;

        event EventHandler WipeHistoryEvent;

        event EventHandler BackwardAskedEvent;
        event EventHandler ForwardAskedEvent;

        void DisplayErrorDialog(string text);
        void SetCurrentState(HttpAnswer answer, Node<HttpQuery> current);
        void UpdateRecent(List<HttpQuery> recent);
        void ShouldBeEnabled(bool should);

        void Show();
    }
}
