using f21sc_coursework_1.Event;
using f21sc_coursework_1.Model.HttpCommunications;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.View.HistoryPanel
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
