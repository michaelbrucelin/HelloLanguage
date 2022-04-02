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

        foreach (var n in query.ToList())
            Console.WriteLine(n);
    }
}

/*
使用 ToList() 取消延迟查询执行，立即执行查询

Computing Square(1)...
Computing Square(2)...
Computing Square(3)...
1
4
9
*/