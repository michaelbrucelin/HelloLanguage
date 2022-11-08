using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0029
{
    public class Solution0029_2_2 : Interface0029
    {
        /// <summary>
        /// 未完成
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 1) return dividend;
            if (dividend == 0) return 0;
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;

            int symbol = 1;
            if (dividend > 0) dividend = -dividend; else symbol = -1;
            if (divisor > 0) divisor = -divisor; else symbol *= -1;

            int left = 1, right = dividend;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                // TODO 主要是想实现一下“快速乘”，这里的二分查找就不写了
            }
            int result = 0;

            return symbol * result;
        }

        /// <summary>
        /// 自己实现一个乘法，本质上就是加法，这里先将y转为二进制
        /// x * 10101 相当于 x * (16 + 4 + 1)，都是2的幂，就可以通过几次叠加得到
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int Multi(int x, int y)
        {
            if (x == 0 || y == 0) return 0;
            if (x == 1) return y;
            if (y == 1) return x;

            int result = 0;
            int b = x;
            while (y > 0)
            {
                if ((y & 1) == 1) result += b;
                b <<= 1;
                y >>= 1;
            }

            return result;
        }
    }
}
