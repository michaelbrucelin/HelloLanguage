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
                int pivotid = (low + high) >> 1;  // 这里从简处理，使用数组中间的元素作为基准点
                int pivot = list[pivotid];

                int i = low, j = high;
                while (i < j)
                {
                    for (; i < j && list[i] <= pivot; i++) ;

                    for (; j > i && list[j] >= pivot; j--) ;

                    if (i != j)
                    {
                        swap(list, i, j);
                    }
                    else  // i == j
                    {
                        if (i < pivotid && list[i] < list[pivotid])
                        {
                            if (i + 1 != pivotid)
                                swap(list, i + 1, pivotid);
                        }
                        else if (i < pivotid && list[i] > list[pivotid])
                        {
                            swap(list, i, pivotid);
                        }
                        else if (j > pivotid && list[j] > list[pivotid])
                        {
                            if (j - 1 != pivotid)
                                swap(list, j - 1, pivotid);
                        }
                        else if (j > pivotid && list[j] < list[pivotid])
                        {
                            swap(list, j, pivotid);
                        }
                    }
                }

                QuickSort(list, low, i - 1);
                QuickSort(list, i + 1, high);
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
