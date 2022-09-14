using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0002
{
    public class Solution0002_2 : Interface0002
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();

            ListNode curr = result;
            ListNode zeroNode = new ListNode(0, null);
            int temp = 0;
            while (true)
            {
                if (l1.val + l2.val + temp >= 10)
                {
                    curr.val = l1.val + l2.val + temp - 10;
                    temp = 1;
                }
                else
                {
                    curr.val = l1.val + l2.val + temp;
                    temp = 0;
                }

                if (l1.next == null && l2.next == null)
                {
                    if (temp > 0)
                        curr.next = new ListNode(temp, null);

                    break;
                }
                else
                {
                    l1 = l1.next == null ? zeroNode : l1.next;
                    l2 = l2.next == null ? zeroNode : l2.next;
                    curr.next = new ListNode();
                    curr = curr.next;
                }
            }

            return result;
        }
    }
}
