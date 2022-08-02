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
            // 测试使用结构体作为字典的Key，可以用
            Dictionary<TestStruct, string> structkey = new Dictionary<TestStruct, string>();

            TestStruct sa = new TestStruct(10, 10);
            TestStruct sb = new TestStruct(10, 20);
            TestStruct sc = new TestStruct(20, 20);
            TestStruct sd = new TestStruct(20, 10);
            TestStruct se = new TestStruct(10, 10);

            structkey.Add(sa, "Struct A");
            structkey.Add(sb, "Struct B");
            structkey.Add(sc, "Struct C");
            structkey.Add(sd, "Struct D");
            // structkey.Add(se, "Struct E");  // 异常

            Console.WriteLine(structkey[se]);  // A

            // 测试使用类作为字典的Key，可以用
            Dictionary<TestClass, string> classkey = new Dictionary<TestClass, string>();

            TestClass ca = new TestClass(10, 10);
            TestClass cb = new TestClass(10, 20);
            TestClass cc = new TestClass(20, 20);
            TestClass cd = new TestClass(20, 10);
            TestClass ce = new TestClass(10, 10);

            classkey.Add(ca, "Class A");
            classkey.Add(cb, "Class B");
            classkey.Add(cc, "Class C");
            classkey.Add(cd, "Class D");
            // classkey.Add(ce, "Class E");   // 异常

            Console.WriteLine(classkey[ce]);  // A
        }
    }

    public struct TestStruct
    {
        public TestStruct(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public struct TestClass
    {
        public TestClass(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}

/*
Struct A
Class A
*/
