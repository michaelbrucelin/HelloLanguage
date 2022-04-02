using System;

class Class1
{
}

class Class2
{
    public void Method1(string s)
    {
        Console.WriteLine("Class2.Method1");
    }
}

class Class3
{
    public void Method1(object o)
    {
        Console.WriteLine("Class3.Method1");
    }
}

class Class4
{
    public void Method1(int i)
    {
        Console.WriteLine("Class4.Method1");
    }
}

static class Extensions
{
    static public void Method1(this object o, int i)
    {
        Console.WriteLine("Extensions.Method1");
    }

    static void Main()
    {
        new Class1().Method1(12); // Extensions.Method1 is called
        new Class2().Method1(12); // Extensions.Method1 is called
        new Class3().Method1(12); // Class3.Method1 is called
        new Class4().Method1(12); // Class4.Method1 is called
    }
}