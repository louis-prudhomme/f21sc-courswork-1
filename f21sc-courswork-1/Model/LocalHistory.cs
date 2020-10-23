using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model
{
    class LocalHistory
    {
        private LinkedListNode<HttpQuery> current;
        private readonly LinkedList<HttpQuery> entries;

        public LocalHistory()
        {
            // todo add home page
            // add current ?
            this.entries = new LinkedList<HttpQuery>();
        }

        public HttpQuery Current { get => this.current.Value; }

        public HttpQuery Previous { get => this.current.Previous.Value; }

        public HttpQuery Next { get => this.current.Next.Value; }
        public bool HasCurrent { get => this.current != null; }
        public bool HasNext { get => this.current.Next != null; }
        public bool HasPrevious { get => this.current.Previous!= null; }

        public void Forward()
        {
            this.current = this.current.Next;
        }

        public void Backward()
        {
            this.current = this.current.Previous;
        }
        public bool IsEmpty { get => this.Count == 0; }
        public int Count { get => this.entries.Count; }

        public void Add(HttpQuery query)
        {
            if (current == null)
            {
                this.entries.AddLast(query);
                this.current = this.entries.Last;
                return;
            }

            if (this.current.Next != null)
            {
                this.RemoveAllEntriesFrom(current);
            }

            this.entries.AddLast(query);
            this.current = this.entries.Last;
        }

        private void RemoveAllEntriesFrom(LinkedListNode<HttpQuery> entry)
        {
            LinkedListNode<HttpQuery> pointer = this.entries.Last;
            while (pointer != entry)
            {
                pointer = pointer.Previous;
                this.entries.Remove(pointer.Next);
            }
        }
    }
}
