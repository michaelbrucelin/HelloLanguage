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
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");

            CountSort2(arr);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");
        }


        /// <summary>
        /// 计数排序
        /// 不稳定排序版本
        /// 计数排序只适用于整数序列，而且序列中的最大值与最小值的差距不是很大的场景
        /// </summary>
        /// <param name="arr"></param>
        public static void CountSort(int[] arr)
        {
            int min = arr[0], max = arr[0];
            foreach (int i in arr)
            {
                if (i < min)
                    min = i;
                else if (i > max)
                    max = i;
            }

            int distance = max - min;
            int[] count_arr = new int[distance + 1];  // C#中整型数组默认全为0，不需要初始化
            foreach (int i in arr)
            {
                count_arr[i - min]++;
            }

            int index = 0;
            for (int i = 0; i < count_arr.Length; i++)
            {
                for (int j = 0; j < count_arr[i]; j++)
                {
                    arr[index++] = (min + i);
                }
            }
        }

        /// <summary>
        /// 计数排序
        /// 稳定排序版本
        /// 非稳定排序版本中的count_arr，每一个元素表示原数组中这个位置对应的值一共有多少个
        /// 此版本中的count_arr，每一个元素表示原数组中这个位置对应的值前面一共有多少（N）个值（准确说是N-1）
        /// 例如原数组：
        /// [95, 94, 91, 98, 99, 90, 99, 93, 91, 92]
        /// [0   1   2   3   4   5   6   7   8   9 ]
        /// 对应的count_arr：
        /// [1   2   1   1   1   1   0   0   1   2 ]
        /// [1   3   4   5   6   7   7   7   8   10 ]
        /// </summary>
        /// <param name="arr"></param>
        public static void CountSort2(int[] arr)
        {
            if (arr.Length == 1) return;

            int min = arr[0], max = arr[0];
            foreach (int i in arr)
            {
                if (i < min)
                    min = i;
                else if (i > max)
                    max = i;
            }
            if (min == max) return;

            int distance = max - min;
            int[] count_arr = new int[distance + 1];    // C#中整型数组默认全为0，不需要初始化
            foreach (int i in arr)
            {
                count_arr[i - min]++;
            }

            for (int i = 1; i < count_arr.Length; i++)  // 重新构建count_arr，以实现稳定排序
            {
                count_arr[i] += count_arr[i - 1];
            }

            int[] buffer = new int[arr.Length];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                buffer[count_arr[arr[i] - min] - 1] = arr[i];
                count_arr[arr[i] - min]--;
            }

            for (int i = 0; i < arr.Length; i++)
                arr[i] = buffer[i];
        }
    }
}
