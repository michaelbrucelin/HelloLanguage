using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class AwaitAsyncTester
    {
        // await/async是个新语法，出现在.NetFramework 4.5中，只是一个语法糖，并不是一个全新的异步多线程方式
        // 语法糖：就是编译器提供的新功能
        // await/async并不会产生新的线程，但是依托于Task而存在，所以在执行时，也是多线程的；

        private Random random = new Random();

        public void Main()
        {
            Console.WriteLine($"This is Main Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            FuncVoidAwaitAsync();
            Console.WriteLine($"This is Main   End\t\t{Thread.CurrentThread.ManagedThreadId}");
        }

        public void Main(Action action)
        {
            Console.WriteLine($"This is Main Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            action();
            Console.WriteLine($"This is Main   End\t\t{Thread.CurrentThread.ManagedThreadId}");
        }

        public async void MainAwaitAsync()
        {
            Console.WriteLine($"This is Main Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            Task<long> result = FuncReturnLongAwaitAsync();
            await result;
            Console.WriteLine(result.Result);
            Console.WriteLine($"This is Main   End\t\t{Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task DoSomeThing()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("hello world");
            });
        }

        // 没有返回值，在方法内部开启一个Task线程
        // 注意与FuncVoidAwaitAsync进行比较，比较执行过程与各个步骤的线程id
        public void FuncVoid()
        {
            Console.WriteLine($"This is FuncVoid Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            Task.Run(() =>
            {
                Console.WriteLine($"This is FuncVoid's Task Start\t\t{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(random.Next(1000, 4000));
                Console.WriteLine($"This is FuncVoid's Task   End\t\t{Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"This is FuncVoid   End\t\t{Thread.CurrentThread.ManagedThreadId}");
        }

        // 与上面方法完全一直，只是单独添加了async，这样的话会报警告，但是不影响编译执行
        // 而且这样添加了async与没有添加async没有任何区别
        // async可以单独使用，不需要与await一起使用
        // public async void FuncVoidJustAsync()
        // {
        //     Console.WriteLine($"This is FuncVoidJustAsync Start\t\t{Thread.CurrentThread.ManagedThreadId}");
        //     Task.Run(() =>
        //     {
        //         Console.WriteLine($"This is FuncVoidJustAsync's Task Start\t\t{Thread.CurrentThread.ManagedThreadId}");
        //         Thread.Sleep(random.Next(1000, 4000));
        //         Console.WriteLine($"This is FuncVoidJustAsync's Task   End\t\t{Thread.CurrentThread.ManagedThreadId}");
        //     });
        //     Console.WriteLine($"This is FuncVoidJustAsync   End\t\t{Thread.CurrentThread.ManagedThreadId}");
        // }

        // 与上面方法完全一直，同时添加了Await与Async
        // 注意与FuncVoid进行比较，比较执行过程与各个步骤的线程id
        // 此时的效果与前面的就不一样了，可以看到FuncVoidAwaitAsync一定在FuncVoidAwaitAsync's Task之后End
        // 猜测是被await关键字阻塞了，但是winform并没有阻塞，效果就像是await后面的代码变成了await的回调
        // 主线程在遇到await后，就继续执行，可以和子线程并行执行了
        // await只能出现在Task前面，而且必须与async一起使用，不能单独使用
        public async void FuncVoidAwaitAsync()
        {
            // 调用线程执行
            Console.WriteLine($"This is FuncVoidAwaitAsync Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            // 调用线程发起，启动新线程执行内部动作
            Task task = Task.Run(() =>
            {
                // Task子线程执行
                Console.WriteLine($"This is FuncVoidAwaitAsync's Task Start\t\t{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(random.Next(1000, 4000));
                Console.WriteLine($"This is FuncVoidAwaitAsync's Task   End\t\t{Thread.CurrentThread.ManagedThreadId}");
            });
            await task;  // 调用线程回去忙自己的事了
                         // Task子线程执行，如果没有await关键字，那么应该由调用线程执行
                         // 可以认为，有了await关键字，等同于将await关键字后面的代码，包装成了一个回调函数
                         // 而回调的线程（线程id）具有多种可能性
                         // 参考FuncVoid2()方法
            Console.WriteLine($"This is FuncVoidAwaitAsync   End\t\t{Thread.CurrentThread.ManagedThreadId}");
        }

        public void FuncVoid2()
        {
            Console.WriteLine($"This is FuncVoid Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"This is FuncVoid's Task Start\t\t{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(random.Next(1000, 4000));
                Console.WriteLine($"This is FuncVoid's Task   End\t\t{Thread.CurrentThread.ManagedThreadId}");
            });

            task.ContinueWith(t => Console.WriteLine($"This is FuncVoid   End\t\t{Thread.CurrentThread.ManagedThreadId}"));
        }

        // 多嵌套一层，观察代码执行过程
        public async void FuncVoidAwaitAsync2()
        {
            Console.WriteLine($"This is FuncVoidAwaitAsync2 Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"This is FuncVoidAwaitAsync2's Task1 Start\t\t{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(random.Next(1000, 4000));
                Console.WriteLine($"This is FuncVoidAwaitAsync2's Task1   End\t\t{Thread.CurrentThread.ManagedThreadId}");
            });
            await task;
            Console.WriteLine($"This is FuncVoidAwaitAsync2   End1\t\t{Thread.CurrentThread.ManagedThreadId}");

            // 再来一次await，这里无论使用多少层await，每一层await后面的都相当于当前线程的回调了，就是await嵌套了而已
            // 这样的话，await/async的代码是多线程的，同时又是从上向下执行的，因为下面的就是上面的回调
            // 也就是说，可以使用同步编码的形式去写异步
            await Task.Run(() =>
            {
                Console.WriteLine($"This is FuncVoidAwaitAsync2's Task2 Start\t\t{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(random.Next(1000, 4000));
                Console.WriteLine($"This is FuncVoidAwaitAsync2's Task2   End\t\t{Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"This is FuncVoidAwaitAsync2   End2\t\t{Thread.CurrentThread.ManagedThreadId}");
        }

        // 尽管方法体内没有写return，但是方法是正确的，而且执行效果与上面的FuncVoidAwaitAsync一致
        // 使用await/async后，原本没有返回值的方法，可以返回Task，原本返回X类型的方法，可以返回Task<X>方法
        // 一般来说，用了await/async，就不要使用void，没有返回值就返回Task就行了，否则在调用时就不能使用await了
        // 感觉有点反人类，先记住
        public async Task FuncReturnTask()
        {
            Console.WriteLine($"This is FuncReturnTask Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"This is FuncReturnTask's Task Start\t\t{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(random.Next(1000, 4000));
                Console.WriteLine($"This is FuncReturnTask's Task   End\t\t{Thread.CurrentThread.ManagedThreadId}");
            });
            await task;
            Console.WriteLine($"This is FuncReturnTask   End\t\t{Thread.CurrentThread.ManagedThreadId}");
        }

        // 测试方法，无法得到真正的返回值（结果永远为0），因为向操作系统申请线程后，主线程就立刻向下走了
        public long FuncReturnLong()
        {
            Console.WriteLine($"This is FuncReturnLong Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            long result = 0;
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"This is FuncReturnLong's Task Start\t\t{Thread.CurrentThread.ManagedThreadId}");
                Enumerable.Range(1, random.Next(100000000, 400000000)).ToList().ForEach(i => result += i);
                Console.WriteLine($"This is FuncReturnLong's Task   End\t\t{Thread.CurrentThread.ManagedThreadId}\t{result}");
                //return result;
            });
            Console.WriteLine($"This is FuncReturnLong   End\t\t{Thread.CurrentThread.ManagedThreadId}");

            return result;
        }

        // 带有返回值的Await/Async，但是阻塞了
        // 使用await/async后，原本没有返回值的方法，可以返回Task，原本返回X类型的方法，可以返回Task<X>方法
        // 一般来说，用了await/async，就不要使用void，没有返回值就返回Task就行了，否则在调用时就不能使用await了
        // 感觉有点反人类，先记住
        public async Task<long> FuncReturnLongAwaitAsync()
        {
            Console.WriteLine($"This is FuncReturnLongAwaitAsync Start\t\t{Thread.CurrentThread.ManagedThreadId}");
            long result = 0;
            Task task = Task.Run(() =>
            {
                Console.WriteLine($"This is FuncReturnLongAwaitAsync's Task Start\t\t{Thread.CurrentThread.ManagedThreadId}");
                Enumerable.Range(1, random.Next(100000000, 200000000)).ToList().ForEach(i => result += i);
                Console.WriteLine($"This is FuncReturnLongAwaitAsync's Task   End\t\t{Thread.CurrentThread.ManagedThreadId}\t{result}");
            });
            await task;
            Console.WriteLine($"This is FuncReturnLongAwaitAsync   End\t\t{Thread.CurrentThread.ManagedThreadId}");

            return result;
        }
    }
}
