using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsBinary
    {
        #region 计算整数对应二进制中1的数量
        /// <summary>
        /// 计算整数对应二进制中1的数量
        /// 用这个方法通常情况下就足够快了
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

        #region 汉明重量
        private const int M1 = 0x55555555;   // 01010101010101010101010101010101
        private const int M2 = 0x33333333;   // 00110011001100110011001100110011
        private const int M4 = 0x0f0f0f0f;   // 00001111000011110000111100001111
        private const int M8 = 0x00ff00ff;   // 00000000111111110000000011111111
        private const int M16 = 0x0000ffff;  // 00000000000000001111111111111111
        private const int M24 = 0x01010101;  // 00000001000000010000000100000001

        /// <summary>
        /// 第1步：计算出来的值n的二进制可以按每 2个二进制位为一组进行分组，各组的十进制表示的就是该组的汉明重量。
        /// 第2步：计算出来的值n的二进制可以按每 4个二进制位为一组进行分组，各组的十进制表示的就是该组的汉明重量。
        /// 第3步：计算出来的值n的二进制可以按每 8个二进制位为一组进行分组，各组的十进制表示的就是该组的汉明重量。
        /// 第4步：计算出来的值n的二进制可以按每16个二进制位为一组进行分组，各组的十进制表示的就是该组的汉明重量。
        /// 第5步：计算出来的值n的二进制可以按每32个二进制位为一组进行分组，各组的十进制表示的就是该组的汉明重量。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int HammingWeight(uint n)
        {
            n = (n & M1) + ((n >> 1) & M1);
            n = (n & M2) + ((n >> 2) & M2);
            n = (n & M4) + ((n >> 4) & M4);
            n = (n & M8) + ((n >> 8) & M8);
            n = (n & M16) + ((n >> 16) & M16);

            return (int)n;
        }

        /// <summary>
        /// 第1步：计算出来的值n的二进制可以按每2个二进制位为一组进行分组，各组的十进制表示的就是该组的汉明重量。
        /// 第2步：计算出来的值n的二进制可以按每4个二进制位为一组进行分组，各组的十进制表示的就是该组的汉明重量。
        /// 第3步：计算出来的值n的二进制可以按每8个二进制位为一组进行分组，各组的十进制表示的就是该组的汉明重量。
        /// 第4步：n * (0x01010101)计算出汉明重量并记录在二进制的高八位，>>24语句则通过右移运算，将汉明重量移到最低八位，最后二进制对应的十进制数就是汉明重量。
        /// 算法时间复杂度是O(1)的。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int HammingWeight2(uint n)
        {
            n = (n & M1) + ((n >> 1) & M1);
            n = (n & M2) + ((n >> 2) & M2);
            n = (n & M4) + ((n >> 4) & M4);
            n = n * M24 >> 24;

            return (int)n;
        }

        public static int HammingWeight3(uint n)
        {
            uint result;

            // C     n - ((n >> 1) & 033333333333) - ((n >> 2) & 011111111111);
            result = n - ((n >> 1) & 3681400539) - ((n >> 2) & 1227133513);  // C#中没有原生的八进制

            // C         ((result + (result >> 3)) & 030707070707) % 63;
            return (int)(((result + (result >> 3)) & 3340530119) % 63);      // C#中没有原生的八进制
        }
        #endregion
        #endregion
    }
}
