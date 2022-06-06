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

            QuickSort(list, 0, list.Count - 1);

            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }

        /// <summary>
        /// 快速排序，就地更改
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static void QuickSort(IList<int> list, int low, int high)
        {
            if (high - low < 1)
                return;
            else if (high - low == 1)
            {
                if (list[low] > list[high])
                {
                    int temp = list[low];
                    list[low] = list[high];
                    list[high] = temp;
                }
            }
            else
            {
                int pivotid = low, pivot = list[low];  // 这里从简处理，使用数组的第一个元素作为基准点

                int i = low, j = high;
                while (i < j)
                {
                    if (pivotid == i)
                    {
                        for (; j > i; j--)
                        {
                            if (list[j] >= pivot)
                                continue;

                            list[i++] = list[j];
                            pivotid = j;
                            break;
                        }
                    }

                    if (pivotid == j)
                    {
                        for (; i < j; i++)
                        {
                            if (list[i] <= pivot)
                                continue;

                            list[j--] = list[i];
                            pivotid = i;
                            break;
                        }
                    }
                }
                list[pivotid] = pivot;

                QuickSort(list, low, pivotid - 1);
                QuickSort(list, pivotid + 1, high);
            }
        }
    }
}
