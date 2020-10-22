using f21sc_courswork_1.Event;
using f21sc_courswork_1.Model;
using f21sc_courswork_1.Utils;
using f21sc_courswork_1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Controller
{
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
            this.view.MainFormClosedEvent += (o, i) => this.MainFormClosedEvent(this, EventArgs.Empty);
        }

        private async void UrlQueriedEventHandler(object sender, UrlQueriedEventArgs e)
        {
            this.globalHistory.Add(HttpQueryHelper.Make(e.Url));

            this.view.SetHttpAnswer(HttpAnswer.BlankAnswer());

            this.view.SetHttpAnswer(await HttpQueryHelper.ExecuteAsync(this.globalHistory.Last()));
        }

        public void Show()
        {
            this.view.Show();
        }
    }
}
