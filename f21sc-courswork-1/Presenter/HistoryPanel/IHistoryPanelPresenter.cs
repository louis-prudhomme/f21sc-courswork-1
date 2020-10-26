using f21sc_courswork_1.Presenter;
using f21sc_courswork_1.Events;
using System;

namespace f21sc_coursework_1.Presenter.HistoryPanel
{
    interface IHistoryPanelPresenter : IPresenter
    {
        /// <summary>
        /// Raised when history is updated
        /// </summary>
        event EventHandler HistoryUpdatedEvent;
        /// <summary>
        /// Raised when the user asks to jump to a specific page
        /// </summary>
        event JumpAskedEvent JumpAskedEvent;
    }
}
