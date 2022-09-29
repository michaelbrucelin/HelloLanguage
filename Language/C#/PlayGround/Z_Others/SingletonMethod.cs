using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test33("tag01");
            Test33("tag02");

            Console.ReadKey();
        }

        /// <summary>
        /// 两次调用会并发执行
        /// </summary>
        /// <param name="tag"></param>
        private async static void Test1(string tag)
        {
            await Task.Run(() =>
            {
                JobSync(tag);
            });
        }

        private static readonly object LOCK = new object();

        /// <summary>
        /// 两次调用由于锁的存在，先执行其中一个调用，再执行另一个调用
        /// </summary>
        /// <param name="tag"></param>
        private async static void Test21(string tag)
        {
            await Task.Run(() =>
            {
                lock (LOCK)
                {
                    JobSync(tag);  // 同步任务
                }
            });
        }

        /// <summary>
        /// 尽管有锁的存在，但是由于锁内部是异步代码，两次调用依然是并发了，可以理解为刚申请了锁，就又释放了
        /// </summary>
        /// <param name="tag"></param>
        private async static void Test22(string tag)
        {
            await Task.Run(() =>
            {
                lock (LOCK)
                {
                    JobAsync(tag);  // 异步任务，也无法在lock中使用await（即使允许await应该也没用）
                }
            });
        }

        /// <summary>
        /// 将异步任务同步执行，就实现了Test21()的效果
        /// </summary>
        /// <param name="tag"></param>
        private async static void Test23(string tag)
        {
            await Task.Run(() =>
            {
                lock (LOCK)
                {
                    JobAsync(tag).GetAwaiter().GetResult();  // 将异步任务同步执行
                }
            });
        }

        // https://blog.cdemi.io/async-waiting-inside-c-sharp-locks/
        // Instantiate a Singleton of the Semaphore with a value of 1. This means that only 1 thread can be granted access at a time.
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        /// <summary>
        /// 这样就实现了“异步任务的单线程操作”
        /// </summary>
        /// <param name="tag"></param>
        private async static void Test24(string tag)
        {
            // Asynchronously wait to enter the Semaphore. If no-one has been granted access to the Semaphore, code execution will proceed, otherwise this thread waits here until the semaphore is released 
            await semaphoreSlim.WaitAsync();
            try
            {
                await JobAsync(tag);
            }
            finally
            {
                // When the task is ready, release the semaphore. It is vital to ALWAYS release the semaphore when we are ready, or else we will end up with a Semaphore that is forever locked.
                // This is why it is important to do the Release within a try...finally clause; program execution may crash or take a different path, this way you are guaranteed execution
                semaphoreSlim.Release();
            }
        }

        /// <summary>
        /// 这样就实现了在等待时间内（这里设置的是10ms），方法主体只能被执行一次
        /// 即，方法执行到 Monitor.TryEnter(LOCK, 10, ref lockAcquired); 时，如果10ms内拿到了锁，就执行，否则退出
        /// </summary>
        /// <param name="tag"></param>
        private async static void Test31(string tag)
        {
            await Task.Run(() =>
            {
                bool lockAcquired = false;
                try
                {
                    Monitor.TryEnter(LOCK, 10, ref lockAcquired);
                    if (lockAcquired)
                    {
                        JobSync(tag);  // 同步任务
                    }
                }
                finally
                {
                    if (lockAcquired)
                    {
                        Monitor.Exit(LOCK);
                    }
                }
            });
        }

        /// <summary>
        /// 由于方法主体任务是异步的，所以刚申请到锁，就释放了锁，所以两次调用依然是并发执行
        /// </summary>
        /// <param name="tag"></param>
        private async static void Test32(string tag)
        {
            await Task.Run(() =>
            {
                bool lockAcquired = false;
                try
                {
                    Monitor.TryEnter(LOCK, 10, ref lockAcquired);
                    if (lockAcquired)
                    {
                        JobAsync(tag);  // 同步任务
                    }
                }
                finally
                {
                    if (lockAcquired)
                    {
                        Monitor.Exit(LOCK);
                    }
                }
            });
        }

        /// <summary>
        /// 将异步任务同步执行，就实现了Test31()的效果
        /// </summary>
        /// <param name="tag"></param>
        private async static void Test33(string tag)
        {
            await Task.Run(() =>
            {
                bool lockAcquired = false;
                try
                {
                    Monitor.TryEnter(LOCK, 10, ref lockAcquired);
                    if (lockAcquired)
                    {
                        JobAsync(tag).GetAwaiter().GetResult();  // 将异步任务同步执行
                    }
                }
                finally
                {
                    if (lockAcquired)
                    {
                        Monitor.Exit(LOCK);
                    }
                }
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
    }
}
