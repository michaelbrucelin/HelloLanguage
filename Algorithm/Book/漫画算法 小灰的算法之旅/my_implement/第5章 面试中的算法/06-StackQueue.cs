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
            StackQueue<int> stackQueue = new StackQueue<int>();
            stackQueue.EnQueue(1);
            stackQueue.EnQueue(2);
            stackQueue.EnQueue(3);

            Console.WriteLine($"弹出元素：{stackQueue.DeQueue()}");
            Console.WriteLine($"弹出元素：{stackQueue.DeQueue()}");

            stackQueue.EnQueue(4);

            Console.WriteLine($"弹出元素：{stackQueue.DeQueue()}");
            Console.WriteLine($"弹出元素：{stackQueue.DeQueue()}");
        }
    }

    /// <summary>
    /// 用两个栈实现一个队列
    /// 原理：
    /// 栈1只负责压栈操作，正常压栈即可
    /// 栈2只负责弹栈操作，弹栈时
    ///     如果栈2非空，正常弹栈即可
    ///     如果栈2空，栈1非空，将栈1中的元素全部弹栈并压栈到栈2中，然后正常弹栈即可
    ///     如果栈2与栈1同时为空，空栈，抛异常即可
    /// </summary>
    class StackQueue<T>
    {
        public StackQueue()
        {
            stack_in = new Stack<T>();
            stack_out = new Stack<T>();
        }

        private Stack<T> stack_in;
        private Stack<T> stack_out;

        public int Count
        {
            get
            {
                return stack_in.Count + stack_out.Count;
            }
        }

        public void EnQueue(T element)
        {
            stack_in.Push(element);
        }

        public T DeQueue()
        {
            if (this.Count == 0)
                throw new Exception("The queue is empty.");

            if (stack_out.Count == 0)
            {
                while (stack_in.Count > 0)
                    stack_out.Push(stack_in.Pop());
            }

            return stack_out.Pop();
        }
    }
}
