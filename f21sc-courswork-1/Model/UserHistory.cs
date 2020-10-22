using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model
{
    class UserHistory
    {
        private SortedDictionary<int, HttpQuery> entries;

        public UserHistory()
        {
            this.entries = new SortedDictionary<int, HttpQuery>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }

        public void Add(HttpQuery entry)
        {
            this.entries.Add(entry.TimestampIssuedAt, entry);
        }

        public void Remove(HttpQuery entry)
        {
            this.entries.Remove(entry.TimestampIssuedAt);
        }

        public void RemoveAll()
        {
            this.entries.Clear();
        }

        public HttpQuery Last()
        {
            return this.entries.First().Value;
        }

        public IEnumerable<HttpQuery> FiveLast()
        {
            return this.entries.Take(5).Select(entry => entry.Value);
        }

        public IEnumerable<HttpQuery> Entries()
        {
            return this.entries.Select(entry => entry.Value);
        }

        public IEnumerable<HttpQuery> Entries(int n)
        {
            return this.entries.Take(n).Select(entry => entry.Value);
        }
    }
}
