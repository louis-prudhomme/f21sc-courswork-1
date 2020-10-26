﻿using f21sc_coursework_1.Events.Favorites;
using f21sc_courswork_1.Controller;
using System;

namespace f21sc_coursework_1.Controller.InputFavInfos
{
    interface IInputFavInfosController : IController
    {
        /// <summary>
        /// Event raised when the form was closed with a <see cref="Fav"/> submitted
        /// </summary>
        event EventHandler FavInputSubmittedEvent;
    }
}
