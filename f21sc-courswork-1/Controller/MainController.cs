using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using f21sc_courswork_1.Utils;
using f21sc_courswork_1.View;
using System;

namespace f21sc_courswork_1.Controller
{
    /// <summary>
    /// Class to control the main view
    /// </summary>
    class MainController : IMainController
    {
        private IMainView view;
        private UserHistory globalHistory;

        public event EventHandler MainFormClosedEvent;

        public MainController(IMainView view)
        {
            this.view = view;
            this.globalHistory = new UserHistory();

            this.view.UrlQueriedEvent += this.UrlQueriedEventHandler;
            this.view.ReloadAskedEvent += this.ReloadQueriedEventHandler;
            this.view.DeleteAllHistoryEvent += this.DeleteAllHistoryEventHandler;
            this.view.MainFormClosedEvent += (o, i) => this.MainFormClosedEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// Asks to load a page
        /// </summary>
        /// <param name="sender">Arguments containing the target URL</param>
        /// <param name="e">Empty</param>
        private async void UrlQueriedEventHandler(object sender, UrlQueriedEventArgs e)
        {
            bool wasHistoryEmpty = this.globalHistory.Empty();
            this.globalHistory.Add(HttpQueryHelper.Make(e.Url));
            this.view.UpdateUrl(this.globalHistory.Last().Uri.ToString());

            if (wasHistoryEmpty && this.globalHistory.Count() == 1)
            {
                this.view.EnableReload();
            }

            this.view.SetHttpAnswer(HttpAnswer.BlankAnswer());
            this.view.SetHttpAnswer(await HttpQueryHelper.ExecuteAsync(this.globalHistory.Last()));
        }

        /// <summary>
        /// Asks to reload the page
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private async void ReloadQueriedEventHandler(object sender, EventArgs e)
        {
            this.view.SetHttpAnswer(HttpAnswer.BlankAnswer());
            this.view.SetHttpAnswer(await HttpQueryHelper.ExecuteAsync(this.globalHistory.Last()));
        }

        /// <summary>
        /// Asks for complete wipe of <see cref="UserHistory"/>
        /// </summary>
        /// <param name="sender">Not important</param>
        /// <param name="e">Empty</param>
        private void DeleteAllHistoryEventHandler(object sender, EventArgs e)
        {
            this.globalHistory.RemoveAll();
            this.view.DisableReload();
        }

        /// <summary>
        /// Asks view to show the form
        /// </summary>
        public void Show()
        {
            this.view.Show();
        }
    }
}
