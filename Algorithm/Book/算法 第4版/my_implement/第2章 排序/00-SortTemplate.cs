using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public abstract class SortTemplate
    {
        //public static void Main(string[] args)
        //{
        //    Shell sortobj = new Shell();

        //    sortobj.Test();
        //    // sortobj.Verify();
        //}

        public void Test(int cnt)
        {
            Random random = new Random();
            IComparable[] arr = new IComparable[cnt];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));

            Show(arr);
            Sort(arr);

            Debug.Assert(IsSorted2(arr));  // Trace.Assert(IsSorted2(arr));
            Show(arr);

            // Verify();
        }

        public void Test()
        {
            Random random = new Random();
            Test(random.Next(29, 43));
        }

        public abstract void Sort<T>(T[] arr) where T : IComparable;

        public bool Less<T>(T v, T w) where T : IComparable
        {
            return v.CompareTo(w) < 0;
        }

        public void Exch<T>(T[] arr, int i, int j) where T : IComparable
        {
            T t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        private void Show<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        /// <summary>
        /// 检验数组是否有序，但是没有检验数组的元素是否与原数组一致
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        private bool IsSorted<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
                if (Less<T>(arr[i], arr[i - 1])) return false;
            return true;
        }

        /// <summary>
        /// 检验数组是否有序，并检验数组的元素是否与原数组一致
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        private bool IsSorted2<T>(T[] arr) where T : IComparable
        {
            T[] arrcopy = arr.ToArray();
            Array.Sort<T>(arrcopy);       // 这里相信API的排序是正确的

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(arrcopy[i]) != 0)
                    return false;
            }

            return true;
        }

        public void Verify()
        {
            int total = 0, yes = 0;

            Random random = new Random();
            int T = random.Next(256, 512);

            List<double[]> errs = new List<double[]>();
            for (int t = 0; t < T; t++)
            {
                int N = random.Next(1024, 2048);
                double[] arr = new double[N];
                Parallel.For(0, N, i => arr[i] = random.NextDouble());

                double[] arrtest = arr.ToArray();
                Sort(arrtest);
                if (IsSorted2<double>(arrtest))
                    yes++;
                else
                    errs.Add(arr);

                total++;
            }

            if (yes == total)
                Console.WriteLine($"共测试{total}次，每次数组长度为1024~2048之间随机，排序全部成功。");
            else
            {
                Console.WriteLine($"共测试{total}次，每次数组长度为1024~2048之间随机，排序成功{yes}次，发生错误的数组如下：");
                errs.ForEach(arr => Show(arr));
            }
        }
    }
}
