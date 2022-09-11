﻿#### 提示 1

在**最优**发工资方案下，至少有一名工人，发给他的工资恰好等于他的最低期望工资。

反证：假设不存在这样的工人，那么发给每名工人的工资都高于其最低期望工资，我们可以把每人的工资都下调，从而得到更优的方案，矛盾。

#### [](https://leetcode.cn/problems/minimum-cost-to-hire-k-workers/solution/yi-bu-bu-ti-shi-ru-he-si-kao-ci-ti-by-en-1p00//#提示-2)提示 2

枚举发了最低期望工资的那名工人，在满足条件 1 的前提下，哪些工人可以满足条件 2？

如何快速地求出这些工人？

#### [](https://leetcode.cn/problems/minimum-cost-to-hire-k-workers/solution/yi-bu-bu-ti-shi-ru-he-si-kao-ci-ti-by-en-1p00//#提示-3)提示 3

定义 ri\=wageiqualityi，表示「每单位工作质量的工资」。

若以 ri 为基准发工资，那么对于 r 值不超过 ri 的工人，发给他们的工资是不低于其最低期望工资的，因此这些工人是可以随意选择的。

那么**按照 ri 从小到大排序**，我们便可以快速地求出这些工人。

要选哪 k 名工人呢？

#### [](https://leetcode.cn/problems/minimum-cost-to-hire-k-workers/solution/yi-bu-bu-ti-shi-ru-he-si-kao-ci-ti-by-en-1p00//#提示-4)提示 4

设这 k 名工人的 quality 之和为 sumQ，若以 ri 为基准发工资，那么发的工资总额为 sumQ⋅ri，因此 sumQ 越小发的工资总额就越小。

因此我们需要在从小到大枚举 ri 时，维护当前最小的 k 个 quality 值。

如何高效维护呢？

#### [](https://leetcode.cn/problems/minimum-cost-to-hire-k-workers/solution/yi-bu-bu-ti-shi-ru-he-si-kao-ci-ti-by-en-1p00//#提示-5)提示 5

用一个**最大堆**来维护。

按照 ri 从小到大的顺序遍历，当堆中有 k 个元素时，如果 qualityi 比堆顶小，则可以弹出堆顶，将 qualityi 入堆，从而得到一个更小的 sumQ，此时有可能找到一个更优解 sumQ⋅ri，更新答案。

```Python
class Solution:
    def mincostToHireWorkers(self, quality: List[int], wage: List[int], k: int) -> float:
        qw = sorted(zip(quality, wage), key=lambda p: p[1] / p[0])  # 按照 r 值排序
        h = [-q for q, _ in qw[:k]]  # 加负号变成最大堆
        heapify(h)
        sum_q = -sum(h)
        ans = sum_q * qw[k - 1][1] / qw[k - 1][0]  # 选 r 值最小的 k 名工人组成当前的最优解
        for q, w in qw[k:]:
            if q < -h[0]:  # sum_q 可以变小，从而可能得到更优的答案
                sum_q += heapreplace(h, -q) + q  # 更新堆顶和 sum_q
                ans = min(ans, sum_q * w / q)
        return ans

```

```Java
class Solution {
    public double mincostToHireWorkers(int[] quality, int[] wage, int k) {
        int n = quality.length, sumQ = 0;
        var id = IntStream.range(0, n).boxed().toArray(Integer[]::new);
        Arrays.sort(id, (i, j) -> wage[i] * quality[j] - wage[j] * quality[i]); // 按照 r 值排序
        var pq = new PriorityQueue<Integer>((a, b) -> b - a); // 最大堆
        for (var i = 0; i < k; ++i) {
            pq.offer(quality[id[i]]);
            sumQ += quality[id[i]];
        }
        var ans = sumQ * ((double) wage[id[k - 1]] / quality[id[k - 1]]); // 选 r 值最小的 k 名工人组成当前的最优解
        for (var i = k; i < n; ++i) {
            var q = quality[id[i]];
            if (q < pq.peek()) { // sumQ 可以变小，从而可能得到更优的答案
                sumQ -= pq.poll() - q;
                pq.offer(q);
                ans = Math.min(ans, sumQ * ((double) wage[id[i]] / q));
            }
        }
        return ans;
    }
}

```

```C++
class Solution {
public:
    double mincostToHireWorkers(vector<int> &quality, vector<int> &wage, int k) {
        int n = quality.size(), id[n], sum_q = 0;
        iota(id, id + n, 0);
        sort(id, id + n, [&](int i, int j) { return wage[i] * quality[j] < wage[j] * quality[i]; }); // 按照 r 值排序
        priority_queue<int> pq;
        for (int i = 0; i < k; ++i) {
            pq.push(quality[id[i]]);
            sum_q += quality[id[i]];
        }
        double ans = sum_q * ((double) wage[id[k - 1]] / quality[id[k - 1]]); // 选 r 值最小的 k 名工人组成当前的最优解
        for (int i = k; i < n; ++i)
            if (int q = quality[id[i]]; q < pq.top()) { // sum_q 可以变小，从而可能得到更优的答案
                sum_q -= pq.top() - q;
                pq.pop();
                pq.push(q);
                ans = min(ans, sum_q * ((double) wage[id[i]] / q));
            }
        return ans;
    }
};

```

```Go
func mincostToHireWorkers(quality, wage []int, k int) float64 {
type pair struct{ q, w int }
qw := make([]pair, len(quality))
for i, q := range quality {
qw[i] = pair{q, wage[i]}
}
sort.Slice(qw, func(i, j int) bool { a, b := qw[i], qw[j]; return a.w*b.q < b.w*a.q }) // 按照 r 值排序
h := hp{make([]int, k)}
sumQ := 0
for i, p := range qw[:k] {
h.IntSlice[i] = p.q
sumQ += p.q
}
heap.Init(&h)
ans := float64(sumQ*qw[k-1].w) / float64(qw[k-1].q) // 选 r 值最小的 k 名工人组成当前的最优解
for _, p := range qw[k:] {
if p.q < h.IntSlice[0] { // sumQ 可以变小，从而可能得到更优的答案
sumQ -= h.IntSlice[0] - p.q
h.IntSlice[0] = p.q
heap.Fix(&h, 0) // 更新堆顶
ans = math.Min(ans, float64(sumQ*p.w)/float64(p.q))
}
}
return ans
}

type hp struct{ sort.IntSlice }
func (h hp) Less(i, j int) bool { return h.IntSlice[i] > h.IntSlice[j] } // 最大堆
func (hp) Push(interface{})     {} // 由于没有用到，可以什么都不写
func (hp) Pop() (_ interface{}) { return }

```

#### [](https://leetcode.cn/problems/minimum-cost-to-hire-k-workers/solution/yi-bu-bu-ti-shi-ru-he-si-kao-ci-ti-by-en-1p00//#复杂度分析)复杂度分析

-   时间复杂度：O(nlog⁡n)，其中 n 为 quality 的长度。排序的时间复杂度为 O(nlog⁡n)，后面和堆有关的时间复杂度为 O(nlog⁡k)，由于 k≤n，总的时间复杂度为 O(nlog⁡n)。
-   空间复杂度：O(n)。由于 k≤n，空间复杂度主要取决于 n。
