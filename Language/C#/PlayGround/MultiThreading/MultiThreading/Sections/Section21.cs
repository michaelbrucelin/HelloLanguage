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

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> task = Task.Run(() => SumTest2(cts.Token, 1000000000), cts.Token);

            // 在之后的某个时间，取消CancellationTokenSource以取消Task
            cts.Cancel();    // 这是异步请求，Task可能已经完成了
            // task.Wait();  // 对一个Canceled的Task调用Wait()，会抛出System.AggregateException异常

            // Console.WriteLine($"The Sum is: {task.Result}.");  // 仍然会抛出异常，没明白是什么原因

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

        private void btnContinue_Click(object sender, EventArgs e)
        {
            // 创建并启动一个Task，继续另一个任务
            Task<int> task = Task.Run(() => SumTest(CancellationToken.None, 10000));

            // ContinueWith返回一个Task，但一般都不需要再使用该对象（下例的cwt）
            Task cwt = task.ContinueWith(t => Console.WriteLine($"The sum is: {t.Result}."));
        }

        private void btnContinue2_Click(object sender, EventArgs e)
        {
            // 创建并启动一个Task，它有多个延续任务
            Task<int> task = Task.Run(() => SumTest(10000));

            // 每个ContinueWith都返回一个Task，但这些Task一般都用不到了
            task.ContinueWith(t => Console.WriteLine($"The sum is: {t.Result}."), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => Console.WriteLine($"Sum threw: {t.Exception.InnerException}."), TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t => Console.WriteLine($"Sum was canceled."), TaskContinuationOptions.OnlyOnCanceled);
        }

        private void btnSubTask_Click(object sender, EventArgs e)
        {
            
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

        private int SumTest2(CancellationToken ct, int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                // 这里不使用ThrowIfCancellationRequested()方法，而是使用IsCancellationRequested属性
                // 也可以达到取消任务的目的，但是调用者不知道得到的结果是最终结果（取消时已经执行完了），还是中途结果（取消时没有执行完）
                if (ct.IsCancellationRequested)
                    return sum;

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
