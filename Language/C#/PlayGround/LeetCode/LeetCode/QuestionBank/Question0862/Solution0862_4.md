#### O(nlogn) 单调栈解法及 O(n) 的单调队列优化

(https://leetcode.cn/topic/cpp/)[单调队列](https://leetcode.cn/tag/monotonic-queue/)[单调栈](https://leetcode.cn/tag/monotonic-stack/)

如果这道题给的整数数组中没有负数，怎么解决？

这个问题就很简单了，中等题里很多类似的，使用二分查找、滑动窗口都能解决。

没有负数的最大的优势是区间和具有“单调性”。单调性是一个非常好的性质，具有单调性的子数组相关问题可以很方便的使用二分查找、滑动窗口等方法解决，近两周的周赛都有这样的题（[2444\. 统计定界子数组的数目](https://leetcode.cn/problems/count-subarrays-with-fixed-bounds/solution/by-vclip-z5h3/)、[2447\. 最大公因数等于 K 的子数组数目](https://leetcode.cn/problems/number-of-subarrays-with-gcd-equal-to-k/solution/onlognlogu-jie-fa-by-vclip-idcb/)）。

子数组相关问题的一个常用方法是固定子数组一端，考虑另一端在什么情况下满足题目给定的条件，如果具有单调性，则满足题目要求的另一端点的可行范围是一段区间，使用二分查找、滑动窗口可以轻松的维护这一段区间，问题也就解决了。

对于本题，由于负数的存在，区间和没有单调性，满足题目条件（和不小于 k）的点是离散的，这使得问题不能套用上面的解决方法，对于这种情况，一个常用的处理方法是，考虑那些真正影响子数组能否满足题目条件或是否是最优解的“关键点”，着重维护这些关键点的信息。

![](./assets/img/Solution0862_4_01.dib)

假设给定数组 [2,1,−2,2,3,−2,1,…]。... 前面的是已经遍历到的元素，... 里是没有遍历到的元素，考虑固定子数组右端点为当前遍历到的最后一个位置（... 前的位置），哪些左端点值是重要的，是关键点？

子数组 [1,−2,2,3,−2,1] 一定不是最优解，因为子数组 [2,3,−2,1] 的子数组之和 4 大于子数组 [1,−2,2,3,−2,1] 的和 3，如果子数组 [1,−2,2,3,−2,1] 满足题目条件，即 k≤3，那么子数组 [2,3,−2,1] 也满足条件（k<3<4），并且长度更短。

一般情况下，我们可以从右往左考虑，让子数组逐渐扩大。设当前子数组为 [i,j]，子数组之和为 sum[i,j]，如果之前经历过的某个子数组 [i′,j] 的子数组之和 sum[i′,j]≥sum[i,j]，则当前子数组一定不是最优解，因为如果当前子数组和 sum[i,j] 不小于 k，那么子数组 [i′,j] 的和 sum[i′,j] 也不小于 k，且子数组 [i′,j] 更小，也就是比当前子数组更优。

在把上面这些一定不是最优解的点去除后，可以发现，剩下的点具有了单调性：从右往左，这些点对应的子数组之和单调递增，于是，没有负数时的解决方法就可以类似地用在这些关键点上。

另一个问题是如何维护这些关键点，即把被固定的右端点向右移动后，关键点会发生哪些变化。

![](./assets/img/Solution0862_4_02.dib)

子数组之和 sum[I,j] 依赖于右端点 j，使得问题不好处理，但子数组之和 sum[I,j] 可以用前缀和表示为 sum[j]−sum[i−1]。无论右端点怎么变化，改变的都是 sum[j]−sum[i−1] 中的 sum[j] 这一项，这对子数组之和之间的大小关系没有影响，因为所有的子数组之和都有这一项，因此只需要考虑 sum[i−1] 之间的关系，原先的子数组之和的递增，对应前缀和的递减，只需要维护一个前缀和的单调栈即可。

当右端点移动到 j 时，把栈中大于等于 sum[j] 的元素移除，然后把 sum[j] 加入栈中，就得到了新的单调栈。

没有负数时的两个方法，其中二分查找法可以直接应用到关键点上，在单调栈上二分即可；滑动窗口也可以类似的应用过来，也就是把子数组和大于等于 k 的关键点移除，把单调栈变成单调队列，但被移除的关键点在之后对应的子数组和可能小于 k，这点与没有负数的情况不同，但结果依然是正确的，因为如果之后子数组和再次回到大于等于 k 的状态，子数组长度一定更长，不会比被移除前的子数组更优。

#### [](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/solution/by-vclip-x7h7//#代码)代码

-   二分查找+单调栈
```C++
class Solution {
public:
    static constexpr int INF = 0x3f3f3f3f;

    int shortestSubarray(const vector<int>& nums, int k) {
        const int n = nums.size();
        int ans = INF;
        long long s = 0;
        vector<pair<long long, int>> stk = {{0, -1}};
        for (int i = 0;i < n;++i) {
            s += nums[i];
            int l = 0, r = stk.size();
            while (l < r) {
                const int mid = (l + r) / 2;
                if (stk[mid].first + k <= s)
                    l = mid + 1;
                else r = mid;
            }
            if (l > 0) ans = min(ans, i - stk[l - 1].second);
            while (!stk.empty() && s <= stk.back().first)
                stk.pop_back();
            stk.emplace_back(s, i);
        }
        return ans < INF ? ans : -1;
    }
};
```

-   单调队列
```C++
class Solution {
public:
    static constexpr int INF = 0x3f3f3f3f;

    int shortestSubarray(const vector<int>& nums, int k) {
        const int n = nums.size();
        int ans = INF;
        long long s = 0;
        deque<pair<long long, int>> q = {{0, -1}};
        for (int i = 0;i < n;++i) {
            s += nums[i];
            int p = -INF;
            for (;!q.empty() && q.front().first + k <= s;q.pop_front())
                p = q.front().second;
            ans = min(ans, i - p);
            while (!q.empty() && s <= q.back().first)
                q.pop_back();
            q.emplace_back(s, i);
        }
        return ans < INF ? ans : -1;
    }
};
```
