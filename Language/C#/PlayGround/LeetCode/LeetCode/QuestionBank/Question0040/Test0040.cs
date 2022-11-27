using LeetCode.QuestionBank.Question0039;
using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0040
{
    public class Test0040
    {
        public void Test()
        {
            Interface0040 solution = new Solution0040_2();
            int[] candidates; int target;
            IList<IList<int>> result, answer;
            int id = 0;

            // 1. 
            candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 }; target = 8;
            answer = new List<IList<int>>() { new List<int>() { 1, 1, 6 }, new List<int>() { 1, 2, 5 }, new List<int>() { 1, 7 }, new List<int>() { 2, 6 } };
            result = solution.CombinationSum2(candidates, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 2. 
            candidates = new int[] { 2, 5, 2, 1, 2 }; target = 5;
            answer = new List<IList<int>>() { new List<int>() { 1, 2, 2 }, new List<int>() { 5 } };
            result = solution.CombinationSum2(candidates, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 3. 
            candidates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            target = 30;
            answer = new List<IList<int>>() { new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
            result = solution.CombinationSum2(candidates, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");
        }
    }
}
