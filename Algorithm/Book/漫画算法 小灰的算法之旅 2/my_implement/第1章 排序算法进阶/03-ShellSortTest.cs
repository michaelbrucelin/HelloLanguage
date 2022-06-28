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
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));

            int[] arr1 = arr.ToArray();
            int[] arr2 = arr.ToArray();
            int[] arr3 = arr.ToArray();
            int[] arr4 = arr.ToArray();
            int[] arr5 = arr.ToArray();

            var r1 = ShellSort1(arr1);
            var r2 = ShellSort2(arr2);
            var r3 = ShellSort3(arr3);
            var r4 = ShellSort4(arr4);
            var r5 = ShellSort5(arr5);

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");

            Console.WriteLine($"\n1. compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i < arr1.Length; i++) Console.Write($"{arr1[i]}, ");

            Console.WriteLine($"\n1. compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i < arr2.Length; i++) Console.Write($"{arr2[i]}, ");

            Console.WriteLine($"\n3. compare times: {r3.compcnt}, swap times: {r3.swapcnt};");
            for (int i = 0; i < arr3.Length; i++) Console.Write($"{arr3[i]}, ");

            Console.WriteLine($"\n4. compare times: {r4.compcnt}, swap times: {r4.swapcnt};");
            for (int i = 0; i < arr4.Length; i++) Console.Write($"{arr4[i]}, ");

            Console.WriteLine($"\n5. compare times: {r5.compcnt}, swap times: {r5.swapcnt};");
            for (int i = 0; i < arr5.Length; i++) Console.Write($"{arr5[i]}, ");
            #endregion

            #region 比较2
            Enumerable.Range(0, 3).ToList().ForEach(i => Console.WriteLine());

            // list = new List<int>(65536);
            // Parallel.For(0, 65536, i => list.Add(random.Next(0, 1000000)));  // Add()不是原子安全的，最终很可能得不到65536个元素
            arr = new int[65536];
            Parallel.For(0, 65536, i => arr[i] = random.Next(0, 1000000));

            arr1 = arr.ToArray();
            arr2 = arr.ToArray();
            arr3 = arr.ToArray();
            arr4 = arr.ToArray();
            arr5 = arr.ToArray();

            r1 = ShellSort1(arr1);
            r2 = ShellSort2(arr2);
            r3 = ShellSort3(arr3);
            r4 = ShellSort4(arr4);
            r5 = ShellSort5(arr5);

            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{arr[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n1. 希尔增量，      compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{arr1[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n2. Knuth增量，     compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{arr2[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n3. Hibbard增量，   compare times: {r3.compcnt}, swap times: {r3.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{arr3[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n4. Sedgewick增量1，compare times: {r4.compcnt}, swap times: {r4.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{arr4[(int)Math.Pow(2, i) - 1]}, ");

            Console.WriteLine($"\n5. Sedgewick增量2，compare times: {r5.compcnt}, swap times: {r5.swapcnt};");
            for (int i = 0; i <= 16; i++) Console.Write($"{(int)Math.Pow(2, i) - 1}-{arr5[(int)Math.Pow(2, i) - 1]}, ");
            #endregion
        }

        /// <summary>
        /// 通用的希尔排序，用于比较不同增量序列的性能
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="gaps"></param>
        public static (int compcnt, int swapcnt) ShellSort0(int[] arr, Stack<int> gaps)
        {
            int compcnt = 0, swapcnt = 0;

            while (gaps.Count > 0)
            {
                int gap = gaps.Pop();
                for (int i = gap; i < arr.Length; i++)
                {
                    int insertValue = arr[i];
                    int j = i - gap;
                    for (; j >= 0 && arr[j] > insertValue; j -= gap)
                    {
                        compcnt++;
                        swapcnt++;
                        arr[j + gap] = arr[j];
                    }
                    if (j + gap != i)
                    {
                        compcnt++;
                        swapcnt++;
                        arr[j + gap] = insertValue;
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
        /// <param name="arr"></param>
        public static (int compcnt, int swapcnt) ShellSort1(int[] arr)
        {
            Stack<int> gaps = GapSequences1(arr.Length);

            return ShellSort0(arr, gaps);
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
        /// <param name="arr"></param>
        public static (int compcnt, int swapcnt) ShellSort2(int[] arr)
        {
            Stack<int> gaps = GapSequences2(arr.Length);

            return ShellSort0(arr, gaps);
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
        /// <param name="arr"></param>
        public static (int compcnt, int swapcnt) ShellSort3(int[] arr)
        {
            Stack<int> gaps = GapSequences3(arr.Length);

            return ShellSort0(arr, gaps);
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
        /// <param name="arr"></param>
        public static (int compcnt, int swapcnt) ShellSort4(int[] arr)
        {
            Stack<int> gaps = GapSequences4(arr.Length);

            return ShellSort0(arr, gaps);
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
        /// <param name="arr"></param>
        public static (int compcnt, int swapcnt) ShellSort5(int[] arr)
        {
            Stack<int> gaps = GapSequences5(arr.Length);

            return ShellSort0(arr, gaps);
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
    }
}

/*
第1次测试
48, 3, 12, 35, 3, 97, 16, 35, 30, 70, 99, 36, 45, 63, 58, 20, 91, 79, 81, 36, 15, 2, 77, 30, 82, 39, 60, 37, 80, 5, 36, 3, 42, 97, 51, 65, 30, 6,
1. compare times: 130, swap times: 130;
2, 3, 3, 3, 5, 6, 12, 15, 16, 20, 30, 30, 30, 35, 35, 36, 36, 36, 37, 39, 42, 45, 48, 51, 58, 60, 63, 65, 70, 77, 79, 80, 81, 82, 91, 97, 97, 99,
1. compare times: 158, swap times: 158;
2, 3, 3, 3, 5, 6, 12, 15, 16, 20, 30, 30, 30, 35, 35, 36, 36, 36, 37, 39, 42, 45, 48, 51, 58, 60, 63, 65, 70, 77, 79, 80, 81, 82, 91, 97, 97, 99,
3. compare times: 176, swap times: 176;
2, 3, 3, 3, 5, 6, 12, 15, 16, 20, 30, 30, 30, 35, 35, 36, 36, 36, 37, 39, 42, 45, 48, 51, 58, 60, 63, 65, 70, 77, 79, 80, 81, 82, 91, 97, 97, 99,
4. compare times: 206, swap times: 206;
2, 3, 3, 3, 5, 6, 12, 15, 16, 20, 30, 30, 30, 35, 35, 36, 36, 36, 37, 39, 42, 45, 48, 51, 58, 60, 63, 65, 70, 77, 79, 80, 81, 82, 91, 97, 97, 99,
5. compare times: 168, swap times: 168;
2, 3, 3, 3, 5, 6, 12, 15, 16, 20, 30, 30, 30, 35, 35, 36, 36, 36, 37, 39, 42, 45, 48, 51, 58, 60, 63, 65, 70, 77, 79, 80, 81, 82, 91, 97, 97, 99,


0-357661, 1-148316, 3-303033, 7-207274, 15-197298, 31-936063, 63-967974, 127-11708, 255-690924, 511-
592522, 1023-825659, 2047-817907, 4095-312897, 8191-726981, 16383-274378, 32767-0, 65535-0,
1. 希尔增量，      compare times: 3839349, swap times: 3839349;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-177330, 65535-999946,
2. Knuth增量，     compare times: 1255678, swap times: 1255678;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-177330, 65535-999946,
3. Hibbard增量，   compare times: 4952831, swap times: 4952831;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-177330, 65535-999946,
4. Sedgewick增量1，compare times: 1166358, swap times: 1166358;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-177330, 65535-999946,
5. Sedgewick增量2，compare times: 838142, swap times: 838142;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-177330, 65535-999946,


第2次测试
72, 97, 49, 8, 81, 31, 81, 67, 77, 63, 61, 80, 92, 73, 76, 37, 13, 94, 94, 71, 45, 41, 55, 76, 90, 41, 5, 21, 73, 1, 31, 35, 14, 90, 76, 99,
1. compare times: 141, swap times: 141;
1, 5, 8, 13, 14, 21, 31, 31, 35, 37, 41, 41, 45, 49, 55, 61, 63, 67, 71, 72, 73, 73, 76, 76, 76, 77, 80, 81, 81, 90, 90, 92, 94, 94, 97, 99,
1. compare times: 132, swap times: 132;
1, 5, 8, 13, 14, 21, 31, 31, 35, 37, 41, 41, 45, 49, 55, 61, 63, 67, 71, 72, 73, 73, 76, 76, 76, 77, 80, 81, 81, 90, 90, 92, 94, 94, 97, 99,
3. compare times: 148, swap times: 148;
1, 5, 8, 13, 14, 21, 31, 31, 35, 37, 41, 41, 45, 49, 55, 61, 63, 67, 71, 72, 73, 73, 76, 76, 76, 77, 80, 81, 81, 90, 90, 92, 94, 94, 97, 99,
4. compare times: 139, swap times: 139;
1, 5, 8, 13, 14, 21, 31, 31, 35, 37, 41, 41, 45, 49, 55, 61, 63, 67, 71, 72, 73, 73, 76, 76, 76, 77, 80, 81, 81, 90, 90, 92, 94, 94, 97, 99,
5. compare times: 167, swap times: 167;
1, 5, 8, 13, 14, 21, 31, 31, 35, 37, 41, 41, 45, 49, 55, 61, 63, 67, 71, 72, 73, 73, 76, 76, 76, 77, 80, 81, 81, 90, 90, 92, 94, 94, 97, 99,


0-995025, 1-248630, 3-656468, 7-201191, 15-646930, 31-17473, 63-614364, 127-872684, 255-554569, 511-440151, 1023-686563, 2047-636255, 4095-953894, 8191-679250, 16383-934987, 32767-563817, 65535-327444,
1. 希尔增量，      compare times: 8426992, swap times: 8426992;
0-7, 1-11, 3-34, 7-96, 15-207, 31-469, 63-870, 127-1713, 255-3504, 511-7786, 1023-15242, 2047-31037, 4095-62696, 8191-127674, 16383-253264, 32767-502582, 65535-999998,
2. Knuth增量，     compare times: 2312910, swap times: 2312910;
0-7, 1-11, 3-34, 7-96, 15-207, 31-469, 63-870, 127-1713, 255-3504, 511-7786, 1023-15242, 2047-31037, 4095-62696, 8191-127674, 16383-253264, 32767-502582, 65535-999998,
3. Hibbard增量，   compare times: 11370424, swap times: 11370424;
0-7, 1-11, 3-34, 7-96, 15-207, 31-469, 63-870, 127-1713, 255-3504, 511-7786, 1023-15242, 2047-31037, 4095-62696, 8191-127674, 16383-253264, 32767-502582, 65535-999998,
4. Sedgewick增量1，compare times: 1820963, swap times: 1820963;
0-7, 1-11, 3-34, 7-96, 15-207, 31-469, 63-870, 127-1713, 255-3504, 511-7786, 1023-15242, 2047-31037, 4095-62696, 8191-127674, 16383-253264, 32767-502582, 65535-999998,
5. Sedgewick增量2，compare times: 1299050, swap times: 1299050;
0-7, 1-11, 3-34, 7-96, 15-207, 31-469, 63-870, 127-1713, 255-3504, 511-7786, 1023-15242, 2047-31037, 4095-62696, 8191-127674, 16383-253264, 32767-502582, 65535-999998,


第3次测试
42, 8, 65, 43, 80, 25, 40, 5, 79, 58, 33, 33, 12, 15, 86, 62, 69, 0, 92, 95, 31, 93, 1, 13, 86, 3, 88, 70, 40,
1. compare times: 95, swap times: 95;
0, 1, 3, 5, 8, 12, 13, 15, 25, 31, 33, 33, 40, 40, 42, 43, 58, 62, 65, 69, 70, 79, 80, 86, 86, 88, 92, 93, 95,
1. compare times: 112, swap times: 112;
0, 1, 3, 5, 8, 12, 13, 15, 25, 31, 33, 33, 40, 40, 42, 43, 58, 62, 65, 69, 70, 79, 80, 86, 86, 88, 92, 93, 95,
3. compare times: 119, swap times: 119;
0, 1, 3, 5, 8, 12, 13, 15, 25, 31, 33, 33, 40, 40, 42, 43, 58, 62, 65, 69, 70, 79, 80, 86, 86, 88, 92, 93, 95,
4. compare times: 122, swap times: 122;
0, 1, 3, 5, 8, 12, 13, 15, 25, 31, 33, 33, 40, 40, 42, 43, 58, 62, 65, 69, 70, 79, 80, 86, 86, 88, 92, 93, 95,
5. compare times: 128, swap times: 128;
0, 1, 3, 5, 8, 12, 13, 15, 25, 31, 33, 33, 40, 40, 42, 43, 58, 62, 65, 69, 70, 79, 80, 86, 86, 88, 92, 93, 95,


0-451357, 1-998261, 3-827295, 7-544253, 15-134867, 31-371027, 63-390956, 127-585115, 255-665422, 511-192709, 1023-405874, 2047-780003, 4095-0, 8191-0, 16383-0, 32767-0, 65535-0,
1. 希尔增量，      compare times: 1586715, swap times: 1586715;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-0, 65535-999965,
2. Knuth增量，     compare times: 593350, swap times: 593350;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-0, 65535-999965,
3. Hibbard增量，   compare times: 1917682, swap times: 1917682;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-0, 65535-999965,
4. Sedgewick增量1，compare times: 600812, swap times: 600812;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-0, 65535-999965,
5. Sedgewick增量2，compare times: 403153, swap times: 403153;
0-0, 1-0, 3-0, 7-0, 15-0, 31-0, 63-0, 127-0, 255-0, 511-0, 1023-0, 2047-0, 4095-0, 8191-0, 16383-0, 32767-0, 65535-999965,
*/
