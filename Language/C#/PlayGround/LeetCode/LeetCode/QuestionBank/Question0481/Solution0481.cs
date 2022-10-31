using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0481
{
    public class Solution0481 : Interface0481
    {
        /// <summary>
        /// 看不懂题系列
        /// 1. “次数字符串”应该是原字符串的前缀吧？怎么能是原字符串的自身呢？难道考虑数学上的极限思想？
        /// 2. 第1位为什么是1？规定（题目没说）？还是不可能为2（怎么证明）？"22112122122112112212"这个2开头的明明也对
        /// 凑合着做吧，也能做
        /// 
        /// 使用快慢指针
        ///     快指针指向字符串的末端，最后一个字符的作为一个位置，即即将填充新字符串的位置
        ///     慢指针指向“次数字符串”的下一个位置，即需要使用这个位置的字符判断该怎样填充字符串
        /// 3-1=2, 3-2=1 或 1^3=2, 2^3=1 可以简单的实现1与2的切换
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MagicalString2(int n)
        {
            if (n <= 3) return 1;

            int[] str = new int[n]; str[0] = 1; str[1] = 2; str[2] = 2;
            int slow = 2, fast = 3;
            while (fast < n)
            {
                if (str[slow] == 1) str[fast] = (str[fast - 1] ^ 3);
                else  // (str[slow] == 2)
                {
                    str[fast] = (str[fast - 1] ^ 3); fast++;
                    if (fast < n) str[fast] = str[fast - 1];
                }
                slow++; fast++;
            }

            int result = 0;
            for (int i = 0; i < n; i++) if (str[i] == 1) result++;

            return result;
        }

        /// <summary>
        /// 与上面逻辑一样，只不过生成字符串的时候就把结果算出来了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MagicalString(int n)
        {
            if (n <= 3) return 1;

            int result = 1;
            int[] str = new int[n]; str[0] = 1; str[1] = 2; str[2] = 2;
            int slow = 2, fast = 3;
            while (fast < n)
            {
                if (str[slow] == 1)
                {
                    if (str[fast - 1] == 1) str[fast] = 2;
                    else  // str[fast - 1] == 2
                    {
                        str[fast] = 1; result++;
                    }
                }
                else  // (str[slow] == 2)
                {
                    if (str[fast - 1] == 1)
                    {
                        str[fast] = 2; fast++;
                        if (fast < n) str[fast] = 2;
                    }
                    else  // str[fast - 1] == 2
                    {
                        str[fast] = 1; result++; fast++;
                        if (fast < n) { str[fast] = 1; result++; }
                    }
                }
                slow++; fast++;
            }

            return result;
        }
    }
}
