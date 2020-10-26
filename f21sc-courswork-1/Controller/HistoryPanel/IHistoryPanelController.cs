using System;

namespace f21sc_coursework_1.Controller.HistoryPanel
{
    interface IHistoryPanelController
    {
        /// <summary>
        /// Raised when history panel is closed
        /// </summary>
        event EventHandler FormHistoryPanelClosedEvent;
        /// <summary>
        /// Raised when history is updated
        /// </summary>
        event EventHandler HistoryUpdatedEvent;

        /// <summary>
        /// Orders the control to show its view
        /// </summary>
        void Show();
    }
}
