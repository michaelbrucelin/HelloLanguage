using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsHttp
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

        #region HttpRequest
        public static string GETWithHttpRequest(string url)
        {
            WebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public static string PostWithHttpRequest(string url, string postData)
        {
            //POST，在.Net Framework 4.0下测试有效
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //string postData = "thing1=" + Uri.EscapeDataString("hello");
            //postData += "&thing2=" + Uri.EscapeDataString("world");

            byte[] data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            WebResponse response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
        #endregion

        #region WebClient
        #region 同步方法
        public static string GETWithWebClient(string url, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                try
                {
                    responseString = client.DownloadString(url);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string GETWithWebClient(string url, NameValueCollection headers, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);

                try
                {
                    responseString = client.DownloadString(url);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string GETWithWebClient(string url, out WebHeaderCollection headers_out, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                try
                {
                    responseString = client.DownloadString(url);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string GETWithWebClient(string url, NameValueCollection headers, out WebHeaderCollection headers_out, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);

                try
                {
                    responseString = client.DownloadString(url);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string PostWithWebClient(string url, NameValueCollection data, Encoding encoding = null)
        {
            //POST，在.Net Framework 4.0下测试有效
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                try
                {
                    byte[] response = client.UploadValues(url, data);
                    //responseString = Encoding.Default.GetString(response);
                    responseString = client.Encoding.GetString(response);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string PostWithWebClient(string url, string json, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                //client.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";

                try
                {
                    responseString = client.UploadString(url, json);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        /// <summary>
        /// 允许服务端返回的gzip压缩的结果数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="isgzip">表示是否允许服务端返回gzip压缩的数据，而不是压缩上传的数据</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string PostWithWebClient(string url, string json, bool isgzip, Encoding encoding = null)
        {
            if (!isgzip)
                return PostWithWebClient(url, json, encoding);
            else
            {
                string responseString = string.Empty;

                using (QWebClient client = new QWebClient())
                {
                    if (encoding != null)
                    {
                        client.Encoding = encoding;
                    }

                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    //client.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
                    client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
                    try
                    {
                        responseString = client.UploadString(url, json);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                return responseString;
            }
        }

        public static string PostWithWebClient(string url, NameValueCollection headers, NameValueCollection data, Encoding encoding = null)
        {
            //POST，在.Net Framework 4.0下测试有效
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);

                try
                {
                    byte[] response = client.UploadValues(url, data);
                    //responseString = Encoding.Default.GetString(response);
                    responseString = client.Encoding.GetString(response);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string PostWithWebClient(string url, NameValueCollection headers, string json, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);
                //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    responseString = client.UploadString(url, json);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string PostWithWebClient(string url, NameValueCollection data, out WebHeaderCollection headers_out, Encoding encoding = null)
        {
            //POST，在.Net Framework 4.0下测试有效
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                try
                {
                    byte[] response = client.UploadValues(url, data);
                    //responseString = Encoding.Default.GetString(response);
                    responseString = client.Encoding.GetString(response);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string PostWithWebClient(string url, string json, out WebHeaderCollection headers_out, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    responseString = client.UploadString(url, json);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string PostWithWebClient(string url, NameValueCollection headers, NameValueCollection data, out WebHeaderCollection headers_out, Encoding encoding = null)
        {
            //POST，在.Net Framework 4.0下测试有效
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);

                try
                {
                    byte[] response = client.UploadValues(url, data);
                    //responseString = Encoding.Default.GetString(response);
                    responseString = client.Encoding.GetString(response);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public static string PostWithWebClient(string url, NameValueCollection headers, string json, out WebHeaderCollection headers_out, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);
                //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    responseString = client.UploadString(url, json);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }
        #endregion

        #region 异步方法
        public async static Task<string> GETWithWebClientAsync(string url, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                try
                {
                    responseString = await client.DownloadStringTaskAsync(url);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public async static Task<string> GETWithWebClientAsync(string url, NameValueCollection headers, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);

                try
                {
                    responseString = await client.DownloadStringTaskAsync(url);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public async static Task<(string, WebHeaderCollection)> GETWithWebClientAsync2(string url, Encoding encoding = null)
        {
            string responseString = string.Empty;
            WebHeaderCollection headers_out;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                try
                {
                    responseString = await client.DownloadStringTaskAsync(url);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return (responseString, headers_out);
        }

        public async static Task<(string, WebHeaderCollection)> GETWithWebClientAsync2(string url, NameValueCollection headers, Encoding encoding = null)
        {
            string responseString = string.Empty;
            WebHeaderCollection headers_out;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);

                try
                {
                    responseString = await client.DownloadStringTaskAsync(url);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return (responseString, headers_out);
        }

        public async static Task<string> PostWithWebClientAsync(string url, NameValueCollection data, Encoding encoding = null)
        {
            //POST，在.Net Framework 4.0下测试有效
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                try
                {
                    byte[] response = await client.UploadValuesTaskAsync(url, data);
                    //responseString = Encoding.Default.GetString(response);
                    responseString = client.Encoding.GetString(response);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public async static Task<string> PostWithWebClientAsync(string url, string json, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                //client.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";

                try
                {
                    responseString = await client.UploadStringTaskAsync(url, json);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        /// <summary>
        /// 允许服务端返回的gzip压缩的结果数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="isgzip">表示是否允许服务端返回gzip压缩的数据，而不是压缩上传的数据</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public async static Task<string> PostWithWebClientAsync(string url, string json, bool isgzip, Encoding encoding = null)
        {
            if (!isgzip)
            {
                return await PostWithWebClientAsync(url, json, encoding);
            }
            else
            {
                string responseString = string.Empty;

                using (QWebClient client = new QWebClient())
                {
                    if (encoding != null)
                    {
                        client.Encoding = encoding;
                    }

                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    //client.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
                    client.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
                    try
                    {
                        responseString = await client.UploadStringTaskAsync(url, json);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                return responseString;
            }
        }

        public async static Task<string> PostWithWebClientAsync(string url, NameValueCollection headers, NameValueCollection data, Encoding encoding = null)
        {
            //POST，在.Net Framework 4.0下测试有效
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);

                try
                {
                    byte[] response = await client.UploadValuesTaskAsync(url, data);
                    //responseString = Encoding.Default.GetString(response);
                    responseString = client.Encoding.GetString(response);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public async static Task<string> PostWithWebClientAsync(string url, NameValueCollection headers, string json, Encoding encoding = null)
        {
            string responseString = string.Empty;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);
                //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    responseString = await client.UploadStringTaskAsync(url, json);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return responseString;
        }

        public async static Task<(string, WebHeaderCollection)> PostWithWebClientAsync2(string url, NameValueCollection data, Encoding encoding = null)
        {
            //POST，在.Net Framework 4.0下测试有效
            string responseString = string.Empty;
            WebHeaderCollection headers_out;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                try
                {
                    byte[] response = await client.UploadValuesTaskAsync(url, data);
                    //responseString = Encoding.Default.GetString(response);
                    responseString = client.Encoding.GetString(response);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return (responseString, headers_out);
        }

        public async static Task<(string, WebHeaderCollection)> PostWithWebClientAsync2(string url, string json, Encoding encoding = null)
        {
            string responseString = string.Empty;
            WebHeaderCollection headers_out;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    responseString = await client.UploadStringTaskAsync(url, json);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return (responseString, headers_out);
        }

        public async static Task<(string, WebHeaderCollection)> PostWithWebClientAsync2(string url, NameValueCollection headers, NameValueCollection data, Encoding encoding = null)
        {
            //POST，在.Net Framework 4.0下测试有效
            string responseString = string.Empty;
            WebHeaderCollection headers_out;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);

                try
                {
                    byte[] response = await client.UploadValuesTaskAsync(url, data);
                    //responseString = Encoding.Default.GetString(response);
                    responseString = client.Encoding.GetString(response);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return (responseString, headers_out);
        }

        public async static Task<(string, WebHeaderCollection)> PostWithWebClientAsync2(string url, NameValueCollection headers, string json, Encoding encoding = null)
        {
            string responseString = string.Empty;
            WebHeaderCollection headers_out;

            using (WebClient client = new WebClient())
            {
                if (encoding != null)
                {
                    client.Encoding = encoding;
                }

                client.Headers.Add(headers);
                //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                try
                {
                    responseString = await client.UploadStringTaskAsync(url, json);
                    headers_out = client.ResponseHeaders;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return (responseString, headers_out);
        }
        #endregion
        #endregion
    }

    /// <summary>
    /// 自动解压服务端返回的gzip压缩的结果数据
    /// </summary>
    public class QWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            return request;
        }
    }

    /// <summary>
    /// 压缩上传数据的示例，没有测试
    /// https://stackoverflow.com/questions/24180697/how-to-upload-gzip-compressed-data-using-system-net-webclient-in-c-sharp
    /// how to using
    /// using (ExtendedWebClient client = new ExtendedWebClient())
    /// {
    ///     try
    ///     {
    ///         //requestData object represents any data you need to send to server
    ///         string data = JsonConvert.SerializeObject(
    ///                         requestData,
    ///                         new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });
    ///
    ///         client.Headers.Add("Content-Type", "application/json; charset=utf-8");
    ///         client.Encoding = System.Text.Encoding.UTF8;
    ///         string url = "http://yourdomain.com/api";
    ///         string response = client.UploadString(url, data);
    ///
    ///         //Deal with response as you need
    ///     }
    ///     catch (Exception ex)
    ///     {
    ///         Console.Error.Write(ex.Message);
    ///     }
    /// }
    /// </summary>
    public class ExtendedWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 60 * 60 * 1000;
            return w;
        }

        private byte[] GZipBytes(string data)
        {
            //Transform string into byte[]
            byte[] ret = null;

            using (MemoryStream outputStream = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    //write to gzipper
                    StreamWriter writer = new StreamWriter(gzip);
                    writer.Write(data);
                    writer.Flush();

                    //write to output stream
                    gzip.Flush();
                    gzip.Close();

                    ret = outputStream.ToArray();
                }
            }

            return ret;
        }

        /// <summary>
        /// Overriden method using GZip compressed data upload.
        /// </summary>
        /// <param name="address">Remote server address.</param>
        /// <param name="data">String data.</param>
        /// <returns>Server response string.</returns>
        public new string UploadString(string address, string data)
        {
            string ret = null;
            byte[] bytes = GZipBytes(data);

            this.Headers.Add("Content-Encoding", "gzip");
            bytes = base.UploadData(address, bytes);
            ret = Encoding.UTF8.GetString(bytes);

            return ret;
        }

        /// <summary>
        /// Overriden method using GZip compressed data upload.
        /// </summary>
        /// <param name="address">Remote server URI.</param>
        /// <param name="data">String data.</param>
        /// <returns>Server response string.</returns>
        public new string UploadString(Uri address, string data)
        {
            string ret = null;
            byte[] bytes = GZipBytes(data);

            this.Headers.Add("Content-Encoding", "gzip");
            bytes = base.UploadData(address, bytes);
            ret = Encoding.UTF8.GetString(bytes);

            return ret;
        }

        /// <summary>
        /// Overriden method using GZip compressed data upload.
        /// </summary>
        /// <param name="address">Remote server address.</param>
        /// <param name="method">HTTP method (e.g. POST, PUT, DELETE, GET).</param>
        /// <param name="data">String data.</param>
        /// <returns>Server response string.</returns>
        public new string UploadString(string address, string method, string data)
        {
            string ret = null;
            byte[] bytes = GZipBytes(data);

            this.Headers.Add("Content-Encoding", "gzip");
            bytes = base.UploadData(address, method, bytes);
            ret = Encoding.UTF8.GetString(bytes);

            return ret;
        }


        /// <summary>
        /// Overriden method using GZip compressed data upload.
        /// </summary>
        /// <param name="address">Remote server URI.</param>
        /// <param name="method">HTTP method (e.g. POST, PUT, DELETE, GET).</param>
        /// <param name="data">String data.</param>
        /// <returns>Server response string.</returns>
        public new string UploadString(Uri address, string method, string data)
        {
            string ret = null;
            byte[] bytes = GZipBytes(data);

            this.Headers.Add("Content-Encoding", "gzip");
            bytes = base.UploadData(address, method, bytes);
            ret = Encoding.UTF8.GetString(bytes);

            return ret;
        }
    }
}
