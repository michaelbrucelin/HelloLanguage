using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0007
{
    public class Solution0007 : Interface0007
    {
        public int Reverse(int x)
        {
            int result = 0;

            int sign = 1;
            if (x < 0)
            {
                sign = -1;
                x *= -1;
            }

            string str_x = new string(x.ToString().Reverse().ToArray()).TrimStart('0');
            if (str_x.Length == 0) str_x = "0";

            try { result = sign * Convert.ToInt32(str_x); }
            catch { }

            return result;
        }
    }
}
