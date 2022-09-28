using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1709
{
    public class Solution1709 : Interface1709
    {
        /// <summary>
        /// 暴力解，提交会超时
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKthMagicNumber(int k)
        {
            int i = 0;
            while (k > 0)
            {
                i++;
                if (IsMagicNumber(i)) k--;
            }

            return i;
        }

        private bool IsMagicNumber(int num)
        {
            if ((num & 1) == 0) return false;
            while (num > 0 && num % 7 == 0) num /= 7;
            while (num > 0 && num % 5 == 0) num /= 5;
            while (num > 0 && num % 3 == 0) num /= 3;

            return num == 1;
        }
    }
}
