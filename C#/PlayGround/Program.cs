using System;
using System.Collections.Generic;
using System.Linq;
using MyTestNameSpace;
namespace PlayGround
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IEnumerable<string> strEnum = MyBasic.GeneratedStrings().Take(100);
            foreach (string item in strEnum)
            {
                System.Console.WriteLine(item);
            }

            /*
            int[] arr = { 0, 1, 2, 3 };
            func_arr(arr);
            System.Console.WriteLine(arr[0]);

            int i = 0, j = 0;
            func_int(i);
            func_int(ref j);
            System.Console.WriteLine(i);
            System.Console.WriteLine(j);
            */
        }

        private static void func_arr(int[] arr)
        {
            arr[0] = 100;
        }

        private static void func_int(int i)
        {
            i = 100;
        }

        private static void func_int(ref int i)
        {
            i = 100;
        }
    }
}
