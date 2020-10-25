using f21sc_coursework_1.Utils.Http;
using System.Net;

namespace f21sc_coursework_1.Model.HttpCommunications
{
    public class HttpAnswer
    {

        /// <summary>
        /// <see cref="int"/> representation of the response <see cref="HttpStatusCode"/>
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// <see cref="string"/> representation of the response <see cref="HttpStatusCode"/>
        /// </summary>
        public string Status => HttpStatusHelper.HttpStatusOf(this.StatusCode);

        /// <summary>
        /// HTML of the page
        /// </summary>
        public string Html { get; }

        /// <summary>
        /// Title of the HTML page if it exists
        /// </summary>
        public string Title { get; }

        public HttpAnswer(string html, string title, int code)
        {
            this.Html = html.Length == 0 ? "<No HTML>" : html;
            this.Title = title.Length == 0 ? "Empty page" : title;
            this.StatusCode = code;
        }

        public HttpAnswer(string html, string title, HttpStatusCode code)
        {
            this.Html = html.Length == 0 ? "<No HTML>" : html;
            this.Title = title.Length == 0 ? "Empty page" : title;
            this.StatusCode = (int)code;
        }

        /// <summary>
        /// Constructs a fetching <see cref="HttpAnswer"/> for feedback purposes
        /// </summary>
        /// <returns></returns>
        public static HttpAnswer MakeFetchingAnswer()
        {
            return new HttpAnswer("Fetching…", "Fetching…", 0);
        }

        /// <summary>
        /// Constructs an error <see cref="HttpAnswer"/> for feedback purposes
        /// </summary>
        /// <returns></returns>
        public static HttpAnswer MakeErrorAnswer()
        {
            return new HttpAnswer("A problem occured", "Could not reach host", -1);
        }
    }
}
