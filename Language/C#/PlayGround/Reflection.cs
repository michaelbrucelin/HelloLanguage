using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> list_int = new List<int>();

            // Type type = typeof(List<>);     // 错误，编译可以通过，但是下面执行到添加元素的位置时会报错
            // Type type = typeof(List<int>);  // 正确
            Type type = list_int.GetType();
            MethodInfo method = type.GetMethod("Add");

            method.Invoke(list_int, new object[] { 1 });
            method.Invoke(list_int, new object[] { 2 });
            // method.Invoke(list_int, new object[] { "a" });  // 异常，C#的泛型不会像Java那样被擦除掉

            foreach (object item in list_int)
                Console.Write($"{item}, ");
        }
    }
}

/*
1, 2, 
*/
