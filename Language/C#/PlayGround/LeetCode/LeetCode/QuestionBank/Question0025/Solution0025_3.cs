using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0025
{
    public class Solution0025_3 : Interface0025
    {
        /// <summary>
        /// 栈 + 迭代
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null) return null;

            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode ptr = head, head_new, head_next;
            int i;
            for (i = 1; i < k && ptr != null; i++, ptr = ptr.next) stack.Push(ptr);
            if (i < k || ptr == null) return head;
            head_new = ptr; head_next = ptr.next;
            while (stack.Count > 0) { ptr.next = stack.Pop(); ptr = ptr.next; }
            ptr.next = null;

            ListNode ptr2;
            while (head_next != null)
            {
                ptr2 = head_next;
                for (i = 1; i < k && ptr2 != null; i++, ptr2 = ptr2.next) stack.Push(ptr2);

                if (i < k || ptr2 == null) { ptr.next = head_next; break; }
                ptr.next = ptr2; ptr = ptr.next; head_next = ptr2.next;
                while (stack.Count > 0) { ptr.next = stack.Pop(); ptr = ptr.next; }
                ptr.next = null;
            }

            return head_new;
        }

        /// <summary>
        /// 栈 + 迭代，原始版本
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup2(ListNode head, int k)
        {
            if (head == null) return null;

            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode ptr = head, head_new, head_next;
            int i;
            for (i = 1; i < k && ptr != null; i++, ptr = ptr.next) stack.Push(ptr);
            if (i < k || ptr == null) return head; else { head_new = ptr; head_next = ptr.next; }
            while (stack.Count > 0) { ptr.next = stack.Pop(); ptr = ptr.next; }
            ptr.next = null;

            ListNode ptr2;
            while (head_next != null)
            {
                ptr2 = head_next;
                for (i = 1; i < k && ptr2 != null; i++, ptr2 = ptr2.next) stack.Push(ptr2);

                if (i < k || ptr2 == null) { ptr.next = head_next; break; } else { ptr.next = ptr2; ptr = ptr.next; head_next = ptr2.next; }
                while (stack.Count > 0) { ptr.next = stack.Pop(); ptr = ptr.next; }
                ptr.next = null;
            }

            return head_new;
        }
    }
}
