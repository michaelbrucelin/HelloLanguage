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
            string info = "async/awite可以以同步的方式写异步多线程的代码；web中常用，winform中使用的比较少；";
        }

        /// <summary>
        /// 方法签名：public static void TaskInFuncSync()，方法内部执行了一个子线程
        /// 可以看到主线程与被调用的方法都执行完了，才看是执行方法内部的子线程
        /// 
        /// > This is Main Start {1}
        /// > This is Function Start {1}
        /// > This is Function End   {1}
        /// > This is Main End   {1}
        /// > This is Function's Task Start {3}
        /// > 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32
        /// > This is Function's Task End   {3}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"This is Main Start {{{Thread.CurrentThread.ManagedThreadId}}}");
            Utils.TaskInFuncSync();
            Console.WriteLine($"This is Main End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// 方法签名：public async static void TaskInFuncAsync()，方法内部执行了一个子线程，且使用await关键字修饰
        /// 可以看到方法内部的代码按顺序执行，但是方法本身与主线程交叉执行了
        /// 
        /// > This is Main Start {1}
        /// > This is Function Start {1}
        /// > This is Function's Task Start {4}
        /// > This is Main End   {1}
        /// > 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32
        /// > This is Function's Task End   {4}
        /// > This is Function End   {1}
        /// 
        /// > This is Main Start {1}
        /// > This is Function Start {1}
        /// > This is Main End   {1}
        /// > This is Function's Task Start {3}
        /// > 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32
        /// > This is Function's Task End   {3}
        /// > This is Function End   {1}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"This is Main Start {{{Thread.CurrentThread.ManagedThreadId}}}");
            Utils.TaskInFuncAsync();
            Console.WriteLine($"This is Main End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// 方法签名：public async static Task TaskInFuncAsync2()，方法内部执行了一个子线程，且使用await关键字修饰
        /// 这里主线程调用的时候，也用了await修饰，所以方法与主线程都按照代码顺序执行的
        /// 
        /// > This is Main Start {1}
        /// > This is Function Start {1}
        /// > This is Function's Task Start {3}
        /// > 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32
        /// > This is Function's Task End   {3}
        /// > This is Function End   {1}
        /// > This is Main End   {1}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAsyncAwait_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"This is Main Start {{{Thread.CurrentThread.ManagedThreadId}}}");
            await Utils.TaskInFuncAsync2();
            Console.WriteLine($"This is Main End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
