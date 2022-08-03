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
    public partial class Section11 : Form
    {
        public Section11()
        {
            InitializeComponent();
        }

        private void Section11_Load(object sender, EventArgs e)
        {
            string info = @"锁的共用问题，如果多个任务共用一个锁，多个任务会相互阻塞，则会将多个任务变成一个线程，
                                第一个任务完成后在进行第二个任务，如果想要多个任务并行执行，则需要每个任务独立使用一个锁；
                            所以声明锁建议声明为私有的，而不是公共的，避免锁被其他地方的代码访问并使用；";
        }

        // 声明两个锁
        private static readonly object LOCK1 = new object();
        private static readonly object LOCK2 = new object();

        /// <summary>
        /// 这里任务1和任务2都是用LOCK1来锁，会导致任务1与任务2执行到锁的位置时，变成单线程；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSameLock_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // 任务1
            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCK1)
                    {
                        Console.WriteLine($"Task1-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"Task1-[{j}] lock  end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }

            // 任务2
            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCK1)
                    {
                        Console.WriteLine($"Task2-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"Task2-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }

        /// <summary>
        /// 这里任务1和任务2各自使用独立的锁，任务1和任务2并行执行，每一把锁只是使当前任务到达锁的位置时变成单线程；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiffLock_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // 任务1
            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCK1)
                    {
                        Console.WriteLine($"Task1-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"Task1-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }

            // 任务2
            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCK2)
                    {
                        Console.WriteLine($"Task2-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"Task2-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }

        /// <summary>
        /// 这里展示了当锁声明为public时，在自己的类中和另一个类中同时引用锁，导致两个任务相互阻塞，无法并行的情形；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublicLock_Click(object sender, EventArgs e)
        {
            // 任务1
            MyTestLock.StartTaskPublic("Task1");

            // 任务2
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (MyTestLock.LOCKPublic)
                    {
                        Console.WriteLine($"Task2-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"Task2-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }

    public class MyTestLock
    {
        public static readonly object LOCKPublic = new object();

        public static void StartTaskPublic(string name)
        {
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (LOCKPublic)
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
