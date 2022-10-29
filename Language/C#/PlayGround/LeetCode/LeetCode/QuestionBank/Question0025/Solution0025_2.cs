using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0025
{
    public class Solution0025_2 : Interface0025
    {
        /// <summary>
        /// 栈 + 递归
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null) return null;

            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode ptr = head;
            int i = 1;
            for (; i < k && ptr != null; i++, ptr = ptr.next) stack.Push(ptr);

            if (i < k || ptr == null) return head;
            ListNode head_new = ptr;
            ListNode ptr_rec = head_new.next;
            while (stack.Count > 0) { ptr.next = stack.Pop(); ptr = ptr.next; }
            head.next = ReverseKGroup(ptr_rec, k);

            return head_new;
        }
    }
}
