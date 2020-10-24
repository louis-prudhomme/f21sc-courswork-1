using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Event
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
