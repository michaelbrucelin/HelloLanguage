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

            #region 比较1
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
            #endregion

            #region 比较2
            Enumerable.Range(0, 3).ToList().ForEach(i => Console.WriteLine());

            // list = new List<int>(65536);
            // Parallel.For(0, 65536, i => list.Add(random.Next(0, 1000000)));  // Add()不是原子安全的，最终很可能得不到65536个元素
            list = new List<int>(new int[65536]);
            Parallel.For(0, 65536, i => list[i] = random.Next(0, 1000000));

            list1 = list.ToList();
            list2 = list.ToList();
            list3 = list.ToList();
            list4 = list.ToList();
            list5 = list.ToList();

            r1 = ShellSort1(list1);
            r2 = ShellSort2(list2);
            r3 = ShellSort3(list3);
            r4 = ShellSort4(list4);
            r5 = ShellSort5(list5);

            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{list[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n1. 希尔增量，      compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{list1[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n2. Knuth增量，     compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{list2[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n3. Hibbard增量，   compare times: {r3.compcnt}, swap times: {r3.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{list3[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n4. Sedgewick增量1，compare times: {r4.compcnt}, swap times: {r4.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{list4[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n5. Sedgewick增量2，compare times: {r5.compcnt}, swap times: {r5.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{list5[(int)Math.Pow(2, i) - 1]}, ");
            #endregion
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

/*
第1次测试
11, 92, 37, 60, 32, 43, 37, 76, 96, 29, 14, 0, 69, 30, 59, 69, 80, 69, 73, 28, 75, 22, 26, 31, 10, 13, 51, 82, 45, 80, 30, 46,
1. compare times: 103, swap times: 103;
0, 10, 11, 13, 14, 22, 26, 28, 29, 30, 30, 31, 32, 37, 37, 43, 45, 46, 51, 59, 60, 69, 69, 69, 73, 75, 76, 80, 80, 82, 92, 96,
1. compare times: 142, swap times: 142;
0, 10, 11, 13, 14, 22, 26, 28, 29, 30, 30, 31, 32, 37, 37, 43, 45, 46, 51, 59, 60, 69, 69, 69, 73, 75, 76, 80, 80, 82, 92, 96,
3. compare times: 127, swap times: 127;
0, 10, 11, 13, 14, 22, 26, 28, 29, 30, 30, 31, 32, 37, 37, 43, 45, 46, 51, 59, 60, 69, 69, 69, 73, 75, 76, 80, 80, 82, 92, 96,
4. compare times: 117, swap times: 117;
0, 10, 11, 13, 14, 22, 26, 28, 29, 30, 30, 31, 32, 37, 37, 43, 45, 46, 51, 59, 60, 69, 69, 69, 73, 75, 76, 80, 80, 82, 92, 96,
5. compare times: 146, swap times: 146;
0, 10, 11, 13, 14, 22, 26, 28, 29, 30, 30, 31, 32, 37, 37, 43, 45, 46, 51, 59, 60, 69, 69, 69, 73, 75, 76, 80, 80, 82, 92, 96,

0-439245, 1-830960, 3-129330, 7-556282, 15-337668, 31-164236, 63-966056, 127-569101, 255-386862, 511-362108, 1023-5832, 2047-991347, 4095-674930, 8191-160416, 16383-573204, 32767-484757, 65535-238285,
1. 希尔增量，      compare times: 8549777, swap times: 8549777;
0-21, 1-54, 3-58, 7-86, 15-150, 31-493, 63-838, 127-2072, 255-4029, 511-7618, 1023-15018, 2047-30691, 4095-61534, 8191-125275, 16383-250860, 32767-501350, 65535-999936,
2. Knuth增量，     compare times: 2094941, swap times: 2094941;
0-21, 1-54, 3-58, 7-86, 15-150, 31-493, 63-838, 127-2072, 255-4029, 511-7618, 1023-15018, 2047-30691, 4095-61534, 8191-125275, 16383-250860, 32767-501350, 65535-999936,
3. Hibbard增量，   compare times: 9638740, swap times: 9638740;
0-21, 1-54, 3-58, 7-86, 15-150, 31-493, 63-838, 127-2072, 255-4029, 511-7618, 1023-15018, 2047-30691, 4095-61534, 8191-125275, 16383-250860, 32767-501350, 65535-999936,
4. Sedgewick增量1，compare times: 1810454, swap times: 1810454;
0-21, 1-54, 3-58, 7-86, 15-150, 31-493, 63-838, 127-2072, 255-4029, 511-7618, 1023-15018, 2047-30691, 4095-61534, 8191-125275, 16383-250860, 32767-501350, 65535-999936,
5. Sedgewick增量2，compare times: 1302984, swap times: 1302984;
0-21, 1-54, 3-58, 7-86, 15-150, 31-493, 63-838, 127-2072, 255-4029, 511-7618, 1023-15018, 2047-30691, 4095-61534, 8191-125275, 16383-250860, 32767-501350, 65535-999936,


第2次测试
62, 60, 56, 25, 69, 71, 94, 52, 30, 16, 59, 83, 90, 14, 94, 5, 97, 45, 4, 55, 53, 48, 94, 56, 95, 54, 97, 14, 54, 61, 24, 74,
1. compare times: 153, swap times: 153;
4, 5, 14, 14, 16, 24, 25, 30, 45, 48, 52, 53, 54, 54, 55, 56, 56, 59, 60, 61, 62, 69, 71, 74, 83, 90, 94, 94, 94, 95, 97, 97,
1. compare times: 118, swap times: 118;
4, 5, 14, 14, 16, 24, 25, 30, 45, 48, 52, 53, 54, 54, 55, 56, 56, 59, 60, 61, 62, 69, 71, 74, 83, 90, 94, 94, 94, 95, 97, 97,
3. compare times: 157, swap times: 157;
4, 5, 14, 14, 16, 24, 25, 30, 45, 48, 52, 53, 54, 54, 55, 56, 56, 59, 60, 61, 62, 69, 71, 74, 83, 90, 94, 94, 94, 95, 97, 97,
4. compare times: 154, swap times: 154;
4, 5, 14, 14, 16, 24, 25, 30, 45, 48, 52, 53, 54, 54, 55, 56, 56, 59, 60, 61, 62, 69, 71, 74, 83, 90, 94, 94, 94, 95, 97, 97,
5. compare times: 161, swap times: 161;
4, 5, 14, 14, 16, 24, 25, 30, 45, 48, 52, 53, 54, 54, 55, 56, 56, 59, 60, 61, 62, 69, 71, 74, 83, 90, 94, 94, 94, 95, 97, 97,

0-596730, 1-220780, 3-44884, 7-520211, 15-179173, 31-693479, 63-539208, 127-910994, 255-476137, 511-57246, 1023-465398, 2047-558019, 4095-879575, 8191-708063, 16383-729570, 32767-596648, 65535-956224,
1. 希尔增量，      compare times: 8581575, swap times: 8581575;
0-6, 1-8, 3-27, 7-47, 15-185, 31-330, 63-775, 127-1962, 255-3781, 511-7438, 1023-15257, 2047-30701, 4095-62375, 8191-123799, 16383-248817, 32767-496579, 65535-999971,
2. Knuth增量，     compare times: 2074711, swap times: 2074711;
0-6, 1-8, 3-27, 7-47, 15-185, 31-330, 63-775, 127-1962, 255-3781, 511-7438, 1023-15257, 2047-30701, 4095-62375, 8191-123799, 16383-248817, 32767-496579, 65535-999971,
3. Hibbard增量，   compare times: 11376060, swap times: 11376060;
0-6, 1-8, 3-27, 7-47, 15-185, 31-330, 63-775, 127-1962, 255-3781, 511-7438, 1023-15257, 2047-30701, 4095-62375, 8191-123799, 16383-248817, 32767-496579, 65535-999971,
4. Sedgewick增量1，compare times: 1822051, swap times: 1822051;
0-6, 1-8, 3-27, 7-47, 15-185, 31-330, 63-775, 127-1962, 255-3781, 511-7438, 1023-15257, 2047-30701, 4095-62375, 8191-123799, 16383-248817, 32767-496579, 65535-999971,
5. Sedgewick增量2，compare times: 1307807, swap times: 1307807;
0-6, 1-8, 3-27, 7-47, 15-185, 31-330, 63-775, 127-1962, 255-3781, 511-7438, 1023-15257, 2047-30701, 4095-62375, 8191-123799, 16383-248817, 32767-496579, 65535-999971,


第3次测试
56, 97, 9, 91, 38, 98, 41, 25, 56, 35, 50, 72, 15, 40, 49, 66, 82, 54, 28, 74, 24, 49, 8, 89, 71, 18, 26, 35, 35,
1. compare times: 124, swap times: 124;
8, 9, 15, 18, 24, 25, 26, 28, 35, 35, 35, 38, 40, 41, 49, 49, 50, 54, 56, 56, 66, 71, 72, 74, 82, 89, 91, 97, 98,
1. compare times: 131, swap times: 131;
8, 9, 15, 18, 24, 25, 26, 28, 35, 35, 35, 38, 40, 41, 49, 49, 50, 54, 56, 56, 66, 71, 72, 74, 82, 89, 91, 97, 98,
3. compare times: 146, swap times: 146;
8, 9, 15, 18, 24, 25, 26, 28, 35, 35, 35, 38, 40, 41, 49, 49, 50, 54, 56, 56, 66, 71, 72, 74, 82, 89, 91, 97, 98,
4. compare times: 130, swap times: 130;
8, 9, 15, 18, 24, 25, 26, 28, 35, 35, 35, 38, 40, 41, 49, 49, 50, 54, 56, 56, 66, 71, 72, 74, 82, 89, 91, 97, 98,
5. compare times: 142, swap times: 142;
8, 9, 15, 18, 24, 25, 26, 28, 35, 35, 35, 38, 40, 41, 49, 49, 50, 54, 56, 56, 66, 71, 72, 74, 82, 89, 91, 97, 98,

0-871629, 1-685675, 3-797991, 7-106393, 15-230900, 31-123521, 63-460791, 127-106406, 255-801782, 511-722905, 1023-96468, 2047-899931, 4095-46907, 8191-89087, 16383-0, 32767-457829, 65535-239611,
1. 希尔增量，      compare times: 9657605, swap times: 9657605;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-64076, 16383-195795, 32767-468253, 65535-999982,
2. Knuth增量，     compare times: 2110981, swap times: 2110981;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-64076, 16383-195795, 32767-468253, 65535-999982,
3. Hibbard增量，   compare times: 11012985, swap times: 11012985;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-64076, 16383-195795, 32767-468253, 65535-999982,
4. Sedgewick增量1，compare times: 1728403, swap times: 1728403;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-64076, 16383-195795, 32767-468253, 65535-999982,
5. Sedgewick增量2，compare times: 1221834, swap times: 1221834;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-64076, 16383-195795, 32767-468253, 65535-999982,
*/
