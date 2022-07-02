using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));

            Node header = LinkedListBuilder(arr);

            Node pointer = header;
            while (pointer != null)
            {
                Console.Write($"{pointer.Value}, ");
                pointer = pointer.Next;
            }

            Console.WriteLine();
            int k = random.Next(1, arr.Length);
            Console.WriteLine($"{k}th from end: {FindKthFromEnd(header, k).Value}");
            Console.WriteLine($"{k}th from end: {FindKthFromEnd2(header, k).Value}");
        }

        /// <summary>
        /// 给你一个链表，但不知道链表的长度，如何找到链表中倒数第k个节点？
        /// 
        /// 这里使用双指针法
        /// 这种解法使用两个指针同时工作，相比于朴素的两次遍历法，程序的实际工作量其实并没有减少，但是在逻辑上，双指针的方法把两次遍历缩减成了一次遍历。
        /// </summary>
        /// <param name="header"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Node FindKthFromEnd(Node header, int k)
        {
            Node p1 = header;
            Node p2 = header;

            // 求倒数第k个节点，p1先走k-1步
            for (int i = 0; i < k - 1; p1 = p1.Next, i++) ;

            // 这时p1与p2一起向前走，当p1走到终点，p1就停留在倒数第k个节点上
            while (p1.Next != null)
            {
                p1 = p1.Next;
                p2 = p2.Next;
            }

            return p2;
        }

        /// <summary>
        /// 给你一个链表，但不知道链表的长度，如何找到链表中倒数第k个节点？
        /// 
        /// 这里使用一个长度为k的队列来实现
        /// 相比于双指针法，这样实现增加了空间复杂度，不一定更好，这里就是写着练习
        /// </summary>
        /// <param name="header"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Node FindKthFromEnd2(Node header, int k)
        {
            Queue<Node> buffer = new Queue<Node>();

            Node pointer = header;
            while (pointer != null)
            {
                if (buffer.Count == k)
                {
                    buffer.Dequeue();
                }

                buffer.Enqueue(pointer);
                pointer = pointer.Next;
            }

            return buffer.Dequeue();
        }

        /// <summary>
        /// 构建一个链表
        /// 可以直接使用.NET内置的LinkedListNode<>与LinkedList<>，这里为了练习，自己简单实现一个
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static Node LinkedListBuilder(int[] arr)
        {
            if (arr.Length == 0) return null;

            Node header = new Node(arr[0]);

            Node pointer = header;
            for (int i = 1; i < arr.Length; i++)
            {
                Node node = new Node(arr[i]);
                pointer.Next = node;
                pointer = node;
            }

            return header;
        }
    }

    /// <summary>
    /// 链表的节点
    /// 可以直接使用.NET内置的LinkedListNode<>与LinkedList<>，这里为了练习，自己简单实现一个
    /// </summary>
    public class Node
    {
        public Node() { }

        public Node(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
