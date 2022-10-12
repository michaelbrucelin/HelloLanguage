using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0817
{
    public class Solution0817 : Interface0817
    {
        public int NumComponents(ListNode head, int[] nums)
        {
            if (nums.Length == 1) return 1;

            HashSet<int> helper = nums.ToHashSet();
            ListNode ptr = head;
            while (ptr != null && (!helper.Contains(ptr.val))) ptr = ptr.next;

            int result = 0;
            bool flag = false;
            while (ptr != null)
            {
                if (helper.Contains(ptr.val)) flag = true;
                else
                {
                    if (flag) result++;
                    flag = false;
                }
                ptr = ptr.next;
            }
            if (flag) result++;

            return result;
        }

        /// <summary>
        /// 注意审题，求的是组件的数量，而不是最长组件的长度
        /// </summary>
        /// <param name="head"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumComponents2(ListNode head, int[] nums)
        {
            if (nums.Length == 1) return 1;
            int result = 1;

            HashSet<int> helper = nums.ToHashSet();
            ListNode ptr = head;
            int temp = 0;
            while (ptr != null)
            {
                if (helper.Contains(ptr.val))
                {
                    temp++;
                    helper.Remove(ptr.val);
                }
                else
                {
                    result = Math.Max(result, temp);
                    temp = 0;

                    if (result >= helper.Count) break;
                }

                ptr = ptr.next;
            }
            result = Math.Max(result, temp);

            return result;
        }
    }
}
