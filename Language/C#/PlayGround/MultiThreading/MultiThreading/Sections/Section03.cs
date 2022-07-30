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
    public partial class Section03 : Form
    {
        public Section03()
        {
            InitializeComponent();
        }

        private void Section03_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取一个异步操作是否完成
        /// 一种比较笨的办法，有下面两个缺点
        /// 1. 这种操作方式会有延迟，即下面while循环中的Thread.Sleep的时间
        /// 2. while循环的时候，UI进程又卡死了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIAsyncResult_Click(object sender, EventArgs e)
        {
            Action<string> action = Functions.DoSomethingLong;
            IAsyncResult asyncResult = action.BeginInvoke("uploading...", null, null);

            int i = 0;
            while (!asyncResult.IsCompleted)
            {
                Thread.Sleep(100);
                Console.WriteLine(new string('.', ++i));
            }
            Console.WriteLine("Completed.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine();
        }
    }
}
