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
            // 检验一下每种冒泡排序的结果，以及每种冒泡排序比较与交换的次数
            Random random = new Random();
            List<int> list = new List<int>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100)));

            List<int> list1 = list.ToList();
            List<int> list2 = list.ToList();
            List<int> list3 = list.ToList();
            List<int> list4 = list.ToList();

            var r1 = BubbleSort(list1);
            var r2 = BubbleSort2(list2);
            var r3 = BubbleSort3(list3);
            var r4 = BubbleSort4(list4);

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            Console.WriteLine($"\n1. compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i < list1.Count; i++) Console.Write($"{list1[i]}, ");

            Console.WriteLine($"\n2. compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i < list2.Count; i++) Console.Write($"{list2[i]}, ");

            Console.WriteLine($"\n3. compare times: {r3.compcnt}, swap times: {r3.swapcnt};");
            for (int i = 0; i < list3.Count; i++) Console.Write($"{list3[i]}, ");

            Console.WriteLine($"\n4. compare times: {r4.compcnt}, swap times: {r4.swapcnt};");
            for (int i = 0; i < list4.Count; i++) Console.Write($"{list4[i]}, ");
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static (int compcnt, int swapcnt) BubbleSort(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    compcnt++;
                    if (list[j] > list[j + 1])
                    {
                        swapcnt++;
                        swap(list, j, j + 1);
                    }
                }
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 冒泡排序2
        /// 优化：如果某一轮没有发生任何比较，则取消后面所有轮次的比较
        /// </summary>
        /// <param name="list"></param>
        private static (int compcnt, int swapcnt) BubbleSort2(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

            bool flag;  // 如果上一轮没有发生任何比较，flag为true，表示不需要下一轮比较
            for (int i = 0; i < list.Count - 1; i++)
            {
                flag = true;
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    compcnt++;
                    if (list[j] > list[j + 1])
                    {
                        swapcnt++;
                        swap(list, j, j + 1);
                        flag = false;
                    }
                }

                if (flag) break;
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 冒泡排序3
        /// 优化：如果在border往后的元素，没有发生过交换，则border往后的元素是排序好的，
        ///       则下一轮只要比较到border即可（border可能比 list.Count-1-i 要小）
        /// </summary>
        /// <param name="list"></param>
        private static (int compcnt, int swapcnt) BubbleSort3(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

            bool flag;  // 如果上一轮没有发生任何比较，flag为true，表示不需要下一轮比较
            int border = list.Count - 1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                flag = true;
                int tempborder = 0;
                for (int j = 0; j < border; j++)
                {
                    compcnt++;
                    if (list[j] > list[j + 1])
                    {
                        swapcnt++;
                        swap(list, j, j + 1);
                        tempborder = j;
                        flag = false;
                    }
                }
                border = tempborder;

                if (flag) break;
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 冒泡排序4
        /// 优化：与BubbleSort3逻辑一致，取消flag（记录上一轮是否发生交换），
        ///       当已排序的边界到达数组的起始位置，就意味着可以取消以后所有轮次的比较
        /// </summary>
        /// <param name="list"></param>
        private static (int compcnt, int swapcnt) BubbleSort4(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

            int border = list.Count - 1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int tempborder = 0;
                for (int j = 0; j < border; j++)
                {
                    compcnt++;
                    if (list[j] > list[j + 1])
                    {
                        swapcnt++;
                        swap(list, j, j + 1);
                        tempborder = j;
                    }
                }
                border = tempborder;

                if (border <= 0) break;
            }

            return (compcnt, swapcnt);
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
74, 47, 21, 49, 78, 94, 54, 35, 49, 87, 91, 98, 3, 18, 3, 6, 65, 14, 0, 58, 72, 97, 82, 19, 43, 40, 51, 18, 5, 72, 54, 64,
1. compare times: 496, swap times: 263;
0, 3, 3, 5, 6, 14, 18, 18, 19, 21, 35, 40, 43, 47, 49, 49, 51, 54, 54, 58, 64, 65, 72, 72, 74, 78, 82, 87, 91, 94, 97, 98,
2. compare times: 481, swap times: 263;
0, 3, 3, 5, 6, 14, 18, 18, 19, 21, 35, 40, 43, 47, 49, 49, 51, 54, 54, 58, 64, 65, 72, 72, 74, 78, 82, 87, 91, 94, 97, 98,
3. compare times: 441, swap times: 263;
0, 3, 3, 5, 6, 14, 18, 18, 19, 21, 35, 40, 43, 47, 49, 49, 51, 54, 54, 58, 64, 65, 72, 72, 74, 78, 82, 87, 91, 94, 97, 98,
4. compare times: 441, swap times: 263;
0, 3, 3, 5, 6, 14, 18, 18, 19, 21, 35, 40, 43, 47, 49, 49, 51, 54, 54, 58, 64, 65, 72, 72, 74, 78, 82, 87, 91, 94, 97, 98,

第2次测试
64, 47, 65, 43, 94, 80, 0, 16, 60, 60, 29, 24, 11, 54, 82, 68, 45, 2, 30, 72, 52, 44, 86, 35, 82, 32, 83, 42, 51, 92, 62, 80,
1. compare times: 496, swap times: 216;
0, 2, 11, 16, 24, 29, 30, 32, 35, 42, 43, 44, 45, 47, 51, 52, 54, 60, 60, 62, 64, 65, 68, 72, 80, 80, 82, 82, 83, 86, 92, 94,
2. compare times: 418, swap times: 216;
0, 2, 11, 16, 24, 29, 30, 32, 35, 42, 43, 44, 45, 47, 51, 52, 54, 60, 60, 62, 64, 65, 68, 72, 80, 80, 82, 82, 83, 86, 92, 94,
3. compare times: 388, swap times: 216;
0, 2, 11, 16, 24, 29, 30, 32, 35, 42, 43, 44, 45, 47, 51, 52, 54, 60, 60, 62, 64, 65, 68, 72, 80, 80, 82, 82, 83, 86, 92, 94,
4. compare times: 388, swap times: 216;
0, 2, 11, 16, 24, 29, 30, 32, 35, 42, 43, 44, 45, 47, 51, 52, 54, 60, 60, 62, 64, 65, 68, 72, 80, 80, 82, 82, 83, 86, 92, 94,

第3次测试
16, 96, 4, 82, 55, 66, 79, 16, 45, 68, 68, 16, 18, 0, 62, 95, 4, 76, 85, 36, 18, 47, 4, 86, 20, 51, 43, 10, 22, 91, 86, 65,
1. compare times: 496, swap times: 237;
0, 4, 4, 4, 10, 16, 16, 16, 18, 18, 20, 22, 36, 43, 45, 47, 51, 55, 62, 65, 66, 68, 68, 76, 79, 82, 85, 86, 86, 91, 95, 96,
2. compare times: 468, swap times: 237;
0, 4, 4, 4, 10, 16, 16, 16, 18, 18, 20, 22, 36, 43, 45, 47, 51, 55, 62, 65, 66, 68, 68, 76, 79, 82, 85, 86, 86, 91, 95, 96,
3. compare times: 429, swap times: 237;
0, 4, 4, 4, 10, 16, 16, 16, 18, 18, 20, 22, 36, 43, 45, 47, 51, 55, 62, 65, 66, 68, 68, 76, 79, 82, 85, 86, 86, 91, 95, 96,
4. compare times: 429, swap times: 237;
0, 4, 4, 4, 10, 16, 16, 16, 18, 18, 20, 22, 36, 43, 45, 47, 51, 55, 62, 65, 66, 68, 68, 76, 79, 82, 85, 86, 86, 91, 95, 96,
*/
