using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0670
{
    public class Solution0670 : Interface0670
    {
        public int MaximumSwap(int num)
        {
            List<int> digits = new List<int>();
            while (num > 0)
            {
                digits.Add(num % 10);
                num /= 10;
            }

            List<int> orderd = digits.OrderBy(i => i).ToList();
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                if (digits[i] == orderd[i]) continue;
                for (int j = 0; j < i; j++)
                {
                    if (digits[j] == orderd[i])
                    {
                        int temp = digits[i]; digits[i] = digits[j]; digits[j] = temp;
                        break;
                    }
                }
                break;
            }

            int result = 0;
            for (int i = digits.Count - 1; i >= 0; i--)
                result = result * 10 + digits[i];
            return result;
        }
    }
}
