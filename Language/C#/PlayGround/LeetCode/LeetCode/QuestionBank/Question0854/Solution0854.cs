using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0854
{
    /// <summary>
    /// 未完成
    /// </summary>
    public class Solution0854 : Interface0854
    {
        /// <summary>
        /// 由于本题中两个字符串是“字母异位词”，所以只要保证每次替换，同时修正两个位置的字母即可，
        ///                                       如果不存在可以修正两个位置的字母，就修正一个位置的字母
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public int KSimilarity(string s1, string s2)
        {
            int result = 0;
            char[] c1 = s1.ToCharArray();

            // 先把一次可以搞定两个字母的给交换了
            for (int i = 0; i < c1.Length; i++)
            {
                int k = i;
                if (c1[i] != s2[i])
                {
                    for (int j = i + 1; j < c1.Length; j++)
                        if (c1[j] == s2[i] && c1[i] == s2[j]) { k = j; break; }
                    if (k != i) { Swap(c1, i, k); result++; };
                }
            }

            // 再搞定一次只能搞定一个字母的
            for (int i = 0; i < c1.Length; i++)
            {
                int k = i;
                if (c1[i] != s2[i])
                {
                    for (int j = i + 1; j < c1.Length; j++)
                    {
                        if (c1[j] == s2[i])
                        {
                            if (c1[i] == s2[j]) { k = j; break; }
                            else k = j;
                        }
                    }
                    if (k != i) { Swap(c1, i, k); result++; };
                }
            }

            return result;
        }

        private void Swap(char[] arr, int i, int j)
        {
            char t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
