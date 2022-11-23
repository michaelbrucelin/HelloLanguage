using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1742
{
    public class Solution1742_3 : Interface1742
    {
        /// <summary>
        /// dp
        /// 如果一个数字的末位不是0，那么数字所在盒子都是前一个数字所在盒子的下一个盒子
        /// 如果一个数字的末位是0，那么重新计算一下，因为发生了“进位”
        /// </summary>
        /// <param name="lowLimit"></param>
        /// <param name="highLimit"></param>
        /// <returns></returns>
        public int CountBalls(int lowLimit, int highLimit)
        {
            int[] buffer = new int[46];  // 由题目知，highLimit最大是100000，那么每位数字和最大为45（99999）

            int key = BitSum(lowLimit);
            buffer[key]++;
            for (int i = lowLimit + 1; i <= highLimit; i++)
            {
                if (i % 10 != 0) key++; else key = BitSum(i);
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
