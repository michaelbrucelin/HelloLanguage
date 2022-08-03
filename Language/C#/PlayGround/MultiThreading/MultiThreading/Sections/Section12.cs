using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Section12 : Form
    {
        public Section12()
        {
            InitializeComponent();
        }

        private void Section12_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 这里锁声明为static类型，锁是类的成员，而不是实例的成员，所以相互阻塞，不再并行；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatic_Click(object sender, EventArgs e)
        {
            // 任务1
            MyTestLockStatic testLock1 = new MyTestLockStatic();
            testLock1.StartTaskStatic("Task1");

            // 任务2
            MyTestLockStatic testLock2 = new MyTestLockStatic();
            testLock2.StartTaskStatic("Task2");
        }

        /// <summary>
        /// 这里虽然两次调用同一个方法，使用的同一个锁，但是两个任务是并行的，这是因为锁是实例类型，两次调用使用的是两个不同的实例化后的锁，所以并行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstance_Click(object sender, EventArgs e)
        {
            // 任务1
            MyTestLockStatic testLock1 = new MyTestLockStatic();
            testLock1.StartTaskNotStatic("Task1");

            // 任务2
            MyTestLockStatic testLock2 = new MyTestLockStatic();
            testLock2.StartTaskNotStatic("Task2");
        }

        private static readonly string LOCKStringNew = "否极泰来";
        /// <summary>
        /// .Net中string具有不可变性，是享元的，只要值一样，无论声明多少次，那么在堆中都是同一个对象；
        /// 这里的3个任务，尽管使用的3个不同的锁变量，但是仍然相互阻塞了，并没有并行执行，
        /// 锁锁定的是内存的引用，由于3个锁的字符串值一样，所以尽管是3个不同的锁变量，但是由于字符串的“享元”特性，锁的却是内存上的同一个引用，所以3个任务相互阻塞，就相当于是一个锁了；
        /// 将3个锁中任何一个锁的字符串值改一下，3个任务就可以并行了；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSameString_Click(object sender, EventArgs e)
        {
            // 任务1
            MyTestLockString testLock1 = new MyTestLockString();
            testLock1.StartTaskString("Task1");

            // 任务2
            MyTestLockString testLock2 = new MyTestLockString();
            testLock2.StartTaskString("Task2");

            // 任务3
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCKStringNew)
                    {
                        Console.WriteLine($"Task3-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"Task3-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }

        private static readonly string LOCKStringNew2 = string.Copy("否极泰来");
        /// <summary>
        /// 使用不同的字符串，当然就是不同的锁了，使用string.Copy()可以创建字面量相同的两个不同的字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiffString_Click(object sender, EventArgs e)
        {
            // 任务1
            MyTestLockString testLock1 = new MyTestLockString();
            testLock1.StartTaskString("Task1");

            // 任务2
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCKStringNew2)
                    {
                        Console.WriteLine($"Task2-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"Task2-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }

        /// <summary>
        /// 静态变量全局唯一，并不是十分准确，当静态变量在泛型类中时，同一参数类型的多个泛型类下，该静态变量时唯一的，但是在不同类型参数的多个泛型类下，静态变量不唯一；
        /// 这里的任务1和任务2相互阻塞，不能并行执行，因为两个泛型类的参数是同一个数据类型，即是同一个类，静态锁也就是同一个锁，所以任务1和任务2相互阻塞，不能并行执行；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSameGenerics_Click(object sender, EventArgs e)
        {
            MyTestLockGeneric<int>.StartTaskPublic("Task1");
            MyTestLockGeneric<int>.StartTaskPublic("Task2");
        }

        /// <summary>
        /// 静态变量全局唯一，并不是十分准确，当静态变量在泛型类中时，同一参数类型的多个泛型类下，该静态变量时唯一的，但是在不同类型参数的多个泛型类下，静态变量不唯一；
        /// 这里的任务1和任务2可以并行执行，因为两个泛型类的参数是不同的数据类型，即不是同一个类，静态锁也就不是同一个锁，所以任务1和任务2可以并行执行；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiffGenerics_Click(object sender, EventArgs e)
        {
            MyTestLockGeneric<int>.StartTaskPublic("Task1");
            MyTestLockGeneric<Random>.StartTaskPublic("Task2");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }

    public class MyTestLockStatic
    {
        private readonly object LOCKNotStatic = new object();

        public void StartTaskNotStatic(string name)
        {
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCKNotStatic)
                    {
                        Console.WriteLine($"{name}-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"{name}-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }

        private readonly static object LOCKStatic = new object();

        public void StartTaskStatic(string name)
        {
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCKStatic)
                    {
                        Console.WriteLine($"{name}-[{j}] start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"{name}-[{j}]   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }
    }

    public class MyTestLockString
    {
        private readonly string LOCKString = "否极泰来";

        public void StartTaskString(string name)
        {
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCKString)
                    {
                        Console.WriteLine($"{name}-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"{name}-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }
    }

    public class MyTestLockGeneric<T>
    {
        private static readonly object LOCK = new object();

        public static void StartTaskPublic(string name)
        {
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCK)
                    {
                        Console.WriteLine($"{name}-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"{name}-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }
    }
}
