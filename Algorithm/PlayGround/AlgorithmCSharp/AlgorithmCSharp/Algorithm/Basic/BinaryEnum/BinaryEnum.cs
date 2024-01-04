using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Basic.BinaryEnum
{
    public class BinaryEnum
    {
        /// <summary>
        /// 一个集合中有n个元素，枚举所有子集，可以使用回溯，这里使用二进制枚举
        /// </summary>
        /// <param name="n"></param>
        public static void EnumSet(int n)
        {
            for (int i = 0; i < 1 << n; i++) Console.WriteLine($"{i}:\t{Convert.ToString(i, 2).PadLeft(n, '0')}");
        }

        /// <summary>
        /// 对于已知的二进制状态sup，枚举此状态的所有子集
        /// 原理：针对sup中的二进制为1的位开始进行减法，假设有k个二进制位，那么像枚举(2^k-1)~0一样枚举其子集
        /// 输出：状态为降序输出
        /// </summary>
        /// <param name="sup"></param>
        public static void EnumSubSet(int sup)
        {
            int sub = sup, i = 0, n = Convert.ToString(sup, 2).Length;
            do
            {
                Console.WriteLine($"{i++}:\t{Convert.ToString(sub, 2).PadLeft(n, '0')}");
            } while ((sub = sub - 1 & sup) != sup);
        }

        /// <summary>
        /// for版本
        /// </summary>
        /// <param name="sup"></param>
        public static void EnumSubSet2(int sup)
        {
            int i = 0, n = Convert.ToString(sup, 2).Length;
            for (int sub = sup; sub != 0; sub = sub - 1 & sup)
                Console.WriteLine($"{i++}:\t{Convert.ToString(sub, 2).PadLeft(n, '0')}");
            Console.WriteLine($"{i++}:\t{Convert.ToString(0, 2).PadLeft(n, '0')}");        // for版本需要单独处理0（一个都不选）
        }

        /// <summary>
        /// 一个集合中有n个元素，需要从其中选择k个元素，枚举所有可能的子集，可以使用回溯，这里使用二进制枚举
        /// 原理：根据当前的符合要求的状态求出第一个大于该状态的符合要求的状态
        ///         1. 从后往前找到第一个降序（即"01"），然后将其变为"10"
        ///         2. 最后将该"10"后面的序列逆转即可
        /// 输出：升序输出
        /// 算法描述：按照字典序的话，最小的子集是(1<<k)-1（连续k个1），所以用它作为初始值。
        ///           现在我们求出kset其后的二进制码
        ///               1. 求出最低位的1开始连续的1的区间，（x&(-x)的值就是将最低位的1独立出来的值）
        ///               2. 将这一区间全部变为0，并将区间最左侧的0变为1
        ///               3. 将第1步取出的区间右移，知道剩下的1的个数少了1个
        ///               4. 将第2步和第3步的结果按位取或
        /// 参考：https://programmingforinsomniacs.blogspot.com/2018/03/gospers-hack-explained.html
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        public static void EnumKSet(int n, int k)
        {
            if (k == 0) throw new Exception("一个元素都不选需要单独处理");

            int kset = (1 << k) - 1, limit = 1 << n, c, r, i = 0;
            while (kset < limit)
            {
                Console.WriteLine($"{i++}:\t{Convert.ToString(kset, 2).PadLeft(n, '0')}");  // 业务逻辑
                c = kset & -kset;
                r = kset + c;
                kset = (((r ^ kset) >> 2) / c) | r;  // kset = (kset & ~r) / c >> 1 | r; 这样也可以，具体有没有差异没分析
            }
        }
    }
}
