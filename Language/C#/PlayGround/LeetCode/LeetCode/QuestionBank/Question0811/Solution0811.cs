using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0811
{
    public class Solution0811 : Interface0811
    {
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < cpdomains.Length; i++)
            {
                string[] pair = cpdomains[i].Split(' ');
                int cnt = Convert.ToInt32(pair[0]);
                string keys = pair[1];

                if (result.ContainsKey(keys)) result[keys] += cnt; else result.Add(keys, cnt);
                while (keys.Contains('.'))
                {
                    keys = keys.Substring(keys.IndexOf('.') + 1);
                    if (result.ContainsKey(keys)) result[keys] += cnt; else result.Add(keys, cnt);
                }
            }

            return result.Select(kv => $"{kv.Value} {kv.Key}").ToList();
        }
    }
}
