using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0009
{
    public class Solution0009_3 : Interface0009
    {
        /// <summary>
        /// 反转一半的整数，这样既没有转为字符串的内存开销，也不会有整型溢出的情况
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;

            int len = (int)Math.Log10(x) + 1;
            int half = len / 2;
            int y = 0;
            for (int i = 0; i < half; i++)
            {
                y = y * 10 + x % 10;
                x /= 10;
            }
            if ((len & 1) == 1) x /= 10;

            return y == x;
        }
    }
}
