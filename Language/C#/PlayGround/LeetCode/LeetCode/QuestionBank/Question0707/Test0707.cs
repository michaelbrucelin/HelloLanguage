using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0707
{
    public class Test0707
    {
        public void Test()
        {
            Interface0707 solution = new MyLinkedList();

            Test01(solution);
            Test02(solution);
        }

        private void Test01(Interface0707 solution)
        {
            int val;

            solution.AddAtHead(1);
            solution.AddAtTail(3);
            solution.AddAtIndex(1, 2);
            val = solution.Get(1); Console.WriteLine($"{val == 2}");
            solution.DeleteAtIndex(1);
            val = solution.Get(1); Console.WriteLine($"{val == 3}");
        }

        private void Test02(Interface0707 solution)
        {
            int val;

            solution.AddAtHead(1);
            solution.DeleteAtIndex(0);
        }
    }
}
