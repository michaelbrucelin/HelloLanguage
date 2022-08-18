using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Section20 : Form
    {
        public Section20()
        {
            InitializeComponent();
        }

        private void Section20_Load(object sender, EventArgs e)
        {

        }

        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(5000);  // 模拟其他工作（5秒）
            Console.WriteLine("Hit <Enter> to end this program...");
        }

        /// <summary>
        /// 默认情况下，CLR会自动将初始线程的执行上下文“流向”子线程，这个很方便，但是也有性能影响
        /// 如果子线程不需要调用线程的执行上下文，可以使用ExecutionContext类来阻止上下文的流动
        /// 对于服务器应用程序，阻止上下文流动性能提升可能非常显著；但客户端应用程序性能提升不了多少
        /// 一个子线程需要主线程执行上下文的示例：
        ///     子线程需要使用用户的Windows身份信息
        /// 阻止上下文调用不但对ThreadPool有效，对Task以及异步IO操作同样有效
        /// 个人总结：先知道这回事，工作中还是使用默认设置吧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContextFlow_Click(object sender, EventArgs e)
        {
            // 将一些数据放到UI线程的逻辑调用上下文中
            CallContext.LogicalSetData("Name", "Jeffery");

            // 初始化要由一个线程池线程做的一些工作，线程池线程能访问逻辑调用上下文数据
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine($"Name={CallContext.LogicalGetData("Name")}"));

            // 阻止UI线程的执行上下文的流动
            ExecutionContext.SuppressFlow();

            // 初始化要由一个线程池线程做的一些工作，线程池线程不能访问逻辑调用上下文数据
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine($"Name={CallContext.LogicalGetData("Name")}"));

            // 恢复UI线程的执行上下文流动，以免影响将来使用更多的线程池线程
            ExecutionContext.RestoreFlow();

            ThreadPool.QueueUserWorkItem(state => Console.WriteLine($"Name={CallContext.LogicalGetData("Name")}"));
        }

        // 这个方法的签名必须匹配WaitCallback委托
        private static void ComputeBoundOp(Object state)
        {
            // 这个方法由一个线程池线程执行
            Console.WriteLine("In ComputeBoundOp: state={0} start", state);
            Thread.Sleep(10000);  // 模拟其他工作（10秒）
            Console.WriteLine("In ComputeBoundOp: state={0} end", state);
            // 这个方法返回后，线程回到线程池中，等待另一个任务
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
