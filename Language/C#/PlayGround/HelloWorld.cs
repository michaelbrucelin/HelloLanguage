using System;

namespace HelloWorld
{
    public class HelloWorld
    {
        public static void Main()
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

/*
没有找到更优雅的方式直接运行 .cs 代码，这里使用powershell的反射机制运行。
(Add-Type -Path "HelloWorld.cs" -PassThru)::Main()

将上面的ps脚本封装为方法，方便日后调用：
function myrun-csharp() {
    pwsh -Command "(Add-Type -Path '${1}' -PassThru)::Main()"
}
myrun-charp HelloWorld.cs

而且这样使用还有很多的限制，目前发现：
1. 只能含有一个类；
2. 只能包含静态方法；
*/