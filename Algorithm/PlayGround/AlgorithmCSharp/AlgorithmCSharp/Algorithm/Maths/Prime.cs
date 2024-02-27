using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmCSharp.Algorithm.Maths
{
    public static class Prime
    {
        /// <summary>
        /// 判断一个正数是否是一个质数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if ((n & 1) == 0) return false;

            int boundary = (int)Math.Floor(Math.Sqrt(n));
            for (int i = 3; i <= boundary; i += 2) if (n % i == 0) return false;

            return true;
        }

        /// <summary>
        /// 返回[1, n]之间的全部质数，埃氏筛，时间复杂度：O(nlog⁡log⁡n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<int> GetPrimes(int n)
        {
            List<int> result = new List<int>();

            bool[] mask = new bool[n]; Array.Fill(mask, true);
            for (int i = 2, boundary = (int)Math.Floor(Math.Sqrt(n)); i < n; i++) if (mask[i])
                {
                    result.Add(i);
                    if (i <= boundary) for (int j = i * i; j < n; j += i)
                        {
                            mask[j] = false;
                        }
                }

            return result;
        }

        /// <summary>
        /// 返回[1, n]之间的全部质数，线性筛，时间复杂度：O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<int> GetPrimes2(int n)
        {
            List<int> result = new List<int>();
            bool[] mask = new bool[n]; Array.Fill(mask, true);
            for (int i = 2; i < n; i++)
            {
                if (mask[i]) result.Add(i);
                for (int j = 0; j < result.Count && i * result[j] < n; j++)
                {
                    mask[i * result[j]] = false;
                    if (i % result[j] == 0) break;
                }
            }

            return result;
        }
    }
}
