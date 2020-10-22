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


        public HttpAnswer(string html, int code)
        {
            Html = html;
            this.Code = code;
        }

        public HttpAnswer(string html, HttpStatusCode code)
        {
            Html = html;
            this.Code = HttpStatusHelper.HttpCode(code);
        }

        public static HttpAnswer BlankAnswer()
        {
            return new HttpAnswer("Fetching…", 0);
        }
    }
}
