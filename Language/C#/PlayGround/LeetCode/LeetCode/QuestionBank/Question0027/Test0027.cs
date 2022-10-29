using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0027
{
    public class Test0027
    {
        public void Test()
        {
            Interface0027 solution = new Solution0027();
            int[] nums; int val, len;
            string result, answer;
            int id = 0;

            // 1.
            nums = new int[] { 3, 2, 2, 3 }; val = 3;
            len = solution.RemoveElement(nums, val);
            answer = "2,[2,2]"; result = $"{len},{Utils.ArrayToString(nums, 0, len).Replace(" ", "")}";
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }; val = 2;
            len = solution.RemoveElement(nums, val);
            answer = "5,[0,1,4,0,3]"; result = $"{len},{Utils.ArrayToString(nums, 0, len).Replace(" ", "")}";
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            nums = new int[] { }; val = 1;
            len = solution.RemoveElement(nums, val);
            answer = "0,[]"; result = $"{len},{Utils.ArrayToString(nums, 0, len).Replace(" ", "")}";
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            nums = new int[] { 1 }; val = 1;
            len = solution.RemoveElement(nums, val);
            answer = "0,[]"; result = $"{len},{Utils.ArrayToString(nums, 0, len).Replace(" ", "")}";
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            nums = new int[] { 1, 1 }; val = 1;
            len = solution.RemoveElement(nums, val);
            answer = "0,[]"; result = $"{len},{Utils.ArrayToString(nums, 0, len).Replace(" ", "")}";
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 6.
            nums = new int[] { 1, 1, 1 }; val = 1;
            len = solution.RemoveElement(nums, val);
            answer = "0,[]"; result = $"{len},{Utils.ArrayToString(nums, 0, len).Replace(" ", "")}";
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 7.
            nums = new int[] { 4, 5 }; val = 5;
            len = solution.RemoveElement(nums, val);
            answer = "1,[4]"; result = $"{len},{Utils.ArrayToString(nums, 0, len).Replace(" ", "")}";
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 8.
            nums = new int[] { 2, 2, 3 }; val = 2;
            len = solution.RemoveElement(nums, val);
            answer = "1,[3]"; result = $"{len},{Utils.ArrayToString(nums, 0, len).Replace(" ", "")}";
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
