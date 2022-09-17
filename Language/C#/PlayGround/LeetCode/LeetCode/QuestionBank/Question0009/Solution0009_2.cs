using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0009
{
    public class Solution0009_2 : Interface0009
    {
        /// <summary>
        /// 反转整个数字，但是如果数字很大，反转后可能会溢出
        /// 例如当x为2147483647时，反转整个整数的结果为：-1126087180
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            else if (x < 10)
                return true;
            else
            {
                int y = 0;

                int temp = x;
                while (temp > 0)
                {
                    y = y * 10 + temp % 10;
                    temp /= 10;
                }

                return x == y;
            }
        }
    }
}
