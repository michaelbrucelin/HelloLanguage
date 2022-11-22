using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0878
{
    public class Solution0878 : Interface0878
    {
        private const int MOD = 1000000007;
        /// <summary>
        /// 二分查找
        /// 假设a <= b
        /// 如果b能被a整除，则忽略b，直接在a中找结果就可以
        /// 如果b不能被a整除，假设a与b的最小公倍数是c，那么小于等于整数k中有k/a + k/b - k/c个能被a或b整除的数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int NthMagicalNumber(int n, int a, int b)
        {
            if (a > b) (a, b) = (b, a);
            if (b % a == 0) return (int)(a * (long)n % MOD);

            int lcm = a * b / GetGCD(a, b);
            long left = a, right = a * (long)n;
            while (left <= right)
            {
                long mid = left + ((right - left) >> 1);
                long cnt_a = mid / a, cnt_b = mid / b, cnt_c = mid / lcm;
                long cnt = cnt_a + cnt_b - cnt_c;
                if (cnt == n)
                    return (int)(Math.Max(Math.Max(a * cnt_a, b * cnt_b), lcm * cnt_c) % MOD);
                else if (cnt > n)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            if ((x & 1) == 0 && (y & 1) == 0)
                return GetGCD(x >> 1, y >> 1) << 1;
            else if ((x & 1) == 0 && (y & 1) == 1)
                return GetGCD(x >> 1, y);
            else if ((x & 1) == 1 && (y & 1) == 0)
                return GetGCD(x, y >> 1);
            else
            {
                if (x > y)
                    return GetGCD(x - y, y);
                else
                    return GetGCD(x, y - x);
            }
        }
    }
}
