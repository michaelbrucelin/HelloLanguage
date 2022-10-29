using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1773
{
    public class Solution1773 : Interface1773
    {
        public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            int result = 0;
            int id = ruleKey switch { "type" => 0, "color" => 1, "name" => 2, _ => throw new NotImplementedException() };
            foreach (var item in items)
                if (item[id] == ruleValue) result++;

            return result;
        }
    }
}
