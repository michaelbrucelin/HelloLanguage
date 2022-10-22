using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0024
{
    public class Solution0024_4 : Interface0024
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode header = new ListNode();
            ListNode ptr1 = header, ptr2 = head;

            Stack<ListNode> stack = new Stack<ListNode>();
            while (ptr2 != null && ptr2.next != null)
            {
                stack.Push(ptr2); ptr2 = ptr2.next;
                stack.Push(ptr2); ptr2 = ptr2.next;
                ptr1.next = stack.Pop(); ptr1 = ptr1.next;
                ptr1.next = stack.Pop(); ptr1 = ptr1.next;
            }
            ptr1.next = ptr2;

            return header.next;
        }
    }
}
