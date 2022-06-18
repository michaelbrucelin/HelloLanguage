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
            List<(int gold, int worker)> resource = new List<(int gold, int worker)> { (400, 5), (500, 5), (200, 3), (300, 4), (350, 3) };
            int worker = 10;

            #region 1. 递归法求解
            Console.WriteLine("1. 递归法求解");
            Console.WriteLine(GetBestGoldMining(resource, resource.Count, worker));
            #endregion

            #region 2. 自底向上求解，使用二维数组
            Console.WriteLine();
            Console.WriteLine("2. 自底向上求解，使用二维数组");
            var plan = GetBestGoldMining2(resource, worker);

            Console.WriteLine(plan.result);

            // column header
            Console.Write($"{(char)32,8}");
            for (int i = 0; i <= worker; i++) Console.Write($"{i,5}");
            Console.WriteLine();

            for (int i = 0; i < plan.table.GetLength(0); i++)
            {
                // row header
                if (i == 0)
                    Console.Write("(0, 0)  ");
                else
                    Console.Write($"{resource[i - 1],8}");

                for (int j = 0; j < plan.table.GetLength(1); j++)
                {
                    Console.Write($"{plan.table[i, j],5}");
                }
                Console.WriteLine();
            }
            #endregion

            #region 3. 自底向上求解，使用一维数组
            Console.WriteLine();
            Console.WriteLine("3. 自底向上求解，使用一维数组");
            var plan2 = GetBestGoldMining3(resource, worker);

            Console.WriteLine(plan2.result);

            // column header
            Console.Write($"{(char)32,8}");
            for (int i = 0; i <= worker; i++) Console.Write($"{i,5}");
            Console.WriteLine();

            // row header
            Console.Write($"{resource[resource.Count - 1],8}");
            for (int i = 0; i < plan2.table.Length; i++)
                Console.Write($"{plan2.table[i],5}");
            #endregion
        }

        /// <summary>
        /// 动态规划
        /// 现有如下5座金矿
        ///     200kg/3人，300kg/4人，350kg/3人，400kg/5人，500kg/5人
        /// 如果参与挖矿的工人的总数是10。每座金矿要么全挖，要么不挖，不能派出一半人挖取一半的金矿。
        /// 要求用程序求出，要想得到尽可能多的黄金，应该选择挖取哪几座金矿？
        /// 
        /// 思路：
        /// 1. 最后一座金矿要么挖，要么不挖，只有这两种可能，
        ///        1.1. 挖，最大效益就是500kg + 剩下5人挖剩下4座金矿的最大效益
        ///        1.2. 不挖，最大效益就是10人挖剩下4座金矿的最大效益
        ///    1.1. 与 1.2. 中较大的结果就是最大效益
        /// 2. “剩下5人挖剩下4座金矿的最大效益”与“10人挖剩下4座金矿的最大效益”，也都可以分为最后一座金矿挖与不挖两种可能
        /// 3. 递归就可以是实现上面的思路
        /// 
        /// 用递归实现
        /// </summary>
        /// <param name="resource">金矿</param>
        /// <param name="gold">有几座金矿可以开采</param>
        /// <param name="worker">有几名工人可以采矿</param>
        /// <returns></returns>
        public static int GetBestGoldMining(List<(int gold, int worker)> resource, int gold, int worker)
        {
            if (gold == 0 || worker == 0) return 0;

            // 如果不采最后一个矿
            int noLast = GetBestGoldMining(resource, gold - 1, worker);

            // 如果采最后一个矿
            int getLast = 0;
            if (worker >= resource[gold - 1].worker)
                getLast = resource[gold - 1].gold + GetBestGoldMining(resource, gold - 1, worker - resource[gold - 1].worker);

            return getLast >= noLast ? getLast : noLast;
        }

        /// <summary>
        /// 动态规划
        /// 利用二维数组，自底向上求解
        /// 
        /// |       |   1 |   2 |   3 |   4 |   5 |   6 |   7 |   8 |   9 |  10 |
        /// +-------+-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+
        /// | 400/5 |   0 |   0 |   0 |   0 | 400 | 400 | 400 | 400 | 400 | 400 |
        /// | 500/5 |   0 |   0 |   0 |   0 | 500 | 500 | 500 | 500 | 500 | 900 |
        /// | 200/3 |   0 |   0 | 200 | 200 | 500 | 500 | 500 | 700 | 700 | 900 |
        /// | 300/4 |   0 |   0 | 200 | 300 | 500 | 500 | 500 | 700 | 800 | 900 |
        /// | 350/3 |   0 |   0 | 350 | 350 | 500 | 550 | 650 | 850 | 850 | 900 |
        /// 
        /// 其实思路与上面用的递归实现是一样的，区别是使用为二维数组记录了已经得到的结果，这样做有2点好处
        /// 1. 使用循环而不是递归，这样就没有递归性能低下的问题
        /// 2. 充分利用已经得到的结果（想想KMP算法），计算的次数更少
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        public static (int result, int[,] table) GetBestGoldMining2(List<(int gold, int worker)> resource, int worker)
        {
            // new int[resource.Count + 1, worker + 1]中的 +1 有两点好处
            // 1. table[0, ...]与table[..., 0]分别表示没有矿与没有工人的最优解，数据完整性上更完整
            // 2. table[0, ...]与table[..., 0]不需要遍历，直接从table[1, 1]处开始遍历，找前面的结果时，不需要判断数组会不会越界（见算法）
            int[,] table = new int[resource.Count + 1, worker + 1];

            for (int i = 1; i < table.GetLength(0); i++)      // i是第几座金矿：resource[i-1]
            {
                for (int j = 1; j < table.GetLength(1); j++)  // j是工人的数量
                {
                    // 这里需要找出j个工人，挖前i个金矿的最优解，共有下面两种情况
                    // 1. 不挖第i座金矿
                    // 此时最优解就是j个工人挖前i-1个金矿的最优解：table[i-1, j]
                    table[i, j] = table[i - 1, j];

                    // 2. 挖第i座金矿
                    // 此时的最优解是第i座金矿 + 剩余的人挖前i-1座金矿的最优解：table[i-1, j-x]，x为第i座金矿需要的人数
                    int temp = 0;
                    if (j >= resource[i - 1].worker)
                        temp = resource[i - 1].gold + table[i - 1, j - resource[i - 1].worker];

                    if (temp > table[i, j])
                        table[i, j] = temp;
                }
            }

            return (table[table.GetLength(0) - 1, table.GetLength(1) - 1], table);
        }

        /// <summary>
        /// 动态规划
        /// 利用二维数组，自底向上求解
        /// 
        /// 与上面的算法不同的是，这里进一步优化了空间复杂度
        /// 上面的算法使用了二维数组记录已经得到的结果，但是仔细看代码实现时会发现，
        /// 计算第i行第j列的时候，只会用到第i-1行的第j1（j1 <= j）列的值，
        /// 所以只需要一个二维数组，从后向前计算，逐步覆盖既有位置的值即可
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        public static (int result, int[] table) GetBestGoldMining3(List<(int gold, int worker)> resource, int worker)
        {
            int[] table = new int[worker + 1];  // +1 参考上一个方法中的注释

            for (int i = 0; i < resource.Count; i++)
            {
                for (int j = worker; j > 0; j--)
                {
                    // 1. 不挖resource[i]这个矿
                    // table[j] = table[j];  // 就是现在的值，不需要操作

                    // 2. 挖resource[i]这个矿
                    if (j >= resource[i].worker)
                        table[j] = Math.Max(table[j], resource[i].gold + table[j - resource[i].worker]);
                }
            }

            return (table[table.Length - 1], table);
        }
    }
}
