using f21sc_coursework_1.Utils.Http;
using System;

namespace f21sc_coursework_1.Model.HttpCommunications
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

        /// <summary>
        /// Host targeted by the <see cref="HttpQuery"/>
        /// </summary>
        public string Host => Uri.Host;

        /// <summary>
        /// Protocol of the <see cref="HttpQuery"/>
        /// </summary>
        public string Protocol => Uri.Scheme;

        private int statusCode;
        /// <summary>
        /// If the <see cref="StatusCode"/> for this <see cref="HttpQuery"/> is an error one, the title will be the HTTP status
        /// </summary>
        public int StatusCode
        {
            get => this.statusCode;
            set
            {
                this.statusCode = value;
                if (HttpStatusHelper.IsAnErrorCode(this.statusCode))
                {
                    this.Title = HttpStatusHelper.HttpStatusOf(this.statusCode);
                }
            }
        }

        public string Status => HttpStatusHelper.HttpStatusOf(this.StatusCode);

        /// <summary>
        /// Title of the HTML page if it exists
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Time at which the request was issued
        /// </summary>
        public DateTime IssuedAt { get; }

        /// <summary>
        /// Is used has a timestamp to sort <see cref="HttpQuery"/>, including in <see cref="GlobalHistory"/>
        /// </summary>
        public long TimestampIssuedAt => this.IssuedAt.Ticks;

        public HttpQuery(Uri uri)
        {
            this.IssuedAt = DateTime.Now;
            this.Uri = uri;
        }

        /// <summary>
        /// Returns a <see cref="string"/> representing the <see cref="HttpQuery"/>
        /// </summary>
        /// <returns><see cref="string"/> representing the <see cref="HttpQuery"/></returns>
        public override string ToString()
        {
            return String.Format("{0}: {1} ({2})", this.IssuedAt.ToString("dd/MM HH:mm"), this.Title, this.Host);
        }
    }
}
