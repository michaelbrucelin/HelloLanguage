using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2283
{
    public class Solution2283 : Interface2283
    {
        public bool DigitCount(string num)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < 10; i++) buffer.Add(i, 0);
            for (int i = 0; i < num.Length; i++) buffer[num[i] - '0']++;

            for (int i = 0; i < num.Length; i++)
                if (num[i] - '0' != buffer[i]) return false;

            return true;
        }
    }
}
