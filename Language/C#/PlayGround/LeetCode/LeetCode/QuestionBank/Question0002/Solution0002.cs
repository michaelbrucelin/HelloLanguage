using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0002
{
    public class Solution0002
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode node_front = new ListNode();

            int temp = 0;
            ListNode node = node_front;
            ListNode node1 = l1;
            ListNode node2 = l2;
            while (node1 != null && node2 != null)
            {
                node.next = new ListNode();
                node = node.next;

                if (node1.val + node2.val + temp < 10)
                {
                    node.val = node1.val + node2.val + temp;
                    temp = 0;
                }
                else
                {
                    node.val = node1.val + node2.val + temp - 10;
                    temp = 1;
                }

                node1 = node1.next;
                node2 = node2.next;
            }

            while (node1 != null)
            {
                node.next = new ListNode();
                node = node.next;

                if (node1.val + temp < 10)
                {
                    node.val = node1.val + temp;
                    temp = 0;
                }
                else
                {
                    node.val = node1.val + temp - 10;
                    temp = 1;
                }

                node1 = node1.next;
            }

            while (node2 != null)
            {
                node.next = new ListNode();
                node = node.next;

                if (node2.val + temp < 10)
                {
                    node.val = node2.val + temp;
                    temp = 0;
                }
                else
                {
                    node.val = node2.val + temp - 10;
                    temp = 1;
                }

                node2 = node2.next;
            }

            if (temp == 1)
            {
                node.next = new ListNode();
                node.next.val = 1;
            }

            return node_front.next;
        }
    }
}
