using LeetCode.QuestionBank.Question0812;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution0812 question = new Solution0812();
            Console.WriteLine(question.LargestTriangleArea(new int[][] { new int[] { 1, 0 }, new int[] { 0, 0 }, new int[] { 0, 1 } }));
            // question.Test();
        }
    }
}
