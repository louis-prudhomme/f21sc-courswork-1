using f21sc_courswork_1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model
{
    public class HttpAnswer
    {
        public int Code { get; }
        public string Status => HttpStatusHelper.HttpStatus(this.Code);
        public string Html { get; }

        public string Title { get; }

        public HttpAnswer(string html, string title, HttpStatusCode code)
        {
            Html = html.Length == 0 ? "<No HTML>" : html;
            Title = title.Length == 0 ? "Empty page" : title;
            this.Code = HttpStatusHelper.HttpCode(code);
        }

        /// <summary>
        /// Constructs a blank answer for feedback purposes
        /// </summary>
        /// <returns></returns>
        public static HttpAnswer BlankAnswer()
        {
            return new HttpAnswer("Fetching…", "Fetching…", 0);
        }
    }
}
