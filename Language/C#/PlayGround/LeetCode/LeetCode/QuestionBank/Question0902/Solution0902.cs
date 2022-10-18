using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0902
{
    public class Solution0902 : Interface0902
    {
        /// <summary>
        /// digits中没有数字0且不重复，难点就在于计算与数字n长度相同的数字的数量
        /// 其实就是逐位分析，
        ///     如果最高位小于目标值，后面位随意，
        ///     如果最高位等于目标值，忽略最高位分析下一位，有递归的味道
        ///     如果最高位大于目标值，跳出
        /// </summary>
        /// <param name="digits"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int AtMostNGivenDigitSet(string[] digits, int n)
        {
            int[] ints = new int[digits.Length];
            for (int i = 0; i < digits.Length; i++) ints[i] = digits[i][0] - '0';
            Array.Sort(ints);

            List<int> nlist = new List<int>();
            while (n > 0) { nlist.Add(n % 10); n /= 10; }

            int result = 0, temp = 1;
            for (int i = 1; i < nlist.Count; i++) { temp *= ints.Length; result += temp; }

            // 下面计算长度为n的数字的数量
            nlist.Reverse();
            for (int i = 0; i < nlist.Count; i++)  // 分析左数第n+1位数字的可能性
            {
                int j = 0;
                while (j < ints.Length && ints[j] < nlist[i]) j++;                                         // 找出第一个大于等于目标值的数字
                if (j == 0 && ints[j] > nlist[i]) break;                                                   // 全部大于，直接跳出
                if (j == ints.Length) { result += (int)Math.Pow(ints.Length, (nlist.Count - i)); break; }  // 全部小于，排列组合后跳出
                result += j * (int)Math.Pow(ints.Length, (nlist.Count - i - 1));                           // 第1位取小于的数字，其余位排列组合
                if (ints[j] > nlist[i]) break;                                                             // 下1位大于跳出
                if (ints[j] == nlist[i] && i == nlist.Count - 1) { result++; break; }                      // 下1位等于，到头了结果+1并跳出循环，否则继续
            }

            return result;
        }
    }
}
