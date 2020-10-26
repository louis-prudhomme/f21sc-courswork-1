using f21sc_coursework_1.Model.HttpCommunications;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace f21sc_coursework_1.Utils.Http
{
    /// <summary>
    /// Helps to execute <see cref="HttpQuery"/> and interpret the result
    /// </summary>
    class HttpQueryHelper
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Executes the <see cref="HttpQuery"/> asynchronously and returns the corresponding <see cref="HttpAnswer"/>
        /// </summary>
        /// <param name="query"><see cref="HttpQuery"/> to execute</param>
        /// <returns></returns>
        public static async Task<HttpAnswer> ExecuteAsync(HttpQuery query)
        {
            HttpResponseMessage response = await client.GetAsync(query.Uri);
            string html = await response.Content.ReadAsStringAsync();

            return new HttpAnswer(html, ExtractHtmlTitle(html), response.StatusCode);
        }

        /// <summary>
        /// Extracts the title from the HTML page
        /// </summary>
        /// <param name="html">HTML page</param>
        /// <returns>A <see cref="string"/> representing the title of the HTML page</returns>
        private static string ExtractHtmlTitle(string html)
        {
            return Regex.Match(html, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }
    }
}
