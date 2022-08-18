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
            lbl07.Text = "Task示例01";
            lbl08.Text = "Task示例02";
            lbl09.Text = "再次理解线程";
            lbl10.Text = "多线程安全问题";
            lbl11.Text = "锁的共用问题";
            lbl12.Text = "锁的其它问题01";
            lbl13.Text = "锁的其它问题02";
            lbl14.Text = "Async/Await示例01";
            lbl15.Text = "Async/Await示例02";
            lbl16.Text = "Async/Await示例03";
            lbl17.Text = "ConfigAwait示例";
            lbl18.Text = "ValueTask示例";
            lbl19.Text = "Thread示例";
            lbl20.Text = "ThreadPool示例";
            lbl21.Text = "";
            lbl22.Text = "";
            lbl23.Text = "";
            lbl24.Text = "";
            lbl25.Text = "";
            lbl26.Text = "";
            lbl27.Text = "";
            lbl28.Text = "";
            lbl29.Text = "";
            lbl30.Text = "";
            lbl31.Text = "";
            lbl32.Text = "";
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
            Section07 section = new Section07();
            section.ShowDialog();
        }

        private void lbl08_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section08 section = new Section08();
            section.ShowDialog();
        }

        private void lbl09_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section09 section = new Section09();
            section.ShowDialog();
        }

        private void lbl10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section10 section = new Section10();
            section.ShowDialog();
        }

        private void lbl11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section11 section = new Section11();
            section.ShowDialog();
        }

        private void lbl12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section12 section = new Section12();
            section.ShowDialog();
        }

        private void lbl13_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section13 section = new Section13();
            section.ShowDialog();
        }

        private void lbl14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section14 section = new Section14();
            section.ShowDialog();
        }

        private void lbl15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section15 section = new Section15();
            section.ShowDialog();
        }

        private void lbl16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section16 section = new Section16();
            section.ShowDialog();
        }

        private void lbl17_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section17 section = new Section17();
            section.ShowDialog();
        }

        private void lbl18_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section18 section = new Section18();
            section.ShowDialog();
        }

        private void lbl19_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section19 section = new Section19();
            section.ShowDialog();
        }

        private void lbl20_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section20 section = new Section20();
            section.ShowDialog();
        }

        private void lbl21_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section21 section = new Section21();
            //section.ShowDialog();
        }

        private void lbl22_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section22 section = new Section22();
            //section.ShowDialog();
        }

        private void lbl23_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section23 section = new Section23();
            //section.ShowDialog();
        }

        private void lbl24_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section24 section = new Section24();
            //section.ShowDialog();
        }

        private void lbl25_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section25 section = new Section25();
            //section.ShowDialog();
        }

        private void lbl26_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section26 section = new Section26();
            //section.ShowDialog();
        }

        private void lbl27_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section27 section = new Section27();
            //section.ShowDialog();
        }

        private void lbl28_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section28 section = new Section28();
            //section.ShowDialog();
        }

        private void lbl29_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section29 section = new Section29();
            //section.ShowDialog();
        }

        private void lbl30_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section30 section = new Section30();
            //section.ShowDialog();
        }

        private void lbl31_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section31 section = new Section31();
            //section.ShowDialog();
        }

        private void lbl32_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Section32 section = new Section32();
            //section.ShowDialog();
        }
    }
}
