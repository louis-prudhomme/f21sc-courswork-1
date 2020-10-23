using f21sc_courswork_1.Utils;
using System.Collections.Generic;
using System.Linq;

namespace f21sc_courswork_1.Model
{
    /// <summary>
    /// Models user global navigation history
    /// </summary>
    class GlobalHistory
    {
        private readonly SortedDictionary<int, HttpQuery> entries;

        public GlobalHistory()
        {
            this.entries = new SortedDictionary<int, HttpQuery>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
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
        public HttpQuery Last { get => this.entries.First().Value; }

        /// <summary>
        /// Returns the last five <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <returns></returns>
        public List<HttpQuery> LastFive()
        {
            return this.Entries(5).ToList();
        }

        /// <summary>
        /// Returns all <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="GlobalHistory"/></returns>
        public List<HttpQuery> Entries()
        {
            return this.entries.Select(entry => entry.Value).ToList();
        }

        /// <summary>
        /// Returns the first <paramref name="n"/> entries in history
        /// </summary>
        /// <param name="n">Number of <see cref="HttpQuery"/> to return</param>
        /// <returns>First <paramref name="n"/> entries in the history</returns>
        public List<HttpQuery> Entries(int n)
        {
            return this.entries.Take(n).Select(entry => entry.Value).ToList();
        }
    }
}
