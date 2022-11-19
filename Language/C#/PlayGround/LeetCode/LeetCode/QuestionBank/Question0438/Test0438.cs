using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0438
{
    public class Test0438
    {
        public void Test()
        {
            Interface0438 solution = new Solution0438_4();
            string s, p;
            IList<int> result, answer;
            int id = 0;

            // 1.
            s = "cbaebabacd"; p = "abc"; answer = new List<int>() { 0, 6 };
            result = solution.FindAnagrams(s, p);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2.
            s = "abab"; p = "ab"; answer = new List<int>() { 0, 1, 2 };
            result = solution.FindAnagrams(s, p);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3.
            s = "abab"; p = "ababab"; answer = new List<int>();
            result = solution.FindAnagrams(s, p);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            s = "baa"; p = "aa"; answer = new List<int>() { 1 };
            result = solution.FindAnagrams(s, p);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
