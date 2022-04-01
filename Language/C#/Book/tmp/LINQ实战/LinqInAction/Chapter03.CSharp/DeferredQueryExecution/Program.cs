using System;
using System.Linq;

static class DeferredQueryExecution
{
    static double Square(double n)
    {
        Console.WriteLine("Computing Square(" + n + ")...");
        return Math.Pow(n, 2);
    }

    public static void Main()
    {
        int[] numbers = { 1, 2, 3 };

        var query = from n in numbers
                    select Square(n);

        foreach (var n in query)
            Console.WriteLine(n);
    }
}