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
    public partial class Section15 : Form
    {
        public Section15()
        {
            InitializeComponent();
        }

        private void Section15_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 就相当于普通的多线程
        /// 
        /// > async 多线程的主线程 Start {1}
        /// > DoSomethingLong start AsyncJob01 {01} 165802:547
        /// > DoSomethingLong start AsyncJob02 {01} 165802:579
        /// > Start sleep 1557 milliseconds;
        /// > DoSomethingLong start AsyncJob03 {01} 165802:587
        /// > async 多线程的主线程 End   {1}
        /// > Start sleep 3960 milliseconds;
        /// > Start sleep 1865 milliseconds;
        /// > DoSomethingLong   end AsyncJob01 {01} 165804:142
        /// > DoSomethingLong   end AsyncJob03 {01} 165804:502
        /// > DoSomethingLong   end AsyncJob02 {01} 165806:596
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"async 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            Utils.DoSomethingLongAsync("AsyncJob01");
            Utils.DoSomethingLongAsync("AsyncJob02");
            Utils.DoSomethingLongAsync("AsyncJob03");

            Console.WriteLine($"async 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// 变成同步执行了
        /// 
        /// > await+async 多线程的主线程 Start {1}
        /// > DoSomethingLong start AsyncJob01 {01} 165827:752
        /// > Start sleep 1541 milliseconds;
        /// > DoSomethingLong   end AsyncJob01 {01} 165829:299
        /// > DoSomethingLong start AsyncJob02 {01} 165829:302
        /// > Start sleep 3408 milliseconds;
        /// > DoSomethingLong   end AsyncJob02 {01} 165832:714
        /// > DoSomethingLong start AsyncJob03 {01} 165832:715
        /// > Start sleep 3294 milliseconds;
        /// > DoSomethingLong   end AsyncJob03 {01} 165836:013
        /// > await+async 多线程的主线程 End   {1}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAwaitAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"await+async 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            await Utils.DoSomethingLongAsync("AsyncJob01");
            await Utils.DoSomethingLongAsync("AsyncJob02");
            await Utils.DoSomethingLongAsync("AsyncJob03");

            Console.WriteLine($"await+async 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        /// <summary>
        /// Task.WhenAll()起到了Task.WaitAll()的作用，同时还不会导致卡界面
        /// 
        /// > await+async 多线程的主线程 Start {1}
        /// > DoSomethingLong start AsyncJob01 {01} 165852:050
        /// > Start sleep 3155 milliseconds;
        /// > DoSomethingLong start AsyncJob02 {01} 165852:052
        /// > DoSomethingLong start AsyncJob03 {01} 165852:059
        /// > Start sleep 1490 milliseconds;
        /// > Start sleep 1217 milliseconds;
        /// > DoSomethingLong   end AsyncJob03 {01} 165853:299
        /// > DoSomethingLong   end AsyncJob02 {01} 165853:552
        /// > DoSomethingLong   end AsyncJob01 {01} 165855:216
        /// > await+async 多线程的主线程 End   {1}
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAwaitAll_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"await+async 多线程的主线程 Start {{{Thread.CurrentThread.ManagedThreadId}}}");

            await Task.WhenAll(
                Utils.DoSomethingLongAsync("AsyncJob01"),
                Utils.DoSomethingLongAsync("AsyncJob02"),
                Utils.DoSomethingLongAsync("AsyncJob03")
            );

            Console.WriteLine($"await+async 多线程的主线程 End   {{{Thread.CurrentThread.ManagedThreadId}}}");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
