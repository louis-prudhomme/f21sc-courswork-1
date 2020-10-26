using f21sc_coursework_1.Model.HttpCommunications;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.Events
{
    /// <summary>
    /// Should be raised when one or several entries are deleted by the user
    /// </summary>
    /// <param name="source">Not important</param>
    /// <param name="e">Contains the entries to delete</param>
    public delegate void HistoryEntriesDeletedEvent(object source, HistoryEntriesDeletedEventArgs e);

    /// <summary>
    /// <see cref="EventArgs"/>-inherited class for the <see cref="HistoryEntriesDeletedEvent"/>
    /// </summary>
    public class HistoryEntriesDeletedEventArgs : EventArgs
    {
        /// <summary>
        /// <see cref="List{T}"/> of <see cref="HttpQuery"/> to delete
        /// </summary>
        public List<HttpQuery> DeletedEntries { get; }

        public HistoryEntriesDeletedEventArgs(List<HttpQuery> deleted)
        {
            this.DeletedEntries = deleted;
        }
    }
}
