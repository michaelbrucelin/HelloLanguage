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
// tester.TestPreOrderBuilder();    // ABDG##H###CE#I##F##   ABDH#K###E##CFI###G#J##
// tester.TestPostOrderBuilder();   // ##G##HD#B###IE##FCA$  ###KH#D##EB##I#F###JGCA$  结尾的$表示录入结束
// tester.TestLevelOrderBuilder();  // ABCD#EFGH#I########   ABCDEFGH###I##J#K######
// tester.TestPreOrderBuilder("ABDG##H###CE#I##F##");
// tester.TestPostOrderBuilder("##G##HD#B###IE##FCA");
tester.TestLevelOrderBuilder("ABCD#EFGH#I########");
// tester.TestPrint();
#endregion

#region PlayGround
//string s = "ABCDEFGH";
//Queue<char> queue = new Queue<char>(s);
//while (queue.Count > 0) Console.WriteLine(queue.Dequeue());
//Console.WriteLine();

//string s = "ABCDEFGH";
//Stack<char> stack = new Stack<char>(s);
//while (stack.Count > 0) Console.WriteLine(stack.Pop());
//Console.WriteLine();
#endregion
