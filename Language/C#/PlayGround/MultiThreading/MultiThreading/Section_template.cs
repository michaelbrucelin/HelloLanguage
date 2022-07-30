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
    public partial class Section_template : Form
    {
        public Section_template()
        {
            InitializeComponent();
        }

        private void Section05_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine();
        }
    }
}
