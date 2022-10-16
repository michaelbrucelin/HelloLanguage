using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0886
{
    public class Solution0886 : Interface0886
    {
        /// <summary>
        /// 这里的HashSet<int>可以考虑用位图来节省内存占用
        /// </summary>
        /// <param name="n"></param>
        /// <param name="dislikes"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool PossibleBipartition(int n, int[][] dislikes)
        {
            Dictionary<int, HashSet<int>> helper = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < dislikes.Length; i++)
            {
                if (helper.ContainsKey(dislikes[i][0]))
                    helper[dislikes[i][0]].Add(dislikes[i][1]);
                else
                    helper.Add(dislikes[i][0], new HashSet<int>() { dislikes[i][1] });

                if (helper.ContainsKey(dislikes[i][1]))
                    helper[dislikes[i][1]].Add(dislikes[i][0]);
                else
                    helper.Add(dislikes[i][1], new HashSet<int>() { dislikes[i][0] });
            }
            if (helper.Count <= 1) return true;

            HashSet<int> group1 = new HashSet<int>();
            HashSet<int> group2 = new HashSet<int>();
            group1.Add(1);
            group2.UnionWith(helper[1]);
            bool flag = false;  // true表示上一轮一个都没添加
            while (helper.Count > 0)
            {
                if (flag)
                {
                    int firstkey = helper.Keys.First();
                    group1.Add(firstkey);
                    group2.UnionWith(helper[firstkey]);
                    helper.Remove(firstkey);
                }

                flag = true;
                foreach (int key in helper.Keys)
                {
                    if (group1.Contains(key))
                    {
                        if (group1.Intersect(helper[key]).Count() > 0) return false;
                        else { group2.UnionWith(helper[key]); helper.Remove(key); }
                        flag = false;
                    }
                    else if (group2.Contains(key))
                    {
                        if (group2.Intersect(helper[key]).Count() > 0) return false;
                        else { group1.UnionWith(helper[key]); helper.Remove(key); }
                        flag = false;
                    }
                }
            }

            return true;
        }
    }
}
