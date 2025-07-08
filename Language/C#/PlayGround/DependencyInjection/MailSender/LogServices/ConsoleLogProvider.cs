using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    /// <summary>
    /// 实现类可以考虑在其它项目中创建，这里图省事直接创建在类库项目中
    /// </summary>
    public class ConsoleLogProvider : ILogProvider
    {
        public void LogError(string msg)
        {
            Console.WriteLine($"Error: {msg}");
        }

        public void LogInfo(string msg)
        {
            Console.WriteLine($"Info: {msg}");
        }
    }
}
