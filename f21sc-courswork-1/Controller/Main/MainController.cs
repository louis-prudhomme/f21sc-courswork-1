using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using f21sc_courswork_1.Utils;
using f21sc_courswork_1.View;
using System;
using System.Drawing.Text;
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

        private Uri homeUri;
        
        private readonly LocalHistory localHistory;
        private readonly GlobalHistory globalHistory;

        public event EventHandler MainFormClosedEvent;
        public event EventHandler HomeUrlInputAskedEvent;
        public event EventHandler HistoryPanelAskedEvent;
        public event EventHandler GlobalHistoryUpdatedEvent;

        public MainController(IMainView view, GlobalHistory globalHistory, Uri homeUri)
        {
            this.view = view;

            this.localHistory = new LocalHistory();
            this.globalHistory = globalHistory;
            this.homeUri = homeUri;

            this.view.UrlSentEvent += this.UrlQueriedEventHandlerAsync;
            this.view.ReloadAskedEvent += this.ReloadQueriedEventHandler;
            this.view.HomeAskedEvent += this.HomeAskedEventHandler;

            this.view.WipeHistoryEvent += this.WipeHistoryEventHandler;

            this.view.BackwardAskedEvent += this.BackwardAskedEventHandlerAsync;
            this.view.ForwardAskedEvent += this.ForwardAskedEventHandlerAsync;

            this.view.MainFormClosedEvent += (o, i) => this.MainFormClosedEvent(this, EventArgs.Empty);
            this.view.HomeUrlInputAskedEvent += (o, i) => this.HomeUrlInputAskedEvent(this, EventArgs.Empty);
            this.view.HistoryPanelAskedEvent += (o, i) => this.HistoryPanelAskedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Adds a query to <see cref="localHistory"/> as well as <see cref="globalHistory"/>
        /// </summary>
        /// <param name="query">Query to add</param>
        private void AddToHistory(HttpQuery query)
        {
            // if the requested url is the same as the current one, do nothing history-wise
            if (this.globalHistory.IsEmpty || this.globalHistory.Last.Uri != query.Uri)
            {
                this.globalHistory.Add(query);
                this.UpdateHistory();
            }
            if(!this.localHistory.HasCurrent || this.localHistory.Current.Uri != query.Uri)
            {
                this.localHistory.Add(query);
            }

        }

        /// <summary>
        /// Asks to load a page
        /// </summary>
        /// <param name="sender">Arguments containing the target URL</param>
        /// <param name="e">Empty</param>
        private async void UrlQueriedEventHandlerAsync(object sender, UrlSentEventArgs e)
        {
            if (HttpUriHelper.TryCreateHttpUri(e.Url, out Uri uri))
            {
                HttpQuery query = new HttpQuery(uri);

                this.AddToHistory(query);
                this.UpdateHistory();

                await Task.Factory.StartNew(() => this.LoadPageAsync(query));
            }
            else
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
            this.UpdateHistory();

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
            this.UpdateHistory();

            await Task.Factory.StartNew(() => this.LoadPageAsync(this.localHistory.Current));
        }

        /// <summary>
        /// Executes the provied <paramref name="query"/> and updates the view with the result.
        /// </summary>
        /// <param name="query"><see cref="HttpQuery"/> to execute</param>
        private async void LoadPageAsync(HttpQuery query)
        {
            this.view.SetCurrentState(HttpAnswer.MakeFetchingAnswer(), this.localHistory.CurrentNode);
            
            HttpAnswer answer;
            try
            {
                answer = await HttpQueryHelper.ExecuteAsync(query);
            } catch (HttpRequestException)
            {
                this.view.DisplayErrorDialog("Could not reach host " + query.Host);
                answer = HttpAnswer.MakeErrorAnswer();
            }

            query.Title = answer.Title;
            query.StatusCode = answer.StatusCode;
            this.view.SetCurrentState(answer, this.localHistory.CurrentNode);
        }

        /// <summary>
        /// Handles global history changes fallouts
        /// </summary>
        public void UpdateHistory()
        {
            this.view.UpdateRecent(this.globalHistory.LastFive());

            this.GlobalHistoryUpdatedEvent(this, EventArgs.Empty);
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
        private void WipeHistoryEventHandler(object sender, EventArgs e)
        {
            this.globalHistory.RemoveAll();

            this.UpdateHistory();
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

        public void UpdateHomeUri(Uri homeUri)
        {
            this.homeUri = homeUri;
        }

        private async void HomeAskedEventHandler(object sender, EventArgs e) 
        {
            await Task.Factory.StartNew(() => this.UrlQueriedEventHandlerAsync(sender, new UrlSentEventArgs(this.homeUri.AbsoluteUri)));
        }
    }
}
