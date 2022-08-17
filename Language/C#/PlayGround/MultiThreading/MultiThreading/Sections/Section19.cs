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
    public partial class Section19 : Form
    {
        public Section19()
        {
            InitializeComponent();
        }

        private void Section19_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// > Main thread: starting a dedicated thread to do an asynchronous operation
        /// > Main thread: Doing other work here...
        /// > In ComputeBoundOp: state=5 start
        /// > Hit <Enter> to end this program...
        /// > In ComputeBoundOp: state=5 end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoJoin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main thread: starting a dedicated thread to do an asynchronous operation");
            Thread dedicatedThread = new Thread(ComputeBoundOp);
            dedicatedThread.Start(5);

            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(1000);         // 模拟做其他工作（1秒）

            // dedicatedThread.Join();  // 等待线程终止
            Console.WriteLine("Hit <Enter> to end this program...");
        }

        /// <summary>
        /// > Main thread: starting a dedicated thread to do an asynchronous operation
        /// > Main thread: Doing other work here...
        /// > In ComputeBoundOp: state=5 start
        /// > In ComputeBoundOp: state=5 end
        /// > Hit <Enter> to end this program...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main thread: starting a dedicated thread to do an asynchronous operation");
            Thread dedicatedThread = new Thread(ComputeBoundOp);
            dedicatedThread.Start(5);

            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(10000);     // 模拟做其他工作（10秒）

            dedicatedThread.Join();  // 等待线程终止
            Console.WriteLine("Hit <Enter> to end this program...");
        }

        /// <summary>
        /// 需要在控制台程序中演示才能看出效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFore_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Worker);  // 创建新线程（默认为前台线程）

            // t.IsBackground = false;      // 无需设置，Thread显示创建的线程默认就是前台线程

            t.Start();                      // 启动线程

            // 此时t是前台线程，则应用程序大约10秒后才终止，需要在控制台程序中演示才能看出效果
            Console.WriteLine("Returning from Main");
        }

        /// <summary>
        /// 需要在控制台程序中演示才能看出效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Worker);  // 创建新线程（默认为前台线程）

            t.IsBackground = true;          // 使线程成为后台线程

            t.Start();                      // 启动线程

            // 此时t是后台线程，则应用程序立刻终止，需要在控制台程序中演示才能看出效果
            Console.WriteLine("Returning from Main");
        }

        // 这个方法的签名必须和 ParameterizedThreadStart 委托匹配
        private static void ComputeBoundOp(Object state)
        {
            // 这个方法由一个专用线程执行
            Console.WriteLine("In ComputeBoundOp: state={0} start", state);
            Thread.Sleep(10000); // 模拟做其他任务（10秒）
            Console.WriteLine("In ComputeBoundOp: state={0} end", state);
            // 这个方法返回后，专用线程将终止
        }

        private static void Worker()
        {
            Thread.Sleep(10000); // 模拟做10秒钟的工作

            // 下面这行代码只有在由一个前台线程执行时才会显示
            Console.WriteLine("Returning from Worker");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
