using f21sc_courswork_1.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Controller.HistoryPanel
{
    interface IHistoryPanelController
    {
        event EventHandler FormHistoryPanelClosedEvent;

        event EventHandler HistoryUpdatedEvent;

        void Show();
    }
}
