using f21sc_coursework_1.Event;
using System;

namespace f21sc_coursework_1.Controller.InputHomeUrl
{
    interface IInputHomeUrlController
    {
        event EventHandler UrlInputFormCanceledEvent;
        event UrlInputFormSubmittedEvent UrlInputFormSubmittedEvent;

        void Show();
    }
}
