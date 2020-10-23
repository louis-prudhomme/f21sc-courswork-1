using System.Collections.Generic;
using System.Linq;

namespace f21sc_courswork_1.Model
{
    /// <summary>
    /// Models user history
    /// </summary>
    class UserHistory
    {
        private readonly SortedDictionary<int, HttpQuery> entries;

        public UserHistory()
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
        public int Count()
        {
            return this.entries.Count;
        }

        /// <summary>
        /// Allows to know whether the history is empty or not
        /// </summary>
        /// <returns>True if the history is empty</returns>
        public bool Empty()
        {
            return this.Count() == 0;
        }

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
        public HttpQuery Last()
        {
            return this.entries.First().Value;
        }

        /// <summary>
        /// Returns the last five <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HttpQuery> FiveLast()
        {
            return this.Entries(5);
        }

        /// <summary>
        /// Returns all <see cref="HttpQuery"/> in the history
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="UserHistory"/></returns>
        public IEnumerable<HttpQuery> Entries()
        {
            return this.entries.Select(entry => entry.Value);
        }

        /// <summary>
        /// Returns the first <paramref name="n"/> entries in history
        /// </summary>
        /// <param name="n">Number of <see cref="HttpQuery"/> to return</param>
        /// <returns>First <paramref name="n"/> entries in the history</returns>
        public IEnumerable<HttpQuery> Entries(int n)
        {
            return this.entries.Take(n).Select(entry => entry.Value);
        }
    }
}
