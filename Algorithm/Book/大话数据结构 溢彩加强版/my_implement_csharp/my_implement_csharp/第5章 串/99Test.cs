using my_implement_csharp.Utilses;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第5章_串
{
    public class _99Test
    {
        public void TestNext(int type)
        {
            _02模式匹配_KMP test = new _02模式匹配_KMP();
            Func<string, int[]> func;
            if (type == 2) func = test.GetNext2; else func = test.GetNext;
            string s;
            int id = 0;

            // 1.
            s = "ababaaaba";
            Console.WriteLine($"{++id,2}, {s}");
            Utils.PrintArray(func(s));

            // 2.
            s = "ababaaxba";
            Console.WriteLine($"{++id,2}, {s}");
            Utils.PrintArray(func(s));

            // 3.
            s = "abababca";
            Console.WriteLine($"{++id,2}, {s}");
            Utils.PrintArray(func(s));

            // 4.
            s = "aaaaax";
            Console.WriteLine($"{++id,2}, {s}");
            Utils.PrintArray(func(s));
        }

        public void TestKMP()
        {
            _02模式匹配_KMP test = new _02模式匹配_KMP();
            string s, t;
            int result, answer;
            int id = 0;

            // 1.
            s = "ababababca"; t = "abababca";
            result = test.KMP(s, t); answer = s.IndexOf(t);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            s = "abcabcabdabba"; t = "abcabd";
            result = test.KMP(s, t); answer = s.IndexOf(t);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            s = "000000000200000000020000000002000000000200000000020000000001"; t = "0000000001";
            result = test.KMP(s, t); answer = s.IndexOf(t);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }

        public void TestKMP2()
        {
            _02模式匹配_KMP test = new _02模式匹配_KMP();
            string s, t;
            int result, answer;
            int id = 0;

            // 1.
            s = "ababababca"; t = "abababca";
            result = test.KMP2(s, t); answer = s.IndexOf(t);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            s = "abcabcabdabba"; t = "abcabd";
            result = test.KMP2(s, t); answer = s.IndexOf(t);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            s = "000000000200000000020000000002000000000200000000020000000001"; t = "0000000001";
            result = test.KMP2(s, t); answer = s.IndexOf(t);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
