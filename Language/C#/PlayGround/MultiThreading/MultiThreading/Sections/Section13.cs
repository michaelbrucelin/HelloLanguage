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
    public partial class Section13 : Form
    {
        public Section13()
        {
            InitializeComponent();
        }

        private void Section13_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 在这里虽然两次调用同一个方法，使用的同一个锁，但是两个任务是并行的，这是因为锁就是实例类型自身，两次调用使用的是两个不同的实例，即两个锁是不一样的，所以并行；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThis_Click(object sender, EventArgs e)
        {
            // 任务1
            MyTestLockThis testLock1 = new MyTestLockThis();
            testLock1.StartTaskThis("Task1");

            // 任务2
            MyTestLockThis testLock2 = new MyTestLockThis();
            testLock2.StartTaskThis("Task2");
        }

        /// <summary>
        /// 但是这样就不能并行了，因为这时锁是同一个锁了；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThis2_Click(object sender, EventArgs e)
        {
            // 任务1
            MyTestLockThis testLock = new MyTestLockThis();
            testLock.StartTaskThis("Task1");

            // 任务2
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (testLock)
                    {
                        Console.WriteLine($"Task2-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"Task2-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }

        /// <summary>
        /// 在递归中使用锁，不会死锁；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecursion_Click(object sender, EventArgs e)
        {
            new MyTestLockRecursion().StartTaskRecursive("Task");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }

    public class MyTestLockThis
    {
        public void StartTaskThis(string name)
        {
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int j = i;
                Task.Run(() =>
                {
                    lock (this)
                    {
                        Console.WriteLine($"{name}-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                        Thread.Sleep(random.Next(1000, 4000));
                        Console.WriteLine($"{name}-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");
                    }
                });
            }
        }
    }

    public class MyTestLockRecursion
    {
        private int _maxDepth = 0;
        public void StartTaskRecursive(string name)
        {
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                _maxDepth++;
                int j = i;
                lock (this)
                {
                    Console.WriteLine($"{name,-10}-[{j}] lock start\t{Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(random.Next(1000, 4000));
                    Console.WriteLine($"{name,-10}-[{j}] lock   end\t{Thread.CurrentThread.ManagedThreadId}");

                    if (_maxDepth < 4)
                        StartTaskRecursive($"{name}_{_maxDepth}");
                    else
                        break;
                }
            }
        }
    }
}
