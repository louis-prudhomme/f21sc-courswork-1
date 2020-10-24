using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using f21sc_courswork_1.Utils;
using f21sc_courswork_1.View;
using f21sc_courswork_1.View.InputHomeUrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Controller.InputHomeUrl
{
    class InputHomeUrlController : IInputHomeUrlController
    {
        private readonly FormInputHomeUrl view;

        public InputHomeUrlController(FormInputHomeUrl view)
        {
            this.view = view;

            this.view.UrlInputFormCanceledEvent += this.UrlInputFormCanceledEventHandler;
            this.view.UrlInputFormSubmittedEvent += this.UrlInputFormSubmittedEventHandler;
            this.view.UrlSentEvent += this.UrlSentEventHandler;
        }

        public event EventHandler UrlInputFormCanceledEvent;
        public event UrlSentEvent UrlInputFormSubmittedEvent;

        public void Show()
        {
            this.view.Show();
        }

        public void UrlSentEventHandler(object sender, UrlSentEventArgs e)
        {
            if (HttpUriHelper.IsValidHttpUri(e.Url))
            {
                this.view.ShouldEnableOk(true);
                this.view.SetUrlFeedback("The URL has been sucessfully verified !");
            } else
            {
                this.view.SetUrlFeedback("Please input a valid URL.");
            }
        }

        public void UrlInputFormCanceledEventHandler(object sender, EventArgs e)
        {
            this.view.Dispose();
            this.UrlInputFormCanceledEvent(this, EventArgs.Empty);
        }

        public void UrlInputFormSubmittedEventHandler(object sender, UrlSentEventArgs e)
        {
            this.view.Dispose();
            this.UrlInputFormSubmittedEvent(this, e);
        }
    }
}
