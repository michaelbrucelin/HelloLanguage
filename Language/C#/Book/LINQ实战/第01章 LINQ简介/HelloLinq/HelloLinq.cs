using System;
using System.Linq;

static class HelloWorld
{
    static void Main()
    {
        string[] words = { "hello", "wonderful", "linq", "beautiful", "world" };

        // Get only short words
        var shortWords = from word in words
                         where word.Length <= 5
                         select word;

        // Print each word out
        foreach (var word in shortWords)
            Console.WriteLine(word);
    }
}