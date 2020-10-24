using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using f21sc_courswork_1.Utils;
using f21sc_courswork_1.View;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Controller.Main
{
    /// <summary>
    /// Class to control the main view
    /// </summary>
    class MainController : IMainController
    {
        private readonly IMainView view;
        
        private readonly LocalHistory localHistory;
        private readonly GlobalHistory globalHistory;

        public event EventHandler MainFormClosedEvent;
        public event EventHandler HomeUrlInputAskedEvent;

        public MainController(IMainView view)
        {
            this.view = view;
            this.localHistory = new LocalHistory();
            this.globalHistory = new GlobalHistory();

            this.view.UrlSentEvent += this.UrlQueriedEventHandlerAsync;
            this.view.ReloadAskedEvent += this.ReloadQueriedEventHandler;

            this.view.DeleteAllHistoryEvent += this.DeleteAllHistoryEventHandler;

            this.view.BackwardAskedEvent += this.BackwardAskedEventHandlerAsync;
            this.view.ForwardAskedEvent += this.ForwardAskedEventHandlerAsync;

            this.view.MainFormClosedEvent += (o, i) => this.MainFormClosedEvent(this, EventArgs.Empty);
            this.view.HomeUrlInputAskedEvent += (o, i) => this.HomeUrlInputAskedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Adds a query to <see cref="localHistory"/> as well as <see cref="globalHistory"/>
        /// </summary>
        /// <param name="query">Query to add</param>
        private void AddToHistory(HttpQuery query)
        {
            // if the requested url is the same as the current one, do nothing history-wise
            if(this.localHistory.HasCurrent && this.localHistory.Current.Uri == query.Uri)
            {
                return;
            }

            this.localHistory.Add(query);
            this.globalHistory.Add(query);

            this.HistoryFallouts();
        }

        /// <summary>
        /// Asks to load a page
        /// </summary>
        /// <param name="sender">Arguments containing the target URL</param>
        /// <param name="e">Empty</param>
        private async void UrlQueriedEventHandlerAsync(object sender, UrlSentEventArgs e)
        {
            Uri uri;
            if (HttpUriHelper.TryCreateHttpUri(e.Url, out uri))
            {
                HttpQuery query = new HttpQuery(uri);

                this.AddToHistory(query);
                this.HistoryFallouts();

                await Task.Factory.StartNew(() => this.LoadPageAsync(query));
            } else
            {
                this.view.DisplayErrorDialog("Invalid URL");
            }
        }

        /// <summary>
        /// Handler for when the forward button is pressed
        /// Loads the <see cref="HttpQuery"/> before the current one
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void BackwardAskedEventHandlerAsync(object sender, EventArgs e)
        {
            this.localHistory.Backward();
            this.HistoryFallouts();

            await Task.Factory.StartNew(() => this.LoadPageAsync(this.localHistory.Current));
        }

        /// <summary>
        /// Handler for when the forward button is pressed
        /// Loads the <see cref="HttpQuery"/> after the current one 
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void ForwardAskedEventHandlerAsync(object sender, EventArgs e)
        {
            this.localHistory.Forward();
            this.HistoryFallouts();

            await Task.Factory.StartNew(() => this.LoadPageAsync(this.localHistory.Current));
        }

        /// <summary>
        /// Handles history changes fallouts
        /// </summary>
        private void HistoryFallouts()
        {
            this.view.ShouldEnableBackward(this.localHistory.HasPrevious);
            this.view.ShouldEnableForward(this.localHistory.HasNext);
            this.view.ShouldEnableReload(this.localHistory.HasCurrent);
            this.view.ShouldEnableRecent(!this.localHistory.IsEmpty);

            if (!this.localHistory.IsEmpty)
            {
                this.view.UpdateRecent(this.globalHistory.LastFive());
            }
        }

        /// <summary>
        /// Executes the provied <paramref name="query"/> and updates the view with the result.
        /// </summary>
        /// <param name="query"><see cref="HttpQuery"/> to execute</param>
        private async void LoadPageAsync(HttpQuery query)
        {
            this.view.UpdateUrl(query.Uri.ToString());

            this.view.SetHttpAnswer(HttpAnswer.FetchingAnswer());
            try
            {
                this.view.SetHttpAnswer(await HttpQueryHelper.ExecuteAsync(query));
            } catch (HttpRequestException)
            {
                this.view.DisplayErrorDialog("Could not reach host " + query.Host);
                this.view.SetHttpAnswer(HttpAnswer.ErrorAnswer());
            }
        }

        /// <summary>
        /// Asks to reload the page
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void ReloadQueriedEventHandler(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => this.LoadPageAsync(this.localHistory.Current));
        }

        /// <summary>
        /// Asks for complete wipe of <see cref="GlobalHistory"/>
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private void DeleteAllHistoryEventHandler(object sender, EventArgs e)
        {
            this.globalHistory.RemoveAll();
            this.localHistory.RemoveAll();

            this.HistoryFallouts();
        }

        /// <summary>
        /// Asks view to show the form
        /// </summary>
        public void Show()
        {
            this.view.Show();
        }

        /// <summary>
        /// Blocks or unblocks the view
        /// </summary>
        /// <param name="should"></param>
        public void ShouldBeEnabled(bool should)
        {
            this.view.ShouldBeEnabled(should);
        }
    }
}
