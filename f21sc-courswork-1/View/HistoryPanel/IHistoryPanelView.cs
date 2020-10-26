using f21sc_coursework_1.Events;
using f21sc_coursework_1.Model.HttpCommunications;
using f21sc_courswork_1.Events;
using f21sc_courswork_1.View;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.View.HistoryPanel
{
    interface IHistoryPanelView : IView
    {
        /// <summary>
        /// Raised when the user asks to delete some <see cref="HttpQuery"/> from history
        /// </summary>
        event HistoryEntriesDeletedEvent HistoryEntriesDeletedEvent;
        /// <summary>
        /// Raised when the user asks to wipe the whole history
        /// </summary>
        event EventHandler HistoryWipedEvent;
        /// <summary>
        /// Raised when the user asks to jump to a specific page
        /// </summary>
        event JumpAskedEvent JumpAskedEvent;

        /// <summary>
        /// Orders the view to update the list of history entries
        /// </summary>
        /// <param name="entries">New history entries to display</param>
        void UpdateHistoryEntries(List<HttpQuery> entries);
    }
}
