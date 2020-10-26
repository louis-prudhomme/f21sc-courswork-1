using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using f21sc_coursework_1.Utils.Http;
using f21sc_courswork_1.Model.Favorites;
using f21sc_courswork_1.Model.Favorites.Exceptions;
using f21sc_courswork_1.View.InputFavInfos;
using System;

namespace f21sc_coursework_1.Controller.InputFavInfos
{
    /// <summary>
    /// Controller for the <see cref="IInputFavInfosView"/>
    /// </summary>
    class InputFavInfosController : IInputFavInfosController
    {
        private readonly IInputFavInfosView view;
        private readonly FavoritesRepository favorites;

        public InputFavInfosController(IInputFavInfosView view, FavoritesRepository favorites, FavInputAskedEventArgs e)
        {
            this.view = view;
            this.favorites = favorites;

            this.view.FavInputCancelledEvent += this.FavInputCancelledEventHandler;
            this.view.FavInputSubmittedEvent += this.FavInputSubmittedEventHandler;

            this.view.PresetFav(e.Name, e.Url);
            this.UrlSentEventHandler(this, new UrlSentEventArgs(e.Url));
            this.view.UrlSentEvent += this.UrlSentEventHandler;
        }

        /// <summary>
        /// Tests the provided URL and either enables the submission controls or orders to prompt an error
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Contains the URL to validate</param>
        public void UrlSentEventHandler(object sender, UrlSentEventArgs e)
        {
            if (HttpUriHelper.TryCreateHttpUri(e.Url, out Uri uri))
            {
                this.view.UpdateUrl(uri.AbsoluteUri);
            }
            else
            {
                this.view.ErrorDialog("Please input a valid URL.");
            }
        }

        /// <summary>
        /// Validates the URL one last time, checks if the submitted <see cref="Fav"/> already exists in the repository
        /// Then raises a <see cref="FavInputSubmittedEvent"/>
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Contains the <see cref="Fav"/> to add</param>
        public void FavInputSubmittedEventHandler(object sender, FavAddedEventArgs e)
        {
            if (HttpUriHelper.TryCreateHttpUri(e.Uri, out Uri uri))
            {
                try
                {
                    this.favorites.Add(new Fav(uri, e.Name));
                    this.FavInputSubmittedEvent(this, EventArgs.Empty);
                    this.view.Close();
                } catch (FavAlreadyExistsException)
                {
                    this.view.ErrorDialog("There is already a favorite with these name and URL.");
                }
            }
            else
            {
                this.view.ErrorDialog("Please input a valid URL.");
            }
        }

        /// <summary>
        /// Informs the controller of its closure
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        public void FavInputCancelledEventHandler(object sender, EventArgs e)
        {
            this.FavInputCanceledEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Show()
        {
            this.view.Show();
        }

        /* ==================================
         * EVENTS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler FavInputCanceledEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler FavInputSubmittedEvent;
    }
}
