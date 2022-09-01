using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1475
{
    public class Solution1475
    {
        public int[] FinalPrices(int[] prices)
        {
            int[] result = prices.ToArray();

            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                {
                    if (prices[j] <= prices[i])
                    {
                        result[i] -= prices[j];
                        break;
                    }
                }
            }

            return result;
        }
    }
}
