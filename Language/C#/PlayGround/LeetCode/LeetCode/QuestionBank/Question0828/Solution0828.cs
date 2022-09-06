using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0828
{
    public class Solution0828 : Interface0828
    {
        /// <summary>
        /// 递增窗口解决
        /// 提交超时
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UniqueLetterString(string s)
        {
            int result = s.Length;  // 长度为1的子串无需验证

            // 长度为2的子串
            // for (int i = 0; i <= s.Length - 2; i++) if (s[i] != s[i + 1]) result += 2;

            // 长度大于等于2的子串（递增窗口解决）
            for (int i = 0; i <= s.Length - 2; i++)
            {
                int cnt = 1;
                Dictionary<char, int> map = new Dictionary<char, int>() { { s[i], 1 } };

                // 依次计算以s[i]开头的全部子串的结果
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (map.ContainsKey(s[j]))
                    {
                        if (map[s[j]] == 1) cnt--;
                        map[s[j]]++;
                    }
                    else
                    {
                        cnt++;
                        map.Add(s[j], 1);
                    }

                    result += cnt;

                    if (cnt == 0 && map.Count == 26) break;  // 无论后面是什么字符，都不会改变结果了
                }
            }

            return result;
        }
    }
}
