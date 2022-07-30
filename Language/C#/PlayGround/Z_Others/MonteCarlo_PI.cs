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
            Random random = new Random();

            Console.WriteLine($"Test 10000     times: {MonteCarlo_PI(random, 100000)}");
            Console.WriteLine($"Test 100000    times: {MonteCarlo_PI(random, 1000000)}");
            Console.WriteLine($"Test 1000000   times: {MonteCarlo_PI(random, 10000000)}");
            Console.WriteLine($"Test 10000000  times: {MonteCarlo_PI(random, 100000000)}");
            // Console.WriteLine($"Test 100000000 times: {MonteCarlo_PI(random, 1000000000)}");
        }

        /// <summary>
        /// 使用蒙特卡洛法计算PI的值
        /// </summary>
        /// <param name="random"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private static double MonteCarlo_PI(Random random, int count)
        {
            int score = 0;
            for (int i = 0; i < count; i++)
            {
                double x = random.NextDouble();
                double y = random.NextDouble();

                if (x * x + y * y < 1)
                    score++;
            }

            return 4.0D * score / count;
        }
    }
}
