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
    public partial class Section04 : Form
    {
        public Section04()
        {
            InitializeComponent();
        }

        private void Section04_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 通过信号量来探测多线程操作是否完成
        /// 这个场景没有实际意义，还不如直接同步执行了
        /// 
        /// 缺点：等待信号量的时候，主线程（UI线程）卡死
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignalFake_Click(object sender, EventArgs e)
        {
            Action<string> action = Functions.DoSomethingLong;
            IAsyncResult asyncResult = action.BeginInvoke("uploading...", null, null);

            // 阻塞当前进程，直到收到信号量，信号量从asyncResult中发出，无延迟
            asyncResult.AsyncWaitHandle.WaitOne();  // 一直等待，与WaitOne(-1)相同
            Console.WriteLine("Completed.");

            // asyncResult.AsyncWaitHandle.WaitOne(1000);  // 阻塞当前线程，等待且最多等待1000ms，超时就放弃阻塞
            // 这个通常用在做超时处理，当一个操作（比如连接服务器）超时，就切换任务（连接另外一个服务器），或者放弃操作、报异常、提示结果等操作
        }

        /// <summary>
        /// 通过信号量来探测多线程操作是否完成
        /// 这是模拟一个真实的使用场景：在多线程操作的同时，又做了另外一件事，两件事都完成时才算完成
        /// 
        /// 缺点：等待信号量的时候，主线程（UI线程）卡死
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignalReal_Click(object sender, EventArgs e)
        {
            Action<string> action = Functions.DoSomethingLong;
            IAsyncResult asyncResult = action.BeginInvoke("uploading...", null, null);

            // 现在由主线程做另一件事
            Enumerable.Range(1, 32).ToList().ForEach(i =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"{i}... ...");
            });

            // 阻塞当前进程，直到收到信号量，信号量从asyncResult中发出，无延迟
            asyncResult.AsyncWaitHandle.WaitOne();
            Console.WriteLine("Completed.");
        }

        /// <summary>
        /// 通过信号量来探测多线程操作是否完成
        /// 尝试解决上面方法“等待”时UI界面卡死的问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignalReal2_Click(object sender, EventArgs e)
        {
            Action<string> action = Functions.DoSomethingLong;
            IAsyncResult asyncResult = action.BeginInvoke("uploading...", null, null);

            // （现在由主线程做另一件事），将这段代码也放到子线程中去执行
            Action action2 = () => Enumerable.Range(1, 32).ToList().ForEach(i =>
                                   {
                                       Thread.Sleep(100);
                                       Console.WriteLine($"{i}... ...");
                                   });
            IAsyncResult asyncResult2 = action2.BeginInvoke(null, null);

            // 阻塞当前进程，直到收到信号量，信号量从asyncResult中发出，无延迟
            // 将主线程的等待也放到子线程从去执行
            Action action_tail = () =>
            {
                asyncResult.AsyncWaitHandle.WaitOne();
                asyncResult2.AsyncWaitHandle.WaitOne();
                Console.WriteLine("Completed.");
            };
            action_tail.BeginInvoke(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine();
        }
    }
}
