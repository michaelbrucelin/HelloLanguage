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

        /// <summary>
        /// 选择排序
        /// 选择排序与冒泡排序
        /// 1. 如果数据完全随机，选择排序交换元素的次数要小于冒泡排序，但是如果数据中大部分数据已经有序，冒泡排序的效率更高
        /// 2. 选择排序不稳定，而冒泡排序是稳定的
        /// </summary>
        /// <param name="list"></param>
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int minid = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minid])
                        minid = j;
                }

                if (i != minid)
                    swap(list, i, minid);
            }
        }

        private static void swap(IList<int> list, int i, int j)
        {
            if (i != j)
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
