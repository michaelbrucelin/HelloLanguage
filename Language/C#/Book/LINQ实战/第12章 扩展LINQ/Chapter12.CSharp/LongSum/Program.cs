using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LinqInAction.Extensibility;

namespace Chapter12.LongSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Standard Sum operator (throws an OverflowException)
            //Enumerable.Sum(new int[] {int.MaxValue, 1});
            //Console.WriteLine("Standard Sum operator: " + (new int[] { int.MaxValue, 1 }).Sum());

            // Custom LongSum operator
            SumExtensions.LongSum(new int[] { int.MaxValue, 1 });
            Console.WriteLine("Custom LongSum operator: " + (new int[] { int.MaxValue, 1 }).LongSum());
        }
    }
}