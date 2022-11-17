using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public class MyUtilsBinary_Test
    {
        //public static void Main(string[] args)
        //{
        //    MyUtilsBinary_Test test = new MyUtilsBinary_Test();
        //    test.VerifyBitCount(1000);
        //    test.TimeBitCount(100000000);
        //}

        public void VerifyBitCount(int count)
        {
            Random random = new Random();
            uint[] nums = new uint[count];
            Parallel.For(0, nums.Length, i => nums[i] = (uint)random.Next(0, int.MaxValue));

            for (int i = 0; i < nums.Length; i++)
            {
                int r1 = MyUtilsBinary.BitCount(nums[i]);
                int r2 = MyUtilsBinary.BitCount2(nums[i]);
                if (r1 != r2)
                {
                    Console.WriteLine($"{i,3}: {r1 == r2,5}, {r1}, {r2}");
                    return;
                }
            }

            Console.WriteLine("全部正确。");
        }

        public void TimeBitCount(int count)
        {
            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();

            uint[] nums = new uint[count];
            Parallel.For(0, nums.Length, i => nums[i] = (uint)random.Next(0, int.MaxValue));

            stopwatch.Start();
            for (int i = 0; i < nums.Length; i++) MyUtilsBinary.BitCount(nums[i]);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < nums.Length; i++) MyUtilsBinary.BitCount2(nums[i]);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
