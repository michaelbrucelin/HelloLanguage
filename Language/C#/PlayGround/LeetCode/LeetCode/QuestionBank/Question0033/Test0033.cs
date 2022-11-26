using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0033
{
    public class Test0033
    {
        public void Test()
        {
            Interface0033 solution = new Solution0033_2();
            int[] nums; int target;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 4, 5, 6, 7, 0, 1, 2 }; target = 0;
            answer = 4; result = solution.Search(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 4, 5, 6, 7, 0, 1, 2 }; target = 3;
            answer = -1; result = solution.Search(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 4, 5, 6, 7, 8, 9, 0, 1, 2 }; target = 5;
            answer = 1; result = solution.Search(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 1 }; target = 0;
            answer = -1; result = solution.Search(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; target = 5;
            answer = 4; result = solution.Search(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            nums = new int[] { 5, 1, 3 }; target = 0;
            answer = -1; result = solution.Search(nums, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
