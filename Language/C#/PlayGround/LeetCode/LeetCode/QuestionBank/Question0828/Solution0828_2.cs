using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0828
{
    /// <summary>
    /// 滑动窗口解决
    /// 由于需要计算整个窗口的结果，所以比递增窗口计算的更慢，没有提交，只是练习
    /// </summary>
    public class Solution0828_2 : Interface0828
    {
        public int UniqueLetterString(string s)
        {
            int result = s.Length;  // 长度为1的子串无需验证

            // 长度大于等于2的子串（滑动窗口解决）
            for (int len = 2; len <= s.Length; len++)
            {
                int cnt = 0;
                Dictionary<char, int> map = new Dictionary<char, int>();

                // 第一个长度为len的子串
                for (int i = 0; i < len; i++)
                {
                    if (map.ContainsKey(s[i]))
                    {
                        if (map[s[i]] == 1) cnt--;
                        map[s[i]]++;
                    }
                    else
                    {
                        cnt++;
                        map.Add(s[i], 1);
                    }

                    // 必须是整个窗口的计算结果，由于需要计算整个窗口的结果，所以比递增窗口计算的更慢
                    // if (cnt == 0 && map.Count == 26) break;  // 无论后面是什么字符，都不会改变结果了
                }
                result += cnt;

                // 利用滑动窗口计算后面长度为len的子串
                for (int i = len; i < s.Length; i++)
                {
                    if (s[i - len] == s[i]) { result += cnt; continue; }

                    // 减去移除窗口的字符
                    if (map[s[i - len]] == 1) { cnt--; map.Remove(s[i - len]); }
                    else if (map[s[i - len]] == 2) { cnt++; map[s[i - len]] = 1; }
                    else map[s[i - len]]--;

                    // 加上进入窗口的字符
                    if (!map.ContainsKey(s[i])) { cnt++; map.Add(s[i], 1); }
                    else if (map[s[i]] == 1) { cnt--; map[s[i]]++; }
                    else map[s[i]]++;

                    result += cnt;
                }
            }

            return result;
        }
    }
}
