using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0496
{
    public class Solution0496_3
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];

            Dictionary<int, int> dic = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();
            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() < nums2[i]) stack.Pop();
                if (stack.Count == 0)
                    dic.Add(nums2[i], -1);
                else
                    dic.Add(nums2[i], stack.Peek());
                stack.Push(nums2[i]);
            }

            for (int i = 0; i < nums1.Length; i++)
                result[i] = dic[nums1[i]];

            return result;
        }
    }
}
