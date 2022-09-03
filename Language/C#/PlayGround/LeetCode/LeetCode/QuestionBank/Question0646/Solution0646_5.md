## 排序 + 贪心 DP（转移剪枝）

起始先将 `pairs` 根据第一维排升序（或直接双关键字排升序）。

考虑定义 f\[i\] 为以 pairs\[i\] 为结尾的最长数对链长度，所有 f\[i\] 中的最大值为答案。

不失一般性考虑 f\[i\] 该如何转移：不难发现 f\[i\] 为所有满足「下标范围在 \[0,i−1\]，且 pairs\[j\]\[1\]<pairs\[i\]\[0\]」条件的 f\[j\]+1 的最大值。

但实际上，我们只需要从 j\=i−1 开始往回找，找到第一个满足 pairs\[j\]\[1\]<pairs\[i\]\[0\] 的位置 j 即可。

容易证明该做法的正确性：**假设贪心解（该做法）找到的位置 j 不是最优位置，即存在比 j 更小的合法下标 j′ 满足 f\[j′\]\>f\[j\]。根据我们的排序规则必然有 pairs\[j′\]\[0\]<\=pairs\[j\]\[0\] 的性质，则可知 pairs\[j\] 必然可以代替 pairs\[j′\] 接在原本以 pairs\[j′\] 为结尾的最优数链上（最优数链长度不变，结果不会变差），则至少有 f\[j′\]\=f\[j\]。**

代码：

```Java
class Solution {
    public int findLongestChain(int[][] pairs) {
        Arrays.sort(pairs, (a,b)->a[0]-b[0]);
        int n = pairs.length, ans = 1;
        int[] f = new int[n];
        for (int i = 0; i < n; i++) {
            f[i] = 1;
            for (int j = i - 1; j >= 0 && f[i] == 1; j--) {
                if (pairs[j][1] < pairs[i][0]) f[i] = f[j] + 1;
            }
            ans = Math.max(ans, f[i]);
        }
        return ans;
    }
}

```

-   时间复杂度：排序的复杂度为 O(nlog⁡n)；不考虑剪枝效果 `DP` 复杂度为 O(n^2)。整体复杂度为 O(n^2)
-   空间复杂度：O(n)

___

## [](https://leetcode.cn/problems/maximum-length-of-pair-chain/solution/by-ac_oier-z91l//#排序-贪心-dp（优化转移）)排序 + 贪心 DP（优化转移）

根据上述分析，我们知道对于一个特定的 pairs\[i\] 而言，其所有合法（满足条件 pairs\[j\]\[1\]<pairs\[i\]\[0\]）的前驱状态 f\[j\] 必然是非单调递增的。

根据 `LIS` 问题的贪心解的思路，我们可以额外使用一个数组记录下特定长度数链的最小结尾值，从而实现二分找前驱状态。

具体的，创建 g 数组，其中 g\[len\]\=x 代表数链长度为 len 时结尾元素的第二维最小值为 x。

如此一来，当我们要找 f\[i\] 的前驱状态时，等价于在 g 数组中找满足「小于 pairs\[i\]\[0\]」的最大下标。同时，我们不再需要显式维护 f 数组，只需要边转移变更新答案即可。

> **不了解 `LIS` 问题的同学可以看前置 🧀 : [LCS 问题与 LIS 问题的相互关系，以及 LIS 问题的最优解证明](https://leetcode.cn/link/?target=https%3A%2F%2Fmp.weixin.qq.com%2Fs%3F__biz%3DMzU4NDE3MTEyMA%3D%3D%26mid%3D2247487814%26idx%3D1%26sn%3De33023c2d474ff75af83eda1***d01892) 🎉🎉🎉**

代码：

```Java
class Solution {
    public int findLongestChain(int[][] pairs) {
        Arrays.sort(pairs, (a,b)->a[0]-b[0]);
        int n = pairs.length, ans = 1;
        int[] g = new int[n + 10];
        Arrays.fill(g, 0x3f3f3f3f);
        for (int i = 0; i < n; i++) {
            int l = 1, r = i + 1;
            while (l < r) {
                int mid = l + r >> 1;
                if (g[mid] >= pairs[i][0]) r = mid;
                else l = mid + 1;
            }
            g[r] = Math.min(g[r], pairs[i][1]);
            ans = Math.max(ans, r);
        }
        return ans;
    }
}

```

-   时间复杂度：排序的复杂度为 O(nlog⁡n)；`DP` 复杂度为 O(nlog⁡n)。整体复杂度为 O(nlog⁡n)
-   空间复杂度：O(n)
