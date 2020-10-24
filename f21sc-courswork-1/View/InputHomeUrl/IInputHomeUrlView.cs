using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.View
{
    interface IInputHomeUrlView
    {
        event EventHandler UrlInputFormCanceledEvent;
        event UrlSentEvent UrlInputFormSubmittedEvent;

        event UrlSentEvent UrlSentEvent;
        
        void SetUrlFeedback(string feedback);
        void ShouldEnableOk(bool should);

        void Show();
    }
}
