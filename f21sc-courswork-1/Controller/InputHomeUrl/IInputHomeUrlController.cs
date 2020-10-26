using f21sc_coursework_1.Events;
using System;

namespace f21sc_coursework_1.Controller.InputHomeUrl
{
    interface IInputHomeUrlController
    {
        /// <summary>
        /// Raised when the form is closed without any URL being submitted
        /// </summary>
        event EventHandler UrlInputFormCancelledEvent;
        /// <summary>
        /// Raised when the user submits an URL through the form
        /// </summary>
        event UrlSentEvent UrlInputFormSubmittedEvent;

        /// <summary>
        /// Orders the controller to show its view
        /// </summary>
        void Show();
    }
}
