using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1403
{
    public class Solution1403
    {
        public void Test()
        {
            Solution1403 q1403 = new Solution1403();

            int[] nums = new int[] { 4, 3, 10, 9, 8 };
            IList<int> result = q1403.MinSubsequence(nums);
            foreach (int i in result)
                Console.Write($"{i} ");

            Console.WriteLine();
            nums = new int[] { 4, 4, 7, 6, 7 };
            result = q1403.MinSubsequence(nums);
            foreach (int i in result)
                Console.Write($"{i} ");
        }

        public IList<int> MinSubsequence(int[] nums)
        {
            List<int> listTar = new List<int>();

            int sumsrc = 0, sumtar = 0;
            List<int> listSrc = nums.ToList();
            sumsrc = nums.Sum();

            while (sumtar <= sumsrc)
            {
                int maxid = 0;
                for (int i = 0; i < listSrc.Count; i++)
                    if (listSrc[i] > listSrc[maxid])
                        maxid = i;

                sumtar += listSrc[maxid];
                sumsrc -= listSrc[maxid];
                listTar.Add(listSrc[maxid]);
                listSrc.RemoveAt(maxid);
            }

            return listTar;
        }
    }
}
