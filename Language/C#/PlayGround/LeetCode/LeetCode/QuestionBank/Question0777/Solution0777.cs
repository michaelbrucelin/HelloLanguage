using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0777
{
    public class Solution0777 : Interface0777
    {
        /// <summary>
        /// L与R只能与相邻的X交换位置，且L只能向左移动，R只能向右移动
        /// 所以start与end中的L与R的相对位置是相同的，即start与end去掉X之后一定是相同的
        /// start与end中，start中的L的索引一定大于等于对应end中的L的索引
        ///               start中的R的索引一定小于等于对应end中的R的索引
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanTransform(string start, string end)
        {
            if (start.Length != end.Length) return false;
            // if (start.Replace("X", "") != end.Replace("X", "")) return false;  // 这行代码可有可无

            int len = start.Length;
            int i = 0, j = 0;
            while (i < len || j < len)
            {
                while (i < len && start[i] == 'X') i++;
                while (j < len && end[j] == 'X') j++;
                if (i == len || j == len) return i == j;
                if (start[i] != end[j]) return false;
                if (start[i] == 'L' && i < j) return false;
                if (start[i] == 'R' && i > j) return false;
                i++; j++;
            }

            return true;
        }
    }
}
