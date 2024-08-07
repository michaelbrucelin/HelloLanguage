﻿// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// using AlgorithmCSharp.Algorithm.KMP;
using AlgorithmCSharp.Algorithm.Basic.BinaryEnum;
// using AlgorithmCSharp.Algorithm.Tree.BinaryTree;
using AlgorithmCSharp.Algorithm.Graph;

Test test = new Test();
// Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
// Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");
// Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
// Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

#region KMP
// test.Start();
#endregion

#region Binary Tree
// test.TestPrint();
// Console.WriteLine("二叉树遍历测试");
// Console.WriteLine($"{Environment.NewLine}前序遍历测试"); test.TestTraverse_PreOrder();
// Console.WriteLine($"{Environment.NewLine}中序遍历测试"); test.TestTraverse_InOrder();
// Console.WriteLine($"{Environment.NewLine}后序遍历测试"); test.TestTraverse_PostOrder();
// Console.WriteLine($"{Environment.NewLine}层序遍历测试"); test.TestTraverse_LevelOrder();
#endregion

#region Graph
// test.ShowInfo();
// Console.WriteLine("图遍历测试");
// Console.WriteLine($"{Environment.NewLine}邻接矩阵遍历测试"); test.TestTraverse_MGraph();
// Console.WriteLine($"{Environment.NewLine}邻接表  遍历测试"); test.TestTraverse_ALGraph();
// Console.WriteLine("图最小生成树测试");
// Console.WriteLine($"{Environment.NewLine}邻接矩阵最小生成树测试"); test.TestMST_MGraph();
// Console.WriteLine($"{Environment.NewLine}邻接表最小生成树测试"); test.TestMST_ALGraph();
// Console.WriteLine("图最短路径测试");
// Console.WriteLine($"{Environment.NewLine}邻接矩阵最短路径测试"); test.TestSP_MGraph();
// Console.WriteLine($"{Environment.NewLine}邻接表最短路径测试"); test.TestSP_ALGraph();
#endregion

#region TEST
{
    //Stack<char> stack = new Stack<char>();
    //stack.Push('a'); stack.Push('b'); stack.Push('c'); stack.Push('d'); stack.Push('e');
    //List<char> list = stack.ToList();
    //for (int i = 0; i < list.Count; i++) Console.WriteLine(list[i]);  // edcba
}

{
    //BinaryEnum.EnumSet(4);
    //BinaryEnum.EnumSubSet(21);   // 21:10101
    //BinaryEnum.EnumSubSet2(21);  // 21:10101
    //BinaryEnum.EnumKSet(8, 1);
}
#endregion
