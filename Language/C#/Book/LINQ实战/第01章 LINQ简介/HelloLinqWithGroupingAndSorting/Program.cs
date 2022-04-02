using System;
using System.Linq;

static class HelloWorld
{
    static void Main()
    {
        string[] words = { "hello", "wonderful", "linq", "beautiful", "world" };

        // Group words by length
        var groups = from word in words
                     orderby word ascending
                     group word by word.Length into lengthGroups
                     orderby lengthGroups.Key descending
                     select new { Length = lengthGroups.Key, Words = lengthGroups };

        /*
        var group = words
                    .OrderBy(s => s)
                    .GroupBy(s => s.Length)
                    .OrderByDescending(g => g.Key)
                    .Select(g => new { Length = g.Key, Words = g });
        */

        // Print each group out
        foreach (var group in groups)
        {
            Console.WriteLine("Words of length " + group.Length);
            foreach (string word in group.Words)
                Console.WriteLine("  " + word);
        }
    }
}

/*
Words of length 9
  beautiful, wonderful
Words of length 5
  hello, world
Words of length 4
  linq
*/