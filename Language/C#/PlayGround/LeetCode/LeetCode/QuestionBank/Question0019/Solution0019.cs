using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0019
{
    public class Solution0019 : Interface0019
    {
        /// <summary>
        /// 双指针
        /// p1寻找链表的末结尾，p2指向p1前第n+1个节点，删除p2后面的节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode p1 = head;
            int i = 1;
            while (p1.next != null && i < n) { p1 = p1.next; i++; }
            if (i != n) return null;  // 链表长度不够或n<=0
            if (p1.next == null)      // 已经到达秒表结尾
                if (p1 == head) return null; else return head.next;

            p1 = p1.next;
            ListNode p2 = head;
            while (p1.next != null) { p1 = p1.next; p2 = p2.next; }
            p2.next = p2.next.next;

            return head;
        }
    }
}
