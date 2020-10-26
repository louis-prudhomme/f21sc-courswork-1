using f21sc_coursework_1.Events;
using f21sc_coursework_1.Model.HttpCommunications;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.View.HistoryPanel
{
    interface IHistoryPanelView
    {
        /// <summary>
        /// Raised when the history panel is closed
        /// </summary>
        event EventHandler HistoryPanelClosedEvent;
        /// <summary>
        /// Raised when the user asks to delete some <see cref="HttpQuery"/> from history
        /// </summary>
        event HistoryEntriesDeletedEvent HistoryEntriesDeletedEvent;
        /// <summary>
        /// Raised when the user asks to wipe the whole history
        /// </summary>
        event EventHandler HistoryWipedEvent;

        /// <summary>
        /// Orders the view to update the list of history entries
        /// </summary>
        /// <param name="entries">New history entries to display</param>
        void UpdateHistoryEntries(List<HttpQuery> entries);
        /// <summary>
        /// Orders the view to show itself
        /// </summary>
        void Show();
    }
}
