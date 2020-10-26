using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Controller
{
    interface IController
    {
        /// <summary>
        /// Raised when the user the view of this controller
        /// </summary>
        event EventHandler ViewClosedEvent;

        /// <summary>
        /// Orders the controller to show itself
        /// </summary>
        void Show();
        /// <summary>
        /// Orders the controller to close
        /// </summary>
        void Close();

        /// <summary>
        /// Whether the view should be enabled
        /// </summary>
        /// <param name="should"></param>
        void ShouldBeEnabled(bool should);
    }
}
