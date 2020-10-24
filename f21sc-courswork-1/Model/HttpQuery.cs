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
    public class HttpQuery
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

        public long TimestampIssuedAt => IssuedAt.Ticks;
        
        public HttpQuery(Uri uri) 
        {
            this.IssuedAt = DateTime.Now;
            this.Uri = uri;
        }
    }
}
