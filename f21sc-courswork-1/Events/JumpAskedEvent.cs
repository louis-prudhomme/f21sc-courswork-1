using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Events
{
    /// <summary>
    /// Should be raised when the user wants to access a page through history or favorites panels.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    public delegate void JumpAskedEvent(object source, JumpAskedEventArgs e);

    /// <summary>
    /// <see cref="EventArgs"/>-inherited class for the <see cref="JumpAskedEvent"/>
    /// </summary>
    public class JumpAskedEventArgs : EventArgs
    {
        public Uri jumpTo { get; }

        public JumpAskedEventArgs(Uri jumpTo)
        {
            this.jumpTo = jumpTo;
        }
    }
}
