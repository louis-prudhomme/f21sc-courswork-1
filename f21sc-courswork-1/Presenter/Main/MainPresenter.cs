using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using f21sc_coursework_1.Model;
using f21sc_coursework_1.Model.History;
using f21sc_coursework_1.Model.HttpCommunications;
using f21sc_coursework_1.Utils.Http;
using f21sc_coursework_1.View;
using f21sc_courswork_1.Model.Favorites.Exceptions;
using f21sc_courswork_1.Model.History.Exceptions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace f21sc_coursework_1.Presenter.Main
{
    /// <summary>
    /// Class to control the main view
    /// </summary>
    class MainPresenter : IMainPresenter
    {
        private readonly IMainView view;

        private readonly UserProfile user;

        private readonly LocalNavigation navigation;

        public MainPresenter(IMainView view, UserProfile user)
        {
            this.view = view;

            this.user = user;
            this.navigation = new LocalNavigation();

            this.view.UrlSentEvent += this.UrlQueriedEventHandlerAsync;
            this.view.ReloadAskedEvent += this.ReloadAskedEventHandler;
            this.view.HomeAskedEvent += this.HomeAskedEventHandler;

            this.view.RemoveFavEvent += this.RemoveFavEventHandler;
            this.view.WipeHistoryEvent += this.WipeHistoryEventHandler;

            this.view.BackwardAskedEvent += this.BackwardAskedEventHandlerAsync;
            this.view.ForwardAskedEvent += this.ForwardAskedEventHandlerAsync;

            if (this.user.HomePage != null)
            {
                this.HomeAskedEventHandler(this, EventArgs.Empty);
            }
            this.view.UpdateHomeUrl(this.user.HomePage != null);

            this.view.ViewClosedEvent += (s, e) => this.ViewClosedEvent(this, EventArgs.Empty);

            this.view.HomeUrlInputAskedEvent += (s, e) => this.HomeUrlInputAskedEvent(this, EventArgs.Empty);
            this.view.HistoryPanelAskedEvent += (s, e) => this.HistoryPanelAskedEvent(this, EventArgs.Empty);
            this.view.FavoritesPanelAskedEvent += (s, e) => this.FavoritesPanelAskedEvent(this, EventArgs.Empty);
            this.view.FavInputAskedEvent += (s, e) => this.FavInputAskedEvent(this, new FavInputAskedEventArgs(e, this.navigation.Current.Title));
        }

        /* ==================================
         * VIEW LISTENERS
         * ==================================*/

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

        /// <summary>
        /// Handler for when the forward button is pressed
        /// Loads the <see cref="HttpQuery"/> before the current one
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void BackwardAskedEventHandlerAsync(object sender, EventArgs e)
        {
            this.navigation.Backward();

            await Task.Factory.StartNew(() => this.UrlQueriedEventHandlerAsync(sender, new UrlSentEventArgs(this.navigation.Current.Uri.AbsoluteUri)));
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

            await Task.Factory.StartNew(() => this.UrlQueriedEventHandlerAsync(sender, 
                new UrlSentEventArgs(this.navigation.Current.Uri.AbsoluteUri)));
        }

        /// <summary>
        /// Handler for when the reload button is pressed
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void HomeAskedEventHandler(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => this.UrlQueriedEventHandlerAsync(sender,
                new UrlSentEventArgs(this.user.HomePage.AbsoluteUri)));
        }

        /// <summary>
        /// Asks to reload the page
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void ReloadAskedEventHandler(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() => this.UrlQueriedEventHandlerAsync(this,
                new UrlSentEventArgs(this.navigation.Current.Uri.AbsoluteUri)));
        }

        /// <summary>
        /// Asks to load a page
        /// Will sanitize the provided URI before calling the next method
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
                this.view.ErrorDialog("Invalid URL");
            }
        }

        /// <summary>
        /// Removes the current site from the favorites if it exists
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Contains the URI to remove</param>
        private void RemoveFavEventHandler(object sender, EventArgs e)
        {
            try
            {
                this.user.Favorites.Remove(this.user.Favorites.Find(this.navigation.Current.Uri));
                this.view.IsCurrentAFav(false);
                this.FavoritesUpdatedEvent(this, EventArgs.Empty);
            } catch (FavDoesntExistException)
            {
                this.view.ErrorDialog("This is not a favorite.");
            }
        }

        /* ==================================
         * INTERNAL METHODS
         * ==================================*/

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
                this.view.ErrorDialog("Could not reach host " + query.Host);
                answer = HttpAnswer.MakeErrorAnswer();
            }

            query.Title = answer.Title;
            query.StatusCode = answer.StatusCode;
            this.UpdateHistory();
            this.view.IsCurrentAFav(this.user.Favorites.Contains(query.Uri));
            this.view.SetCurrentState(answer, this.navigation.CurrentNode);
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
                try 
                { 
                    this.user.History.Add(query); 
                } catch (EntryAlreadyExistsException)
                {
                    this.view.ErrorDialog("A problem occured. It should not have happened.");
                    this.ViewClosedEvent(this, EventArgs.Empty);
                }
            }
            if (!this.navigation.HasCurrent || this.navigation.Current.Uri != query.Uri)
            {
                this.navigation.Add(query);
            }
        }

        /* ==================================
         * INHERITED METHODS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void UpdateHistory()
        {
            this.view.UpdateRecent(this.user.History.LastFive());

            this.GlobalHistoryUpdatedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void UpdateFavorites()
        {
            this.view.IsCurrentAFav(this.user.Favorites.Contains(this.navigation.Current.Uri));
        }

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
        public void ShouldBeEnabled(bool should)
        {
            this.view.ShouldBeEnabled(should);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="error"></param>
        public void ErrorDialog(string error)
        {
            this.view.ErrorDialog(error);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void InitiateJump(Uri target)
        {
            Task.Factory.StartNew(() => this.UrlQueriedEventHandlerAsync(this,
                new UrlSentEventArgs(target.AbsoluteUri)));
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void UpdateHomeUrl()
        {
            this.view.UpdateHomeUrl(this.user.HomePage != null);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Close()
        {
            this.view.Close();
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
        public event EventHandler GlobalHistoryUpdatedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler FavoritesUpdatedEvent;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HomeUrlInputAskedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler HistoryPanelAskedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler FavoritesPanelAskedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event FavInputAskedEvent FavInputAskedEvent;
    }
}
