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
            MinStack<int> minstack = new MinStack<int>();
            minstack.Push(4);
            minstack.Push(9);
            minstack.Push(7);
            minstack.Push(2);
            minstack.Push(8);
            minstack.Push(1);
            minstack.Push(3);
            minstack.Push(6);

            while (minstack.Count > 0)
            {
                Console.WriteLine($"minimal element is: {minstack.GetMin()}");
                Console.WriteLine($"the top element is: {minstack.Pop()}");
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// 实现一个最小栈
    /// 该栈除了包含栈的压栈、出栈方法外，还可以以O(1)的时间复杂度获得栈当前的最小值
    /// </summary>
    class MinStack<T> where T : IComparable
    {
        public MinStack()
        {
            this.mainstack = new Stack<T>();
            this.minstack = new Stack<T>();
        }

        private Stack<T> mainstack;
        private Stack<T> minstack;

        public int Count { get { return mainstack.Count; } }

        public void Push(T element)
        {
            mainstack.Push(element);

            if (mainstack.Count == 1 || element.CompareTo(minstack.Peek()) <= 0)
            {
                minstack.Push(element);
            }
        }

        public T Pop()
        {
            if (mainstack.Count == 0)
                throw new Exception("this stack is empty.");

            if (mainstack.Peek().CompareTo(minstack.Peek()) == 0)
                minstack.Pop();

            return mainstack.Pop();
        }

        public T GetMin()
        {
            if (mainstack.Count == 0)
                throw new Exception("this stack is empty.");

            return minstack.Peek();
        }
    }
}
