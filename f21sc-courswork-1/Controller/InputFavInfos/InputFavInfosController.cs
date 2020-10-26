using f21sc_coursework_1.Events;
using f21sc_coursework_1.Events.Favorites;
using f21sc_coursework_1.Utils.Http;
using f21sc_courswork_1.Model.Favorites;
using f21sc_courswork_1.Model.Favorites.Exceptions;
using f21sc_courswork_1.View.InputFavInfos;
using System;
using System.Windows.Forms;

namespace f21sc_coursework_1.Controller.InputFavInfos
{
    /// <summary>
    /// Controller for the <see cref="IInputFavInfosView"/>
    /// </summary>
    class InputFavInfosController : IInputFavInfosController
    {
        private readonly InputFavMode mode;
        private readonly IInputFavInfosView view;
        private readonly FavoritesRepository favorites;

        private readonly Fav toEdit;

        public InputFavInfosController(IInputFavInfosView view, FavoritesRepository favorites, FavInputAskedEventArgs e)
        {
            this.view = view;
            this.favorites = favorites;

            this.mode = InputFavMode.CREATION;
            this.FinishSetup(e.Name, e.Url);
        }

        public InputFavInfosController(IInputFavInfosView view, FavoritesRepository favorites, FavoriteModifiedEventArgs e)
        {
            this.view = view;
            this.favorites = favorites;

            this.mode = InputFavMode.MODIFICATION;
            this.toEdit = e.Modified;
            this.FinishSetup(e.Modified.Name, e.Modified.Uri.AbsoluteUri);
        }

        /* ==================================
         * INTERNAL METHODS
         * ==================================*/

        /// <summary>
        /// Finishes the setup of the controller, regardless of the mode
        /// </summary>
        /// <param name="presetName">Preset name of the event</param>
        /// <param name="presetUrl">Preset URL of the event</param>
        private void FinishSetup(string presetName, string presetUrl)
        {
            this.view.ViewClosedEvent += this.ViewClosedEventHandler;
            this.view.FavInputSubmittedEvent += this.FavInputSubmittedEventHandler;

            this.view.UrlSentEvent += this.UrlSentEventHandler;

            this.view.PresetFav(presetName, presetUrl);
            this.UrlSentEventHandler(this, new UrlSentEventArgs(presetUrl));
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
        public void FavInputSubmittedEventHandler(object sender, FavSubmittedEventArgs e)
        {
            if (HttpUriHelper.TryCreateHttpUri(e.Uri, out Uri uri))
            {
                try
                {
                    if (this.mode == InputFavMode.MODIFICATION)
                    {
                        this.favorites.Remove(this.toEdit);
                    }
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
        public void ViewClosedEventHandler(object sender, EventArgs e)
        {
            this.ViewClosedEvent(this, EventArgs.Empty);
        }

        /* ==================================
         * INHERITED METHODS
         * ==================================*/

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="error"></param>
        public void ErrorDialog(string error)
        {
            MessageBox.Show(error,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void ShouldBeEnabled(bool should)
        {
            throw new NotImplementedException();
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
        public void Close()
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
        public event EventHandler FavInputSubmittedEvent;
    }

    enum InputFavMode
    {
        MODIFICATION,
        CREATION,
    }
}
