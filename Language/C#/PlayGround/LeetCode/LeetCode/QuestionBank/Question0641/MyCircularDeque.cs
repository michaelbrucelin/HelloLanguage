using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0641
{
    /**
    * Your MyCircularDeque object will be instantiated and called as such:
    * MyCircularDeque obj = new MyCircularDeque(k);
    * bool param_1 = obj.InsertFront(value);
    * bool param_2 = obj.InsertLast(value);
    * bool param_3 = obj.DeleteFront();
    * bool param_4 = obj.DeleteLast();
    * int param_5 = obj.GetFront();
    * int param_6 = obj.GetRear();
    * bool param_7 = obj.IsEmpty();
    * bool param_8 = obj.IsFull();
    */
    public class MyCircularDeque
    {

        public MyCircularDeque(int k)
        {
            this.capacity = k;
            list = new List<int>();
        }

        private int capacity;
        private List<int> list;

        public bool InsertFront(int value)
        {
            if (list.Count >= this.capacity)
                return false;

            list.Insert(0, value);
            return true;
        }

        public bool InsertLast(int value)
        {
            if (list.Count >= this.capacity)
                return false;

            list.Add(value);
            return true;
        }

        public bool DeleteFront()
        {
            if (list.Count == 0)
                return false;

            list.RemoveAt(0);
            return true;
        }

        public bool DeleteLast()
        {
            if (list.Count == 0)
                return false;

            list.RemoveAt(list.Count - 1);
            return true;
        }

        public int GetFront()
        {
            if (list.Count == 0)
                return -1;

            return list[0];
        }

        public int GetRear()
        {
            if (list.Count == 0)
                return -1;

            return list[list.Count - 1];
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public bool IsFull()
        {
            return list.Count >= this.capacity;
        }
    }
}
