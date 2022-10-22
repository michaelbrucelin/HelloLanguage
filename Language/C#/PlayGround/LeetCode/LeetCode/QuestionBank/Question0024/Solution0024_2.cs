using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0024
{
    public class Solution0024_2 : Interface0024
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode head_new = head.next;
            head.next = SwapPairs(head_new.next);
            head_new.next = head;

            return head_new;
        }
    }
}
