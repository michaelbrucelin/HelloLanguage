using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

class Program
{
    static void Main(string[] args)
    {
        CSharpCodeProvider csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
        CompilerParameters paras = new CompilerParameters(new string[] { "mscorlib.dll", "System.Core.dll" }, "foo.exe", true);
        paras.GenerateExecutable = true;
        CompilerResults results = csc.CompileAssemblyFromSource(paras,
            @"using System;
              using System.Linq;
              class Program {
                  public static void Main(string[] args) {
                      var q = from i in Enumerable.Range(1,100)
                              where i % 2 == 0
                              select i;
                      Console.WriteLine(""hello csc."");
                 }
              }");

        results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
        results.Output.Cast<string>().ToList().ForEach(output => Console.WriteLine(output));

        Console.WriteLine("done");
        Console.ReadKey();
    }
}
