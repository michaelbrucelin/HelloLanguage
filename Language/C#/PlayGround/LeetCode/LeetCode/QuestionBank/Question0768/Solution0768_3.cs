using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0768
{
    public class Solution0768_3
    {
        /// <summary>
        /// 单调栈
        /// 用一个单调栈来记录最终分组每组中的最大值，所以栈一定的单调递减（严格说是不增）的，即stack.Peek() >= stack.Pop().Peek()
        /// 那么逐个元素分析，将分组的最大值在栈中，那么最终栈中的元素数量就是最终分组的数量
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxChunksToSorted(int[] arr)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (stack.Count == 0 || arr[i] >= stack.Peek())       // 此时arr[i]是新的一个分组的最大值
                    stack.Push(arr[i]);
                else                                                  // 此时arr[i]需要合并最后一个分组中
                {
                    int lastgroupmax = stack.Pop();
                    while (stack.Count > 0 && arr[i] < stack.Peek())  // 如果arr[i]比倒数第二个分组（如果存在）的最大值还要小，那么最后两个分组需要合并
                        stack.Pop();                                  // 直到arr[i]大于倒数第二个分组（如果存在）的最大值为止
                    stack.Push(lastgroupmax);
                }
            }

            return stack.Count;
        }
    }
}
