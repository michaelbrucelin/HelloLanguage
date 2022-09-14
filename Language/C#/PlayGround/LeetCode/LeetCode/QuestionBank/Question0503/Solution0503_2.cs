using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0503
{
    public class Solution0503_2 : Interface0503
    {
        public int[] NextGreaterElements(int[] nums)
        {
            int[] result = new int[nums.Length];
            Array.Fill(result, -1);

            Stack<int> stack = new Stack<int>();
            int N = nums.Length * 2;
            for (int i = 0; i < N - 1; i++)
            {
                int id = i >= nums.Length ? i - nums.Length : i;

                while (stack.Count > 0 && nums[id] > nums[stack.Peek()])
                    result[stack.Pop()] = nums[id];
                stack.Push(id);
            }

            return result;
        }
    }
}
