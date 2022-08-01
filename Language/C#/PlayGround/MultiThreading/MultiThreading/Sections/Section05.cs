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
    public partial class Section05 : Form
    {
        public Section05()
        {
            InitializeComponent();
        }

        private void Section05_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 在主线程中通过EndInvoke + IAsyncResult来获取子线程的返回值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIAsyncResult_Click(object sender, EventArgs e)
        {
            Func<long, long> func = Functions.DoSomethingLong2;
            IAsyncResult asyncResult = func.BeginInvoke(100000000, null, null);  // 这个异步调用结果，是用来描述异步操作的

            // 现在做另一件事
            Enumerable.Range(1, 32).ToList().ForEach(i =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"{i}... ...");
            });

            long result = func.EndInvoke(asyncResult);  // 获取异步操作的真实返回值
            Console.WriteLine($"执行结果为：{result}");
        }

        /// <summary>
        /// 在回调函数中通过EndInvoke + IAsyncResult来获取子线程的返回值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallback_Click(object sender, EventArgs e)
        {
            // 获取异步操作的结果，也可以在回调函数中操作
            Func<long, long> func = Functions.DoSomethingLong2;
            IAsyncResult asyncResult = func.BeginInvoke(100000000, ar =>  // 这里的lambda参数（ar）就是BeginInvoke()的返回值
                                       {
                                           long result = func.EndInvoke(ar);
                                           Console.WriteLine($"执行结果为：{result}");
                                       }, null);

            // 现在做另一件事
            Enumerable.Range(1, 32).ToList().ForEach(i =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"{i}... ...");
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine();
        }
    }
}
