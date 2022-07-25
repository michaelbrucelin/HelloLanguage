using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program_2_1_24 : SortTemplate
    {
        // public static void Main(string[] args)
        // {
        //     Program_2_1_24 insertion = new Program_2_1_24();
        // 
        //     // insertion.Test();
        //     // insertion.Verify();
        //     insertion.Test2();
        // 
        //     /*
        //     WithoutSentinel: 4.001999999999997
        //     WithSentinel:    3.890999999999996
        //     
        //     WithoutSentinel: 0.3380000000000001
        //     WithSentinel:    0.24100000000000008
        //     
        //     WithoutSentinel: 1.426
        //     WithSentinel:    1.3789999999999996
        //     
        //     WithoutSentinel: 2.6829999999999954
        //     WithSentinel:    2.627999999999993
        //     
        //     WithoutSentinel: 1.9929999999999948
        //     WithSentinel:    1.9179999999999957
        //     
        //     WithoutSentinel: 1.5539999999999978
        //     WithSentinel:    1.5529999999999984
        //     
        //     WithoutSentinel: 2.023999999999998
        //     WithSentinel:    1.9209999999999967
        //     
        //     WithoutSentinel: 2.0859999999999883
        //     WithSentinel:    1.9139999999999922
        //     
        //     WithoutSentinel: 2.3809999999999936
        //     WithSentinel:    2.2709999999999972
        //     
        //     WithoutSentinel: 0.8970000000000006
        //     WithSentinel:    0.8000000000000005
        //     */
        // }

        public override void Sort<T>(T[] arr)
        {
            SortWithSentinel(arr);
        }

        /// <summary>
        /// 插入排序  普通版，无哨兵
        /// 通常人们整理桥牌的方法是一张一张的来，将每一张牌插入到其他已经有序的牌中的适当位置。
        /// 在计算机的实现中，为了给要插入的元素腾出空间，我们需要将其余所有元素在插入之前都向右移动一位。这种算法叫做插入排序。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void SortWithoutSentinel<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && Less<T>(arr[j], arr[j - 1]); j--)
                    Exch<T>(arr, j, j - 1);
            }
        }

        /// <summary>
        /// 插入排序  哨兵版
        /// 在插入排序的实现中先找出最小的元素并将其置于数组的最左边，这样就能去掉内循环的判断条件j>0。
        /// 注意：这是一种常见的规避边界测试的方法，能够省略判断条件的元素通常被称为哨兵。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void SortWithSentinel<T>(T[] arr) where T : IComparable
        {
            // 先找出最小的元素并放到数组的最左边
            int minid = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (Less<T>(arr[i], arr[minid]))
                    minid = i;
            }
            if (minid != 0)
                Exch<T>(arr, 0, minid);

            // 插入排序
            for (int i = 2; i < arr.Length; i++)
            {
                for (int j = i; Less<T>(arr[j], arr[j - 1]); j--)  // 已经知道arr[0]是数组的最小的元素，所以不需要j>0这个条件了
                    Exch<T>(arr, j, j - 1);
            }
        }

        public void Test2()
        {
            Random random = new Random();

            string[] algs = new string[] { "WithoutSentinel", "WithSentinel" };

            int N = random.Next(1024, 2048);
            int T = random.Next(256, 512);

            Compare2(algs, N, T);
        }

        /// <summary>
        /// 多轮比较，不同算法之间的数组是一致的，尽可能达到测试的准确
        /// </summary>
        /// <param name="algs"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        public void Compare2(string[] algs, int N, int T)
        {
            double[] result = TimeRandomInput(algs, N, T);

            for (int i = 0; i < algs.Length; i++)
                Console.WriteLine($"{algs[i] + ":",-17}{result[i]}");
        }

        /// <summary>
        /// 多个算法多轮测试
        /// </summary>
        /// <param name="algs"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        /// <returns></returns>
        public double[] TimeRandomInput(string[] algs, int N, int T)
        {
            double[] total = new double[algs.Length];

            Random random = new Random();
            double[] arr = new double[N];

            for (int t = 0; t < T; t++)
            {
                Parallel.For(0, N, i => arr[i] = random.NextDouble());

                for (int i = 0; i < algs.Length; i++)
                {
                    double[] arrtmp = arr.ToArray();
                    total[i] += Time(algs[i], arrtmp);
                }
            }

            return total;
        }

        public double Time<T>(string alg, T[] arr) where T : IComparable
        {
            Stopwatch watch = new Stopwatch();

            Action<T[]> sortfunc = null;
            if (alg == "WithoutSentinel") sortfunc = SortWithoutSentinel;
            else if (alg == "WithSentinel") sortfunc = SortWithSentinel;

            Debug.Assert(sortfunc != null);
            watch.Start();
            sortfunc(arr);
            watch.Stop();

            return watch.ElapsedMilliseconds * 1.0D / 1000;
        }
    }
}
