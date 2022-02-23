public class HelloWorld
{
    public static void Main()
    {
        System.Console.WriteLine("Hello, World!");
    }
}

/*
没有找到更优雅的方式直接运行 .cs 代码，这里使用powershell的反射机制运行。
(Add-Type -Path "HelloWorld.cs" -PassThru)::Main()
将上面的ps脚本封装为方法，方便日后调用：
MyRun-Dotnet ./HelloWorld.cs
*/