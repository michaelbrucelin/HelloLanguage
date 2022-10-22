using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0024
{
    public class Solution0024 : Interface0024
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode header = new ListNode(); header.next = head;
            ListNode ptrPerv = header;
            ListNode ptrA = ptrPerv.next;
            ListNode ptrB = ptrA.next;
            while (true)
            {
                ptrPerv.next = ptrB; ptrA.next = ptrB.next; ptrB.next = ptrA;  // 交换

                if (ptrA.next != null && ptrA.next.next != null)
                {
                    ptrPerv = ptrA; ptrA = ptrPerv.next; ptrB = ptrA.next;     // 移动指针
                }
                else break;
            }

            return header.next;
        }
    }
}
