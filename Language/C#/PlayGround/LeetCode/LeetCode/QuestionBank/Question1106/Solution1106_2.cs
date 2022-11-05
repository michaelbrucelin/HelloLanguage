using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LeetCode.QuestionBank.Question1106
{
    public class Solution1106_2 : Interface1106
    {
        public bool ParseBoolExpr(string expression)
        {
            if (expression.Length == 1) return expression == "t" ? true : false;

            Stack<char> chars = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case ',':
                        break;
                    case '&':
                    case '|':
                    case '!':
                    case '(':
                    case 't':
                    case 'f':
                        chars.Push(expression[i]);
                        break;
                    case ')':
                        int t = 0, f = 0; char c;
                        while ((c = chars.Pop()) != '(') if (c == 't') t++; else f++;
                        c = chars.Pop();
                        switch (c)
                        {
                            case '&':
                                chars.Push(f > 0 ? 'f' : 't');
                                break;
                            case '|':
                                chars.Push(t > 0 ? 't' : 'f');
                                break;
                            case '!':
                                chars.Push(f == 1 ? 't' : 'f');
                                break;
                        }
                        break;
                }
            }

            //char result = ' ';
            //while (chars.Count > 0) result = chars.Pop();
            //return result == 't' ? true : false;
            return chars.Pop() == 't' ? true : false;
        }
    }
}
