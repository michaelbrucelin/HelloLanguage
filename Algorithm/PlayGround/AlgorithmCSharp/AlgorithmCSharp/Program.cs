// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// using AlgorithmCSharp.Algorithm.KMP;
using AlgorithmCSharp.Algorithm.Tree.BinaryTree;

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
Console.WriteLine("前序遍历测试"); test.TestTraverse_PreOrder();
Console.WriteLine("中序遍历测试"); test.TestTraverse_InOrder();
Console.WriteLine("后序遍历测试"); test.TestTraverse_PostOrder();
Console.WriteLine("层序遍历测试"); test.TestTraverse_LevelOrder();
#endregion
