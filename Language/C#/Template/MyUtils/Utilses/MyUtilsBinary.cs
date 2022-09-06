using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsBinary
    {
        /// <summary>
        /// 计算整数对应二进制中1的数量
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static int BitCount(uint u)
        {
            int result = 0;

            while (u > 0)
            {
                result++;
                u &= (u - 1);
            }

            return result;
        }

        /// <summary>
        /// 计算整数对应二进制中1的数量
        /// 测试并不比上一种方法快，不确认是不是C#的问题，没有在C中验证
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public static int BitCount2(uint u)
        {
            uint result;

            // C     u - ((u >> 1) & 033333333333) - ((u >> 2) & 011111111111);
            result = u - ((u >> 1) & 3681400539) - ((u >> 2) & 1227133513);  // C#中没有原生的八进制

            // C         ((result + (result >> 3)) & 030707070707) % 63;
            return (int)(((result + (result >> 3)) & 3340530119) % 63);      // C#中没有原生的八进制
        }
    }
}
