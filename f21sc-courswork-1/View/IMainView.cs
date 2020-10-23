using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.View
{
    interface IMainView
    {
        event EventHandler MainFormClosedEvent;

        event UrlQueriedEvent UrlQueriedEvent;
        event EventHandler ReloadAskedEvent;
        
        event EventHandler DeleteAllHistoryEvent;

        event EventHandler BackwardAskedEvent;
        event EventHandler ForwardAskedEvent;
        void SetHttpAnswer(HttpAnswer answer);
        void UpdateUrl(string url);
        void UpdateRecent(List<HttpQuery> recent);
        void DisableReload();
        void EnableReload();
        void DisableBackward();
        void EnableBackward();
        void DisableForward();
        void EnableForward();

        void Show();
    }
}
