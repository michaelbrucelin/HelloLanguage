using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int low = 2147483647, high = 2147483647;
            Console.WriteLine($"low = {low}, high = {high}");
            Console.WriteLine($"(low + high) / 2:          {(low + high) / 2}");           // 溢出，结果为：-1
            Console.WriteLine($"low + ((high - low) >> 1): {low + ((high - low) >> 1)}");  // 正确，结果为：2147483647
            Console.WriteLine($"(low + high) >> 1:         {(low + high) >> 1}");          // 溢出，结果为：-1
            Console.WriteLine($"(low + high) >>> 1:        {(low + high) >>> 1}");         // 正确，结果为：2147483647

            low = -2147483648; high = 2147483641;
            Console.WriteLine($"low = {low}, high = {high}");
            Console.WriteLine($"(low + high) / 2:          {(low + high) / 2}");           // 正确，结果为：-3
            Console.WriteLine($"low + ((high - low) >> 1): {low + ((high - low) >> 1)}");  // 溢出，结果为：2147483644
            Console.WriteLine($"(low + high) >> 1:         {(low + high) >> 1}");          // 正确，结果为：-4
            Console.WriteLine($"(low + high) >>> 1:        {(low + high) >>> 1}");         // 错误，结果为：2147483644

            // 使用(low + high) >>> 1求平均值仅适用于结果保证不是负数的情况，但好处是即使两个数的和int溢出也能求出正确的结果
        }
    }
}
