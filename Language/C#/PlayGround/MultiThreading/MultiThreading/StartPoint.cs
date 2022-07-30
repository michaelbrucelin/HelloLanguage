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
    public partial class StartPoint : Form
    {
        public StartPoint()
        {
            InitializeComponent();
        }

        private void StartPoint_Load(object sender, EventArgs e)
        {
            txt01.Text = "一个简单的示例";
            txt02.Text = "回调函数";
            txt03.Text = "探测多线程操作是否完成01_IAsyncResult.IsCompleted";
            txt04.Text = "探测多线程操作是否完成02_信号量";
        }

        private void txt01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section01 section = new Section01();
            section.ShowDialog();
        }

        private void txt02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section02 section = new Section02();
            section.ShowDialog();
        }

        private void txt03_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section03 section = new Section03();
            section.ShowDialog();
        }

        private void txt04_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section04 section = new Section04();
            section.ShowDialog();
        }

        private void txt05_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt06_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt07_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt08_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt09_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt10_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt11_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt12_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt13_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt14_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txt15_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
