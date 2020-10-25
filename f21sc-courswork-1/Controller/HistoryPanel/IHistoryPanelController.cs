using System;

namespace f21sc_courswork_1.Controller.HistoryPanel
{
    interface IHistoryPanelController
    {
        event EventHandler FormHistoryPanelClosedEvent;

        event EventHandler HistoryUpdatedEvent;

        void Show();
    }
}
