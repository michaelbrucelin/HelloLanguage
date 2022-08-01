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
    public partial class Section02 : Form
    {
        public Section02()
        {
            InitializeComponent();
        }

        private void Section02_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 没有使用回调函数
        /// 这样虽然实现了异步，但是在业务逻辑上是错误的，异步方法还没有完成，就打印完成了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoCallback_Click(object sender, EventArgs e)
        {
            Action<string> action = Utils.DoSomethingLong;
            action.BeginInvoke("DoSomethingLong", null, null);

            Console.WriteLine($"\r\n********************Successed {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}}********************\r\n");
        }

        /// <summary>
        /// 使用回调函数
        /// 这样既实现了异步，有实现了再异步方法完成后，再打印完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallback_Click(object sender, EventArgs e)
        {
            Action<string> action = Utils.DoSomethingLong;
            AsyncCallback callback = ar =>
            {
                Console.WriteLine($"AsyncState: {ar.AsyncState}");
                Console.WriteLine($"********************Successed {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}}********************\r\n");
            };

            action.BeginInvoke("DoSomethingLong", callback, "hello world");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine();
        }
    }
}
