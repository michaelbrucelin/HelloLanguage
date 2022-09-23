using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0707
{
    /// <summary>
    /// Your MyLinkedList object will be instantiated and called as such:
    /// MyLinkedList obj = new MyLinkedList();
    /// int param_1 = obj.Get(index);
    /// obj.AddAtHead(val);
    /// obj.AddAtTail(val);
    /// obj.AddAtIndex(index,val);
    /// obj.DeleteAtIndex(index);
    /// </summary>
    public interface Interface0707
    {
        public int Get(int index);

        public void AddAtHead(int val);

        public void AddAtTail(int val);

        public void AddAtIndex(int index, int val);

        public void DeleteAtIndex(int index);
    }
}
