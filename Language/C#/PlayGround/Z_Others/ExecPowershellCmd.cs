using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string cmd = "Test-NetConnection -ComputerName 127.0.0.1 -Port 6060 -InformationLevel Detailed";
            string output = ExecuteDosCmd(cmd);
            Console.WriteLine($"{output.Length}, {output}");

            cmd = "Test-NetConnection -ComputerName 8.8.8.8 -Port 6060 -InformationLevel Detailed";
            output = ExecuteDosCmd(cmd);
            Console.WriteLine($"{output.Length}, {output}");
        }

        /// <summary>
        /// 执行cmd命令，并获取结果
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="timeout">等待时间，milliseconds</param>
        /// <returns></returns>
        public static string ExecuteDosCmd(string cmd, int timeout = 0)
        {
            string output = "";                                  // 输出字符串

            if (cmd != null && cmd != "")
            {
                Process process = new Process();                 // 创建进程对象
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "powershell.exe";                // 设定需要执行的命令
                // info.Arguments = "-NoExit " + cmd;            // 设定参数
                info.Arguments = cmd;                            // 设定参数
                info.UseShellExecute = false;                    // 不使用系统外壳程序启动
                info.RedirectStandardInput = false;              // 不重定向输入
                info.RedirectStandardOutput = true;              // 重定向输出
                info.CreateNoWindow = true;                      // 不创建窗口
                process.StartInfo = info;
                try
                {
                    if (process.Start())                              // 开始进程
                    {
                        if (timeout == 0)
                            process.WaitForExit();                    // 这里无限等待进程结束
                        else
                            process.WaitForExit(timeout);             // 这里等待进程结束，等待时间为指定的毫秒
                        output = process.StandardOutput.ReadToEnd();  // 读取进程的输出
                    }
                }
                catch { }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }

            return output;
        }
    }
}
