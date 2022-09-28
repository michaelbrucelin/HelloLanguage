using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1709
{
    public class Solution1709_2 : Interface1709
    {
        private List<int> helper = new List<int>() { 1, 3, 5, 7 };
        private int pos3 = 0, pos5 = 0, pos7 = 0;

        /// <summary>
        /// 假定已知前k-1个MagicNum {x1, x2, ... xk-1}，那么第k个MagicNum必然在{3*x1...3*xk-1, 5*x1...5*xk-1, 7*x1...7*xk-1}中
        /// 基于上面的假设，采用3指针分别记录3 5 7上次的位置，然后采用3 5 7各自向后一位后乘积的最小值即可
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetKthMagicNumber(int k)
        {
            if (k <= helper.Count) return helper[k - 1];

            int cnt = k - helper.Count;
            for (int i = 0; i < cnt; i++)
            {
                int v = GetSmallest(helper[pos3 + 1] * 3, helper[pos5 + 1] * 5, helper[pos7 + 1] * 7);
                helper.Add(v);
                if (helper[pos3 + 1] * 3 == v) pos3++;
                if (helper[pos5 + 1] * 5 == v) pos5++;
                if (helper[pos7 + 1] * 7 == v) pos7++;
            }

            return helper[k - 1];
        }

        private int GetSmallest(int x, int y, int z)
        {
            if (x <= y && x <= z) return x;
            if (y <= z && y <= x) return y;
            if (z <= x && z <= y) return z;

            throw new Exception("An unlikely outcome");
        }
    }
}
