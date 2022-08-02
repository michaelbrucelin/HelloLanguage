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
    public partial class Section08 : Form
    {
        public Section08()
        {
            InitializeComponent();
        }

        private void Section08_Load(object sender, EventArgs e)
        {
            string info = "一个稍微复杂的示例，可以保证Task.WaitAny/All一定在TaskFactory.ContinueWhenAny/All后面执行";
        }

        /// <summary>
        /// 这样多执行几次，可以看到Task.WaitAny/All与TaskFactory.ContinueWhenAny/All，谁先谁后完全没有规律
        /// 因为TaskFactory.ContinueWhenAny/All是由一个新的子线程运行的，而Task.WaitAny/All是由主线程运行的，
        /// 本质上谁先谁后就是线程之间运行先后的问题，而线程是由操作系统调度，程序是控制不了的，所以谁先谁后没有规律
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task1")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task2")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task3")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task4")));

            TaskFactory taskFactory = new TaskFactory();
            taskFactory.ContinueWhenAny(tasks.ToArray(), task =>
            {
                Console.WriteLine("{{{0}}}\tTaskFactory.ContinueWhenAny完成了一个线程", Thread.CurrentThread.ManagedThreadId);
            });

            taskFactory.ContinueWhenAll(tasks.ToArray(), task =>
            {
                Console.WriteLine("{{{0}}}\tTaskFactory.ContinueWhenAll所有线程全部完成", Thread.CurrentThread.ManagedThreadId);
            });

            Task.WaitAny(tasks.ToArray());
            Console.WriteLine("Task.WaitAny完成了一个线程");

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Task.WaitAll所有线程全部完成");

            Console.WriteLine("********************Button执行结束********************");
        }

        /// <summary>
        /// 这样写可以保证Task.WaitAny/All一定在TaskFactory.ContinueWhenAny/All后面执行
        /// 真实测试，Task.WaitAll确实一定在TaskFactory.ContinueWhenAll后面执行，
        ///           但是第一次Task.WaitAny总是在TaskFactory.ContinueWhenAny之前执行，
        ///           第二次开始就在之后执行了，不确认为什么，实战中还是少玩票为好
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest2_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task1")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task2")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task3")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task4")));

            TaskFactory taskFactory = new TaskFactory();
            // 注意这里，将TaskFactory加到tasks中了
            tasks.Add(taskFactory.ContinueWhenAny(tasks.ToArray(), task =>
            {
                Console.WriteLine("{{{0}}}\tTaskFactory.ContinueWhenAny完成了一个线程", Thread.CurrentThread.ManagedThreadId);
            }));

            // 注意这里，将TaskFactory加到tasks中了
            tasks.Add(taskFactory.ContinueWhenAll(tasks.ToArray(), task =>
            {
                Console.WriteLine("{{{0}}}\tTaskFactory.ContinueWhenAll所有线程全部完成", Thread.CurrentThread.ManagedThreadId);
            }));

            Task.WaitAny(tasks.ToArray());
            Console.WriteLine("Task.WaitAny完成了一个线程");

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Task.WaitAll所有线程全部完成");

            Console.WriteLine("********************Button执行结束********************");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
