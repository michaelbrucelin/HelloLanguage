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
    public partial class Section10 : Form
    {
        public Section10()
        {
            InitializeComponent();
        }

        private void Section10_Load(object sender, EventArgs e)
        {
            string info = @"多线程的安全问题指的是，一段代码，单线程执行和多线程执行的结果不一致，就表明多线程有线程安全问题。
                            多线程去访问一个集合，一般是没有问题的，多线程的安全问题通常都发生在修改同一个对象的时候。";
        }

        /// <summary>
        /// 多执行几次下面示例，或者将10000调大，可以看到输出结果有可能小于10000，也就是有数据丢失了。
        /// 下面示例中，List是个数组结构，在内存上是连续存储的，
        /// 假如在同一时刻，多个线程（cpu）同时向List添加数据，即向同一块内存空间中写数据，
        /// 内存就会先执行一个请求，再执行另一个请求，这样就造成数据覆盖，也就是数据丢失了；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnLock_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10000; i++)  // 这里循环的次数越多，越能看出效果
            {
                tasks.Add(Task.Run(() => list.Add(i)));
            }

            TaskFactory taskFactory = new TaskFactory();
            taskFactory.ContinueWhenAll(tasks.ToArray(), task => { Console.WriteLine(list.Count); });
        }

        // 声明一个锁
        // 微软官方（MSDN）推荐的写法
        private static readonly object LOCK = new object();

        /// <summary>
        /// 解决上面的问题也简单，加一个锁就可以了，加锁后就能解决线程安全问题；
        /// 这里锁的原理也很简单，加锁后就是变成单线程化了，
        /// 也就是说lock可以保证在任意时刻，至多只能有一个线程进入lock的闭包代码块中，其他的线程在外面排队，即单线程化；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10000; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    lock (LOCK)  // 加锁，这样就能解决线程安全问题
                    {
                        list.Add(i);
                    }
                }));
            }

            TaskFactory taskFactory = new TaskFactory();
            taskFactory.ContinueWhenAll(tasks.ToArray(), task => { Console.WriteLine(list.Count); });
        }

        /// <summary>
        /// 其实lock就是一个语法糖，上面的写法等价于下面的写法，lock就是Monitor类的简写，
        /// 可以看反编译的代码，本质上通过Monitor类锁定了一个内存的引用地址，lock将这个引用占用，有点像数据库的事务，
        /// 所以lock必须是一个引用类型，不可以是值类型，同时lock也能为null
        /// 因为object是所有引用类型的父类，所以写lock时都直接写object了；
        /// <span style = "color:red" > 一句话，lock占据了变量的引用；</span>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMonitor_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10000; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    Monitor.Enter(LOCK);
                    list.Add(i);
                    Monitor.Exit(LOCK);
                }));
            }

            TaskFactory taskFactory = new TaskFactory();
            taskFactory.ContinueWhenAll(tasks.ToArray(), task => { Console.WriteLine(list.Count); });
        }

        /// <summary>
        /// 需要注意的是，有时候子线程抛异常，主线程并不异常，即主线程不处理子线程抛出的异常，
        /// 但是结果是错的，多线程有时候会有自己“吞异常”这种情况出现，
        /// 例如下面的例子，如果没有try catch的话，程序并不会异常，但是结果为0
        /// 在.Net Framrwork 4.8中运行，即使没有使用try catch也会异常，不确认是不是.Net做了调整；
        /// 
        /// 锁锁定的是引用，即变量所在栈到堆（真实值存储的位置）的引用，这里不报错是因为IDE检测不出来，
        /// 但是null比较特殊，null在内存中没有东西，而不是指向一个特殊的内存空间，是一个特殊的存在，所以不能作为锁来使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnException_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10000; i++)
            {
#if false
                tasks.Add(Task.Run(() =>
                {
                    lock (null)
                    {
                        list.Add(i);
                    }
                }));
#else
                tasks.Add(Task.Run(() =>
                {
                    try
                    {
                        lock (null)
                        {
                            list.Add(i);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception in sub thread: {ex.Message}");
                        throw ex;
                    }
                }));
#endif
            }

            TaskFactory taskFactory = new TaskFactory();
            taskFactory.ContinueWhenAll(tasks.ToArray(), task => { Console.WriteLine(list.Count); });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
