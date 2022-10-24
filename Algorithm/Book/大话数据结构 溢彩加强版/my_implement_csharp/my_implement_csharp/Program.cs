// See https://aka.ms/new-console-template for more information
using my_implement_csharp.Utilses;
using my_implement_csharp.第5章_串;

Console.WriteLine("Hello, World!");

_02模式匹配_KMP test = new _02模式匹配_KMP();
string s;
int[] next;
int id = 0;

// 1.
s = "ababaaaba";
Console.WriteLine($"{++id,2}, {s}");
Utils.PrintArray(test.GetNext(s));

// 2.
s = "ababaaxba";
Console.WriteLine($"{++id,2}, {s}");
Utils.PrintArray(test.GetNext(s));
