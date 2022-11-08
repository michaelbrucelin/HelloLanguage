using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0029
{
    public class Solution0029_3 : Interface0029
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 1) return dividend;
            if (dividend == 0) return 0;
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;

            int symbol = 1;
            if (dividend > 0) dividend = -dividend; else symbol = -1;
            if (divisor > 0) divisor = -divisor; else symbol *= -1;

            List<int> helper = new List<int>(); helper.Add(divisor);
            int b = divisor;
            while (b >= dividend - b)  // 跳出循环条件：b < dividend
            {
                b <<= 1;
                helper.Add(b);
            }

            int result = 0;
            for (int i = helper.Count - 1; i >= 0; i--)
            {
                if (helper[i] > dividend)
                {
                    result += (1 << i); dividend -= helper[i];
                }
                else if (helper[i] == dividend)
                {
                    result += (1 << i); dividend -= helper[i];
                    break;
                }
            }

            return symbol * result;
        }
    }
}
