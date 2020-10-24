using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Utils
{
    class HttpQueryHelper
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Executes the query asynchronously and returns the corresponding answer
        /// </summary>
        /// <param name="query">Query to execute</param>
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
        /// <returns></returns>
        private static string ExtractHtmlTitle(string html)
        {
            return Regex.Match(html, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }
    }
}
