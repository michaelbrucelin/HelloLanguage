using System;

namespace TestCSharp
{
    public class Program
    {
        public const int A1 = B1 * 10;
        public const int B1 = 10;
        public static readonly int A2 = B2 * 10;
        public static readonly int B2 = 10;

        /// <summary>
        /// 二者本质的区别在于
        /// const的值是在编译期间确定的，因此只能在声明时通过常量表达式指定其值
        /// 而static readonly是在运行时计算出其值的，所以还可以通过静态构造函数来赋值
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine($"A1 is {A1}, B1 is {B1}");  // A1 is 100, B1 is 10
            Console.WriteLine($"A2 is {A2}, B2 is {B2}");  // A2 is 0,   B2 is 10
            Console.ReadLine();

            /*
             * const是静态常量，在编译的时候就将A1与B1的值确定下来了（即B1 = 10, A1 = B1 * 10 = 10 * 10 = 100）
             *     所以在Main函数中的输出是：A1 is 100, B1 is 10
             * static readonly是动态常量，变量的值在编译时不予以解析，所以都是默认值，由于A2与B2都是int，所以A2 = 0, B2 = 0
             *     当程序执行到A2 = B2 * 10时，A2 = 0 * 10 = 0, 程序接着执行到B2 = 10时，才会将10赋给B2
             */
        }
    }
}
