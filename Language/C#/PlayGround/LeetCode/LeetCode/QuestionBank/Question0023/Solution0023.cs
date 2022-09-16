using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0023
{
    public class Solution0023 : Interface0023
    {
        /// <summary>
        /// 按照各个链表的头结点排序，取第一个链表的头结点
        ///     如果第一个链表到达末尾，移除这一项
        ///     否则按照头结点排序，继续，注意，这时已知后面节点已经有序，可以只对第一个链表向后执行插入排序即可
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            List<ListNode> list = lists.Where(node => node != null).OrderBy(node => node.val).ToList();
            if (list.Count == 0) return null;
            if (list.Count == 1) return list[0];

            ListNode header = new ListNode();
            ListNode pointer = header;
            while (list.Count > 0)
            {
                pointer.next = list[0];
                pointer = list[0];

                if (list[0].next == null)
                {
                    list.RemoveAt(0);
                }
                else
                {
                    list[0] = list[0].next;
                    for (int i = 1; i < list.Count; i++)  // 插入排序将list[0]插入到合适的位置
                        if (list[i - 1].val > list[i].val) Swap(list, i - 1, i); else break;
                }
            }

            return header.next;
        }

        private void Swap(IList<ListNode> list, int i, int j)
        {
            ListNode temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
