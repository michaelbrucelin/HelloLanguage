using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// TODO 未完成

namespace SynthesisTool
{
    public class HttpClientGet
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
            Demo1();
            Console.WriteLine(StringRepeat("=", 64));
        }

        private static void Demo1()
        {
            var client = new HttpClient();
            var result = client.GetAsync("http://www.microsoft.com").Result;
            var content = result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private static readonly HttpClient client = new HttpClient();

        /*
        private static async Task<string> GetStringAsync(string url)
        {
            // var responseString = await client.GetStringAsync("http://www.example.com/recepticle.aspx");
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
        */

        private static string StringRepeat(string s, int n)
        {
            return new StringBuilder(s.Length * n)
                        .AppendJoin(s, new string[n + 1])
                        .ToString();
        }
    }
}