using System;

namespace f21sc_coursework_1.Utils.Exceptions
{
    /// <summary>
    /// Exception made for the <see cref="Backer{T}"/> class.
    /// </summary>
    class BackerException : Exception
    {
        public BackerException(string message, Exception inner) : base(message, inner) { }
    }
}
