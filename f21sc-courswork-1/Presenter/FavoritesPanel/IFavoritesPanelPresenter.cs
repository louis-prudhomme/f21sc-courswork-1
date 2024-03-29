﻿using f21sc_coursework_1.Events.Favorites;
using f21sc_courswork_1.Presenter;
using f21sc_courswork_1.Events;
using System;

namespace f21sc_coursework_1.Presenter.FavoritesPanel
{
    interface IFavoritesPanelPresenter : IPresenter
    {
        /// <summary>
        /// Raised when the user asks for the modification of one favorite
        /// </summary>
        event FavoriteModifiedEvent FavoriteModifiedEvent;
        /// <summary>
        /// Raised when the favorites are updated by the panel
        /// </summary>
        event EventHandler FavoritesUpdatedEvent;
        /// <summary>
        /// Raised when the user asks to jump to a specific page
        /// </summary>
        event JumpAskedEvent JumpAskedEvent;

        /// <summary>
        /// Order the presenter to update its favorites
        /// </summary>
        void UpdateFavorites();
    }
}
