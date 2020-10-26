using f21sc_coursework_1.Events.Favorites;
using f21sc_courswork_1.Presenter;
using System;

namespace f21sc_coursework_1.Presenter.InputFavInfos
{
    interface IInputFavInfosPresenter : IPresenter
    {
        /// <summary>
        /// Event raised when the form was closed with a <see cref="Fav"/> submitted
        /// </summary>
        event EventHandler FavInputSubmittedEvent;
    }
}
