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

            swap(a, b);

            Console.WriteLine("After: a=" + a.Name);
            Console.WriteLine("After: b=" + b.Name);

            Console.ReadLine();
        }

        public static void swap(Employee x, Employee y)
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
C#中引用类型的参数，也是值引用（没有使用ref限定的话），即复制了对象的一个新的引用，也就是说，方法无法更改变量的引用。
下面示例可以看出，在方法内部，确实交换了变量的引用，但是在方法外部，并没有真的交换了变量的引用。
运行结果：
Before: a=Alice
Before: b=Bob
Begin of method: x=Alice
Begin of method: y=Bob
End of method: x=Bob
End of method: y=Alice
After: a=Alice
After: b=Bob
*/