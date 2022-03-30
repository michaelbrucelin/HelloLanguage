using System;
using System.Linq;

static class HelloWorld
{
  static void Main()
  {
    string[] words = { "hello", "wonderful", "linq", "beautiful", "world" };

    // Group words by length
    var groups =
      from word in words
      orderby word ascending
      group word by word.Length into lengthGroups
      orderby lengthGroups.Key descending
      select new { Length = lengthGroups.Key, Words = lengthGroups };

    // Print each group out
    foreach (var group in groups)
    {
      Console.WriteLine("Words of length " + group.Length);
      foreach (string word in group.Words)
        Console.WriteLine("  " + word);
    }
  }
}