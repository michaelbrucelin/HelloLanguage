using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0017
{
    public class Solution0017 : Interface0017
    {
        private Dictionary<char, string[]> mapping = new Dictionary<char, string[]>
        {
            {'2', new string[]{ "a","b","c"} }, {'3', new string[]{ "d","e","f"} },     {'4', new string[]{ "g","h","i"} }, {'5', new string[]{ "j","k","l"} },
            {'6', new string[]{ "m","n","o"} } ,{'7', new string[]{ "p","q","r","s"} }, {'8', new string[]{ "t","u","v"} }, {'9', new string[]{ "w","x","y","z"} }
        };

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0) return new List<string>();

            List<string> result = new List<string>();
            foreach (string item in mapping[digits[0]]) result.Add(item);
            for (int i = 1; i < digits.Length; i++)
            {
                List<string> buffer = new List<string>();
                foreach (string item1 in result) foreach (string item2 in mapping[digits[i]])
                        buffer.Add($"{item1}{item2}");
                result = buffer;
            }

            return result;
        }
    }
}
