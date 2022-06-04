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
            List<int> list = new List<int>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100)));

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            SelectionSort(list);

            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }

        private enum SortType { ASC, DESC }
        private static void SelectionSort(IList<int> list, SortType sorttype = SortType.ASC)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }

                if (minIndex != i)
                {
                    int temp = list[i];
                    list[i] = list[minIndex];
                    list[minIndex] = temp;
                }
            }

            if (sorttype == SortType.DESC)
                list.Reverse();
        }
    }
}
