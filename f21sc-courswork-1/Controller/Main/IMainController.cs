using System;

namespace f21sc_courswork_1.Controller.Main
{
    interface IMainController
    {
        event EventHandler MainFormClosedEvent;

        event EventHandler HomeUrlInputAskedEvent;
        event EventHandler HistoryPanelAskedEvent;
        event EventHandler FavoritesPanelAskedEvent;

        event EventHandler GlobalHistoryUpdatedEvent;

        void ShouldBeEnabled(bool should);
        void UpdateHomeUri(Uri homeUri);
        void UpdateHistory();
        void Show();
    }
}
