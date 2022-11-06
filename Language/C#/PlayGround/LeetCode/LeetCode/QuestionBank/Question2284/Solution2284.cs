using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2284
{
    public class Solution2284 : Interface2284
    {
        public string LargestWordCount(string[] messages, string[] senders)
        {
            if (senders.Length == 1 || senders.Distinct().Count() == 1) return senders[0];

            int len = messages.Length;
            int[] wordcnt = new int[len];
            for (int i = 0; i < len; i++)
                wordcnt[i] = messages[i].Count(c => c == ' ') + 1;

            Dictionary<string, int> buffer = new Dictionary<string, int>();
            for (int i = 0; i < len; i++)
                if (buffer.ContainsKey(senders[i]))
                    buffer[senders[i]] += wordcnt[i];
                else
                    buffer.Add(senders[i], wordcnt[i]);

            string result = ""; int count = -1;
            foreach (string key in buffer.Keys)
                if (buffer[key] > count || (buffer[key] == count && StringComparer.Ordinal.Compare(key, result) > 0))
                {
                    result = key;
                    count = buffer[key];
                }
            // if (buffer[key] > count || (buffer[key] == count && key.CompareTo(result) > 0)) { result = key; count = buffer[key]; }

            return result;
        }
    }
}
