using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0023
{
    public class Solution0023_3 : Interface0023
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;
            if (lists.Length == 1) return lists[0];

            return MergeKLists(lists, 0, lists.Count() - 1);
        }

        private ListNode MergeKLists(ListNode[] lists, int left, int right)
        {
            if (left == right) return lists[left];
            if (left > right) return null;

            int mid = left + (right - left) / 2;
            return Merge2Lists(MergeKLists(lists, left, mid), MergeKLists(lists, mid + 1, right));
        }

        private ListNode Merge2Lists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode header = new ListNode();
            ListNode ptr = header, ptr1 = l1, ptr2 = l2;
            while (ptr1 != null && ptr2 != null)
            {
                if (ptr1.val <= ptr2.val) { ptr.next = ptr1; ptr1 = ptr1.next; }
                else { ptr.next = ptr2; ptr2 = ptr2.next; }
                ptr = ptr.next;
            }
            if (ptr1 != null) ptr.next = ptr1;
            if (ptr2 != null) ptr.next = ptr2;

            return header.next;
        }
    }
}
