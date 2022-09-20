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
    public partial class Section22 : Form
    {
        public Section22()
        {
            InitializeComponent();
        }

        private void Section22_Load(object sender, EventArgs e)
        {

        }

        private void btnSample01_Click(object sender, EventArgs e)
        {
            Parallel.For(0, 10, i => DoWork(i + 1));  // 内部10个任务是并行的，但是这条语句是阻塞的，
                                                      // 也就是说如果忽略内部10个任务是并行这一点，这条语句以同步的for循环没有区别

            Console.WriteLine($"all jobs is done.");
        }

        private void btnSample02_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }

        private void DoWork(int i)
        {
            Thread.Sleep(1000 * i);
            Console.WriteLine($"job{i} is done.");
        }
    }
}
