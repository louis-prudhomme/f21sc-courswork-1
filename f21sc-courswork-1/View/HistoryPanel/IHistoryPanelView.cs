﻿using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.View
{
    interface IHistoryPanelView
    {
        event EventHandler HistoryPanelClosedEvent;

        event HistoryEntryDeletedEvent HistoryEntryDeletedEvent;
        event EventHandler HistoryDeletedEvent;

        void Show();
    }
}
