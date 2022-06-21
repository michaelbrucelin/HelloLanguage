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

            ShellSort(list);

            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }

        /// <summary>
        /// 希尔排序，Donald Shell
        /// 希尔排序是插入排序的升级版，也是时间复杂度最早突破O(n^2)的通用算法之一
        /// 
        /// 希尔排序的时间复杂度取决去增量的选择，由于每一轮希尔增量之间是等比的，这就导致了希尔增量存在盲区，例如：
        ///     [2, 1, 5, 3, 7, 6, 9, 8]这个数组，无论以4 为增量还是以2为增量，每组内部的元素都没有任何交换，直至增量为1，退化为插入排序
        ///     对于这样的数组，希尔排序不但没有减少插入排序的工作量，反而增加了分组操作的成本
        /// 为了保证分组粗调没有盲区，每一轮的增量需要彼此互质，后面会使用两种比较有代表性的增量：Hibbard增量与Sedgewick增量
        /// 
        /// 这里使用希尔增量来实现，假定数组长度为N，那么希尔增量为[N/2, N/4, N/8,... 2, 1]
        /// </summary>
        /// <param name="list"></param>
        public static void ShellSort(IList<int> list)
        {
            int span = list.Count / 2;
            while (span >= 1)
            {
                for (int i = span; i < list.Count; i++)
                {
                    int insertValue = list[i];
                    int j = i - span;
                    for (; j >= 0 && list[j] > insertValue; j -= span)
                    {
                        list[j + span] = list[j];
                    }
                    if (j + span != i)
                        list[j + span] = insertValue;
                }

                span /= 2;
            }
        }

        /// <summary>
        /// 希尔排序
        /// 
        /// 这里使用Hibbard增量来实现，增量序列为：[1, 3, 7, 15, 31, ...]
        ///     通项公式为：hi = 2^i − 1
        ///     递推公式为：h1 = 1, hi = 2*hi−1 + 1
        /// 此种增量排序最坏时间复杂度为O(N^3/2)，平均时间复杂度约为O(N^5/4)
        /// </summary>
        /// <param name="list"></param>
        public static void ShellSort2(IList<int> list)
        {

        }

        /// <summary>
        /// 希尔排序
        /// 
        /// 这里使用Sedgewick增量来实现，增量序列为：[1, 5, 19, 41, 109, ...]
        ///     通项公式为：hi = MAX(9*4^i − 9*2^i + 1, 4^i − 3*2^i + 1)
        /// 此种增量排序最坏时间复杂度为O(N^4/3)，平均时间复杂度约为O(N^7/6)
        /// </summary>
        /// <param name="list"></param>
        public static void ShellSort3(IList<int> list)
        {

        }

        /// <summary>
        /// 希尔排序
        /// 
        /// 这里使用Knuth增量来实现，增量序列为：[1, 4, 13, 40, 121, ...]
        ///     通项公式为：hi = (3^i − 1)/2
        ///     递推公式为：h1 = 1, hi = 3*hi−1 + 1
        /// 此种增量排序时间复杂度是O(N^3/2)
        /// </summary>
        /// <param name="list"></param>
        public static void ShellSort4(IList<int> list)
        {

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
