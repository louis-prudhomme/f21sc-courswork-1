using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using f21sc_courswork_1.Utils;
using f21sc_courswork_1.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Controller
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

        public MainController(IMainView view)
        {
            this.view = view;
            this.localHistory = new LocalHistory();
            this.globalHistory = new GlobalHistory();

            this.view.UrlQueriedEvent += this.UrlQueriedEventHandlerAsync;
            this.view.ReloadAskedEvent += this.ReloadQueriedEventHandler;

            this.view.DeleteAllHistoryEvent += this.DeleteAllHistoryEventHandler;

            this.view.BackwardAskedEvent += this.BackwardAskedEventHandlerAsync;
            this.view.ForwardAskedEvent += this.ForwardAskedEventHandlerAsync;

            this.view.MainFormClosedEvent += (o, i) => this.MainFormClosedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Adds a query to <see cref="localHistory"/> as well as <see cref="globalHistory"/>
        /// </summary>
        /// <param name="query">Query to add</param>
        private void AddToHistory(HttpQuery query)
        {
            // if the requested url is the same as the current one, do nothing history-wise
            if(this.localHistory.HasCurrent && this.localHistory.Current == query)
            {
                return;
            }

            this.localHistory.Add(query);
            this.globalHistory.Add(query);

            this.view.DisableForward();
            if (this.localHistory.Count == 2)
            {
                this.view.EnableBackward();
            }

            if (this.globalHistory.Count == 1)
            {
                this.view.EnableReload();
            }
        }

        /// <summary>
        /// Asks to load a page
        /// </summary>
        /// <param name="sender">Arguments containing the target URL</param>
        /// <param name="e">Empty</param>
        private async void UrlQueriedEventHandlerAsync(object sender, UrlQueriedEventArgs e)
        {
            HttpQuery query = HttpQueryHelper.Make(e.Url);

            this.AddToHistory(query);
            await Task.Factory.StartNew(() => this.LoadPageAsync(query));
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

            if (!this.localHistory.HasPrevious)
            {
                this.view.DisableBackward();
            }

            await Task.Factory.StartNew(() => this.LoadPageAsync(this.localHistory.Current));
            this.view.EnableForward();
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

            if (!this.localHistory.HasNext)
            {
                this.view.DisableForward();
            }

            await Task.Factory.StartNew(() => this.LoadPageAsync(this.localHistory.Current));
            this.view.EnableBackward();
        }

        /// <summary>
        /// Executes the provied <paramref name="query"/> and updates the view with the result.
        /// </summary>
        /// <param name="query"><see cref="HttpQuery"/> to execute</param>
        private async void LoadPageAsync(HttpQuery query)
        {
            this.view.UpdateUrl(query.Uri.ToString());

            this.view.UpdateRecent(this.globalHistory.LastFive());

            this.view.SetHttpAnswer(HttpAnswer.BlankAnswer());
            this.view.SetHttpAnswer(await HttpQueryHelper.ExecuteAsync(query));
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
            this.view.DisableReload();
        }

        /// <summary>
        /// Asks view to show the form
        /// </summary>
        public void Show()
        {
            this.view.Show();
        }
    }
}
