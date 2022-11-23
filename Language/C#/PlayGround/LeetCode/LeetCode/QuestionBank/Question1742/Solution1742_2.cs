using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1742
{
    public class Solution1742_2 : Interface1742
    {
        public int CountBalls(int lowLimit, int highLimit)
        {
            int[] buffer = new int[46];  // 由题目知，highLimit最大是100000，那么每位数字和最大为45（99999）
            for (int i = lowLimit; i <= highLimit; i++)
            {
                int key = BitSum(i);
                buffer[key]++;
            }

            return buffer.Max();
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
