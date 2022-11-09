using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0764
{
    public class Test0764
    {
        public void Test()
        {
            Interface0764 solution = new Solution0764();
            int n; int[][] mines;
            int result, answer;
            int id = 0;

            // 1.
            n = 5; mines = new int[][] { new int[] { 4, 2 } };
            answer = 2; result = solution.OrderOfLargestPlusSign(n, mines);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            n = 1; mines = new int[][] { new int[] { 0, 0 } };
            answer = 0; result = solution.OrderOfLargestPlusSign(n, mines);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            n = 3; mines = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 }, new int[] { 2, 1 }, new int[] { 2, 2 } };
            answer = 1; result = solution.OrderOfLargestPlusSign(n, mines);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            n = 3; mines = new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 }, new int[] { 2, 1 }, new int[] { 2, 2 } };
            answer = 0; result = solution.OrderOfLargestPlusSign(n, mines);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            n = 5; mines = new int[][] { new int[] { 4, 1 } };
            answer = 3; result = solution.OrderOfLargestPlusSign(n, mines);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }

        public void TestDivergentTraverse()
        {
            Utils0764 utils0764 = new Utils0764();

            utils0764.ExtendTraverse(1); Console.WriteLine(Environment.NewLine);
            utils0764.ExtendTraverse(2); Console.WriteLine(Environment.NewLine);
            utils0764.ExtendTraverse(3); Console.WriteLine(Environment.NewLine);
            utils0764.ExtendTraverse(4); Console.WriteLine(Environment.NewLine);
            utils0764.ExtendTraverse(5); Console.WriteLine(Environment.NewLine);
            utils0764.ExtendTraverse(6); Console.WriteLine(Environment.NewLine);
        }
    }
}
