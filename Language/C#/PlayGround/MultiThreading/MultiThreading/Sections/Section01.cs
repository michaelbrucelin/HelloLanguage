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
    public partial class Section01 : Form
    {
        public Section01()
        {
            InitializeComponent();
        }

        private void Section01_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 同步演示，卡界面，执行慢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"\r\n********************Sync Function start {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}}********************\r\n");

            Action<string> action = Utils.DoSomethingLong;
            for (int i = 0; i < 5; i++)
            {
                string name = $"Sync Function_{i}";
                // DoSomethingLong(name);
                action.Invoke(name);                   // Invoke()是同步调用，这里不需要委托（像上一行那样直接执行就可以），为了和下面异步代码一致，才这么写的
            }

            Console.WriteLine($"\r\n********************Sync Function end {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}}********************\r\n");
        }

        /// <summary>
        /// 异步演示，不卡界面，执行快
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"\r\n********************Async Function start {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}}********************\r\n");

            Action<string> action = Utils.DoSomethingLong;
            for (int i = 0; i < 5; i++)
            {
                string name = $"Async Function_{i}";
                action.BeginInvoke(name, null, null);  // BeginInvoke()是异步调用
            }

            Console.WriteLine($"\r\n********************Async Function end {{{Thread.CurrentThread.ManagedThreadId.ToString("00")}}}********************\r\n");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
