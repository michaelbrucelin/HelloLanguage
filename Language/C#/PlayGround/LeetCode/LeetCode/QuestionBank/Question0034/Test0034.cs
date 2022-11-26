using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0034
{
    public class Test0034
    {
        public void Test()
        {
            Interface0034 solution = new Solution0034();
            int[] nums; int target;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 5, 7, 7, 8, 8, 10 }; target = 8;
            answer = new int[] { 3, 4 }; result = solution.SearchRange(nums, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            nums = new int[] { 5, 7, 7, 8, 8, 10 }; target = 6;
            answer = new int[] { -1, -1 }; result = solution.SearchRange(nums, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            nums = new int[] { }; target = 0;
            answer = new int[] { -1, -1 }; result = solution.SearchRange(nums, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
