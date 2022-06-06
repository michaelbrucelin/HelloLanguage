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

            var list_sort = QuickSort(list);

            Console.WriteLine();
            for (int i = 0; i < list_sort.Count; i++)
                Console.Write($"{list_sort[i]}, ");
        }

        private static List<int> QuickSort(IList<int> list)
        {
            if (list.Count < 2)
                return list.ToList();
            else if (list.Count == 2)
            {
                if (list[0] <= list[1])
                    return list.ToList();
                else
                    return new List<int>() { list[1], list[0] };
            }
            else
            {
                int pivot = list[0];  // 这里从简处理，使用数组的第一个元素作为基准点

                List<int> list_min = QuickSort(list.Where((i, j) => i <= pivot && j > 0).ToList());
                List<int> list_max = QuickSort(list.Where((i, j) => i > pivot && j > 0).ToList());

                list_min.Add(pivot);
                return list_min.Concat(list_max).ToList();
            }
        }
    }
}
