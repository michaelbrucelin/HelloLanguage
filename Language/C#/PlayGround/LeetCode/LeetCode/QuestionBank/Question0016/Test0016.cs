using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0016
{
    public class Test0016
    {
        public void Test()
        {
            Interface0016 solution = new Solution0016_3();
            int[] nums; int target;
            int result, answer;
            int id = 0;

            nums = new int[] { -1, 2, 1, -4 }; target = 1; answer = 2;
            result = solution.ThreeSumClosest(nums, target);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { 0, 0, 0 }; target = 1; answer = 0;
            result = solution.ThreeSumClosest(nums, target);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { 4, 0, 5, -5, 3, 3, 0, -4, -5 }; target = -2; answer = -2;
            result = solution.ThreeSumClosest(nums, target);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { -1, 2, 1, -4, 3, 4, 5, 6, -9, -8, -5, -3, 10, 13, 16 }; target = 10; answer = 10;
            result = solution.ThreeSumClosest(nums, target);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { -1, 2, 1, -4, 3, 4, 5, 6, -9, -8, -5, -3, 10, 13, 16 }; target = 49; answer = 39;
            result = solution.ThreeSumClosest(nums, target);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
