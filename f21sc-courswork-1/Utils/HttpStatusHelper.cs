using f21sc_courswork_1.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Utils
{
    class HttpStatusHelper
    {
        /// <summary>
        /// Maps a HTTP status code to the corresponding status
        /// </summary>
        /// <param name="code">HTTP status code</param>
        /// <returns>Matching HTTP status</returns>
        public static string HttpStatus(int code)
        {
            switch (code)
            {
                case 200:
                    return "OK";
                case 400:
                    return "Bad request";
                case 403:
                    return "Forbidden";
                case 404:
                    return "Not found";
                case 418:
                    return "I’m a teapot";
                case 0:
                    return "Fetching…";
                default:
                    throw new UnrecognizedHttpStatusCodeException(code);
            }
        }

        /// <summary>
        /// Maps a HTTP status code to the corresponding status
        /// </summary>
        /// <param name="code">HTTP status code</param>
        /// <returns>Matching HTTP status</returns>
        public static string HttpStatus(HttpStatusCode code)
        {
            return HttpStatus((int)code);
        }

        /// <summary>
        /// Maps a HTTP status code to the corresponding code
        /// </summary>
        /// <param name="code">HTTP status code</param>
        /// <returns>Matching HTTP status</returns>
        public static int HttpCode(HttpStatusCode code)
        {
            return (int)code;
        }
    }
}
