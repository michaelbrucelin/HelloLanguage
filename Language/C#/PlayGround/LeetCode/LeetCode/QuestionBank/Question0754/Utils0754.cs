using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0754
{
    public class Utils0754
    {
        public void GetReachNumbers()
        {
            while (true)
            {
                Console.WriteLine("Please input a steps(int) or 'q' to quit:");
                string input = Console.ReadLine();
                if (input.ToLower() == "q") return;
                try
                {
                    ReachNumbers(Convert.ToInt32(input));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ReachNumbers(int steps)
        {
            if (steps == 1) { Console.WriteLine("[ -1, 1 ]"); return; }

            HashSet<int> set = new HashSet<int>() { -1, 1 };
            int i = 2;
            for (; i <= steps; i++)
            {
                HashSet<int> buffer = new HashSet<int>();
                foreach (int item in set)
                {
                    buffer.Add(item - i);
                    buffer.Add(item + i);
                }
                set = buffer;
            }
            Utils.PrintArray(set.OrderBy(i => i).ToList());
        }
    }
}
