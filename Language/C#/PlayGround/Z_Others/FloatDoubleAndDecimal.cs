using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine(1/0);   // 无法编译
            Console.WriteLine(1 / 0F);   // float
            Console.WriteLine(1 / 0D);   // double
            // Console.WriteLine(1/0M);  // decimal 无法编译

            Console.WriteLine($"{Environment.NewLine}1 / 3 = ?");
            float f13 = 1 / 3F;
            double d13 = 1 / 3D;
            decimal m13 = 1 / 3M;
            Console.WriteLine($"float:   {f13}");
            Console.WriteLine($"double:  {d13}");
            Console.WriteLine($"decimal: {m13}");

            Console.WriteLine($"{Environment.NewLine}f = 1 / 3; f * 3 = ?");
            Console.WriteLine($"float:   {f13 * 3}");
            Console.WriteLine($"double:  {d13 * 3}");
            Console.WriteLine($"decimal: {m13 * 3}");

            Console.WriteLine($"{Environment.NewLine}0.1 + 0.2 == 0.3");
            Console.WriteLine($"float:   {0.1F + 0.2F == 0.3F}");
            Console.WriteLine($"double:  {0.1D + 0.2D == 0.3D}");
            Console.WriteLine($"decimal: {0.1M + 0.2M == 0.3M}");

            Console.WriteLine($"{Environment.NewLine}0.1 * 0.1 = ?");
            Console.WriteLine($"float:   {0.1F * 0.1F}");
            Console.WriteLine($"double:  {0.1D * 0.1D}");
            Console.WriteLine($"decimal: {0.1M * 0.1M}");
        }
    }
}

/*
正无穷大
正无穷大

1 / 3 = ?
float:   0.33333334
double:  0.3333333333333333
decimal: 0.3333333333333333333333333333

f = 1 / 3; f * 3 = ?
float:   1
double:  1
decimal: 0.9999999999999999999999999999

0.1 + 0.2 == 0.3
float:   True
double:  False
decimal: True

0.1 * 0.1 = ?
float:   0.010000001
double:  0.010000000000000002
decimal: 0.01
*/
