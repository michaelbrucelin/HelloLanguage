using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public class MyInstGists
    {
        /// <summary>
        /// 执行次数表达式替换
        /// 输入的表达式只允许有0-9，+，* 12个字符，开头与结尾必须为数字，不允许有连续的符号（++、**、+*、*+）
        /// 1*10 --> 1,1,1,1,1,1,1,1,1,1
        /// 1*3+5+2*3+5+4 --> 1,1,1,5,2,2,2,5,4
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<uint> ConvertTimesExpr(string input)
        {
            if (Regex.IsMatch(input, @"[^0-9+*]"))
            {
                throw new Exception("输入的表达式不合法，含有非法字符。");
            }
            else if (Regex.IsMatch(input, @"^[^0-9]|[^0-9]$"))
            {
                throw new Exception("输入的表达式不合法，必须以数字开头或结尾。");
            }
            else if (Regex.IsMatch(input, @"\+\+|\+\*|\*\+|\*\*"))
            {
                throw new Exception("输入的表达式不合法，不允许有连续的符号。");
            }

            LinkedList<uint> rslt = new LinkedList<uint>();

            //使用下面两个数组也可以进行操作，下面没有采用这种方法
            //string[] digit = Regex.Split(input, @"[^0-9]");
            //string[] symbol = Regex.Split(input, @"\d");

            for (int i = 0; i < input.Length;)
            {
                if (char.IsNumber(input[i]))
                {
                    int j = 1;
                    while (i + j < input.Length && char.IsNumber(input[i + j]))  //如果后面还有数字，需要一起取出
                        j++;

                    rslt.AddLast(Convert.ToUInt32(input.Substring(i, j)));

                    i += j;
                }
                else if (input[i] == '*')
                {
                    uint temp = rslt.Last.Value;  //取出需要重复的数字
                    rslt.RemoveLast();

                    i++;  //由于上面的正则限制，这里默认*号后面第一位一定是数字
                    int j = 1;
                    while (i + j < input.Length && char.IsNumber(input[i + j]))
                        j++;
                    uint times = Convert.ToUInt32(input.Substring(i, j));
                    for (uint x = 0; x < times; x++)
                    {
                        rslt.AddLast(temp);
                    }

                    i += j;
                }
                else
                {
                    //+号不做处理
                    i++;
                }
            }

            return rslt.ToList();
        }
    }
}
