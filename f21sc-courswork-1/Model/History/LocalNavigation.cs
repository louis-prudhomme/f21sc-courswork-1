using f21sc_coursework_1.Model.HttpCommunications;
using f21sc_courswork_1.Model.History.Exceptions;
using System.Collections.Generic;

namespace f21sc_coursework_1.Model.History
{
    /// <summary>
    /// Represents the user's navigation ; bears not correlation with <see cref="GlobalHistory"/>
    /// </summary>
    class LocalNavigation
    {
        private LinkedListNode<HttpQuery> current;
        private readonly LinkedList<HttpQuery> entries;

        public LocalNavigation()
        {
            this.entries = new LinkedList<HttpQuery>();
        }

        /// <summary>
        /// Returns the current entry
        /// </summary>
        public HttpQuery Current { get => this.HasCurrent ? this.current.Value : null; }

        /// <summary>
        /// Returns the previous entry
        /// </summary>
        public HttpQuery Previous { get => this.HasPrevious ? this.current.Previous.Value : null; }
        /// <summary>
        /// Returns the next entry
        /// </summary>
        public HttpQuery Next { get => this.HasNext ? this.current.Next.Value : null; }

        /// <summary>
        /// Returns true if the history is empty
        /// </summary>
        public bool IsEmpty { get => this.Count == 0; }
        /// <summary>
        /// Returns the number of entries in the history
        /// </summary>
        public int Count { get => this.entries.Count; }

        public Node<HttpQuery> CurrentNode => new Node<HttpQuery>(
            this.HasPrevious ? this.Previous : null,
            this.HasCurrent ? this.Current : null,
            this.HasNext ? this.Next : null);
        /// <summary>
        /// Returns true if the history has a current entry
        /// </summary>
        public bool HasCurrent { get => this.current != null; }
        /// <summary>
        /// Returns true if the history current entry has a next one
        /// </summary>
        public bool HasNext { get => this.current != null && this.current.Next != null; }
        /// <summary>
        /// Returns true if the history current entry has a previous one
        /// </summary>
        public bool HasPrevious { get => this.current != null && this.current.Previous != null; }

        /// <summary>
        /// Moves the pointer from the current query to the next one
        /// </summary>
        /// <exception cref="ImpossibleNavigationException">When there is no next node to navigate to</exception>
        public void Forward()
        {
            if (!this.HasNext)
            {
                throw new ImpossibleNavigationException();
            }
            this.current = this.current.Next;
        }


        /// <summary>
        /// Moves the pointer from the current query to the previous one
        /// </summary>
        /// <exception cref="ImpossibleNavigationException">When there is no previous node to navigate to</exception>
        public void Backward()
        {
            if (!this.HasPrevious)
            {
                throw new ImpossibleNavigationException();
            }
            this.current = this.current.Previous;
        }

        /// <summary>
        /// Removes all <see cref="HttpQuery"/> in the history
        /// </summary>
        public void RemoveAll()
        {
            this.entries.Clear();
        }

        /// <summary>
        /// Adds an entry to the history
        /// </summary>
        /// <param name="query"><see cref="HttpQuery"/> to add</param>
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

        /// <summary>
        /// Removes all entries in the history from the given one until the last one
        /// </summary>
        /// <param name="entry">Entry from which everything must be deleted</param>
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
