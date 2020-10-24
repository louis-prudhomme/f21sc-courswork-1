using f21sc_courswork_1.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Controller.InputHomeUrl
{
    interface IInputHomeUrlController
    {
        void Show();

        event EventHandler UrlInputFormCanceledEvent;
        event UrlInputFormSubmittedEvent UrlInputFormSubmittedEvent;
    }
}
