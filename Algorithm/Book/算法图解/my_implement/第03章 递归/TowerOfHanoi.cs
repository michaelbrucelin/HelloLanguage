using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            int level = 10;

            TowerOfHanoi(level, "TA", "TB", "TC");
            Console.WriteLine($"Level {level} Tower of Hanoi requires a total of {steps} steps to complete.");
        }

        static int steps = 0;

        private static void TowerOfHanoi(int level, string TA, string TB, string TC)
        {
            if (level == 0)
            {
                Console.WriteLine("there is no data in TA.");
                return;
            }

            if (level == 1)
            {
                Console.WriteLine($"{TA}-->{TC}");
                steps++;
            }
            else
            {
                TowerOfHanoi(level - 1, TA, TC, TB);
                TowerOfHanoi(1, TA, TB, TC);
                TowerOfHanoi(level - 1, TB, TA, TC);
            }
        }
    }
}
