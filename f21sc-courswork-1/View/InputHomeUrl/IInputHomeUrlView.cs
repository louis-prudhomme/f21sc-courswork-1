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
        event UrlInputFormSubmittedEvent UrlInputFormSubmittedEvent;

        event UrlSentEvent UrlSentEvent;

        void UpdateUrl(string url);
        void SetUrlFeedback(string feedback);
        void ShouldEnableOk(bool should);

        void Show();
    }
}
