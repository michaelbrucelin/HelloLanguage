using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program_2_1_25 : SortTemplate
    {
        // public static void Main(string[] args)
        // {
        //     Program_2_1_25 insertion = new Program_2_1_25();
        // 
        //     // insertion.Test();
        //     // insertion.Verify();
        //     insertion.Test2();
        // 
        //     /*
        //     Exch:            0.8840000000000007
        //     NotExch:         0.6270000000000003
        //     
        //     Exch:            5.3709999999999924
        //     NotExch:         3.966999999999986
        //     
        //     Exch:            2.7669999999999924
        //     NotExch:         2.045999999999995
        //     
        //     Exch:            3.854999999999994
        //     NotExch:         2.969999999999994
        //     
        //     Exch:            1.7079999999999977
        //     NotExch:         1.1829999999999992
        //     
        //     Exch:            3.483999999999996
        //     NotExch:         2.6319999999999935
        //     
        //     Exch:            1.6979999999999975
        //     NotExch:         1.2329999999999997
        //     
        //     Exch:            0.9330000000000006
        //     NotExch:         0.7140000000000004
        //     
        //     Exch:            1.904999999999999
        //     NotExch:         1.3309999999999997
        //     
        //     Exch:            3.2259999999999844
        //     NotExch:         2.3179999999999903
        //     */
        // }

        public override void Sort<T>(T[] arr)
        {
            SortNotExch<T>(arr);
        }

        /// <summary>
        /// 插入排序  普通版，每次比较都进行交换
        /// 通常人们整理桥牌的方法是一张一张的来，将每一张牌插入到其他已经有序的牌中的适当位置。
        /// 在计算机的实现中，为了给要插入的元素腾出空间，我们需要将其余所有元素在插入之前都向右移动一位。这种算法叫做插入排序。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void SortExch<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && Less<T>(arr[j], arr[j - 1]); j--)
                    Exch<T>(arr, j, j - 1);
            }
        }

        /// <summary>
        /// 插入排序  不交换版
        /// 将当前元素的值临时存储起来，如果当前元素比前面的元素大，将前面的元素写入当前位置，直到找到合适的位置，将临时存储的元素写入到这个位置。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void SortNotExch<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T t = arr[i];
                int j;
                for (j = i; j > 0 && Less<T>(t, arr[j - 1]); j--)
                    arr[j] = arr[j - 1];  // Exch<T>(arr, j, j - 1);

                if (j != i)
                    arr[j] = t;
            }
        }

        public void Test2()
        {
            Random random = new Random();

            string[] algs = new string[] { "Exch", "NotExch" };

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
            if (alg == "Exch") sortfunc = SortExch;
            else if (alg == "NotExch") sortfunc = SortNotExch;

            Debug.Assert(sortfunc != null);
            watch.Start();
            sortfunc(arr);
            watch.Stop();

            return watch.ElapsedMilliseconds * 1.0D / 1000;
        }
    }
}
