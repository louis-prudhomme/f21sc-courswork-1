using f21sc_coursework_1.Model.HttpCommunications;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Event
{
    public delegate void HistoryEntriesDeletedEvent(object source, HistoryEntriesDeletedEventArgs e);

    public class HistoryEntriesDeletedEventArgs : EventArgs
    {
        public List<HttpQuery> DeletedEntries { get; }

        public HistoryEntriesDeletedEventArgs(List<HttpQuery> deleted)
        {
            this.DeletedEntries = deleted;
        }
    }
}
