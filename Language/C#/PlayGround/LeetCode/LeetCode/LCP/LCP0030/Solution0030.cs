using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0030
{
    public class Solution0030
    {
        public int MagicTower(int[] nums)
        {
            // if (nums.Sum() < 0) return -1;
            long sum = 0;
            for (int i = 0; i < nums.Length; i++) sum += nums[i];
            if (sum < 0) return -1;

            int result = 0;

            long current = 1;
            Queue<int> queue = new Queue<int>(nums);
            Stack<int> stack = new Stack<int>();  // .NetFramework没有内建优先队列，这里用栈简单模拟
            while (queue.Count > 0)
            {
                int value = queue.Dequeue();
                current += value;
                if (value < 0) _Push(stack, value);

                while (current <= 0)
                {
                    if (stack.Count == 0) return -1;

                    int recover = stack.Pop();
                    current -= recover;
                    queue.Enqueue(recover);
                    result++;
                }
            }

            return result;
        }

        private void _Push(Stack<int> stack, int i)
        {
            Stack<int> buffer = new Stack<int>();
            while (stack.Count > 0 && stack.Peek() < i)
                buffer.Push(stack.Pop());

            stack.Push(i);
            while (buffer.Count > 0)
                stack.Push(buffer.Pop());
        }
    }
}
