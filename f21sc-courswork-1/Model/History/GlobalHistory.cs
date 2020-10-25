using f21sc_courswork_1.Model.HttpCommunications;
using System.Collections.Generic;
using System.Linq;

namespace f21sc_courswork_1.Model.History
{
    /// <summary>
    /// Models user global navigation history
    /// </summary>
    class GlobalHistory
    {
        private readonly SortedDictionary<long, HttpQuery> entries;

        public GlobalHistory()
        {
            this.entries = new SortedDictionary<long, HttpQuery>(Comparer<long>.Create((a, b) => b.CompareTo(a)));
        }

        /// <summary>
        /// Add an <see cref="HttpQuery"/> to history
        /// </summary>
        /// <param name="entry"></param>
        public void Add(HttpQuery entry)
        {
            this.entries.Add(entry.TimestampIssuedAt, entry);
        }

        /// <summary>
        /// Returns the number of <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <returns>The number of entries</returns>
        public int Count { get => this.entries.Count; }

        /// <summary>
        /// Allows to know whether the history is empty or not
        /// </summary>
        /// <returns>True if the history is empty</returns>
        public bool IsEmpty { get => this.entries.Count == 0; }

        /// <summary>
        /// Removes an <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <param name="entry">Entry to delete</param>
        public void Remove(HttpQuery entry)
        {
            this.entries.Remove(entry.TimestampIssuedAt);
        }

        /// <summary>
        /// Removes an <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <param name="entry">Entry to delete</param>
        public void RemoveAll(List<HttpQuery> entriesToDelete)
        {
            entriesToDelete.Select(entry => entry.TimestampIssuedAt).ToList().ForEach(timestamp => this.entries.Remove(timestamp));
        }

        /// <summary>
        /// Removes all <see cref="HttpQuery"/> in the history
        /// </summary>
        public void RemoveAll()
        {
            this.entries.Clear();
        }

        /// <summary>
        /// Returns the last <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <returns></returns>
        public HttpQuery Last { get => this.entries.Count == 0 ? null : this.entries.First().Value; }

        /// <summary>
        /// Returns the last five <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <returns></returns>
        public List<HttpQuery> LastFive()
        {
            return this.NEntries(5).ToList();
        }

        /// <summary>
        /// Returns all <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="GlobalHistory"/></returns>
        public List<HttpQuery> Entries => this.entries.Select(entry => entry.Value).ToList();

        /// <summary>
        /// Returns the first <paramref name="n"/> entries in history
        /// </summary>
        /// <param name="n">Number of <see cref="HttpQuery"/> to return</param>
        /// <returns>First <paramref name="n"/> entries in the history</returns>
        public List<HttpQuery> NEntries(int n)
        {
            return this.entries.Take(n).Select(entry => entry.Value).ToList();
        }

        public Dictionary<string, int> NumberOfVisits()
        {
            return this.entries.Select(entry => entry.Value).GroupBy(query => query.Host).ToDictionary(group => group.Key, group => group.Count());
        }
    }
}
