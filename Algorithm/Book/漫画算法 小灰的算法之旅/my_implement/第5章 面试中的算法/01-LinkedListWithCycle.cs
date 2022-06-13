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
            Node node1 = new Node(1);
            Node node2 = new Node(4);
            Node node3 = new Node(9);
            Node node4 = new Node(16);
            Node node5 = new Node(25);
            Node node6 = new Node(36);
            Node node7 = new Node(49);
            Node node8 = new Node(64);
            Node node9 = new Node(81);
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node8;
            node8.Next = node9;

            Console.WriteLine($"链表中是否有环：{HasCycle(node1)}");
            Console.WriteLine($"链表中环的长度：{CycleLen(node1)}");
            var cyclehead = CycleHead(node1);
            if (cyclehead.index == -1)
                Console.WriteLine($"链表中环起始于：{cyclehead.index}，节点的值为：null");
            else
                Console.WriteLine($"链表中环起始于：{cyclehead.index}，节点的值为：{cyclehead.node.Data}");

            node9.Next = node6;
            Console.WriteLine($"链表中是否有环：{HasCycle(node1)}");
            Console.WriteLine($"链表中环的长度：{CycleLen(node1)}");
            cyclehead = CycleHead(node1);
            if (cyclehead.index == -1)
                Console.WriteLine($"链表中环起始于：{cyclehead.index}，节点的值为：null");
            else
                Console.WriteLine($"链表中环起始于：{cyclehead.index}，节点的值为：{cyclehead.node.Data}");
        }

        /// <summary>
        /// 判断链表中是否有环
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static bool HasCycle(Node header)
        {
            Node walker = header;
            Node runner = header;

            while (runner.Next != null && runner.Next.Next != null)
            {
                runner = runner.Next.Next;
                walker = walker.Next;

                if (runner == walker)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 计算链表中环的长度
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static int CycleLen(Node header)
        {
            Node walker = header;
            Node runner = header;

            while (runner.Next != null && runner.Next.Next != null)
            {
                runner = runner.Next.Next;
                walker = walker.Next;

                if (runner == walker)
                {
                    int len = 0;
                    while (runner != walker || len == 0)
                    {
                        len++;
                        runner = runner.Next.Next;
                        walker = walker.Next;
                    }

                    return len;
                }
            }

            return -1;
        }

        /// <summary>
        /// 计算链表中环的起点
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public static (Node node, int index) CycleHead(Node header)
        {
            Node walker = header;
            Node runner = header;

            while (runner.Next != null && runner.Next.Next != null)
            {
                runner = runner.Next.Next;
                walker = walker.Next;

                if (runner == walker)
                {
                    Node walker2 = header;
                    int stepat = 0;
                    while (walker2 != walker)
                    {
                        stepat++;
                        walker2 = walker2.Next;
                        walker = walker.Next;
                    }

                    return (walker2, stepat);
                }
            }

            return (null, -1);
        }
    }

    /// <summary>
    /// 链表节点
    /// API中有LinkedList与LinkedListNode类，这里为了演示，自定义实现
    /// </summary>
    class Node
    {
        public Node(int data)
        {
            this.Data = data;
        }

        public int Data { get; set; }
        public Node Next { get; set; }
    }
}
