using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0010
{
    /// <summary>
    /// 未完成
    /// </summary>
    public class Solution0010 : Interface0010
    {
        /// <summary>
        /// 将模式字符串拆解开，然后再分析，拆解出来的总共有4类
        ///     1. 纯字母串，例如："aabb"
        ///     2. 字母星："c*"
        ///     3. 一个点："."
        ///     4. 点星：".*"
        /// 例如将 "aabb..*c*dd" 拆解为 "aabb" "." ".*" "c*" "dd"
        /// 
        /// 拆解过程
        /// - 遇到 '.' 产生一个新串，要么是 "."，要么是".*"
        /// - 遇到 '*' 产生一个新串，与前一个字符结合
        /// - 遇到字母，添加到当前串中
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(string s, string p)
        {
            List<(int type, string pattern)> patterns = PatternSplit(p);
            return IsMatch(s, patterns);
        }

        private bool IsMatch(string s, List<(int type, string pattern)> patterns)
        {
            int id_s = -1, id_p = 0;
            for (; id_p < patterns.Count; id_p++)
            {
                int ptype = patterns[id_p].type;
                string pattern = patterns[id_p].pattern;
                switch (ptype)
                {
                    case 1:
                        for (int j = 0; j < pattern.Length; j++)
                            if (++id_s >= s.Length || s[id_s] != pattern[j]) return false;
                        break;
                    case 2:
                        List<(int type, string pattern)> patterns2 = patterns.Where((c, index) => index > id_p).ToList();
                        int id_s_t2 = id_s;
                        if (++id_s_t2 < s.Length && IsMatch(s.Substring(id_s_t2), patterns2)) return true;
                        while (++id_s_t2 < s.Length)
                        {
                            if (s[id_s_t2 - 1] != pattern[0]) return false;
                            if (IsMatch(s.Substring(id_s_t2), patterns2)) return true;
                        }
                        break;
                    case 3:
                        if (++id_s >= s.Length) return false;
                        break;
                    case 4:
                        List<(int type, string pattern)> patterns4 = patterns.Where((c, index) => index > id_p).ToList();
                        int id_s_t4 = id_s;
                        if (++id_s_t4 < s.Length && IsMatch(s.Substring(id_s_t4), patterns4)) return true;
                        while (++id_s_t4 < s.Length)
                            if (IsMatch(s.Substring(id_s_t4), patterns4)) return true;
                        break;
                    default:
                        throw new Exception("Invalid Input.");
                }
            }

            if (id_s >= s.Length - 1)  // 字符串中的字符已经处理完
            {
                if (id_p >= patterns.Count - 1) return true;
                for (; id_p < patterns.Count; id_p++)
                    if (patterns[id_p].type == 1 || patterns[id_p].type == 3) return false;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 将模式字符串拆解开，拆解出来的总共有4类
        ///     1. 纯字母串，例如："aabb"
        ///     2. 字母星："c*"
        ///     3. 一个点："."
        ///     4. 点星：".*"
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private List<(int type, string pattern)> PatternSplit(string pattern)
        {
            List<(int type, string pattern)> patterns = new List<(int, string)>();
            List<char> buffer = new List<char>();
            for (int i = 0; i < pattern.Length; i++)
            {
                switch (pattern[i])
                {
                    case '.':
                        if (buffer.Count > 0) { patterns.Add((1, new string(buffer.ToArray()))); buffer = new List<char>(); }
                        if (i + 1 < pattern.Length && pattern[i + 1] == '*') { patterns.Add((4, ".*")); i++; }
                        else patterns.Add((3, "."));
                        break;
                    case '*':
                        if (buffer.Count == 0) throw new Exception("Invalid Input.");  // 题目不允许 * 前面没有其他字符
                        string item = $"{buffer.Last()}*";
                        buffer.RemoveAt(buffer.Count - 1);
                        if (buffer.Count > 0) { patterns.Add((1, new string(buffer.ToArray()))); buffer = new List<char>(); }
                        patterns.Add((2, item));
                        break;
                    default:  // 小写字母
                        buffer.Add(pattern[i]);
                        break;
                }
            }
            if (buffer.Count > 0) patterns.Add((1, new string(buffer.ToArray())));

            return patterns;
        }
    }
}
