using f21sc_coursework_1.Events;
using f21sc_coursework_1.Model.History;
using f21sc_coursework_1.View.HistoryPanel;
using System;

namespace f21sc_coursework_1.Controller.HistoryPanel
{
    /// <summary>
    /// Controller for the <see cref="IHistoryPanelView"/>
    /// </summary>
    class HistoryPanelController : IHistoryPanelController
    {
        private readonly IHistoryPanelView view;
        private readonly GlobalHistory history;

        public HistoryPanelController(IHistoryPanelView view, GlobalHistory history)
        {
            this.view = view;
            this.history = history;

            this.view.UpdateHistoryEntries(history.Entries);

            this.view.HistoryWipedEvent += this.HistoryWipedEventHandler;
            this.view.HistoryEntriesDeletedEvent += this.HistoryEntriesDeletedEventHandler;

            this.view.HistoryPanelClosedEvent += (o, e) => this.FormHistoryPanelClosedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handler for when the history is wiped by the user
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        public void HistoryWipedEventHandler(object sender, EventArgs e)
        {
            this.history.RemoveAll();
            this.view.UpdateHistoryEntries(this.history.Entries);
            this.HistoryUpdatedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Handler for when one or several entries are deleted by the user
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Contains entries to be deleted</param>
        public void HistoryEntriesDeletedEventHandler(object sender, HistoryEntriesDeletedEventArgs e)
        {
            this.history.RemoveAll(e.DeletedEntries);
            this.view.UpdateHistoryEntries(this.history.Entries);
            this.HistoryUpdatedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Show()
        {
            this.view.Show();
        }

        /* ==================================
         * EVENTS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler FormHistoryPanelClosedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HistoryUpdatedEvent;
    }
}
