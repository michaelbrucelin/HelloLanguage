using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1403
{
    public class Solution1403
    {
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
