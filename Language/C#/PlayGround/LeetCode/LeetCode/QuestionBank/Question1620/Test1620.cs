using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1620
{
    public class Test1620
    {
        public void Test()
        {
            Interface1620 solution = new Solution1620();
            int[][] towers; int radius;
            int[] result, answer;
            int id = 0;

            // 1.
            towers = new int[][] { new int[] { 1, 2, 5 }, new int[] { 2, 1, 7 }, new int[] { 3, 1, 9 } };
            radius = 2; answer = new int[] { 2, 1 };
            result = solution.BestCoordinate(towers, radius);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {result}, answer: {answer}");

            // 2.
            towers = new int[][] { new int[] { 23, 11, 21 } };
            radius = 9; answer = new int[] { 23, 11 };
            result = solution.BestCoordinate(towers, radius);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {result}, answer: {answer}");

            // 3.
            towers = new int[][] { new int[] { 1, 2, 13 }, new int[] { 2, 1, 7 }, new int[] { 0, 1, 9 } };
            radius = 2; answer = new int[] { 1, 2 };
            result = solution.BestCoordinate(towers, radius);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {result}, answer: {answer}");

            // 4.
            towers = new int[][] { new int[] { 42, 0, 0 } };
            radius = 7; answer = new int[] { 0, 0 };
            result = solution.BestCoordinate(towers, radius);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {result}, answer: {answer}");

            // 5.
            towers = new int[][] { new int[] { 1, 2, 13 }, new int[] { 2, 1, 7 }, new int[] { 0, 1, 9 }, new int[] { 3, 1, 9 }, new int[] { 7, 8, 9 }, new int[] { 8, 7, 10 }, new int[] { 12, 21, 33 }, new int[] { 10, 10, 18 }, new int[] { 49, 49, 9 } };
            radius = 8; answer = new int[] { 12, 21 };
            result = solution.BestCoordinate(towers, radius);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {result}, answer: {answer}");

            // 6.
            towers = new int[][] { new int[] { 1, 2, 13 }, new int[] { 2, 1, 7 }, new int[] { 0, 1, 9 }, new int[] { 3, 1, 9 }, new int[] { 7, 8, 9 }, new int[] { 8, 7, 10 }, new int[] { 12, 21, 33 }, new int[] { 10, 10, 18 }, new int[] { 49, 49, 49 } };
            radius = 8; answer = new int[] { 49, 49 };
            result = solution.BestCoordinate(towers, radius);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {result}, answer: {answer}");
        }
    }
}
