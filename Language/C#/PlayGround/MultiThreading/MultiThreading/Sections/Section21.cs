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
    public partial class Section21 : Form
    {
        public Section21()
        {
            InitializeComponent();
        }

        private void Section21_Load(object sender, EventArgs e)
        {

        }

        private void btnException_Click(object sender, EventArgs e)
        {
            // 创建一个Task（现在还没有开始运行）
            Task<int> task = new Task<int>(n => SumTest((int)n), 1000000000);

            // 可以后再启动任务
            task.Start();

            // 注意，如果任务出现异常，异常会被“吞噬”掉并存储在一个集合中，线程池线程回到线程池中
            // 当调用Wait()方法或Result属性时，会抛出System.AggregateException对象
            try
            {
                // 可选择显示的等待任务完成
                task.Wait();  // 注意，还有一些重载的版本能接受timeout/CancellationToken值
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Wait(): {ex.Message}");
            }

            try
            {
                // 可获得结果（Result属性内部会调用Wait()）
                Console.WriteLine($"The Sum is: {task.Result}.");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Result: {ex.Message}");

                Exception baseEx = ex.GetBaseException();  // 返回作为问题根源的最内层的AggregateException（假定集合只有一个最内层的异常）
                Console.WriteLine("GetBaseException()");
                Console.WriteLine(baseEx.Message);

                // 一些其它的多线程异常的属性与方法
                // ex.InnerExceptions
                // ex.InnerException
                // ex.Flatten()
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> task = Task.Run(() => SumTest(cts.Token, 1000000000), cts.Token);

            // 在之后的某个时间，取消CancellationTokenSource以取消Task
            cts.Cancel();  // 这是异步请求，Task可能已经完成了

            try
            {
                // 如果任务已经取消，Result会抛出一个AggregateException
                Console.WriteLine($"The Sum is: {task.Result}.");
            }
            catch (AggregateException ex)
            {
                // 将任何OperationCanceledException对象都视为已处理
                // 其它任何异常都造成抛出一个新的AggregateException
                // 其中只包含未处理的异常
                ex.Handle(x => x is OperationCanceledException);

                // 所有异常都处理好之后，执行下面这一行
                Console.WriteLine("Sum was canceled.");
            }
        }

        private int SumTest(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
                checked { sum += n; }  // 如果n太大，会抛出System.OverflowException

            return sum;
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
