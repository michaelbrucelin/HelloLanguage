using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            List<int> list = new List<int>(100);
            Parallel.For(0, 100, i => list.Add(random.Next(0, 256)));
            list.Sort();

            int v = random.Next(0, 256);
            Console.WriteLine($"{v}-{BinarySearch(list, v)}{Environment.NewLine}");

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{i}:{list[i]}, ");
        }

        private static int BinarySearch(IList<int> list, int value)
        {
            int low, high, mid;
            low = 0;
            high = list.Count - 1;
            while (low <= high)
            {
                mid = (low + high) >> 1;
                if (list[mid] == value)
                    return mid;
                else if (list[mid] < value)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
    }
}
