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
        }

        private void txt01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Section01 section01 = new Section01();
            section01.ShowDialog();
        }
    }
}
