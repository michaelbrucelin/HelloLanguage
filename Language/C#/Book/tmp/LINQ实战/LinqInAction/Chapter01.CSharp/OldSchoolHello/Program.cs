using System;

static class HelloWorld
{
  static void Main()
  {
    string[] words = new string[] { "hello", "wonderful", "linq",
                                    "beautiful", "world" };

    foreach (string word in words)
    {
      if (word.Length <= 5)
        Console.WriteLine(word);
    }
  }
}