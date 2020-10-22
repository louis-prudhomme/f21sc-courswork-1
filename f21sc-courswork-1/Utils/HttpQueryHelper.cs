using f21sc_courswork_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Utils
{
    class HttpQueryHelper
    {
        private static readonly HttpClient client = new HttpClient();


        public static HttpQuery Make(string uri)
        {
            return new HttpQuery(uri);
        }

        public static async Task<HttpAnswer> ExecuteAsync(HttpQuery query)
        {
            return new HttpAnswer(await client.GetAsync(query.Uri).Result.Content.ReadAsStringAsync(), client.GetAsync(query.Uri).Result.StatusCode);
        }
    }
}
