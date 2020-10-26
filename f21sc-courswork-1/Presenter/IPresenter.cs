using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Presenter
{
    interface IPresenter
    {
        /// <summary>
        /// Raised when the user the view of this presenter
        /// </summary>
        event EventHandler ViewClosedEvent;

        /// <summary>
        /// Orders the presenter to show itself
        /// </summary>
        void Show();
        /// <summary>
        /// Orders the presenter to close
        /// </summary>
        void Close();

        /// <summary>
        /// Whether the view should be enabled
        /// </summary>
        /// <param name="should"></param>
        void ShouldBeEnabled(bool should);
    }
}
