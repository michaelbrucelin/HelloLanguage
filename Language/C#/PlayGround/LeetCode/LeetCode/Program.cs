using LeetCode.QuestionBank.Question1224;
using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution1224_2 question = new Solution1224_2();
            Console.WriteLine($"2 : {question.MaxEqualFreq(new int[] { 1, 1 })}");
            Console.WriteLine($"3 : {question.MaxEqualFreq(new int[] { 1, 1, 2 })}");
            Console.WriteLine($"5 : {question.MaxEqualFreq(new int[] { 1, 1, 1, 2, 2, 2 })}");
            Console.WriteLine($"7 : {question.MaxEqualFreq(new int[] { 2, 2, 1, 1, 5, 3, 3, 5 })}");
            Console.WriteLine($"8 : {question.MaxEqualFreq(new int[] { 10, 2, 8, 9, 3, 8, 1, 5, 2, 3, 7, 6 })}");
            Console.WriteLine($"13: {question.MaxEqualFreq(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5 })}");
            // question.Test();
        }
    }
}
