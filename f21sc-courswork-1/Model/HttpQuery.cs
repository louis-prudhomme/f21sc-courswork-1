using f21sc_courswork_1.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Model
{
    /// <summary>
    /// This class represents a user-issued HTTP request
    /// </summary>
    [Serializable]
    class HttpQuery
    {
        /// <summary>
        /// URL the user wants to access
        /// </summary>
        public Uri Uri { get; }
        public string Host => Uri.Host;
        public string Protocol => Uri.Scheme;
        /// <summary>
        /// Time at which the request was issued
        /// </summary>
        public DateTime IssuedAt { get; }

        public int TimestampIssuedAt => TimeHelper.DateTimeToTimestamp(IssuedAt);
        
        public HttpQuery(string targetUrl) 
        {
            IssuedAt = DateTime.Now;
            Uri = CreateUriSafe(targetUrl);
        }

        private Uri CreateUriSafe(string targetUrl)
        {
            return this.CheckUri(targetUrl);
        }

        /// <summary>
        /// If an URI is considered incorrect by <see cref="Uri.IsWellFormedUriString(string, UriKind)"/>, tries to append http:// or www. to it
        /// </summary>
        /// <param name="uri">URI to check</param>
        /// <returns>Return the URI or a correct version of it</returns>
        private Uri CheckUri(string uri)
        {
            if(!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                if (!uri.StartsWith("http://") && !uri.StartsWith("https://"))
                {
                    if (!uri.StartsWith("www."))
                    {
                        return this.CheckUri("www." + uri);
                    }
                    return this.CheckUri("http://" + uri);
                }
            }
            return new Uri(uri);
        }
    }
}
