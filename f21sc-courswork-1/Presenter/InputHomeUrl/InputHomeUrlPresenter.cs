using f21sc_coursework_1.Events;
using f21sc_coursework_1.Utils.Http;
using f21sc_coursework_1.View;
using System;

namespace f21sc_coursework_1.Presenter.InputHomeUrl
{
    /// <summary>
    /// This is the presenter for the <see cref="IInputHomeUrlView"/>
    /// </summary>
    class InputHomeUrlPresenter : IInputHomeUrlPresenter
    {
        private readonly IInputHomeUrlView view;

        public InputHomeUrlPresenter(IInputHomeUrlView view)
        {
            this.view = view;

            this.view.ViewClosedEvent += (s, e) => this.ViewClosedEvent(this, EventArgs.Empty);
            this.view.HomeUrlSubmittedEvent += this.UrlInputFormSubmittedEventHandler;

            this.view.UrlSentEvent += this.UrlSentEventHandler;
        }

        /* ==================================
         * INTERNAL METHODS
         * ==================================*/

        /// <summary>
        /// Handles to user's request to test an URL
        /// Will validate said URL and update the view in consequence
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Contains the URL to test</param>
        public void UrlSentEventHandler(object sender, UrlSentEventArgs e)
        {
            if (HttpUriHelper.TryCreateHttpUri(e.Url, out Uri uri))
            {
                this.view.UpdateUrl(uri.AbsoluteUri);
                this.view.SetUrlFeedback("The URL has been sucessfully verified !");
            }
            else
            {
                this.view.SetUrlFeedback("Please input a valid URL.");
            }
        }

        /// <summary>
        /// Handles the submission of an URL by the user
        /// Will validate and sanitize said URL or prompt an error dialog
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Contains the URL to submit</param>
        public void UrlInputFormSubmittedEventHandler(object sender, UrlSentEventArgs e)
        {
            if (HttpUriHelper.TryCreateHttpUri(e.Url, out Uri uri))
            {
                this.UrlInputFormSubmittedEvent(this, new UrlSentEventArgs(uri));
            } else
            {
                this.view.ErrorDialog("The URL was incorrect. Please input a valid URL.");
            }
        }

        /* ==================================
         * INHERITED METHODS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Show()
        {
            this.view.Show();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="should"></param>
        public void ShouldBeEnabled(bool should)
        {
            throw new NotImplementedException();
        }

        /* ==================================
         * EVENTS
         * ==================================*/
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler ViewClosedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event UrlSentEvent UrlInputFormSubmittedEvent;
    }
}
