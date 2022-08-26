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

            // Get a reference to a synchronization context task scheduler
            m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Text = "Synchronization Context Task Scheduler Demo";
            Visible = true; Width = 600; Height = 100;
        }

        private readonly TaskScheduler m_syncContextTaskScheduler;
        private CancellationTokenSource m_cts;

        private void Section21_Scheduler_Load(object sender, EventArgs e)
        {

        }

        private void btnScheduler_Click(object sender, EventArgs e)
        {

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (m_cts != null)
            { // An operation is in flight, cancel it
                m_cts.Cancel();
                m_cts = null;
            }
            else
            { // An operation is not in flight, start it
                Text = "Operation running";
                m_cts = new CancellationTokenSource();
                // This task uses the default task scheduler and executes on a thread pool thread
                Task<Int32> t = Task.Run(() => SumTest(m_cts.Token, 20000), m_cts.Token);
                // These tasks use the sync context task scheduler and execute on the GUI thread
                t.ContinueWith(task => Text = "Result: " + task.Result,
                CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                m_syncContextTaskScheduler);
                t.ContinueWith(task => Text = "Operation canceled",
                CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled,
                m_syncContextTaskScheduler);
                t.ContinueWith(task => Text = "Operation faulted",
                CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
                m_syncContextTaskScheduler);
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
