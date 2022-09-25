using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0788
{
    public class Solution0778 : Interface0788
    {
        private readonly HashSet<int> allRotatedDigits = new HashSet<int>() { 0, 1, 2, 5, 6, 8, 9 };
        private readonly HashSet<int> trueRotatedDigits = new HashSet<int>() { 2, 5, 6, 9 };

        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int RotatedDigits(int n)
        {
            int result = 0;
            for (int i = 1; i <= n; i++)
                if (IsRotatedDigits(i)) result++;

            return result;
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
