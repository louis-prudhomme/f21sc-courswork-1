using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model.History;
using f21sc_courswork_1.View.HistoryPanel;
using System;

namespace f21sc_courswork_1.Controller.HistoryPanel
{
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

        public event EventHandler FormHistoryPanelClosedEvent;
        public event EventHandler HistoryUpdatedEvent;

        public void HistoryWipedEventHandler(object sender, EventArgs e)
        {
            this.history.RemoveAll();
            this.view.UpdateHistoryEntries(this.history.Entries);
            this.HistoryUpdatedEvent(this, EventArgs.Empty);
        }

        public void HistoryEntriesDeletedEventHandler(object sender, HistoryEntriesDeletedEventArgs e)
        {
            this.history.RemoveAll(e.DeletedEntries);
            this.view.UpdateHistoryEntries(this.history.Entries);
            this.HistoryUpdatedEvent(this, EventArgs.Empty);
        }

        public void Show()
        {
            this.view.Show();
        }
    }
}
