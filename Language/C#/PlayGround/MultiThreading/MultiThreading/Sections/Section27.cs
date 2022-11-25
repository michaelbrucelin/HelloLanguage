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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MultiThreading
{
    public partial class Section27 : Form
    {
        public Section27()
        {
            InitializeComponent();
        }

        private void Section27_Load(object sender, EventArgs e)
        {
            /*
            SemaphoreSlim类的作用就是控制访问某资源的线程数量。
            Semaphore，中文译为信号灯。在C#中，它可以允许指定数量的线程同时访问共享资源，而其他的线程必须等待。
            即现在有5个线程同时运行，但Semaphore指定2个线程可以同时访问某一共享资源。
                当执行Semaphore.Wait()时，只有2个线程可以同时进入访问共享资源，而其他三个线程则阻塞等待，直到某一个线程执行Semaphore.Release()时，就会释放一个阻塞的线程。
            即同时访问共享资源的线程数量必须小于或等于Semaphore指定的数量。
            SemaphoreSlim是Semaphore的轻量型实现，即占用资源没有Semaphore多。
            Semaphore可以实现进程和线程并发同步；
            SemaphoreSlim只能实现线程的并发同步。
            */
        }

        private void btnSample01_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                Sample01($"tag0{i + 1}", 5, 2);
        }

        /// <summary>
        /// 现在有n个人要过桥
        /// 但是一座桥上只能承受m个人，再多桥就会塌
        /// 
        /// 方法实现了控制资源同时最多被m个线程操作，但是在所有人“上桥”之前，UI是卡住的
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        private void Sample01(string tag, int n, int m)
        {
            SemaphoreSlim semaphoreslim = new SemaphoreSlim(m);
            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(1000);  // 排队上桥
                int index = i;       // 定义index避免出现闭包的问题
                Task.Run(() =>
                {
                    semaphoreslim.Wait();
                    try
                    {
                        Console.WriteLine($"{tag} 第{index + 1}个人正在过桥。");
                        Thread.Sleep(5000);  // 模拟过桥需要花费的时间
                    }
                    finally
                    {
                        Console.WriteLine($"\t\t\t\t{tag} 第{index + 1}个人已经过桥。");
                        semaphoreslim.Release();
                    }
                });
            }

            Console.WriteLine($"方法{tag}执行结束。");
        }

        private void btnSample02_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                Sample02($"tag0{i + 1}", 5, 2);
        }

        /// <summary>
        /// 解决了Sample01的UI卡死问题，但是并不是全局的资源访问数，每个方法内部独立的
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        public async void Sample02(string tag, int n, int m)
        {
            SemaphoreSlim semaphoreslim = new SemaphoreSlim(m);
            await Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    Thread.Sleep(1000);  // 排队上桥
                    int index = i;       // 定义index避免出现闭包的问题
                    Task.Run(() =>
                    {
                        semaphoreslim.Wait();
                        try
                        {
                            Console.WriteLine($"{tag} 第{index + 1}个人正在过桥。");
                            Thread.Sleep(5000);  // 模拟过桥需要花费的时间
                        }
                        finally
                        {
                            Console.WriteLine($"\t\t\t\t{tag} 第{index + 1}个人已经过桥。");
                            semaphoreslim.Release();
                        }
                    });
                }
            });

            Console.WriteLine($"方法{tag}执行结束。");
        }

        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(2);

        private void btnSample03_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                Sample03($"tag0{i + 1}", 5, 2);
        }

        /// <summary>
        /// 这里实现了全局控制资源访问数，即无论多少个方法（线程）在并行执行，资源的访问总数是被控制住的
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        public async void Sample03(string tag, int n, int m)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    Thread.Sleep(1000);  // 排队上桥
                    int index = i;       // 定义index避免出现闭包的问题
                    Task.Run(() =>
                    {
                        semaphore.Wait();
                        try
                        {
                            Console.WriteLine($"{tag} 第{index + 1}个人正在过桥。");
                            Thread.Sleep(5000);  // 模拟过桥需要花费的时间
                        }
                        finally
                        {
                            Console.WriteLine($"\t\t\t\t{tag} 第{index + 1}个人已经过桥。");
                            semaphore.Release();
                        }
                    });
                }
            });

            Console.WriteLine($"方法{tag}执行结束。");
        }

        private static readonly SemaphoreSlim lock_1 = new SemaphoreSlim(1);

        private void btnSample04_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                Sample04($"tag0{i + 1}", 3);
        }

        /// <summary>
        /// 通过SemaphoreSlim，限制异步方法同一时间只能有一个实例的运行
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="n"></param>
        public async void Sample04(string tag, int n)
        {
            await Task.Run(() =>
            {
                lock_1.Wait();
                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        Thread.Sleep(1000);  // 排队上桥
                        Console.WriteLine($"{tag} 第{i + 1}个人正在过桥。");
                        Thread.Sleep(3000);  // 模拟过桥需要花费的时间
                        Console.WriteLine($"\t\t\t\t{tag} 第{i + 1}个人已经过桥。");
                    }
                }
                finally
                {
                    lock_1.Release();
                }
            });

            Console.WriteLine($"方法{tag}执行结束。");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
