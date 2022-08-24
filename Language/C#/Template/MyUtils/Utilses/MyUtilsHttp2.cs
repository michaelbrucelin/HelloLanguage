using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsHttp2
    {
        static MyUtilsHttp2()
        {
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));     // 允许服务端以gzip格式压缩数据
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));  // 允许服务端以deflate格式压缩数据
        }

        #region HttpClient
        private static HttpClientHandler handler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate  // 自动解压缩
        };
        private static readonly HttpClient client = new HttpClient(handler);

        #region 异步方法
        public static async Task<string> GETWithHttpClientAsync(string url)
        {
            string responseString = await client.GetStringAsync(url);

            return responseString;
        }

        public static async Task<string> PostWithHttpClientAsync(string url, Dictionary<string, string> values)
        {
            FormUrlEncodedContent content = new FormUrlEncodedContent(values);
            string responseString = await PostWithHttpClientAsync(url, content);

            return responseString;
        }

        public static async Task<string> PostWithHttpClientAsync(string url, FormUrlEncodedContent content)
        {
            // Dictionary<string, string> values = new Dictionary<string, string>()
            // {
            //     { "thing1", "hello" },
            //     { "thing2", "world" }
            // };

            // KeyValuePair<string, string>[] values = new KeyValuePair<string, string>[] {
            //     new KeyValuePair<string, string>("thing1", "hello"),
            //     new KeyValuePair<string, string>("thing2", "world")
            // };

            // FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = await client.PostAsync(url, content);
            string responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public static async Task<string> PostWithHttpClientAsync(string url, string json)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(message);
            string responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
        #endregion

        #region 同步方法
        // .Net Core 5中有同步方法，client.Send()，即client.SendAsync()的同步版本，从哪个版本开始有的不清楚，.Net Framework 4.8中没有同步方法
        // 这里只能通过阻塞Task来实现
        public static string GETWithHttpClient(string url)
        {
            Task<string> task = client.GetStringAsync(url);
            task.Wait();

            return task.Result;
        }

        public static string PostWithHttpClient(string url, Dictionary<string, string> values)
        {
            FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            return PostWithHttpClient(url, content);
        }

        public static string PostWithHttpClient(string url, FormUrlEncodedContent content)
        {
            // Dictionary<string, string> values = new Dictionary<string, string>()
            // {
            //     { "thing1", "hello" },
            //     { "thing2", "world" }
            // };

            // KeyValuePair<string, string>[] values = new KeyValuePair<string, string>[] {
            //     new KeyValuePair<string, string>("thing1", "hello"),
            //     new KeyValuePair<string, string>("thing2", "world")
            // };

            // FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            Task<HttpResponseMessage> task1 = client.PostAsync(url, content);
            task1.Wait();
            Task<string> task2 = task1.Result.Content.ReadAsStringAsync();

            return task2.Result;
        }

        public static string PostWithHttpClient(string url, string json)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> task1 = client.SendAsync(message);
            task1.Wait();
            Task<string> task2 = task1.Result.Content.ReadAsStringAsync();
            task2.Wait();

            return task2.Result;
        }
        #endregion
        #endregion
    }
}
