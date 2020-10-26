using f21sc_coursework_1.Events;
using f21sc_courswork_1.Controller;
using System;

namespace f21sc_coursework_1.Controller.InputHomeUrl
{
    interface IInputHomeUrlController : IController
    {
        /// <summary>
        /// Raised when the user submits an URL through the form
        /// </summary>
        event UrlSentEvent UrlInputFormSubmittedEvent;
    }
}
