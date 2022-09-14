using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0496
{
    public class Solution0496_2 : Interface0496
    {
        /// <summary>
        /// 在题目的提示下，确实有O(m+n)的解法，只需要针对nums2构建一个字典即可
        /// key是nums2的值，value是nums2后面第一个大于当前值的值，用单调栈即可轻松构造
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];

            Dictionary<int, int> dic = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                dic.Add(nums2[i], -1);

                if (stack.Count == 0 || nums2[i] < stack.Peek())
                    stack.Push(nums2[i]);
                else
                {
                    while (stack.Count > 0 && nums2[i] > stack.Peek())
                        dic[stack.Pop()] = nums2[i];
                    stack.Push(nums2[i]);
                }
            }

            for (int i = 0; i < nums1.Length; i++)
                result[i] = dic[nums1[i]];

            return result;
        }
    }
}
