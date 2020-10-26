using System;

namespace f21sc_courswork_1.Model.History.Exceptions
{
    /// <summary>
    /// Thrown in <see cref="GlobalHistory"/> when an entry already exists upon addition
    /// </summary>
    class EntryAlreadyExistsException : Exception
    {
        public EntryAlreadyExistsException() : base() { }
    }
}
