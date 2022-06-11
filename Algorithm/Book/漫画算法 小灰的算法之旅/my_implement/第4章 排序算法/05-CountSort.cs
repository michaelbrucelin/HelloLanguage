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
            Random random = new Random();
            List<int> list = new List<int>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100)));

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            var list2 = CountSort(list);

            Console.WriteLine();
            for (int i = 0; i < list2.Count; i++)
                Console.Write($"{list2[i]}, ");
        }

        public static IList<int> CountSort(IList<int> list)
        {
            int min = list[0], max = list[list.Count - 1];
            foreach (int i in list)
            {
                if (i < min)
                    min = i;
                else if (i > max)
                    max = i;
            }

            int distance = max - min;
            int[] temp = new int[distance + 1];  // C#中整型数组默认全为0，不需要初始化
            foreach (int i in list)
            {
                temp[i - min]++;
            }

            IList<int> result = new List<int>(list.Count);
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[i]; j++)
                {
                    result.Add(min + i);
                }
            }

            return result;
        }
    }
}
