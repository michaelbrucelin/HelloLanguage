using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1475
{
    public class Solution1475_2 : Interface1475
    {
        public int[] FinalPrices(int[] prices)
        {
            int[] result = prices.ToArray();

            Stack<int> stack = new Stack<int>();
            for (int i = prices.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() > prices[i]) stack.Pop();

                if (stack.Count == 0)
                {
                    stack.Push(prices[i]);
                    continue;
                }

                if (prices[i] == stack.Peek()) result[i] = 0;
                else
                {
                    result[i] -= stack.Peek();
                    stack.Push(prices[i]);
                }
            }

            return result;
        }
    }
}
