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
    internal sealed partial class Section21_Scheduler : Form
    {
        public Section21_Scheduler()
        {
            InitializeComponent();

            // 获得对一个同步上下文任务调度器的引用
            m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            Text = "Synchronization Context Task Scheduler Demo";
            Visible = true; Width = 400; Height = 100;
        }

        private readonly TaskScheduler m_syncContextTaskScheduler;
        private CancellationTokenSource m_cts;

        private void Section21_Scheduler_Load(object sender, EventArgs e)
        {

        }

        private void btnScheduler_Click(object sender, EventArgs e)
        {
            // OnMouseClick(null);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (m_cts != null)  // 如果一个操作正在进行，取消它
            {
                m_cts.Cancel();
                m_cts = null;
            }
            else                // 如果操作还没有开始，启动它
            {
                Text = "Operation running";
                m_cts = new CancellationTokenSource();

                // 这个任务使用默认任务调度器，在一个线程池线程上执行
                Task<int> t = Task.Run(() => SumTest(m_cts.Token, 20000), m_cts.Token);

                // 这些任务使用同步上下文任务调度器，在GUI线程上执行
                t.ContinueWith(task => Text = "Result: " + task.Result, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, m_syncContextTaskScheduler);
                t.ContinueWith(task => Text = "Operation canceled", CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, m_syncContextTaskScheduler);
                t.ContinueWith(task => Text = "Operation faulted", CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, m_syncContextTaskScheduler);
            }

            base.OnMouseClick(e);
        }

        private int SumTest(CancellationToken ct, int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                // 在取消标识引用的CancellationTokenSource上调用Cancel，
                // 下面这行代码就会抛出OperationCanceledException
                ct.ThrowIfCancellationRequested();  // 与ct.IsCancellationRequested属性类似，但是会抛出异常，
                                                    // 这样调用者就可以知道得到的结果是任务运行完的结果，还是任务出错的中途结果

                checked { sum += n; }  // 如果n太大，会抛出System.OverflowException
            }

            return sum;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }
    }
}
