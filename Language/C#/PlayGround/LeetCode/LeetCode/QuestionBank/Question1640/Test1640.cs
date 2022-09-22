using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1640
{
    public class Test1640
    {
        public void Test()
        {
            Interface1640 solution = new Solution1640_2();
            int[] arr; int[][] pieces;
            bool result, answer;
            int id = 0;

            arr = new int[] { 85 }; pieces = new int[][] { new int[] { 85 } }; answer = true;
            result = solution.CanFormArray(arr, pieces);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            arr = new int[] { 15, 88 }; pieces = new int[][] { new int[] { 88 }, new int[] { 15 } }; answer = true;
            result = solution.CanFormArray(arr, pieces);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            arr = new int[] { 49, 18, 16 }; pieces = new int[][] { new int[] { 16, 18, 49 } }; answer = false;
            result = solution.CanFormArray(arr, pieces);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            arr = new int[] { 91, 4, 64, 78 }; pieces = new int[][] { new int[] { 78 }, new int[] { 4, 64 }, new int[] { 91 } }; answer = true;
            result = solution.CanFormArray(arr, pieces);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
