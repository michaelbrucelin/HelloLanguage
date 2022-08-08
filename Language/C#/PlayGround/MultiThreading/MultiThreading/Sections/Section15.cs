using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            string info = "awite/async可以以同步的方式写异步多线程的代码；web中常用，winform中使用的比较少；";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AwaitAsyncTester().Main();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AwaitAsyncTester().MainAwaitAsync();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
