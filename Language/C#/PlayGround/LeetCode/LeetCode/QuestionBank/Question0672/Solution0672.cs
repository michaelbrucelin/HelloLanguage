using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0672
{
    public class Solution0672 : Interface0672
    {
        /// <summary>
        /// 找规律，具体见Solution0672.xlsx
        /// </summary>
        /// <param name="n"></param>
        /// <param name="presses"></param>
        /// <returns></returns>
        public int FlipLights(int n, int presses)
        {
            if (presses == 0) return 1;
            if (n == 1) return 2;
            if (n == 2) { if (presses == 1) return 3; else return 4; }

            // n >= 3, presses >= 1
            HashSet<char> result = new HashSet<char>();
            result.Add('A');
            for (int i = 1; i <= presses; i++)
            {
                HashSet<char> buffer = new HashSet<char>();
                foreach (char c in result)
                {
                    buffer.Add(StateTransition(c, 'B'));
                    buffer.Add(StateTransition(c, 'C'));
                    buffer.Add(StateTransition(c, 'D'));
                    buffer.Add(StateTransition(c, 'E'));
                }
                result = buffer;
            }

            return result.Count;
        }

        /// <summary>
        /// 状态转移方程
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        private char StateTransition(char c1, char c2)
        {
            if (c1 == 'A' && c2 == 'B') return 'B';
            if (c1 == 'A' && c2 == 'C') return 'C';
            if (c1 == 'A' && c2 == 'D') return 'D';
            if (c1 == 'A' && c2 == 'E') return 'E';

            if (c1 == 'B' && c2 == 'B') return 'A';
            if (c1 == 'B' && c2 == 'C') return 'D';
            if (c1 == 'B' && c2 == 'D') return 'C';
            if (c1 == 'B' && c2 == 'E') return 'F';

            if (c1 == 'C' && c2 == 'B') return 'D';
            if (c1 == 'C' && c2 == 'C') return 'A';
            if (c1 == 'C' && c2 == 'D') return 'B';
            if (c1 == 'C' && c2 == 'E') return 'G';

            if (c1 == 'D' && c2 == 'B') return 'C';
            if (c1 == 'D' && c2 == 'C') return 'B';
            if (c1 == 'D' && c2 == 'D') return 'A';
            if (c1 == 'D' && c2 == 'E') return 'H';

            if (c1 == 'E' && c2 == 'B') return 'F';
            if (c1 == 'E' && c2 == 'C') return 'G';
            if (c1 == 'E' && c2 == 'D') return 'H';
            if (c1 == 'E' && c2 == 'E') return 'A';

            if (c1 == 'F' && c2 == 'B') return 'E';
            if (c1 == 'F' && c2 == 'C') return 'H';
            if (c1 == 'F' && c2 == 'D') return 'G';
            if (c1 == 'F' && c2 == 'E') return 'B';

            if (c1 == 'G' && c2 == 'B') return 'H';
            if (c1 == 'G' && c2 == 'C') return 'E';
            if (c1 == 'G' && c2 == 'D') return 'F';
            if (c1 == 'G' && c2 == 'E') return 'C';

            if (c1 == 'H' && c2 == 'B') return 'G';
            if (c1 == 'H' && c2 == 'C') return 'F';
            if (c1 == 'H' && c2 == 'D') return 'E';
            if (c1 == 'H' && c2 == 'E') return 'D';

            throw new ArgumentException();
        }
    }
}
