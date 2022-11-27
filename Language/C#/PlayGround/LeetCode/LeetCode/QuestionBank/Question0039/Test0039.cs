using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0039
{
    public class Test0039
    {
        public void Test()
        {
            Interface0039 solution = new Solution0039_2();
            int[] candidates; int target;
            IList<IList<int>> result, answer;
            int id = 0;

            // 1. 
            candidates = new int[] { 2, 3, 6, 7 }; target = 7;
            answer = new List<IList<int>>() { new List<int>() { 2, 2, 3 }, new List<int>() { 7 } };
            result = solution.CombinationSum(candidates, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 2. 
            candidates = new int[] { 2, 3, 5 }; target = 8;
            answer = new List<IList<int>>() { new List<int>() { 2, 2, 2, 2 }, new List<int>() { 2, 3, 3 }, new List<int>() { 3, 5 } };
            result = solution.CombinationSum(candidates, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 3. 
            candidates = new int[] { 2 }; target = 1;
            answer = new List<IList<int>>();
            result = solution.CombinationSum(candidates, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            // 4. 
            candidates = new int[] { 4, 2, 8 }; target = 8;
            answer = new List<IList<int>>() { new List<int>() { 4, 4 }, new List<int>() { 4, 2, 2 }, new List<int>() { 2, 2, 2, 2 }, new List<int>() { 8 } };
            result = solution.CombinationSum(candidates, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");
        }
    }
}
