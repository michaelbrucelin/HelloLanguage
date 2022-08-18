using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsHttp2
    {
        //https://stackoverflow.com/questions/4015324/how-to-make-http-post-web-request

        #region HttpClient
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GETWithHttpClientAsync(string url)
        {
            string responseString = await client.GetStringAsync(url);

            return responseString;
        }

        public static async Task<string> PostWithHttpClientAsync(string url, Dictionary<string, string> values)
        {
            //POST，在.Net Framework 4.5下测试有效，配合async/await很不错
            //Dictionary<string, string> values = new Dictionary<string, string>()
            //{
            //    { "thing1", "hello" },
            //    { "thing2", "world" }
            //};
            FormUrlEncodedContent content = new FormUrlEncodedContent(values);
            HttpResponseMessage response = await client.PostAsync(url, content);
            string responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
        #endregion
    }
}
