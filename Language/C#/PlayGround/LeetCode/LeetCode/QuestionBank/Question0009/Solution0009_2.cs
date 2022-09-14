using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0009
{
    public class Solution0009_2 : Interface0009
    {
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
