using System;
using System.Linq;

static class QueryReuse
{
  static double Square(double n)
  {
    Console.WriteLine("Computing Square("+n+")...");
    return Math.Pow(n, 2);
  }
  
  public static void Main()
  {
    int[] numbers = {1, 2, 3};

    var query =
      from n in numbers
      select Square(n);

    foreach (var n in query)
      Console.WriteLine(n);

    for (int i = 0; i < numbers.Length; i++)
      numbers[i] = numbers[i]+10;

    Console.WriteLine("- Collection updated -");

    foreach (var n in query)
      Console.WriteLine(n);
  }
}