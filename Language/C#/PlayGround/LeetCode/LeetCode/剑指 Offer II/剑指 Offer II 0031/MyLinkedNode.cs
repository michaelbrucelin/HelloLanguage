using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer_II.剑指_Offer_II_0031
{
    /// <summary>
    /// .Net内置的LinkedListNode的Previous与Next属性是只读的，这里简单模拟一个
    /// </summary>
    public class MyLinkedNode<T>
    {
        public MyLinkedNode(T key, T value)
        {
            this.Key = key;
            this.Value = value;
        }

        public T Key;
        public T Value;
        public MyLinkedNode<T> Previous;
        public MyLinkedNode<T> Next;
    }
}
