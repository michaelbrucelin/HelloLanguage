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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MultiThreading
{
    public partial class Section26 : Form
    {
        public Section26()
        {
            InitializeComponent();

            id = 0;
        }

        private int id;
        public string Tag { get { return $"tag{id++,0:D2}"; } }

        private void Section26_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 多次调用（点击）会并发执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSample01_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                JobSync(Tag);
            });
        }

        private static void JobSync(string tag)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{tag} {i}");
                Thread.Sleep(1000);
            }
        }

        private async static Task JobAsync(string tag)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"{tag} {i}");
                    Thread.Sleep(1000);
                }
            });
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
