using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0792
{
    public class Solution0792_6 : Interface0792
    {
        public int NumMatchingSubseq(string s, string[] words)
        {
            Queue<(int, int)>[] helper = new Queue<(int, int)>[26];            // 第一个int是words的索引，第二个int是words[id]中char的索引
            for (int i = 0; i < 26; i++) helper[i] = new Queue<(int, int)>();
            for (int i = 0; i < words.Length; i++) helper[words[i][0] - 'a'].Enqueue((i, 0));

            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int id = s[i] - 'a'; int cnt = helper[id].Count;
                for (int j = 0; j < cnt; j++)
                {
                    var item = helper[id].Dequeue();
                    int word_id = item.Item1, char_id = item.Item2;
                    if (char_id == words[word_id].Length - 1) { result++; continue; }
                    helper[words[word_id][char_id + 1] - 'a'].Enqueue((word_id, char_id + 1));
                }
            }

            return result;
        }
    }
}
