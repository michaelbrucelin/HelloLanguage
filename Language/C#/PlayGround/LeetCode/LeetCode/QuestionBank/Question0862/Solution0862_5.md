#### [](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/solution/by-ac_oier-es0s//#前缀和-离散化-权值树状数组)前缀和 + 离散化 + 权值树状数组

由于求解的对象是子数组，容易联想到求连续段之和，容易联想到「前缀和」，假设我们预处理出的前缀和数组为 sum（为了方便，我们令前缀和数组坐标从 1 开始）。

即每个 nums[i] 而言，本质上是找满足「sum[i]−sum[j]⩾k」条件的最大坐标 j，其中 j 的取值范围为 [0,i−1]，从而知道以 i 作为左端点时，满足条件的最短子数组长度为 i−j。

先考虑存在负数域的问题，由于我们需要使用 sum[X]，以及对应的 sum[X]+k，而 k 的取值为 1e9，我们可以通过「离散化」手段将其映射到 2 倍的数组长度，大小为 $2\times10^5$。

对于每个 sum[i] 而言，我们利用「权值树状数组」来维护满足大于等于 sum[i]+k 的最大下标。起始我们先初始化树状数组为 −1，遍历过程中，查询是否存在满足条件的下标（若不为 `-1` 则更新 `ans`），并更新权值树状数组对应的最大下标即可。

代码：

```Java
class Solution {
    static int N = 200010;
    static int[] tr = new int[N], sum = new int[N];
    int n, m, ans;
    int lowbit(int x) {
        return x & -x;
    }
    void update(int val, int loc) {
        for (int i = val; i < m; i += lowbit(i)) tr[i] = Math.max(tr[i], loc);
    }
    int query(int x) {
        int ans = -1;
        for (int i = x; i > 0; i -= lowbit(i)) ans = Math.max(ans, tr[i]);
        return ans;
    }
    int getIdx(List<Long> list, long x) {
        int l = 0, r = list.size() - 1;
        while (l < r) {
            int mid = l + r >> 1;
            if (list.get(mid) >= x) r = mid;
            else l = mid + 1;
        }
        return r + 1;
    }
    public int shortestSubarray(int[] nums, int k) {
        n = nums.length; m = 2 * n + 10; ans = n + 10;
        Arrays.fill(tr, -1);
        long[] temp = new long[m];
        List<Long> list = new ArrayList<>();
        list.add(0L);
        for (int i = 1; i <= 2 * n + 1; i++) {
            if (i <= n) temp[i] = temp[i - 1] + nums[i - 1];
            else temp[i] = temp[i - (n + 1)] + k;
            list.add(temp[i]);
        }
        Collections.sort(list);
        for (int i = 0; i <= 2 * n + 1; i++) sum[i] = getIdx(list, temp[i]);
        update(sum[n + 1], 0);
        for (int i = 1; i <= n; i++) {
            int j = query(sum[i]);
            if (j != -1) ans = Math.min(ans, i - j);
            update(sum[n + 1 + i], i);
        }
        return ans == n + 10 ? -1 : ans;
    }
}
```

-   时间复杂度：预处理前缀和的的复杂度为 O(n)，排序并进行离散化的复杂度为 O(nlog⁡n)；构造答案的复杂度为 O(nlog⁡n)。整体复杂度为 O(nlog⁡n)
-   空间复杂度：O(n)
