using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0927
{
    public class Solution0927 : Interface0927
    {
        /// <summary>
        /// 如果有结果，需要满足下面几个条件
        /// 1. 1的数量是3的倍数
        ///     假设为3n，那么每一组有n个1
        /// 2. 令c1为第一组1与第二组1之间0的数量，c2为第二组1与第三组1之间0的数量，c3是第三组1后面0的数量
        ///     需要保证c1>=c3，c2>=c3
        /// 3. 每组1的结构一致，要么都是111，或者都是1101这样的
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] ThreeEqualParts(int[] arr)
        {
            int sum1 = arr.Sum();
            if (sum1 % 3 != 0) return new int[] { -1, -1 };
            if (sum1 == 0) return new int[] { 0, 2 };

            int cnt = sum1 / 3;
            StringBuilder sb = new StringBuilder();
            string one1, one2, one3;           // 3组1
            int cnt1 = 0, cnt2 = 0, cnt3 = 0;  // 3组0的数量
            int index1, index2;                // 第1组1与第2组1最后1位的索引

            int id = 0, cnt0 = 0;
            while (id < arr.Length && arr[id] == 0) id++;
            while (cnt0 < cnt) { if (arr[id] == 1) cnt0++; sb.Append(arr[id++]); }
            index1 = id;
            one1 = sb.ToString();
            while (id < arr.Length && arr[id] == 0) { cnt1++; id++; }

            sb.Clear(); cnt0 = 0;
            while (cnt0 < cnt) { if (arr[id] == 1) cnt0++; sb.Append(arr[id++]); }
            index2 = id;
            one2 = sb.ToString();
            while (id < arr.Length && arr[id] == 0) { cnt2++; id++; }

            sb.Clear(); cnt0 = 0;
            while (cnt0 < cnt) { if (arr[id] == 1) cnt0++; sb.Append(arr[id++]); }
            one3 = sb.ToString();
            while (id < arr.Length && arr[id] == 0) { cnt3++; id++; }

            if (cnt1 < cnt3 || cnt2 < cnt3) return new int[] { -1, -1 };
            if (one1 != one2 || one2 != one3) return new int[] { -1, -1 };

            return new int[] { index1 + cnt3 - 1, index2 + cnt3 };
        }
    }
}
