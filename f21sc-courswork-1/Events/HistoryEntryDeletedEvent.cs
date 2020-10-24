using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Event
{
    public delegate void HistoryEntryDeletedEvent(object source, HistoryEntryDeletedEventArgs e);
    
    public class HistoryEntryDeletedEventArgs : EventArgs
    {
        public HttpQuery DeletedEntry { get; }

        public HistoryEntryDeletedEventArgs(HttpQuery deleted)
        {
            this.DeletedEntry = deleted;
        }
    }
}
