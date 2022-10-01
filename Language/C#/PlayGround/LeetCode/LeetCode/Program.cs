using LeetCode.Interview.Interview1709;
using LeetCode.QuestionBank.Question0018;
using LeetCode.LCP.LCP0030;
using LeetCode.剑指_Offer.剑指_Offer_0053_1;
using LeetCode.剑指_Offer_II.剑指_Offer_II_0031;
using System;
using System.Collections.Generic;
using LeetCode.Utilses;
using System.Linq;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Test0018 test = new();
            test.Test();
            // Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            //var list = PatternSplit("aa..*d");
            //Utils.ArrayToString(list.Select(item => item.pattern).ToArray());
            //Console.WriteLine(Utils.ArrayToString(PatternSplit("aa..*d")));

            // Console.WriteLine(Math.Floor((2 - 3) / 2d));

            // Console.WriteLine(Utils.GenerateRandomIntArray(30, 0, 1000));

            // 检查整型是否溢出
            //int x = int.MaxValue;
            //Console.WriteLine(x);
            //Console.WriteLine($"checked(x-1): {checked(x - 1)}");
            //Console.WriteLine($"checked(x+1): {checked(x + 1)}");

            //int[] helper = new int[26];
            //Array.Fill(helper, -100);
            //Console.WriteLine(helper[3]);

            //SortedList<int, int> list = new SortedList<int, int>();
            //list.Add(5, 5);
            //list.Add(4, 4);
            //list.Add(1, 1);
            //list.Add(2, 2);
            //list.Add(0, 0);
            //list.Add(2, 2);  // 报错
            //Console.WriteLine($"{list.Values[0]}, {list.Values[1]}, {list.Values[2]}, {list.Values[3]}, {list.Values[4]}");

            //bool[] arr = new bool[10];  // 默认值是false
            //Console.WriteLine(arr[8]);

            //Tuple<int, int, int> tuple = new Tuple<int, int, int>(1, 2, 3);
            //Console.WriteLine(tuple.ToString());

            //(int, int, int) tuple2 = (1, 2, 3);
            //Console.WriteLine(tuple2.ToString());

            //HashSet<int> hashset = new HashSet<int>();
            //hashset.Add(10);
            //hashset.Add(6);
            //hashset.Add(8);
            //hashset.Add(10);
            //foreach (int i in hashset) Console.WriteLine(i);

            //SortedSet<int> sortedset = new SortedSet<int>();
            //sortedset.Add(10);
            //sortedset.Add(6);
            //sortedset.Add(8);
            //sortedset.Add(10);
            //foreach (int i in sortedset) Console.WriteLine(i);

            //Stack<int> stack = new Stack<int>();
            //stack.Push(3);
            //stack.Push(2);
            //stack.Push(1);
            //stack.Push(9);
            //List<int> list = new List<int>(stack);
            //Utils.PrintArray(list);

            //int[] arr1 = new int[] { 1, 3, 5, 7, 9 };
            //int[] arr2 = new int[] { 0, 2, 4, 6, 8 };
            //Console.WriteLine(arr1[0]);
            //Console.WriteLine(arr2[0]);
            //(arr1, arr2) = (arr2, arr1);
            //Console.WriteLine(arr1[0]);
            //Console.WriteLine(arr2[0]);
        }

        private static List<(int type, string pattern)> PatternSplit(string pattern)
        {
            List<(int type, string pattern)> patterns = new List<(int, string)>();
            List<char> buffer = new List<char>();
            for (int i = 0; i < pattern.Length; i++)
            {
                switch (pattern[i])
                {
                    case '.':
                        if (buffer.Count > 0) { patterns.Add((1, new string(buffer.ToArray()))); buffer = new List<char>(); }
                        if (i + 1 < pattern.Length && pattern[i + 1] == '*') { patterns.Add((4, ".*")); i++; }
                        else patterns.Add((3, "."));
                        break;
                    case '*':
                        if (buffer.Count == 0) throw new Exception("Invalid Input.");  // 题目不允许 * 前面没有其他字符
                        string item = $"{buffer.Last()}*";
                        buffer.RemoveAt(buffer.Count - 1);
                        if (buffer.Count > 0) { patterns.Add((1, new string(buffer.ToArray()))); buffer = new List<char>(); }
                        patterns.Add((2, item));
                        break;
                    default:  // 小写字母
                        buffer.Add(pattern[i]);
                        break;
                }
            }
            if (buffer.Count > 0) patterns.Add((1, new string(buffer.ToArray())));

            return patterns;
        }
    }
}
