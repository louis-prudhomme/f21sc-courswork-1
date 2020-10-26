using f21sc_coursework_1.Events.Favorites;
using System;

namespace f21sc_coursework_1.Controller.InputFavInfos
{
    interface IInputFavInfosController
    {
        /// <summary>
        /// Event raised when the form has been closed without any <see cref="Fav"/> submitted
        /// </summary>
        event EventHandler FavInputCanceledEvent;
        /// <summary>
        /// Event raised when the form was closed with a <see cref="Fav"/> submitted
        /// </summary>
        event EventHandler FavInputSubmittedEvent;

        /// <summary>
        /// Orders the controller to show the view
        /// </summary>
        void Show();
    }
}
