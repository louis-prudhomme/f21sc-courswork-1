using f21sc_coursework_1.Events;
using f21sc_courswork_1.View;
using System;

namespace f21sc_coursework_1.View
{
    interface IInputHomeUrlView : IView
    {
        /// <summary>
        /// Raised when an url is submitted by the user
        /// </summary>
        event UrlSentEvent HomeUrlSubmittedEvent;

        /// <summary>
        /// Raised when an url is sent for validation pruposes by the user
        /// </summary>
        event UrlSentEvent UrlSentEvent;

        /// <summary>
        /// Orders the view to update the url with the provided one
        /// </summary>
        /// <param name="url">Validated and sanitized URL</param>
        void UpdateUrl(string url);
        /// <summary>
        /// Sets the URL feedback
        /// </summary>
        /// <param name="feedback"> feedback</param>
        void SetUrlFeedback(string feedback);
    }
}
