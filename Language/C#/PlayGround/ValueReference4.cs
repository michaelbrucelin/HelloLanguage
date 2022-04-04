using System;

namespace TestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee a = new Employee("Alice", 70000);
            Employee b = new Employee("Bob", 60000);
            Console.WriteLine("Before: a=" + a.Name);
            Console.WriteLine("Before: b=" + b.Name);

            swap(ref a, ref b);

            Console.WriteLine("After: a=" + a.Name);
            Console.WriteLine("After: b=" + b.Name);

            Console.ReadLine();
        }

        public static void swap(ref Employee x, ref Employee y)
        {
            Console.WriteLine("Begin of method: x=" + x.Name);
            Console.WriteLine("Begin of method: y=" + y.Name);
            Employee temp = x;
            x = y;
            y = temp;
            Console.WriteLine("End of method: x=" + x.Name);
            Console.WriteLine("End of method: y=" + y.Name);
        }
    }

    class Employee
    {
        public Employee(string n, double s)
        {
            Name = n;
            Salary = s;
        }

        public string Name { get; }
        public double Salary { get; }
    }
}

/*
C#中的参数，使用ref限定的话，就是引用传递，相当于C中的地址传递，即传递了变量的地址。
下面示例可以看出，在方法内部，确实交换了变量的引用，在方法外部，也确实交换了变量的引用。
运行结果：
Before: a=Alice
Before: b=Bob
Begin of method: x=Alice
Begin of method: y=Bob
End of method: x=Bob
End of method: y=Alice
After: a=Bob
After: b=Alice
*/