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
    public partial class Section24 : Form
    {
        public Section24()
        {
            InitializeComponent();
        }

        private static System.Threading.Timer s_timer;

        private void Section24_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 让一个线程池线程立即调用回调方法，以后每2秒调用一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimer_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Checking status every 2 seconds");

            // 创建但不启动计时器。确保s_timer在线程池线程调用Status之前引用该计时器
            s_timer = new System.Threading.Timer(Status, null, Timeout.Infinite, Timeout.Infinite);

            // 现在s_timer已被赋值，可以启动计时器了
            // 现在在Status中调用Change，保证不会抛出NullReferenceException
            s_timer.Change(0, Timeout.Infinite);

            // Console.WriteLine();  // 防止进程被终止，Winform项目不需要
        }

        /// <summary>
        /// 利用Task的静态Delay方法和C#的async和await关键字，实现需要定时执行的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelay_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Checking status every 2 seconds");
            Status();

            // Console.ReadLine();  // 防止进程被终止，Winform项目不需要
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }

        /// <summary>
        /// 这个方法的签名必须和TimerCallback委托匹配
        /// </summary>
        /// <param name="state"></param>
        private void Status(object state)
        {
            // 这个方法由一个线程池线程执行
            Console.WriteLine($"In Status at {DateTime.Now}");
            Thread.Sleep(1000);  // 模拟其他工作（1秒）

            // 返回前让Timer在2秒后再次触发
            s_timer.Change(2000, Timeout.Infinite);

            // 这个方法返回后，线程回归池中，等待下一个工作项
        }

        /// <summary>
        /// 该方法可获取你想要的任何参数
        /// </summary>
        private async void Status()
        {
            while (true)
            {
                Console.WriteLine(@"Checking status at {DateTime.Now}");
                // 要检查的代码放到这里... ...

                // 在循环末尾，在不阻塞线程的前提下延迟2秒
                await Task.Delay(2000);  // await允许线程返回
                                         // 2秒之后，某个线程会在await之后介入并继续循环
            }
        }
    }
}
