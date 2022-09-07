using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1592
{
    public class Test1592
    {
        public void Test()
        {
            Interface1592 solution = new Solution1592_2();
            string str, answer, result;
            int id = 0;

            // 1.
            str = "  this   is  a sentence ";
            answer = "this   is   a   sentence";
            result = solution.ReorderSpaces(str);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 2. 
            str = " practice   makes   perfect";
            answer = "practice   makes   perfect ";
            result = solution.ReorderSpaces(str);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 3. 
            str = "hello   world";
            answer = "hello   world";
            result = solution.ReorderSpaces(str);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 4. 
            str = "  walks  udp package   into  bar a";
            answer = "walks  udp  package  into  bar  a ";
            result = solution.ReorderSpaces(str);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 5. 
            str = "a";
            answer = "a";
            result = solution.ReorderSpaces(str);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 6. 
            str = "  walks";
            answer = "walks  ";
            result = solution.ReorderSpaces(str);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");
        }
    }
}
