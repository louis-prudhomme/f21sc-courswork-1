using System;

namespace f21sc_courswork_1.Model.History.Exceptions
{
    /// <summary>
    /// Thrown in <see cref="GlobalHistory"/> when an entry does not exist upon deletion
    /// </summary>
    class EntryDoesntExistException : Exception
    {
        public EntryDoesntExistException() : base() { }
    }
}
