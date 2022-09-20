using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0698
{
    public class Test0698
    {
        public void Test()
        {
            Interface0698 solution = new Solution0698();
            int[] nums; int k;
            bool result, answer;
            int id = 0;

            nums = new int[] { 4, 3, 2, 3, 5, 2, 1 }; k = 4; answer = true;
            result = solution.CanPartitionKSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { 1, 2, 3, 4 }; k = 3; answer = false;
            result = solution.CanPartitionKSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { 1 }; k = 1; answer = true;
            result = solution.CanPartitionKSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { 1, 1, 1, 1, 2, 2, 2, 2 }; k = 2; answer = true;
            result = solution.CanPartitionKSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums = new int[] { 4, 4, 6, 2, 3, 8, 10, 2, 10, 7 }; k = 4; answer = true;
            result = solution.CanPartitionKSubsets(nums, k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
