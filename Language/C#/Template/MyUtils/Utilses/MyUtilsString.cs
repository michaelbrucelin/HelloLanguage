using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsString
    {
        // 字符串按照指定长度拆分为数组，如果最后一项长度不够，是否保留
        public enum StrSplitByChunkOption { keep, remove };
        // 字符串按照指定长度拆分为数组
        public static IEnumerable<string> StrSplitByChunk(string str, int chunkSize, StrSplitByChunkOption option)
        {
            if (option == StrSplitByChunkOption.keep)
            {
                int cnt = (int)Math.Ceiling(str.Length * 1.0 / chunkSize);
                return Enumerable.Range(0, cnt)
                                 .Select(i => str.Substring(i * chunkSize, Math.Min(chunkSize, str.Length - chunkSize * i)));
            }
            else if (option == StrSplitByChunkOption.remove)
            {
                return Enumerable.Range(0, str.Length / chunkSize)
                                 .Select(i => str.Substring(i * chunkSize, chunkSize));
            }
            else
            { return null; }
        }

        /// <summary>
        /// 使用指定的分隔字符将字符串分割为字符串数组，与string.Split()不同的是，这里保留分隔符作为数组独立的项
        /// </summary>
        /// <param name="s"></param>
        /// <param name="delims"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitAndKeep(string s, char[] delims)
        {
            int start = 0, index;

            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0) yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);
                start = index + 1;
            }

            if (start < s.Length) yield return s.Substring(start);
        }

        /// <summary>
        /// Returns the number of steps required to transform the source string
        /// into the target string.
        /// 比较两个字符串的相似度
        /// </summary>
        public static int CalLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) { return 0; }
            if ((source.Length == 0) || (target.Length == 0)) { return 0; }
            if (source == target) { return source.Length; }

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0) { return targetWordCount; }
            if (targetWordCount == 0) { return sourceWordCount; }

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }

        /// <summary>
        /// Calculate percentage similarity of two strings
        /// <param name="source">Source String to Compare with</param>
        /// <param name="target">Targeted String to Compare</param>
        /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// 比较两个字符串的相似度
        /// </summary>
        public static double CalLevenshteinSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) { return 0.0; }
            if ((source.Length == 0) || (target.Length == 0)) { return 0.0; }
            if (source == target) { return 1.0; }

            int stepsToSame = CalLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        // 字符串替换
        // [[0n]]—>n位随机数字；
        // [[an]]—>n位随机小写字母；[[An]]—>n位随机大写字母；[[aAn]]—>n位随机字母（随机大小写）；
        // [[n]] —>n位随机数字字母（随机大小写）；
        // [[na]]—>n位随机数字字母（小写）；[[nA]]—>n位随机数字字母（大写）；
        // 以上结构不允许嵌套，即[[[0n]]]无效；
        public static string ReplaceMaskStr(string input)
        {
            string chars_0 = "0123456789";
            string chars_a = "abcdefghijklmnopqrstuvwxyz";
            string chars_A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chars_aA = chars_a + chars_A;
            string chars_0a = chars_0 + chars_a;
            string chars_0A = chars_0 + chars_A;
            string chars_0aA = chars_0 + chars_a + chars_A;

            // [[0n]]
            input = Regex.Replace(input, @"(?<!\[)\[\[0(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_0, Convert.ToInt32(match.Groups[1].Value))
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[an]]
            input = Regex.Replace(input, @"(?<!\[)\[\[a(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_a, Convert.ToInt32(match.Groups[1].Value))
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[An]]
            input = Regex.Replace(input, @"(?<!\[)\[\[A(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_A, Convert.ToInt32(match.Groups[1].Value))
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[aAn]]
            input = Regex.Replace(input, @"(?<!\[)\[\[aA(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_aA, Convert.ToInt32(match.Groups[1].Value))
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[n]]
            input = Regex.Replace(input, @"(?<!\[)\[\[(\d)\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_0aA, Convert.ToInt32(match.Groups[1].Value))
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[na]]
            input = Regex.Replace(input, @"(?<!\[)\[\[(\d)a\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_0a, Convert.ToInt32(match.Groups[1].Value))
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            }));
            // [[nA]]
            input = Regex.Replace(input, @"(?<!\[)\[\[(\d)A\]\]", new MatchEvaluator(delegate (Match match)
            {
                return new string(Enumerable.Repeat(chars_0A, Convert.ToInt32(match.Groups[1].Value))
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            }));

            return input;
        }
    }
}
