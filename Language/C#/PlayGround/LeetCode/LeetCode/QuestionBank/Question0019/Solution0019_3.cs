using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0019
{
    public class Solution0019_3 : Interface0019
    {
        /// <summary>
        /// 借助栈来实现
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            Stack<ListNode> helper = new Stack<ListNode>();
            ListNode p = head;
            while (p != null) { helper.Push(p); p = p.next; }

            for (int i = 0; i < n; i++) p = helper.Pop();
            if (helper.Count == 0) return p.next;
            helper.Pop().next = p.next;

            return head;
        }
    }
}
