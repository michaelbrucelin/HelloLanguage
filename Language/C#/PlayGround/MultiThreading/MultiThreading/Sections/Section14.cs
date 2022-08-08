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
    public partial class Section14 : Form
    {
        public Section14()
        {
            InitializeComponent();
        }

        private void Section14_Load(object sender, EventArgs e)
        {
            string info = "awite/async可以以同步的方式写异步多线程的代码；web中常用，winform中使用的比较少；";
        }

        /// <summary>
        /// 在一个没有返回值的方法内部开启一个Task线程
        /// > This is Main Start {1}
        /// > This is NoReturn Start {1}
        /// > This is NoReturn End   {1}
        /// > This is Main End   {1}
        /// > This is NoReturn's Task Start {3}
        /// > 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32
        /// > This is NoReturn's Task End   {3}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"This is Main Start {{{Thread.CurrentThread.ManagedThreadId}}}");
            Utils.TaskInSyncFunc();
            Console.WriteLine($"This is Main End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// 
        /// > This is Main Start {1}
        /// > This is NoReturn Start {1}
        /// > This is Main End   {1}
        /// > This is NoReturn's Task Start {3}
        /// > 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32
        /// > This is NoReturn's Task End   {3}
        /// > This is NoReturn End   {1}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"This is Main Start {{{Thread.CurrentThread.ManagedThreadId}}}");
            Utils.TaskInAsyncFunc();
            Console.WriteLine($"This is Main End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
