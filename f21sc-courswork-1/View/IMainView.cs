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
        event UrlQueriedEvent UrlQueriedEvent;
        event EventHandler MainFormClosedEvent;
        event EventHandler ReloadAskedEvent;
        event EventHandler DeleteAllHistoryEvent;
        void SetHttpAnswer(HttpAnswer answer);
        void UpdateUrl(string url);
        void DisableReload();
        void EnableReload();

        void Show();
    }
}
