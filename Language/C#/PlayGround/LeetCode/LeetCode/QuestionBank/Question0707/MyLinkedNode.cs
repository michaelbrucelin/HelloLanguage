using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0707
{
    public class MyLinkedNode
    {
        public MyLinkedNode(int val, MyLinkedNode prev = null, MyLinkedNode next = null)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
        }

        public int val { get; set; }
        public MyLinkedNode prev { get; set; }
        public MyLinkedNode next { get; set; }
    }
}
