using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Section22 : Form
    {
        public Section22()
        {
            InitializeComponent();
        }

        private void Section22_Load(object sender, EventArgs e)
        {

        }

        private void btnSample01_Click(object sender, EventArgs e)
        {
            Parallel.For(0, 10, i => DoWork(i + 1));  // 内部10个任务是并行的，但是这条语句是阻塞的，
                                                      // 也就是说如果忽略内部10个任务是并行这一点，这条语句以同步的for循环没有区别

            Console.WriteLine($"all jobs is done.");
        }

        private void btnSample02_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string searchPattern = "*";
            long result = GetDirectoryBytes(path, searchPattern, SearchOption.AllDirectories);
            Console.WriteLine($"Directory \"{path}\"'s total bytes: {result}.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Utils.ClearTerminal();
        }

        private void DoWork(int i)
        {
            Thread.Sleep(1000 * i);
            Console.WriteLine($"job_{i} is done.");
        }

        /// <summary>
        /// Parallel.For与Foreach方法有一些重载版本允许传递3个委托
        ///     任务局部初始化委托（localInit），为参与工作的每个任务都调用一次该委托。这个委托是在任务被要求处理一个工作项之前调用的。
        ///     主体委托（body），为参与工作的各个线程所处理的每一项都调用一次该委托。
        ///     任务局部终结委托（localFinally），为参与工作的每一个任务都调用一次该委托。这个委托是在任务处理好派发给它的所有工作项之后调用的（回调？）。
        ///         即使主体委托代码引发一个未处理的异常，也会调用它。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        private long GetDirectoryBytes(string path, string searchPattern, SearchOption searchOption)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(path, searchPattern, searchOption);
            long masterTotal = 0;

            ParallelLoopResult result = Parallel.ForEach<string, long>(
                files,
                () =>
                {   // 参数localInit: 每个任务开始前调用一次
                    // 每个任务开始之前，总计值都初始化为0
                    return 0;  // 将taskLocalTotal初始值设为0
                },
                (file, loopState, index, taskLocalTotal) =>
                {   // 参数body: 每个工作项调用一次
                    // 获得这个文件的大小，把它添加到这个任务的累加值上
                    long fileLength = 0;
                    FileStream fs = null;
                    try
                    {
                        fs = File.OpenRead(file);
                        fileLength = fs.Length;
                    }
                    catch (IOException) { /* 忽略拒绝访问的任何文件 */ }
                    finally { if (fs != null) fs.Dispose(); }
                    return taskLocalTotal + fileLength;
                },
                taskLocalTotal =>
                {   // 参数localFinally: 每个任务完成时调用一次
                    // 将这个任务的总计值（taskLocalTotal）加到总计值（masterTotal）上
                    Interlocked.Add(ref masterTotal, taskLocalTotal);
                });

            return masterTotal;
        }
    }
}
