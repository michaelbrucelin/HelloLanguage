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

            var list2 = CountSort2(list);

            Console.WriteLine();
            for (int i = 0; i < list2.Count; i++)
                Console.Write($"{list2[i]}, ");
        }

        /// <summary>
        /// 计数排序
        /// 不稳定排序版本
        /// 计数排序只适用于整数序列，而且序列中的最大值与最小值的差距不是很大的场景
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<int> CountSort(IList<int> list)
        {
            int min = list[0], max = list[0];
            foreach (int i in list)
            {
                if (i < min)
                    min = i;
                else if (i > max)
                    max = i;
            }

            int distance = max - min;
            int[] count_arr = new int[distance + 1];  // C#中整型数组默认全为0，不需要初始化
            foreach (int i in list)
            {
                count_arr[i - min]++;
            }

            IList<int> result = new List<int>(list.Count);
            for (int i = 0; i < count_arr.Length; i++)
            {
                for (int j = 0; j < count_arr[i]; j++)
                {
                    result.Add(min + i);
                }
            }

            return result;
        }

        /// <summary>
        /// 计数排序
        /// 稳定排序版本
        /// 非稳定排序版本中的count_arr，每一个元素表示原素组中这个位置对应的值一共有多少个
        /// 此版本中的count_arr，每一个元素表示原数组中这个位置对应的值前面一共有多少（N）个值（准确说是N+1）
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<int> CountSort2(IList<int> list)
        {
            if (list.Count == 1) return list;

            int min = list[0], max = list[0];
            foreach (int i in list)
            {
                if (i < min)
                    min = i;
                else if (i > max)
                    max = i;
            }
            if (min == max) return list;

            int distance = max - min;
            int[] count_arr = new int[distance + 1];    // C#中整型数组默认全为0，不需要初始化
            foreach (int i in list)
            {
                count_arr[i - min]++;
            }

            for (int i = 1; i < count_arr.Length; i++)  // 重新构建count_arr，以实现稳定排序
            {
                count_arr[i] += count_arr[i - 1];
            }

            IList<int> result = new List<int>(list.Count);
            for (int i = 0; i < list.Count; i++) result.Add(int.MinValue);  // 初始化，否则下面只能使用Add()，而无法使用索引

            for (int i = list.Count - 1; i >= 0; i--)
            {
                result[count_arr[list[i] - min] - 1] = list[i];
                count_arr[list[i] - min]--;
            }

            return result;
        }
    }
}
