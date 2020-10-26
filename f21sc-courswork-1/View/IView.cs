using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.View
{
    interface IView
    {
        /// <summary>
        /// Raised when the user closes this view
        /// </summary>
        event EventHandler ViewClosedEvent;

        /// <summary>
        /// Whether the view should be enabled
        /// </summary>
        /// <param name="should"></param>
        void ShouldBeEnabled(bool should);
        /// <summary>
        /// Displays an error dialog using <see cref="MessageBox"/>
        /// </summary>
        /// <param name="error">Error description to display</param>
        void ErrorDialog(string text);

        /// <summary>
        /// Orders the view to show up
        /// </summary>
        void Show();

        /// <summary>
        /// Orders the view to close
        /// </summary>
        void Close();
    }
}
