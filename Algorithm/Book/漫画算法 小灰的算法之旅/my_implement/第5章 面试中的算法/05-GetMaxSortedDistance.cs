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

            Console.WriteLine();
            Console.WriteLine($"The max sorted distance is {GetMaxSortedDistance(list)}.");

            list.Sort();
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            Console.WriteLine();
            for (int i = 0; i < list.Count - 1; i++)
                Console.Write($"{list[i + 1] - list[i]}, ");
        }

        /// <summary>
        /// 计算一个列表排序后相邻元素的最大间距
        /// 排序后自然很容易就可以得到结果，这里不排序，仍然可以得到正确的结果
        /// 原理：
        /// 利用桶排序的原理来实现，这里采用有多少个元素，就创建多少个桶
        /// 桶的跨度 = (最大值-最小值)/(桶数-1)，其中最后一个桶只存最大值，为[ ]，其余所有桶均为[ )
        /// 之所以这么设计桶，因为代码更统一，更容易找到每个元素属于那个桶
        /// 注意，桶排序需要对每个桶内部的元素排序，这里不需要，只要拿到每个桶内部元素的最大值与最小值即可
        ///       然后计算每个桶的最大值与右边第一个非空桶的最小值的差值，所有差值的最大值即结果
        /// 简单论证：
        /// 这里采用的是，有多少个元素就创建多少个桶
        ///     首先忽略列表只有一个元素，与所有元素都相等这两种特殊情况
        ///     如果每个桶都有且只有一个元素，那么这时已经完成了排序，按照上面的描述自然得到的就是结果
        ///     如果存在至少一个桶内部含有至少两个元素，则至少有一个桶为空，
        ///         那么这个空桶两侧最靠近的非空桶上面的值，一定大于等于桶的跨度
        ///         而桶内部元素的差值一定小于等于桶的差值
        /// 所以上述的值就是正确的结果
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int GetMaxSortedDistance(IList<int> list)
        {
            if (list.Count == 1) return -1;

            int min = list[0], max = list[0];
            foreach (int i in list)
            {
                if (i < min) min = i;
                if (i > max) max = i;
            }
            if (min == max) return 0;                                               // 所以下面分桶的时候，不会发生所有元素在一个桶中的可能性
                                                                                    // 第一个桶与最后一个桶一定非空，最小值在第一个桶，最大值在最后一个桶

            Bucket[] buckets = new Bucket[list.Count];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = new Bucket();

            decimal span = (max * 1.0m - min) / (list.Count - 1);
            foreach (int i in list)
                buckets[(int)Math.Floor((i - min) / span)].Add(i);

            int maxspan = -1;
            int leftmax = buckets[0].Min;
            // int start = 0;
            // for (; start < buckets.Length && buckets[start].IsEmpty; start++) ;  // 第一个桶一定非空，所以不需要找第一个非空的桶
            for (int i = 1; i < buckets.Length; i++)
            {
                if (buckets[i].IsEmpty)
                    continue;
                else
                {
                    if (buckets[i].Min - leftmax > maxspan)
                        maxspan = buckets[i].Min - leftmax;

                    leftmax = buckets[i].Max;
                }
            }

            return maxspan;
        }
    }

    class Bucket
    {
        private bool isEmpty = true;
        public bool IsEmpty { get { return isEmpty; } }

        private int min;
        public int Min { get { return min; } }

        private int max;
        public int Max { get { return max; } }

        public void Add(int i)
        {
            if (isEmpty)
            {
                isEmpty = false;
                min = i;
                max = i;
            }
            else
            {
                if (i < min) min = i;
                if (i > max) max = i;
            }
        }
    }
}
