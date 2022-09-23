using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0707
{
    public class MyLinkedList : Interface0707
    {
        public MyLinkedList()
        {
            length = 0;
            head = null;
            tail = null;
        }

        private int length;
        public int Length { get { return length; } }

        private MyLinkedNode head;
        public MyLinkedNode Head { get { return head; } }

        private MyLinkedNode tail;
        public MyLinkedNode Tail { get { return tail; } }

        public void AddAtHead(int val)
        {
            MyLinkedNode node = new MyLinkedNode(val);
            if (length == 0) head = tail = node;
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
            }

            length++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index <= 0) { AddAtHead(val); return; }
            if (index == length) { AddAtTail(val); return; }
            if (index > length) return;



            MyLinkedNode pointer_prev; int i;
            if (index - 1 <= Length / 2)  // 这里就不使用跳表了，只做简单的优化，索引在前面就从前向后找，索引在后面就从后向前找
            {
                pointer_prev = Head; i = 0;
                while (i < index - 1) { pointer_prev = pointer_prev.next; i++; }
            }
            else
            {
                pointer_prev = Tail; i = Length - 1;
                while (i > index - 1) { pointer_prev = pointer_prev.prev; i--; }
            }
            MyLinkedNode pointer_next = pointer_prev.next;

            MyLinkedNode node = new MyLinkedNode(val);
            node.prev = pointer_prev;
            node.next = pointer_next;
            pointer_prev.next = node;
            pointer_next.prev = node;

            length++;
        }

        public void AddAtTail(int val)
        {
            MyLinkedNode node = new MyLinkedNode(val);
            if (length == 0) head = tail = node;
            else
            {
                node.prev = tail;
                tail.next = node;
                tail = node;
            }

            length++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= length) return;

            if (length == 1) head = tail = null;
            else if (index == 0)
            {
                head = head.next;
                head.prev = null;
            }
            else if (index == length - 1)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                MyLinkedNode pointer; int i;
                if (index <= Length / 2)  // 这里就不使用跳表了，只做简单的优化，索引在前面就从前向后找，索引在后面就从后向前找
                {
                    pointer = Head; i = 0;
                    while (i < index) { pointer = pointer.next; i++; }
                }
                else
                {
                    pointer = Tail; i = Length - 1;
                    while (i > index) { pointer = pointer.prev; i--; }
                }

                pointer.prev.next = pointer.next;
                pointer.next.prev = pointer.prev;
            }

            length--;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= Length) return -1;
            if (index == 0) return Head.val; else if (index == Length - 1) return Tail.val;

            MyLinkedNode pointer; int i;
            if (index <= Length / 2)  // 这里就不使用跳表了，只做简单的优化，索引在前面就从前向后找，索引在后面就从后向前找
            {
                pointer = Head; i = 0;
                while (i < index) { pointer = pointer.next; i++; }
            }
            else
            {
                pointer = Tail; i = Length - 1;
                while (i > index) { pointer = pointer.prev; i--; }
            }

            return pointer.val;
        }
    }
}
