using f21sc_coursework_1.Utils.Http.Exceptions;
using System.Net;

namespace f21sc_coursework_1.Utils.Http
{
    class HttpStatusHelper
    {
        public const int FATAL_ERROR_CODE = -1;

        /// <summary>
        /// Maps a <see cref="HttpStatusCode> to the corresponding status
        /// </summary>
        /// <param name="code">HTTP status code</param>
        /// <returns>Matching HTTP status</returns>
        public static string HttpStatusOf(int code)
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
                case FATAL_ERROR_CODE:
                    return "Something wrong happened.";
                default:
                    throw new UnrecognizedHttpStatusCodeException(code);
            }
        }

        /// <summary>
        /// Maps a status code to the corresponding status
        /// </summary>
        /// <param name="code">HTTP status code</param>
        /// <returns>status</returns>
        public static string HttpStatusOf(HttpStatusCode code)
        {
            return HttpStatusOf((int)code);
        }

        /// <summary>
        /// Maps a <see cref="HttpStatusCode"/> to the corresponding code
        /// </summary>
        /// <param name="code">HTTP status code</param>
        /// <returns>Matching HTTP status</returns>
        public static int HttpCodeOf(HttpStatusCode code)
        {
            return (int)code;
        }

        /// <summary>
        /// Indicates whether the provided status code is an error code or not
        /// </summary>
        /// <param name="code">status to test</param>
        /// <returns>True if the code is equal to <see cref="FATAL_ERROR_CODE"/> or superior to 400</returns>
        public static bool IsAnErrorCode(int code)
        {
            return (int)code == FATAL_ERROR_CODE || (int)code >= 400;
        }
    }
}
