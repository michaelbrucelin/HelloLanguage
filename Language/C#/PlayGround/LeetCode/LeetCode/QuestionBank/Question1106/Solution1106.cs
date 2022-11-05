using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1106
{
    public class Solution1106 : Interface1106
    {
        /// <summary>
        /// 用两个栈解决，一个栈存放逻辑运算符，一个栈存放括号与布尔值
        /// 不用考虑表达式的有效性，写起来会简单很多
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool ParseBoolExpr(string expression)
        {
            if (expression.Length == 1) return expression == "t" ? true : false;

            Stack<char> ops = new Stack<char>();
            Stack<char> bools = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case ',':                   // 整个串中最多的就是','，所以把它放前面
                        break;
                    case '&':
                    case '|':
                    case '!':
                        ops.Push(expression[i]);
                        break;
                    case '(':
                    case 't':
                    case 'f':
                        bools.Push(expression[i]);
                        break;
                    case ')':
                        char op = ops.Pop();    // 题目保证输入有效，一定存在运算符，下面也是一样，一些判断就不写了
                        char c1 = bools.Pop();  // 一定是't'或者'f'
                        char c2 = bools.Pop();  // 有可能是')'
                        switch (op)
                        {
                            case '&':
                                while (c2 != '(') { c1 = (c1 == 'f' || c2 == 'f') ? 'f' : 't'; c2 = bools.Pop(); }
                                bools.Push(c1);
                                break;
                            case '|':
                                while (c2 != '(') { c1 = (c1 == 't' || c2 == 't') ? 't' : 'f'; c2 = bools.Pop(); }
                                bools.Push(c1);
                                break;
                            case '!':
                                bools.Push(c1 == 't' ? 'f' : 't');
                                break;
                        }
                        break;
                }
            }

            //char result = ' ';
            //while (bools.Count > 0) result = bools.Pop();
            //return result == 't' ? true : false;
            return bools.Pop() == 't' ? true : false;
        }

        //public static bool operator |(char c1, char c2)
        //{
        //    return (c1 == 't' || c2 == 't') ? true : false;
        //}
    }
}
