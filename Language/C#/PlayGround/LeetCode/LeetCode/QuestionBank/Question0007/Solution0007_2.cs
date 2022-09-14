using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0007
{
    public class Solution0007_2 : Interface0007
    {
        public int Reverse(int x)
        {
            int result = 0;

            int i;
            while (x != 0)
            {
                i = x % 10;
                x /= 10;
                try
                {
                    result = checked(result * 10 + i);
                }
                catch (OverflowException)
                {
                    result = 0;
                    break;
                }
            }

            return result;
        }

        public int Reverse2(int x)
        {
            int result = 0;

            while (x != 0)
            {
                if (result < int.MinValue / 10 || result > int.MaxValue / 10)
                {
                    return 0;
                }
                int digit = x % 10;
                x /= 10;
                result = result * 10 + digit;
            }

            return result;
        }
    }
}
