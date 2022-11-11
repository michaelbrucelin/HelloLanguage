// See https://aka.ms/new-console-template for more information

// using my_implement_csharp.第5章_串;

using my_implement_csharp.第6章_树;

Console.WriteLine("Hello, World!");

// Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

_99Test tester = new _99Test();

#region KMP
// tester.TestNext(2);
// tester.TestKMP(2);
#endregion

#region 二叉树
// tester.TestTraverse_2_2();
tester.TestPreOrderBuilder();  // ABDG##H###CE#I##F##  ABDH#K###E##CFI###G#J##
// tester.TestPrint();
#endregion
