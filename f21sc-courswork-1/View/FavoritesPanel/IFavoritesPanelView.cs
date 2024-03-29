﻿using f21sc_coursework_1.Events.Favorites;
using f21sc_courswork_1.Events;
using f21sc_courswork_1.Model.Favorites;
using f21sc_courswork_1.View;
using System;
using System.Collections.Generic;

namespace f21sc_coursework_1.View.FavoritesPanel
{
    interface IFavoritesPanelView : IView
    {
        /// <summary>
        /// Raised when the view is closed
        /// </summary>
        event JumpAskedEvent JumpAskedEvent;
        /// <summary>
        /// Raised when user asks for the deletion of one or more favorites
        /// </summary>
        event FavoritesDeletedEvent FavoritesDeletedEvent;
        /// <summary>
        /// Raised when user asks for the modification of a favorite
        /// </summary>
        event FavoriteModifiedEvent FavoriteModifiedEvent;

        /// <summary>
        /// Updates the view's list of <see cref="Fav"/>
        /// </summary>
        /// <param name="favorites">New list to display</param>
        void UpdateFavoriteItems(List<Fav> favorites);
    }
}
