using System;
using System.Linq;

namespace f21sc_courswork_1.Utils.Http
{
    class HttpUriHelper
    {
        /// <summary>
        /// If an URI is considered incorrect by <see cref="Uri.IsWellFormedUriString(string, UriKind)"/>, tries to append http:// or www. to it
        /// </summary>
        /// <param name="uri">URI to check</param>
        /// <returns>Return the URI or a correct version of it</returns>
        public static bool TryCreateHttpUri(string uri, out Uri result)
        {
            if (!uri.Contains('.'))
            {
                result = null;
                return false;
            }

            if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                result = new Uri(uri);
                return IsHttpUri(result);
            }

            if (!uri.StartsWith("http://") && !uri.StartsWith("https://"))
            {
                if (!uri.StartsWith("www."))
                {
                    uri = "www." + uri;
                }
                uri = "http://" + uri;

                return TryCreateHttpUri(uri, out result) && IsHttpUri(result);
            }

            result = null;
            return false;
        }

        /// <summary>
        /// Checks if an URL a validly formed
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static bool IsHttpUri(Uri uri)
        {
            return uri.Scheme.Equals("http") || uri.Scheme.Equals("https");
        }

        /// <summary>
        /// Returns true if the provided string make a good <see cref="Uri"/>
        /// </summary>
        /// <param name="uri">String to check</param>
        /// <returns>True if <paramref name="uri"/>is a good <see cref="Uri"/></returns>
        public static bool IsValidHttpUri(string uri)
        {
            return TryCreateHttpUri(uri, out _);
        }
    }
}
