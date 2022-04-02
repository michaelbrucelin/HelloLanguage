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

        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = numbers[i] + 10;

        Console.WriteLine("- Collection updated -");

        foreach (var n in query)
            Console.WriteLine(n);
    }
}

/*
延迟查询执行，重用查询以得到不同的结果

Computing Square(1)...
1
Computing Square(2)...
4
Computing Square(3)...
9
- Collection updated -
Computing Square(11)...
121
Computing Square(12)...
144
Computing Square(13)...
169
*/