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
    public partial class Section06 : Form
    {
        public Section06()
        {
            InitializeComponent();
        }

        private void Section06_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// .NetFramework 1.0和1.1时代，使用Thread
        /// Thread的API特别丰富，可以玩的很花哨，但是一般人根本玩不好，主要是因为线程资源是操作系统管理的，响应并不灵敏，所以不好控制
        /// Thread启动线程没有控制，真的可以一个循环启动100W个线程，导致系统死机
        /// Thread就像给了一个四岁小孩一把热武器，威力很大，但是造成的破坏可能更大
        /// thread.Suspend();     // 挂起线程
        /// thread.Resume();      // 恢复线程
        /// thread.Join();        // 等待线程，阻塞（暂停）调用线程，直到子线程销毁或终止
        /// thread.IsBackground;  // 设置前后台线程
        /// thread.Abort();       // 销毁线程
        /// Thread.ResetAbort();  // 将销毁的线程恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThread_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Thread 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            ThreadStart threadStart = () =>
            {
                Console.WriteLine($"This is Thread Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 32).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.Write($"{i} ");
                });
                Console.WriteLine();
                Console.WriteLine($"This is Thread End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };

            Thread thread = new Thread(threadStart);
            thread.Start();

            // 下面的输出在子线程没执行完（甚至还没有开始执行）就输出了，典型的多线程执行现象
            Console.WriteLine($"Thread 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// .NetFramework 2.0时代（新的CLR），使用ThreadPool
        /// ThreadPool，池化资源管理设计思想，线程是一种资源，在Thread时代，每次使用线程，都需要向操作系统申请，使用完后再释放掉；
        /// 池化就是做一个容器，容器提前申请n个线程，当程序需要使用线程时，直接去容器中获取，用完后再放回容器，避免频繁申请和销毁；
        /// 容器管理着每个线程的控制状态（闲置，忙碌等），容器还会根据当前闲置线程的数量，主动申请（扩容）和释放线程资源；
        /// 优点：1、线程复用；2、可以限制最大线程数量
        /// 缺点：API太少了，线程的等待、顺序控制太弱（可以通过MRE，ManualResetEvent控制），影响了实战
        /// API
        /// ThreadPool.GetMaxThreads();
        /// ThreadPool.GetMinThreads();
        /// ThreadPool.SetMaxThreads();
        /// ThreadPool.SetMinThreads();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"ThreadPool 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            WaitCallback waitCallback = o =>
            {
                Console.WriteLine($"This is ThreadPool Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 32).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.Write($"{i} ");
                });
                Console.WriteLine();
                Console.WriteLine($"This is ThreadPool End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };

            ThreadPool.QueueUserWorkItem(waitCallback);

            // 下面的输出在子线程没执行完（甚至还没有开始执行）就输出了，典型的多线程执行现象
            Console.WriteLine($"ThreadPool 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// .NetFramework 3.0时代，使用Task
        /// Task被称之为C#多线程的最佳实践
        /// Task线程全部来自于线程池，同时提供了丰富的api，非常适合开发实战
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTask_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Task 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            Action action = () =>
            {
                Console.WriteLine($"This is Task Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 32).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.Write($"{i} ");
                });
                Console.WriteLine();
                Console.WriteLine($"This is Task End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };

            Task task = new Task(action);
            task.Start();

            // 下面的输出在子线程没执行完（甚至还没有开始执行）就输出了，典型的多线程执行现象
            Console.WriteLine($"Task 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// Parallel可以启动多线程，主线程也参与运算，所以可以节约一个线程
        /// 由于主线程被当成其中一个线程参与了运算，所以相等于多个子线程一起运算，然后阻塞等待子线程全部完成的模型，当然，如果是Winform项目，会卡界面
        /// 
        /// 可以通过ParallelOptions轻松控制最大并发数量
        /// API：Parallel.For()、Parallel.ForEach()、Parallel.Invoke()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnParallel_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Parallel 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            Action action1 = () =>
            {
                Console.WriteLine($"This is Parallel 1 Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i => { Thread.Sleep(1000); Console.WriteLine($"{{1}}=={i}... ..."); });
                Console.WriteLine($"This is Parallel 1 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            Action action2 = () =>
            {
                Console.WriteLine($"This is Parallel 2 Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i => { Thread.Sleep(1000); Console.WriteLine($"{{2}}=={i}... ..."); });
                Console.WriteLine($"This is Parallel 2 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            Action action3 = () =>
            {
                Console.WriteLine($"This is Parallel 3 Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i => { Thread.Sleep(1000); Console.WriteLine($"{{3}}=={i}... ..."); });
                Console.WriteLine($"This is Parallel 3 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };
            Action action4 = () =>
            {
                Console.WriteLine($"This is Parallel 4 Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i => { Thread.Sleep(1000); Console.WriteLine($"{{4}}=={i}... ..."); });
                Console.WriteLine($"This is Parallel 4 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };

            Parallel.Invoke(action1, action2, action3, action4);

            // 下面的输出在Parallel全部执行完的时候输出，其实也好理解，因为主线程作为Parallel的一个子线程参与了运算
            // 可以将整体看成是同步执行，而Parallel的内部是并行执行的
            Console.WriteLine($"Parallel 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        private void btnParallel2_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Parallel 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            Action<int> action = (pid) =>
            {
                Console.WriteLine($"This is Parallel {pid} Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 4).ToList().ForEach(i => { Thread.Sleep(1000); Console.WriteLine($"{{{pid}}}=={i}... ..."); });
                Console.WriteLine($"This is Parallel {pid} End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            };

            Parallel.For(1, 5, action);
            // Parallel.ForEach<int>(Enumerable.Range(1, 4), action);  // 与Parallel.For(1, 5, action)等价

            // 下面的输出在Parallel全部执行完的时候输出，其实也好理解，因为主线程作为Parallel的一个子线程参与了运算
            // 可以将整体看成是同步执行，而Parallel的内部是并行执行的
            Console.WriteLine($"Parallel 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// await/async是个新语法，出现在.NetFramework 4.5中，只是一个语法糖，并不是一个全新的异步多线程方式
        /// async可以单独使用，但是await必须出现在Task前面，且必须和async同时使用；
        /// 语法糖：就是编译器提供的新功能
        /// await/async并不会产生新的线程，但是依托于Task而存在，所以在执行时，也是多线程的；
        /// 
        /// 基本模型
        /// public async Task DoSomeThing()
        /// {
        ///     await Task.Run(() =>
        ///     {
        ///         Console.WriteLine("hello world");
        ///     });
        /// }
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAsyncAwait_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"async+await 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            await Task.Run(() =>
            {
                Console.WriteLine($"This is async+await Start {{{Thread.CurrentThread.ManagedThreadId}}}");
                Enumerable.Range(1, 32).ToList().ForEach(i =>
                {
                    Thread.Sleep(100);
                    Console.Write($"{i} ");
                });
                Console.WriteLine();
                Console.WriteLine($"This is async+await End   {{{Thread.CurrentThread.ManagedThreadId}}}");
            });

            // 下面的输出是在await标记的Task完成后才输出的，而且不卡界面（不卡主线程）
            // 类似于同步编程的方式，异步的执行效果
            Console.WriteLine($"async+await 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
