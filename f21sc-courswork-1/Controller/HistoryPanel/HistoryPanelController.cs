using f21sc_coursework_1.Events;
using f21sc_coursework_1.Model.History;
using f21sc_coursework_1.View.HistoryPanel;
using f21sc_courswork_1.Events;
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

            this.view.ViewClosedEvent += (s, e) => this.ViewClosedEvent(this, EventArgs.Empty);
            this.view.JumpAskedEvent += (s, e) => this.JumpAskedEvent(this, e);
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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Close()
        {
            this.view.Close();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="should"></param>
        public void ShouldBeEnabled(bool should)
        {
            throw new NotImplementedException();
        }

        /* ==================================
         * EVENTS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler ViewClosedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HistoryUpdatedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event JumpAskedEvent JumpAskedEvent;
    }
}
