using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2103
{
    public class Solution2103 : Interface2103
    {
        private Dictionary<char, int> bin = new Dictionary<char, int> { { 'R', 1 }, { 'G', 2 }, { 'B', 4 } };

        public int CountPoints(string rings)
        {
            if (rings.Length < 6)
                return 0;

            Dictionary<char, int> buffer = new Dictionary<char, int>();
            for (int i = 0; (i << 1) + 1 < rings.Length; i++)
            {
                if (buffer.ContainsKey(rings[(i << 1) + 1]))
                    buffer[rings[(i << 1) + 1]] |= bin[rings[(i << 1)]];
                else
                    buffer[rings[(i << 1) + 1]] = bin[rings[(i << 1)]];
            }

            int result = 0;
            foreach (int value in buffer.Values)
                if (value == 7)
                    result++;

            return result;
        }

        public int CountPoints2(string rings)
        {
            if (rings.Length < 6)
                return 0;

            int result = 0;
            for (int i = 0; i < 10; i++)
                if (rings.Contains($"R{i}") && rings.Contains($"G{i}") && rings.Contains($"B{i}"))
                    result++;

            return result;
        }
    }
}
