using System;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            Console.WriteLine("Before: a=" + a);
            Console.WriteLine("Before: b=" + b);

            swap(ref a, ref b);

            Console.WriteLine("After: a=" + a);
            Console.WriteLine("After: b=" + b);

            Console.ReadLine();
        }

        public static void swap(ref int x, ref int y)
        {
            Console.WriteLine("Begin of method: x=" + x);
            Console.WriteLine("Begin of method: y=" + y);
            int temp = x;
            x = y;
            y = temp;
            Console.WriteLine("End of method: x=" + x);
            Console.WriteLine("End of method: y=" + y);
        }
    }
}

/*
Before: a=10
Before: b=20
Begin of method: x=10
Begin of method: y=20
End of method: x=20
End of method: y=10
After: a=20
After: b=10
*/
