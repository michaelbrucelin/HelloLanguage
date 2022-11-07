using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0816
{
    public class Test0816
    {
        public void Test()
        {
            Interface0816 solution = new Solution0816();
            string s;
            IList<string> result, answer;
            int id = 0;

            // 1.
            s = "(123)"; answer = "(1, 2.3);(1, 23);(1.2, 3);(12, 3)".Split(';').ToList();
            result = solution.AmbiguousCoordinates(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2.
            s = "(0123)"; answer = "(0, 1.23);(0, 12.3);(0, 123);(0.1, 2.3);(0.1, 23);(0.12, 3)".Split(';').ToList();
            result = solution.AmbiguousCoordinates(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3.
            s = "(00011)"; answer = "(0, 0.011);(0.001, 1)".Split(';').ToList();
            result = solution.AmbiguousCoordinates(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4.
            s = "(100)"; answer = "(10, 0)".Split(';').ToList();
            result = solution.AmbiguousCoordinates(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5.
            s = "(001001)"; answer = "(0, 0.1001);(0.01, 0.01)".Split(';').ToList();
            result = solution.AmbiguousCoordinates(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer)}, result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
