public class HttpClientGet
{
    public static void Main()
    {
        Demo1();
        Console.WriteLine("=".MyRepeat(64));
    }

    private static void Demo1()
    {
        var client = new HttpClient();
        var result = client.GetAsync("http://www.microsoft.com").Result;
        var content = result.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);
    }

    private static readonly HttpClient client = new HttpClient();

    private static async Task<string> GetStringAsync(string url)
    {
        // var responseString = await client.GetStringAsync("http://www.example.com/recepticle.aspx");
        var response = await client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}

public static class StringExtensions
{
    public static string MyRepeat(this string s, int n)
    {
        return new StringBuilder(s.Length * n)
                    .AppendJoin(s, new string[n + 1])
                    .ToString();
    }
}