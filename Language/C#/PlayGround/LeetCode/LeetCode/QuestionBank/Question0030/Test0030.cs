using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0030
{
    public class Test0030
    {
        public void Test()
        {
            Interface0030 solution = new Solution0030_2();
            string s; string[] words;
            IList<int> result, answer;
            int id = 0;

            // 1.
            s = "barfoothefoobarman"; words = new string[] { "foo", "bar" };
            answer = new List<int>() { 0, 9 };
            result = solution.FindSubstring(s, words);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2.
            s = "wordgoodgoodgoodbestword"; words = new string[] { "word", "good", "best", "word" };
            answer = new List<int>();
            result = solution.FindSubstring(s, words);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3.
            s = "barfoofoobarthefoobarman"; words = new string[] { "bar", "foo", "the" };
            answer = new List<int>() { 6, 9, 12 };
            result = solution.FindSubstring(s, words);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
