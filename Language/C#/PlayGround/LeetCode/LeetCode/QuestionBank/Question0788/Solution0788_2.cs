using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0788
{
    public class Solution0788_2 : Interface0788
    {
        private readonly HashSet<int> allRotatedDigits = new HashSet<int>() { 0, 1, 2, 5, 6, 8, 9 };
        private readonly HashSet<int> trueRotatedDigits = new HashSet<int>() { 2, 5, 6, 9 };

        /// <summary>
        /// 暴力解的多线程版
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RotatedDigits(int n)
        {
            int result = 0;
            Parallel.For(1, n + 1, i => { if (IsRotatedDigits(i)) lock (this) { result++; } });

            return result;
        }

        /// <summary>
        /// 暴力解的多线程版  无锁版
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RotatedDigits2(int n)
        {
            bool[] result = new bool[n + 1];
            Parallel.For(1, n + 1, i => { if (IsRotatedDigits(i)) result[i] = true; });

            return result.Count(b => b);
        }

        private bool IsRotatedDigits(int n)
        {
            bool flag = false;
            while (n > 0)
            {
                int i = n % 10;
                if (trueRotatedDigits.Contains(i)) { flag = true; n /= 10; continue; }
                if (!allRotatedDigits.Contains(i)) { return false; }

                n /= 10;
            }

            return flag;
        }
    }
}
