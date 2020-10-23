using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Utils.Exceptions
{
    /// <summary>
    /// Exception made for the <see cref="Backer{T}"/> class.
    /// </summary>
    class BackerException : Exception
    {
        public BackerException(string message, Exception inner) : base(message, inner) { }
    }
}
