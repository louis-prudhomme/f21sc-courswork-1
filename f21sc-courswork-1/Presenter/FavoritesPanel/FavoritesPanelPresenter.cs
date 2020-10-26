using f21sc_coursework_1.Events.Favorites;
using f21sc_coursework_1.View.FavoritesPanel;
using f21sc_courswork_1.Events;
using f21sc_courswork_1.Model.Favorites;
using f21sc_courswork_1.Model.Favorites.Exceptions;
using System;

namespace f21sc_coursework_1.Presenter.FavoritesPanel
{
    /// <summary>
    /// Presenter handling <see cref="IFavoritesPanelPresenter"/>
    /// </summary>
    class FavoritesPanelPresenter : IFavoritesPanelPresenter
    {
        private readonly FavoritesRepository favorites;
        private readonly IFavoritesPanelView view;

        public FavoritesPanelPresenter(IFavoritesPanelView view, FavoritesRepository favorites)
        {
            this.view = view;
            this.favorites = favorites;

            this.view.UpdateFavoriteItems(favorites.ToList());
            this.view.FavoritesDeletedEvent += this.FavoritesDeletedEventHandler;

            this.view.FavoriteModifiedEvent += (s, e) => this.FavoriteModifiedEvent(this, e);
            this.view.ViewClosedEvent += (s, e) => this.ViewClosedEvent(this, EventArgs.Empty);
            this.view.JumpAskedEvent += (s, e) => this.JumpAskedEvent(this, e);
        }

        /// <summary>
        /// Handles user demand of favorites deletion by deleting the <see cref="Fav"/> and updating the view
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Contains the <see cref="Fav"/> to delete</param>
        private void FavoritesDeletedEventHandler(object sender, FavoritesDeletedEventArgs e)
        {
            try
            {
                e.DeletedFavorites.ForEach(favToDel => this.favorites.Remove(favToDel));
                this.view.UpdateFavoriteItems(this.favorites.ToList());
            } catch (FavDoesntExistException)
            {
                this.view.ErrorDialog("A problem occured.");
                this.view.Close();
            } finally
            {
                // some favorites might have been deleted before the exception
                this.FavoritesUpdatedEvent(this, EventArgs.Empty);
            }
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
        public void UpdateFavorites()
        {
            this.view.UpdateFavoriteItems(this.favorites.ToList());
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="should"></param>
        public void ShouldBeEnabled(bool should)
        {
            this.view.ShouldBeEnabled(should);
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
        public event FavoriteModifiedEvent FavoriteModifiedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event EventHandler FavoritesUpdatedEvent;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public event JumpAskedEvent JumpAskedEvent;
    }
}
