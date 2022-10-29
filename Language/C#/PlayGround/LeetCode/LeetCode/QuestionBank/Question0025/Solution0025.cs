using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0025
{
    public class Solution0025 : Interface0025
    {
        /// <summary>
        /// 题目提示“设计一个只用 O(1) 额外内存空间的算法解决此问题”，这里就不借助栈O(k)，直接迭代试试
        /// 使用尾插法，假设k=3
        /// pre
        /// tail     head
        /// dummy    1     2     3     4     5
        /// # 我们用tail 移到要翻转的部分最后一个元素
        /// pre      head        tail
        /// dummy    1     2     3     4     5
        ///          cur
        /// # 我们尾插法的意思就是,依次把cur移到tail后面
        /// pre            tail  head
        /// dummy    2     3     1     4     5
        ///          cur
        /// # 依次类推
        /// pre      tail        head
        /// dummy    3     2     1     4     5
        ///          cur
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null) return null;

            ListNode dummy = new ListNode(); dummy.next = head;
            ListNode ptr_dummy = dummy, ptr; int i;
            while (ptr_dummy.next != null)
            {
                for (i = 1, ptr = ptr_dummy.next; i < k && ptr != null; i++, ptr = ptr.next) { }
                if (i < k || ptr == null) break;
                var info = ReverseLinkedList(ptr_dummy.next, ptr);
                ptr_dummy.next = info.head;
                ptr_dummy = info.tail;
            }

            return dummy.next;
        }

        private (ListNode head, ListNode tail) ReverseLinkedList(ListNode head, ListNode tail)
        {
            ListNode ptr = head;
            while (ptr != tail)
            {
                ListNode ptr_next = ptr.next;
                ptr.next = tail.next;
                tail.next = ptr;
                ptr = ptr_next;
            }

            return (tail, head);
        }
    }
}
