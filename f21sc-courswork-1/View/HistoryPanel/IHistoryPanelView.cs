using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.View.HistoryPanel
{
    interface IHistoryPanelView
    {
        event EventHandler HistoryPanelClosedEvent;

        event HistoryEntriesDeletedEvent HistoryEntriesDeletedEvent;
        event EventHandler HistoryWipedEvent;

        void UpdateHistoryEntries(List<HttpQuery> entries);

        void Show();
    }
}
