using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] array = { 4, 1, 2, 2, 5, 1, 4, 3 };

            var r = FindLostNum3(array);
            Console.WriteLine($"({r.x}, {r.y})");
        }

        /// <summary>
        /// 题目
        /// 在一个无序数组里有99个不重复的正整数，范围是1～100，唯独缺少1个1～100中的整数。
        /// 如何找出这个缺失的整数？
        /// 
        /// 思路
        /// 先算出1+2+3+…+100的和，然后依次减去数组里的元素，最后得到的差值，就是那个缺失的整数。
        /// 
        /// 这里就不实现了
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int FindLostNum(IList<int> list)
        {
            return -1;
        }

        /// <summary>
        /// 对上一个题目的扩展
        /// 一个无序数组里有若干个正整数，范围是1～100，其中99个整数都出现了偶数次，只有1个整数出现了奇数次。
        /// 如何找到这个出现奇数次的整数？
        /// 
        /// 思路
        /// 利用异或运算，两个整数执行异或运算，相同位得0，不同位得1。也就是说
        ///     1. 两个相同的整数执行异或运算结果为0
        ///     2. 任何整数与1进行异或运算，结果为反值
        ///     3. 任何整数与0进行异或运算，结果为原值
        /// 所以，只要将数组中的元素，依次做异或运算，最后的结果就是答案
        /// 
        /// 这里就不实现了
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int FindLostNum2(IList<int> list)
        {
            return -1;
        }

        /// <summary>
        /// 再次扩展
        /// 假设一个无序数组里有若干个正整数，范围是1～100，其中有98个整数出现了偶数次，只有2个整数出现了奇数次。
        /// 如何找到这2个出现奇数次的整数？
        /// 
        /// 思路
        /// 假定最终结果的两个数字为：x, y
        /// 1. 仍然将整个数组中的元素依次异或，那么最终的结果就是x^y的结果，假定异或结果为：0B001010（至少有一位是1，否则x就等于y了）
        /// 2. 随便取一个为1的位，假定选择倒数第2位，将原数组分为两个新数组，
        ///        一个数组的元素倒数第2位都是0，另一个数组的元素的倒数第2位都是1 
        ///        此时，x与y一定分别在其中一个数组内
        /// 3. 而现在的两个新数组都符合上一个题目的条件，所以问题解决了
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static (int x, int y) FindLostNum3(IList<int> list)
        {
            int xor = list.Aggregate((i, j) => i ^ j);

            if (xor == 0) return (-1, -1);

            int mask = 1;
            while ((xor & mask) == 0) mask <<= 1;  // 寻找合适的掩码

            // List<int> list1 = new List<int>();
            // List<int> list2 = new List<int>();

            // foreach (int i in list)
            // {
            //     if ((i & mask) == mask)
            //         list1.Add(i);
            //     else
            //         list2.Add(i);
            // }

            // int r1 = list1.Aggregate((i, j) => i ^ j);
            // int r2 = list2.Aggregate((i, j) => i ^ j);
            // 不需要像上面那样真的分两个数组，直接进行运算就可以
            int r1 = 0, r2 = 0;
            foreach (int i in list)
            {
                if ((i & mask) == 0)
                    r1 ^= i;
                else
                    r2 ^= i;
            }

            return (r1, r2);
        }
    }
}
