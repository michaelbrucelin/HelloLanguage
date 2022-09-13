using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0670
{
    public class Solution0670_2 : Interface0670
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MaximumSwap(int num)
        {
            List<int> digits = new List<int>();
            int num2 = num;
            while (num2 > 0)
            {
                digits.Add(num2 % 10);
                num2 /= 10;
            }

            int maxid = 0;
            int id1 = -1, id2 = -1;
            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] > digits[maxid]) maxid = i;                 // 找到第一个最大“位”
                if (digits[i] < digits[maxid]) { id1 = i; id2 = maxid; }  // 找到最后一个比最大“位”小的“位”
            }

            if (id1 >= 0)
            {
                int temp = digits[id1]; digits[id1] = digits[id2]; digits[id2] = temp;

                int result = 0;
                for (int i = digits.Count - 1; i >= 0; i--)
                    result = result * 10 + digits[i];
                return result;
            }

            return num;
        }
    }
}
