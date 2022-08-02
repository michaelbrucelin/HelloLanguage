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
    public partial class Section09 : Form
    {
        public Section09()
        {
            InitializeComponent();
        }

        private void Section09_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 下面代码使用循环创建了10个线程，但是线程的输出中i全部为10，而不是想象中的0-9，
        /// 尤其是第1次执行，通常全都为10，第1次以后执行，不是0-9，而是没有规律的数字（当然在0-9之间）；
        /// 这是因为.Net只负责向操作系统申请线程，当i=0时向操作系统申请了1个线程，不管操作系统是否响应了，继续下1次循环，i=1了，再申请第2个线程，
        /// 所以一瞬间就向操作系统申请了10个线程，这时i也变为10，通常这时操作系统也将响应申请，提供线程运算，
        /// 所以i都是10，至于第2次、第3次执行不一定都是10了，应该是.Net线程池的原因，没有向操作系统申请线程，而是直接从线程池中获取线程导致的；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Console.WriteLine($"Task [{i}] start\t{Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(random.Next(2000, 8000));
                    Console.WriteLine($"Task [{i}]   end\t{Thread.CurrentThread.ManagedThreadId}");
                });
            }
        }

        /// <summary>
        /// 知道了原因，那么让.Net慢点向操作系统线程试试，可以看到虽然不一定输出是严格的0-9，但是显然不是全部为10了，也可以加大延迟时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest2_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(10);  // 慢点申请
                Task.Run(() =>
                {
                    Console.WriteLine($"Task [{i}] start\t{Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(random.Next(2000, 8000));
                    Console.WriteLine($"Task [{i}]   end\t{Thread.CurrentThread.ManagedThreadId}");
                });
            }
        }

        /// <summary>
        /// 彻底的解决问题，由于只定义了一个i，所以才出现了上面的问题，
        /// 在循环的闭包中创建另一个变量j来存储i就可以了，这样就有10个j分别记录每一个i的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest3_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int j = i;  // 这样会创建10个j
                Task.Run(() =>
                {
                    Console.WriteLine($"Task [{i}] [{j}] start\t{Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(random.Next(2000, 8000));
                    Console.WriteLine($"Task [{i}] [{j}]   end\t{Thread.CurrentThread.ManagedThreadId}");
                });
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
