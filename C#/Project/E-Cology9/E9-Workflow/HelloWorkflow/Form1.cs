using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using E9_Workflow;

namespace HelloWorkflow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Test wf = new Test();

            //string result = wf.TestWithDetail();
            //MessageBox.Show(result);

            string result = wf.Test0();
            MessageBox.Show(result);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
