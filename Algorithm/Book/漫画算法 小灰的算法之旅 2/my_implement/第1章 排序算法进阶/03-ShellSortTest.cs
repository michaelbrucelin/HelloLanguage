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
            // 检验一下几种增量序列的结果，以及每种增量序列比较与交换的次数
            Random random = new Random();
            List<int> list = new List<int>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100)));

            List<int> list1 = list.ToList();
            List<int> list2 = list.ToList();
            List<int> list3 = list.ToList();
            List<int> list4 = list.ToList();
            List<int> list5 = list.ToList();

            var r1 = ShellSort1(list1);
            var r2 = ShellSort2(list2);
            var r3 = ShellSort3(list3);
            var r4 = ShellSort4(list4);
            var r5 = ShellSort5(list5);

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            Console.WriteLine($"\n1. compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i < list1.Count; i++) Console.Write($"{list1[i]}, ");

            Console.WriteLine($"\n1. compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i < list2.Count; i++) Console.Write($"{list2[i]}, ");

            Console.WriteLine($"\n3. compare times: {r3.compcnt}, swap times: {r3.swapcnt};");
            for (int i = 0; i < list3.Count; i++) Console.Write($"{list3[i]}, ");

            Console.WriteLine($"\n4. compare times: {r4.compcnt}, swap times: {r4.swapcnt};");
            for (int i = 0; i < list4.Count; i++) Console.Write($"{list4[i]}, ");

            Console.WriteLine($"\n5. compare times: {r5.compcnt}, swap times: {r5.swapcnt};");
            for (int i = 0; i < list5.Count; i++) Console.Write($"{list5[i]}, ");
        }

        /// <summary>
        /// 通用的希尔排序，用于比较不同增量序列的性能
        /// </summary>
        /// <param name="list"></param>
        /// <param name="gaps"></param>
        public static (int compcnt, int swapcnt) ShellSort0(IList<int> list, Stack<int> gaps)
        {
            int compcnt = 0, swapcnt = 0;

            while (gaps.Count > 0)
            {
                int gap = gaps.Pop();
                for (int i = gap; i < list.Count; i++)
                {
                    int insertValue = list[i];
                    int j = i - gap;
                    for (; j >= 0 && list[j] > insertValue; j -= gap)
                    {
                        compcnt++;
                        swapcnt++;
                        list[j + gap] = list[j];
                    }
                    if (j + gap != i)
                    {
                        compcnt++;
                        swapcnt++;
                        list[j + gap] = insertValue;
                    }
                }
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 希尔排序，Donald Shell
        /// 希尔排序是插入排序的升级版，也是时间复杂度最早突破O(n^2)的通用算法之一
        /// 
        /// 希尔排序的时间复杂度取决去增量的选择，由于每一轮希尔增量之间是等比的，这就导致了希尔增量存在盲区，例如：
        ///     [2, 1, 5, 3, 7, 6, 9, 8]这个数组，无论以4 为增量还是以2为增量，每组内部的元素都没有任何交换，直至增量为1，退化为插入排序
        ///     对于这样的数组，希尔排序不但没有减少插入排序的工作量，反而增加了分组操作的成本
        /// 为了保证分组粗调没有盲区，每一轮的增量需要彼此互质，后面会使用两种比较有代表性的增量：Hibbard增量与Sedgewick增量
        /// 这里有各种增量序列的论述：https://en.wikipedia.org/wiki/Shellsort#Gap_sequences
        /// 
        /// 这里使用希尔增量来实现，假定数组长度为N，那么希尔增量为[N/2, N/4, N/8,... 2, 1]
        /// </summary>
        /// <param name="list"></param>
        public static (int compcnt, int swapcnt) ShellSort1(IList<int> list)
        {
            Stack<int> gaps = GapSequences1(list.Count);

            return ShellSort0(list, gaps);
        }

        private static Stack<int> GapSequences1(int length)
        {
            Stack<int> gaps = new Stack<int>();

            Stack<int> temp = new Stack<int>();
            for (int i = length / 2; i >= 1; i = i >> 1)
                temp.Push(i);

            while (temp.Count > 0)
                gaps.Push(temp.Pop());

            return gaps;
        }

        /// <summary>
        /// 希尔排序
        /// 
        /// 这里使用Knuth增量来实现，增量序列为：[1, 4, 13, 40, 121, 364, 1093, 3280, ...]
        ///     通项公式为：hi = (3^i − 1)/2
        ///     递推公式为：h1 = 1, hi = 3*hi−1 + 1
        /// 此种增量排序时间复杂度是O(N^3/2)
        /// </summary>
        /// <param name="list"></param>
        public static (int compcnt, int swapcnt) ShellSort2(IList<int> list)
        {
            Stack<int> gaps = GapSequences2(list.Count);

            return ShellSort0(list, gaps);
        }

        private static Stack<int> GapSequences2(int length)
        {
            Stack<int> gaps = new Stack<int>();

            for (int i = 1; i < length; i = i * 3 + 1)
                gaps.Push(i);

            return gaps;
        }

        /// <summary>
        /// 希尔排序
        /// 
        /// 这里使用Hibbard增量来实现，增量序列为：[1, 3, 7, 15, 31, 63, 127, 255, 511, ...]
        ///     通项公式为：hi = 2^i − 1
        ///     递推公式为：h1 = 1, hi = 2*hi−1 + 1
        /// 此种增量排序最坏时间复杂度为O(N^3/2)，平均时间复杂度约为O(N^5/4)
        /// </summary>
        /// <param name="list"></param>
        public static (int compcnt, int swapcnt) ShellSort3(IList<int> list)
        {
            Stack<int> gaps = GapSequences3(list.Count);

            return ShellSort0(list, gaps);
        }

        private static Stack<int> GapSequences3(int length)
        {
            Stack<int> gaps = new Stack<int>();

            for (int i = 1; i < length; i = i << 1 + 1)
                gaps.Push(i);

            return gaps;
        }

        /// <summary>
        /// 希尔排序
        /// 
        /// 这里使用Sedgewick增量1来实现，增量序列为：[1, 8, 23, 77, 281, 1073, 4193, 16577, 65921, ...]
        ///     通项公式为：hi = = 4^(i+1) + 3*2^i + 1, prefixed with 1
        /// 此种增量排序最坏时间复杂度为O(N^4/3)，平均时间复杂度约为O(N^7/6)
        /// </summary>
        /// <param name="list"></param>
        public static (int compcnt, int swapcnt) ShellSort4(IList<int> list)
        {
            Stack<int> gaps = GapSequences4(list.Count);

            return ShellSort0(list, gaps);
        }

        private static Stack<int> GapSequences4(int length)
        {
            Stack<int> gaps = new Stack<int>();

            gaps.Push(1);

            int i = 0;
            while (true)
            {
                int temp = (int)Math.Pow(4, i + 1) + (int)Math.Pow(2, i) * 3 + 1;
                if (temp < length)
                {
                    gaps.Push(temp);
                    i++;
                }
                else
                    break;
            }

            return gaps;
        }

        /// <summary>
        /// 希尔排序
        /// 
        /// 这里使用Sedgewick增量2来实现，增量序列为：[1, 5, 19, 41, 109, 209, 505, 929, 2161, ...]
        ///     通项公式为：https://en.wikipedia.org/wiki/Shellsort#Gap_sequences ，太复杂了，来这看吧
        /// 此种增量排序最坏时间复杂度为O(N^4/3)，平均时间复杂度约为O(N^7/6)
        /// 
        /// 据说当数据量较大时，这个是最好的增量序列
        /// </summary>
        /// <param name="list"></param>
        public static (int compcnt, int swapcnt) ShellSort5(IList<int> list)
        {
            Stack<int> gaps = GapSequences5(list.Count);

            return ShellSort0(list, gaps);
        }

        private static Stack<int> GapSequences5(int length)
        {
            Stack<int> gaps = new Stack<int>();

            int i = 0;
            while (true)
            {
                int temp;
                if ((i & 1) != 1)
                    temp = (int)(Math.Pow(2, i) - Math.Pow(2, i >> 1)) * 9 + 1;
                else
                    temp = (int)Math.Pow(2, i) * 8 - (int)Math.Pow(2, (i + 1) >> 1) * 6 + 1;

                if (temp < length)
                {
                    gaps.Push(temp);
                    i++;
                }
                else
                    break;
            }

            return gaps;
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
