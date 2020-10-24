using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Controller.Main
{
    interface IMainController
    {
        event EventHandler MainFormClosedEvent;
        event EventHandler HomeUrlInputAskedEvent;
        event EventHandler HistoryPanelAskedEvent;
        event EventHandler GlobalHistoryUpdatedEvent;

        void ShouldBeEnabled(bool should);
        void UpdateHistory();
    }
}
