using System;

namespace WindowsFormsApp0
{
    /// <summary>  
    /// 与控制台交互  
    /// </summary>  
    public static class MyUtilsShell
    {
        /// <summary>  
        /// 输出信息  
        /// </summary>  
        /// <param name="format"></param>  
        /// <param name="args"></param>  
        public static void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }

        /// <summary>  
        /// 输出信息  
        /// </summary>  
        /// <param name="output"></param>  
        public static void WriteLine(string output)
        {
            Console.ForegroundColor = GetConsoleColor(output);
            Console.WriteLine(@"[{0}]{1}", DateTimeOffset.Now, output);
        }

        /// <summary>  
        /// 根据输出文本选择控制台文字颜色  
        /// </summary>  
        /// <param name="output"></param>  
        /// <returns></returns>  
        private static ConsoleColor GetConsoleColor(string output)
        {
            if (output.StartsWith("警告")) { return ConsoleColor.Yellow; }
            if (output.StartsWith("错误")) { return ConsoleColor.Red; }
            if (output.StartsWith("注意")) { return ConsoleColor.Green; }
            return ConsoleColor.Gray;
        }
    }
}
