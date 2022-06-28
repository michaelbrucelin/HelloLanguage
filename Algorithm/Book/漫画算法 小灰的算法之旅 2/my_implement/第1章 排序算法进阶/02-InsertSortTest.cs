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
            // 检验一下两种插入排序的结果，以及每种插入排序比较与交换的次数
            Random random = new Random();
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));

            int[] arr1 = arr.ToArray();
            int[] arr2 = arr.ToArray();

            var r1 = InsertSort(arr1);
            var r2 = InsertSort2(arr2);

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");

            Console.WriteLine($"\n1. compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i < arr1.Length; i++) Console.Write($"{arr1[i]}, ");

            Console.WriteLine($"\n2. compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i < arr2.Length; i++) Console.Write($"{arr2[i]}, ");
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arr"></param>
        public static (int compcnt, int swapcnt) InsertSort(int[] arr)
        {
            int compcnt = 0, swapcnt = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                int insertValue = arr[i], j = i - 1;
                for (; j >= 0 && arr[j] > insertValue; j--)
                {
                    compcnt++;
                    swapcnt++;
                    arr[j + 1] = arr[j];
                }


                if (j + 1 != i)
                {
                    swapcnt++;
                    arr[j + 1] = insertValue;
                }
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 插入排序
        /// 优化，向前找合适的插入位置时，由于前面是有序区，尝试使用类似于二分查找的方式查找插入的位置
        /// 疑问
        ///     不使用二分查找（上面的方式），需要比较n次，赋值n次
        ///     使用二分查找，需要比较log2n次，需要赋值n次，而且多了一次循环（上面比较和赋值是一次循环，而这里比较和赋值是两次循环）
        /// 不确认这个优化到底有没有意义
        /// </summary>
        /// <param name="arr"></param>
        public static (int compcnt, int swapcnt) InsertSort2(int[] arr)
        {
            int compcnt = 0, swapcnt = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                var r = BinarySearch4InsertSort(arr, 0, i - 1, arr[i]);

                int index = r.index;
                compcnt += r.compcnt;
                if (arr[index] == arr[i])
                    for (; index <= i && arr[index] == arr[i]; index++, compcnt++) ;
                else if (arr[index] < arr[i])  // list[index+1]一定大于list[i]，插入的位置是index+1
                    index += 1;
                //else                         // list[index-1]一定小于list[i]，插入的位置是index
                //    index = index;

                if (index < i)
                {
                    int insertValue = arr[i];
                    for (int j = i; j > index; j--)
                    {
                        swapcnt++;
                        arr[j] = arr[j - 1];
                    }

                    swapcnt++;
                    arr[index] = insertValue;
                }
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 二分查找
        /// 为插叙排序写的，即使没有找到要查找的值，也返回最后的结果，因为那里是最接近要查找值的位置，假定为i
        /// 如果位置i的值，就是要查找的值，那么i-1与i+1的值，也有可能是要查找的值
        /// 如果位置i的值比要查找的值小，那么i+1位置的值，一定比要查找的值大（想想为什么？可以用反证法）
        /// 如果位置i的值比要查找的值大，那么i-1位置的值，一定比要查找的值小（想想为什么？可以用反证法）
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static (int index, int compcnt) BinarySearch4InsertSort(int[] arr, int low, int high, int value)
        {
            int compcnt = 0;

            if (low == high) return (low, compcnt);

            int mid = low + (high - low) / 2;
            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (arr[mid] == value)
                {
                    compcnt++;
                    return (mid, compcnt);
                }
                else if (arr[mid] > value)
                {
                    compcnt++;
                    high = mid - 1;
                }
                else  // (list[mid] < value)
                    low = mid + 1;
            }

            if (low == mid + 1)
                return (high, compcnt);
            else
                return (low, compcnt);
        }
    }
}

/*
第1次测试
88, 64, 74, 57, 91, 33, 9, 48, 33, 96, 63, 68, 54, 97, 62, 66, 5, 38, 49, 89, 66, 32, 52, 52, 4, 99, 47, 83, 91, 8, 33, 90, 86,
1. compare times: 271, swap times: 299;
4, 5, 8, 9, 32, 33, 33, 33, 38, 47, 48, 49, 52, 52, 54, 57, 62, 63, 64, 66, 66, 68, 74, 83, 86, 88, 89, 90, 91, 91, 96, 97, 99,
2. compare times: 64, swap times: 299;
4, 5, 8, 9, 32, 33, 33, 33, 38, 47, 48, 49, 52, 52, 54, 57, 62, 63, 64, 66, 66, 68, 74, 83, 86, 88, 89, 90, 91, 91, 96, 97, 99,

第2次测试
4, 26, 38, 18, 20, 33, 70, 59, 5, 5, 38, 71, 59, 67, 79, 80, 24, 49, 22, 38, 55, 23, 16, 96, 34, 4, 79, 91, 11, 94,
1. compare times: 171, swap times: 193;
4, 4, 5, 5, 11, 16, 18, 20, 22, 23, 24, 26, 33, 34, 38, 38, 38, 49, 55, 59, 59, 67, 70, 71, 79, 79, 80, 91, 94, 96,
2. compare times: 46, swap times: 193;
4, 4, 5, 5, 11, 16, 18, 20, 22, 23, 24, 26, 33, 34, 38, 38, 38, 49, 55, 59, 59, 67, 70, 71, 79, 79, 80, 91, 94, 96,

第3次测试
83, 74, 9, 30, 7, 26, 97, 53, 38, 53, 80, 65, 10, 60, 52, 92, 33, 97, 42, 9, 48, 51, 95, 49, 57, 93, 47, 29, 33, 66, 23, 80, 70, 26, 54, 23,
1. compare times: 319, swap times: 352;
7, 9, 9, 10, 23, 23, 26, 26, 29, 30, 33, 33, 38, 42, 47, 48, 49, 51, 52, 53, 53, 54, 57, 60, 65, 66, 70, 74, 80, 80, 83, 92, 93, 95, 97, 97,
2. compare times: 71, swap times: 352;
7, 9, 9, 10, 23, 23, 26, 26, 29, 30, 33, 33, 38, 42, 47, 48, 49, 51, 52, 53, 53, 54, 57, 60, 65, 66, 70, 74, 80, 80, 83, 92, 93, 95, 97, 97,
*/
