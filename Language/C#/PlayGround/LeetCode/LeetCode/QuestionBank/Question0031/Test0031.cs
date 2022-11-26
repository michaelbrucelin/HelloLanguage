using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0031
{
    public class Test0031
    {
        public void Test()
        {
            Interface0031 solution = new Solution0031();
            int[] nums;
            int[] answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 3 };
            answer = new int[] { 1, 3, 2 };
            solution.NextPermutation(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums, answer) + ",",-6} result: {Utils.ArrayToString(nums)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            nums = new int[] { 3, 2, 1 };
            answer = new int[] { 1, 2, 3 };
            solution.NextPermutation(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums, answer) + ",",-6} result: {Utils.ArrayToString(nums)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            nums = new int[] { 1, 1, 5 };
            answer = new int[] { 1, 5, 1 };
            solution.NextPermutation(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums, answer) + ",",-6} result: {Utils.ArrayToString(nums)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            nums = new int[] { 7, 8, 0, 9, 2, 4, 1, 6, 5, 3 };
            answer = new int[] { 7, 8, 0, 9, 2, 4, 3, 1, 5, 6 };
            solution.NextPermutation(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums, answer) + ",",-6} result: {Utils.ArrayToString(nums)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            nums = new int[] { 2, 6, 8, 9, 4, 3, 7, 5, 1, 0 };
            answer = new int[] { 2, 6, 8, 9, 4, 5, 0, 1, 3, 7 };
            solution.NextPermutation(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(nums, answer) + ",",-6} result: {Utils.ArrayToString(nums)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
