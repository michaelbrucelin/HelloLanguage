using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Utilses
{
    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    public class SinglyListNode
    {
        public int val;
        public SinglyListNode next;
        public SinglyListNode(int val = 0, SinglyListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
