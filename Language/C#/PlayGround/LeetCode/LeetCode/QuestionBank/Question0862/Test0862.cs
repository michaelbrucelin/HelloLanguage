using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0862
{
    public class Test0862
    {
        public void Test()
        {
            Interface0862 solution = new Solution0862();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1 }; k = 1; answer = 1;
            result = solution.ShortestSubarray(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            nums = new int[] { 1, 2 }; k = 4; answer = -1;
            result = solution.ShortestSubarray(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            nums = new int[] { 2, -1, 2 }; k = 3; answer = 3;
            result = solution.ShortestSubarray(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { -62, -95, -3, 86, 18, -61, 6, -23, 19, 11, 74, -68, -44, -81, 3, -81, 22, -83, -68, 55, 69, 6, 25, -19, -91, -17, 81, -16, -19, 64, -61, -88, -25, 38, -10, -33, -66, -20, -28, -91, 34, -32, -6, -48, 18, 71, -56, -87, 90, 39, -24, -17, -96, 32, 18, -57, -78, 88, -33, 14, 21, 4, -25, -16, 93, 1, 62, -5, -75, -13, -72, 43, -39, 25, 49, -31, 51, 5, -50, 50, 79, 44, -59, -17, 80, 97, 53, 46, 45, 49, 80, 71, 18, -98, -15, 66, 76, 99, 38, -28 };
            k = 1; answer = 1;
            result = solution.ShortestSubarray(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
