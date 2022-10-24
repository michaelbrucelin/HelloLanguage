using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0915
{
    public class Test0915
    {
        public void Test()
        {
            Interface0915 solution = new Solution0915_3();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 5, 0, 3, 8, 6 }; answer = 3;
            result = solution.PartitionDisjoint(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 1, 1, 0, 6, 12 }; answer = 4;
            result = solution.PartitionDisjoint(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 24, 11, 49, 80, 63, 8, 61, 22, 73, 85 }; answer = 9;
            result = solution.PartitionDisjoint(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
