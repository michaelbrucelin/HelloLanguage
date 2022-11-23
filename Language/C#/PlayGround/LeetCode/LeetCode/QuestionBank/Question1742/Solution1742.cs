using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1742
{
    public class Solution1742 : Interface1742
    {
        public int CountBalls(int lowLimit, int highLimit)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = lowLimit; i <= highLimit; i++)
            {
                int key = BitSum(i);
                if (buffer.ContainsKey(key)) buffer[key]++; else buffer.Add(key, 1);
            }

            return buffer.Max(kv => kv.Value);
        }

        private int BitSum(int x)
        {
            int result = 0;
            while (x > 0)
            {
                result += x % 10;
                x /= 10;
            }

            return result;
        }
    }
}
