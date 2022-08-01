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
            lbl01.Text = "一个简单的示例";
            lbl02.Text = "回调函数";
            lbl03.Text = "探测子线程是否完成1_IAsyncResult.IsCompleted";
            lbl04.Text = "探测子线程是否完成2_信号量";
            lbl05.Text = "获取多线程操作的返回值";
            lbl06.Text = "版本演变历史";
        }

        // 下面的注册事件，稍后改为反射来完成
        private void lbl01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section01 section = new Section01();
            section.ShowDialog();
        }

        private void lbl02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section02 section = new Section02();
            section.ShowDialog();
        }

        private void lbl03_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section03 section = new Section03();
            section.ShowDialog();
        }

        private void lbl04_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section04 section = new Section04();
            section.ShowDialog();
        }

        private void lbl05_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section05 section = new Section05();
            section.ShowDialog();
        }

        private void lbl06_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section06 section = new Section06();
            section.ShowDialog();
        }

        private void lbl07_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl08_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl09_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl10_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl11_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl12_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl13_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl14_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl15_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl16_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl17_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl18_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl19_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl20_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl21_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl22_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl23_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl24_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl25_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl26_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl27_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl28_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl29_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl30_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl31_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lbl32_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
