using f21sc_coursework_1.Event;
using f21sc_coursework_1.Events.Favorites;
using f21sc_coursework_1.Model;
using f21sc_coursework_1.Model.History;
using f21sc_coursework_1.Model.HttpCommunications;
using f21sc_coursework_1.Utils.Http;
using f21sc_coursework_1.View;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace f21sc_coursework_1.Controller.Main
{
    /// <summary>
    /// Class to control the main view
    /// </summary>
    class MainController : IMainController
    {
        private readonly IMainView view;

        private UserProfile user;

        private readonly LocalNavigation navigation;

        public event EventHandler MainFormClosedEvent;

        public event EventHandler GlobalHistoryUpdatedEvent;
        public event EventHandler FavoritesUpdatedEvent;

        public event EventHandler HomeUrlInputAskedEvent;
        public event EventHandler HistoryPanelAskedEvent;
        public event EventHandler FavoritesPanelAskedEvent;

        public MainController(IMainView view, UserProfile user)
        {
            this.view = view;

            this.user = user;
            this.navigation = new LocalNavigation();

            this.view.UrlSentEvent += this.UrlQueriedEventHandlerAsync;
            this.view.ReloadAskedEvent += this.ReloadQueriedEventHandler;
            this.view.HomeAskedEvent += this.HomeAskedEventHandler;

            this.view.WipeHistoryEvent += this.WipeHistoryEventHandler;

            this.view.BackwardAskedEvent += this.BackwardAskedEventHandlerAsync;
            this.view.ForwardAskedEvent += this.ForwardAskedEventHandlerAsync;

            this.view.FavAddedEvent += this.FavAddedEventHandler;
            this.view.FavRemovedEvent += this.FavRemovedEventHandler;

            this.HomeAskedEventHandler(this, EventArgs.Empty);

            this.view.MainFormClosedEvent += (s, e) => this.MainFormClosedEvent(this, EventArgs.Empty);

            this.view.HomeUrlInputAskedEvent += (s, e) => this.HomeUrlInputAskedEvent(this, EventArgs.Empty);
            this.view.HistoryPanelAskedEvent += (s, e) => this.HistoryPanelAskedEvent(this, EventArgs.Empty);
            this.view.FavoritesPanelAskedEvent += (s, e) => this.FavoritesPanelAskedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Adds a query to <see cref="navigation"/> as well as <see cref="globalHistory"/>
        /// </summary>
        /// <param name="query">Query to add</param>
        private void AddToHistory(HttpQuery query)
        {
            // if the requested url is the same as the current one, do nothing history-wise
            if (this.user.History.IsEmpty || this.user.History.Last.Uri != query.Uri)
            {
                this.user.History.Add(query);
            }
            if (!this.navigation.HasCurrent || this.navigation.Current.Uri != query.Uri)
            {
                this.navigation.Add(query);
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
            this.navigation.Backward();

            await Task.Factory.StartNew(() => this.LoadPageAsync(this.navigation.Current));
        }

        /// <summary>
        /// Handler for when the forward button is pressed
        /// Loads the <see cref="HttpQuery"/> after the current one 
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void ForwardAskedEventHandlerAsync(object sender, EventArgs e)
        {
            this.navigation.Forward();

            await Task.Factory.StartNew(() => this.LoadPageAsync(this.navigation.Current));
        }

        /// <summary>
        /// Executes the provied <paramref name="query"/> and updates the view with the result.
        /// </summary>
        /// <param name="query"><see cref="HttpQuery"/> to execute</param>
        private async void LoadPageAsync(HttpQuery query)
        {
            this.view.SetCurrentState(HttpAnswer.MakeFetchingAnswer(), this.navigation.CurrentNode);

            HttpAnswer answer;
            try
            {
                answer = await HttpQueryHelper.ExecuteAsync(query);
            }
            catch (HttpRequestException)
            {
                this.view.DisplayErrorDialog("Could not reach host " + query.Host);
                answer = HttpAnswer.MakeErrorAnswer();
            }

            query.Title = answer.Title;
            query.StatusCode = answer.StatusCode;
            this.UpdateHistory();
            this.view.IsCurrentAFav(this.user.Favorites.Contains(query.Uri));
            this.view.SetCurrentState(answer, this.navigation.CurrentNode);
        }

        /// <summary>
        /// Handles global history changes fallouts
        /// </summary>
        public void UpdateHistory()
        {
            this.view.UpdateRecent(this.user.History.LastFive());

            this.GlobalHistoryUpdatedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Asks to reload the page
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void ReloadQueriedEventHandler(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => this.LoadPageAsync(this.navigation.Current));
        }

        /// <summary>
        /// Asks for complete wipe of <see cref="GlobalHistory"/>
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private void WipeHistoryEventHandler(object sender, EventArgs e)
        {
            this.user.History.RemoveAll();

            this.UpdateHistory();
        }

        private void FavAddedEventHandler(object sender, FavAddedEventArgs e)
        {
            this.user.Favorites.Add(e.Fav);
            this.FavoritesUpdatedEvent(this, EventArgs.Empty);
            this.view.IsCurrentAFav(this.user.Favorites.Contains(this.navigation.Current.Uri));
        }

        private void FavRemovedEventHandler(object sender, FavRemovedEventArgs e)
        {
            this.user.Favorites.Remove(this.user.Favorites.Find(e.Uri));
            this.FavoritesUpdatedEvent(this, EventArgs.Empty);
            this.view.IsCurrentAFav(this.user.Favorites.Contains(this.navigation.Current.Uri));
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
            this.user.HomePage = homeUri;
        }

        private async void HomeAskedEventHandler(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => this.UrlQueriedEventHandlerAsync(sender, new UrlSentEventArgs(this.user.HomePage.AbsoluteUri)));
        }
    }
}
