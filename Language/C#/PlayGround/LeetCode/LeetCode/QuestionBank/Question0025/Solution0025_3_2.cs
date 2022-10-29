using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0025
{
    public class Solution0025_3_2 : Interface0025
    {
        /// <summary>
        /// 栈 + 迭代，设置哨兵
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null) return null;

            ListNode dummy = new ListNode(); dummy.next = head;
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode ptr = dummy, ptr_k; int i;
            while (ptr.next != null)
            {
                for (i = 0, ptr_k = ptr.next; i < k && ptr_k != null; i++, ptr_k = ptr_k.next) stack.Push(ptr_k);
                if (i < k) break;
                while (stack.Count > 0) { ptr.next = stack.Pop(); ptr = ptr.next; }
                ptr.next = ptr_k;
            }

            return dummy.next;
        }
    }
}
