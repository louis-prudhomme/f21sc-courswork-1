using f21sc_courswork_1.Event;
using f21sc_courswork_1.Utils;
using f21sc_courswork_1.View;
using f21sc_courswork_1.View.InputHomeUrl;
using System;

namespace f21sc_courswork_1.Controller.InputHomeUrl
{
    class InputHomeUrlController : IInputHomeUrlController
    {
        private readonly IInputHomeUrlView view;

        public InputHomeUrlController(IInputHomeUrlView view)
        {
            this.view = view;

            this.view.UrlInputFormCanceledEvent += this.UrlInputFormCanceledEventHandler;
            this.view.UrlInputFormSubmittedEvent += this.UrlInputFormSubmittedEventHandler;
            this.view.UrlSentEvent += this.UrlSentEventHandler;
        }

        public event EventHandler UrlInputFormCanceledEvent;
        public event UrlInputFormSubmittedEvent UrlInputFormSubmittedEvent;

        public void Show()
        {
            this.view.Show();
        }

        public void UrlSentEventHandler(object sender, UrlSentEventArgs e)
        {
            if (HttpUriHelper.TryCreateHttpUri(e.Url, out Uri uri))
            {
                this.view.ShouldEnableOk(true);
                this.view.UpdateUrl(uri.AbsoluteUri);
                this.view.SetUrlFeedback("The URL has been sucessfully verified !");
            } else
            {
                this.view.SetUrlFeedback("Please input a valid URL.");
            }
        }

        public void UrlInputFormCanceledEventHandler(object sender, EventArgs e)
        {
            this.UrlInputFormCanceledEvent(this, EventArgs.Empty);
        }

        public void UrlInputFormSubmittedEventHandler(object sender, UrlInputFormSubmittedEventArgs e)
        {
            this.UrlInputFormSubmittedEvent(this, e);
        }
    }
}
