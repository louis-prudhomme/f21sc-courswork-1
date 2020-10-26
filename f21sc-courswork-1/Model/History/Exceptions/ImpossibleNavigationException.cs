using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model.History.Exceptions
{
    /// <summary>
    /// Should be thrown when an impossible navigation is asked to <see cref="LocalNavigation"/>
    /// </summary>
    class ImpossibleNavigationException : Exception
    {
        public ImpossibleNavigationException() : base() { }
    }
}
