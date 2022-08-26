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
            // 在一个任务内部启动子任务
            Task<int[]> parent = new Task<int[]>(() =>
            {
                int[] results = new int[3];  // 创建一个数组来存储结果

                // 这个任务创建并启动了3个子任务
                // 一个任务创建的Task对象默认是顶级对象，与创建它们的任务无关，但TaskCreationOptions.AttachedToParent标识可以将一个Task与创建它的Task关联
                // 结果就是除非所有子任务（以及子任务的子任务）结束运行，否则创建任务（父任务）不认为已经结束
                new Task(() => results[0] = SumTest(10000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = SumTest(20000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = SumTest(30000), TaskCreationOptions.AttachedToParent).Start();

                // 返回对数组的引用（即使数组元素可能还没有初始化）
                return results;
            });

            // 父任务及其子任务运行完成后，用一个延续任务显示结果
            // 调用ContinueWith方法创建Task时，可指定TaskContinuationOptions.AttachedToParent标志将延续任务指定为子任务（不会死锁？）
            // Task cwt = parent.ContinueWith(parentTask => Array.ForEach(parentTask.Result, Console.WriteLine), TaskContinuationOptions.AttachedToParent);
            Task cwt = parent.ContinueWith(parentTask => Array.ForEach(parentTask.Result, Console.WriteLine));

            // 启动父任务，便于它启动它的子任务
            parent.Start();
        }

        private void btnFactory_Click(object sender, EventArgs e)
        {
            Task parent = new Task(() =>
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                TaskFactory<int> tf = new TaskFactory<int>(cts.Token, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

                // 这个任务创建并启动了3个子任务
                Task<int>[] childTasks = new[] {
                    tf.StartNew(() => SumTest(cts.Token, 10000)),
                    tf.StartNew(() => SumTest(cts.Token, 20000)),
                    tf.StartNew(() => SumTest(cts.Token, int.MaxValue))  // 太大, 会抛出OverflowException异常
                };

                // 任何子任务抛出异常，就取消其余子任务
                for (int i = 0; i < childTasks.Length; i++)
                    childTasks[i].ContinueWith(t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);

                // 所有子任务完成后，从未出错/未取消的任务获取返回的最大值，然后将最大值传递给另一个任务来显示最大结果
                tf.ContinueWhenAll(
                    childTasks,
                    completedTasks => completedTasks.Where(t => t.Status == TaskStatus.RanToCompletion).Max(t => t.Result),
                    CancellationToken.None
                )
                .ContinueWith(t => Console.WriteLine($"The maximum is: {t.Result}"), TaskContinuationOptions.ExecuteSynchronously);
            });

            // 子任务完成后，也显示任何未处理的异常
            parent.ContinueWith(p =>
            {
                // 我将所有文本放在一个StringBuilder中，并只调用Console.WriteLine一次，
                // 因为这个任务可能和上面的任务并行执行，而我不希望任务的输出变得不连续
                StringBuilder sb = new StringBuilder("The following exception(s) occurred:" + Environment.NewLine);
                foreach (Exception ex in p.Exception.Flatten().InnerExceptions)
                    sb.AppendLine($" {e.GetType()}");
                Console.WriteLine(sb.ToString());
            }, TaskContinuationOptions.OnlyOnFaulted);

            // 启动父任务，使它能启动子任务
            parent.Start();
        }

        private void btnScheduler_Click(object sender, EventArgs e)
        {
            Section21_Scheduler scheduler = new Section21_Scheduler();
            scheduler.ShowDialog();
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
