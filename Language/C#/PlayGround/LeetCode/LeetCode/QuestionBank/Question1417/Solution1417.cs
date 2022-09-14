using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1417
{
    public class Solution1417 : Interface1417
    {
        public string Reformat(string s)
        {
            List<char> buffer = new List<char>();

            Queue<char> digits = new Queue<char>();
            Queue<char> letters = new Queue<char>();

            for (int i = 0; i < s.Length; i++)
                if (char.IsDigit(s[i])) digits.Enqueue(s[i]);
                else letters.Enqueue(s[i]);

            if (digits.Count - letters.Count > 1 || digits.Count - letters.Count < -1)
                return "";

            bool needigit;
            if (digits.Count == letters.Count)
                needigit = char.IsDigit(s[0]) ? true : false;
            else
                needigit = (digits.Count > letters.Count);

            while (buffer.Count < s.Length)
            {
                if (needigit && digits.Count > 0)
                    buffer.Add(digits.Dequeue());
                else if ((!needigit) && letters.Count > 0)
                    buffer.Add(letters.Dequeue());
                else
                    return "";

                needigit = !needigit;
            }

            return new string(buffer.ToArray());
        }
    }
}
