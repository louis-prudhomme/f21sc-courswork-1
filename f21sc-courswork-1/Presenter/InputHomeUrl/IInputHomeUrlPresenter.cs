using f21sc_coursework_1.Events;
using f21sc_courswork_1.Presenter;
using System;

namespace f21sc_coursework_1.Presenter.InputHomeUrl
{
    interface IInputHomeUrlPresenter : IPresenter
    {
        /// <summary>
        /// Raised when the user submits an URL through the form
        /// </summary>
        event UrlSentEvent UrlInputFormSubmittedEvent;
    }
}
