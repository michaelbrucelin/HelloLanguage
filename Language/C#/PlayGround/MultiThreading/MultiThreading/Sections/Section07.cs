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
    public partial class Section07 : Form
    {
        public Section07()
        {
            InitializeComponent();
        }

        private void Section07_Load(object sender, EventArgs e)
        {
            string info = @"这里演示Task.WaitAny()、Task.WaitAll()、TaskFactory.ContinueWhenAny()、TaskFactory.ContinueWhenAll()四个方法，
                            这四个方法之间由于线程的不可预测性，没有先后顺序，但是只要灵活应用，基本上能解决绝大多数多线程业务场景；";
        }

        /// <summary>
        /// 使用Task同时执行多个任务，并等待多个任务的完成
        /// 缺点，在执行Task.WaitAny()与Task.WaitAll()时，主线程会被阻塞，Winform项目会卡界面。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultiJobs_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task1")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task2")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task3")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task4")));

            // 阻塞当前线程，直到任意一个任务完成，由于主线程（UI线程）被阻塞，所以会卡界面
            Task.WaitAny(tasks.ToArray());
            Console.WriteLine("完成了一个线程");

            // 阻塞当前线程，直到所有任务全部都完成，由于主线程（UI线程）被阻塞，所以会卡界面
            // 既需要多线程来提高性能，又需要在所有线程全部完成后才能执行下一步操作时，可以这样使用
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("所有线程全部完成");

            Console.WriteLine("********************Button执行结束********************");
        }

        /// <summary>
        /// 示例1虽然等待了多线程完成，但是卡界面了，这里展示一种既可以等待多线程完成，又不卡界面的方式；
        /// 这里只是展示个小技巧，实战中不要线程套线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultiJobs2_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task1")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task2")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task3")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task4")));

            // 使用一个新的线程作为等待线程，这就意味着方法体中的内容由这个线程去执行
            // 这样即使需要阻塞多线程，也不会卡界面，因为等待线程是这个新的线程，而不是主线程（UI线程）
            // 但是需要注意的是，这个虽然实现了预期效果，但是不是推荐做法：
            //     1、尽量不要线程套线程，因为有更优秀的方法替代，除非你是geek
            //     2、这里的功能全部都是由等待线程（新创建的子线程）完成的，在Winform中子线程是不能操作界面（UI线程）的
            Task.Run(() =>
            {
                // 阻塞当前线程，直到任意一个任务完成，由于等待线程是一个Task线程，所以不会卡界面
                Task.WaitAny(tasks.ToArray());
                Console.WriteLine("完成了一个线程");

                // 阻塞当前线程，直到所有任务全部都完成，由于等待线程是一个Task线程，所以不会卡界面
                // 既需要多线程来提高性能，又需要在所有线程全部完成后才能执行下一步操作时，可以这样使用
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("所有线程全部完成");
            });

            Console.WriteLine("********************Button执行结束********************");
        }

        /// <summary>
        /// 这个是示例1卡界面问题的正确解决方式，示例2只是一个小聪明，不可取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultiJobs3_Click(object sender, EventArgs e)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task1")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task2")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task3")));
            tasks.Add(Task.Run(() => Utils.DoSomethingLong("Task4")));

            TaskFactory taskFactory = new TaskFactory();
            // 等待任一任务完成后，启动一个新的Task来完成后续动作，与Action.BeginInvoke的回调函数基本一致
            taskFactory.ContinueWhenAny(tasks.ToArray(), task =>
            {
                Console.WriteLine("{{{0}}}\t完成了一个线程", Thread.CurrentThread.ManagedThreadId);
            });

            // 等待全部任务完成后，启动一个新的Task来完成后续动作，与Action.BeginInvoke的回调函数基本一致
            taskFactory.ContinueWhenAll(tasks.ToArray(), task =>
            {
                Console.WriteLine("{{{0}}}\t所有线程全部完成", Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("********************Button执行结束********************");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
