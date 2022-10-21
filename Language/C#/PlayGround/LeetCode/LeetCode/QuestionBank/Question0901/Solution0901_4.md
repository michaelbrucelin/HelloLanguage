﻿#### [](https://leetcode.cn/problems/online-stock-span/solution/by-ac_oier-m8g7//#分块)分块

又名优雅的暴力。

这是一道在线问题，在调用 `next` 往数据流存入元素的同时，返回连续段不大于当前元素的数的个数。

一个朴素的想法是：使用数组 `nums` 将所有 `price` 进行存储，每次返回时往前找到第一个不满足要求的位置，并返回连续段的长度。

但对于 $10^4$ 的调用次数来看，该做法的复杂度为 $O(n^2)$，计算量为 $10^8$，不满足 `OJ` 要求。

实际上我们可以利用「分块」思路对其进行优化，将与连续段的比较转换为与最值的比较。

具体的，我们仍然使用 `nums` 对所有的 `price` 进行存储，同时使用 `region` 数组来存储每个连续段的最大值，其中 region[loc]=x 含义为块编号为 `loc` 的最大值为 `x`，其中块编号 `loc` 块对应了数据编号 `idx` 的范围 [(loc−1)×len+1,loc×len]。

对于 `next` 操作而言，除了直接更新数据数组 `nums[++idx] = price` 以外，我们还需要更新 `idx` 所在块的最值 `region[loc]`，然后从当前块 `loc` 开始往前扫描其余块，使用 `left` 和 `right` 代指当前处理到的块的左右端点，若当前块满足 `region[loc] <= price`，说明块内所有元素均满足要求，直接将当前块 `loc` 所包含元素个数累加到答案中，直到遇到不满足的块或达到块数组边界，若存在遇到不满足要求的块，再使用 `right` 和 `left` 统计块内满足要求 `nums[i] <= price` 的个数。

对于块个数和大小的设定，是运用分块降低复杂度的关键，数的个数为 $10^4$，我们可以设定块大小为 $\sqrt{n}=100$，这样也限定了块的个数为 $\sqrt{n}=100$ 个。这样对于单次操作而言，我们最多遍历进行 $\sqrt{n}$ 次的块间操作，同时最多进行一次块内操作，整体复杂度为 $O(\sqrt{n})$，单次 `next` 操作计算量为 $2×10^2$ 以内，单样例计算量为 $2×10^6$，可以过。

为了方便，我们令块编号 `loc` 和数据编号 `idx` 均从 111 开始；同时为了防止每个样例都 `new` 大数组，我们采用 `static` 优化，并在 `StockSpanner` 的初始化中做重置工作。

代码：

```Java
class StockSpanner {
    static int N = 10010, len = 100, idx = 0;
    static int[] nums = new int[N], region = new int[N / len + 10];
    public StockSpanner() {
        for (int i = 0; i <= getIdx(idx); i++) region[i] = 0;
        idx = 0;
    }
    int getIdx(int x) {
        return (x - 1) / len + 1;
    }
    int query(int price) {
        int ans = 0, loc = getIdx(idx), left = (loc - 1) * len + 1, right = idx;
        while (loc >= 1 && region[loc] <= price) {
            ans += right - left + 1;
            loc--; right = left - 1; left = (loc - 1) * len + 1;
        }
        for (int i = right; loc >= 1 && i >= left && nums[i] <= price; i--) ans++;
        return ans;
    }
    public int next(int price) {
        nums[++idx] = price;
        int loc = getIdx(idx);
        region[loc] = Math.max(region[loc], price);
        return query(price);
    }
}
```

-   时间复杂度：由于使用了 `static` 优化，`StockSpanner` 初始化时，需要对上一次使用的块进行重置，复杂度为$O(\sqrt{n})$；由于块大小和数量均为 $\sqrt{n}$，`next` 操作复杂度为 $O(\sqrt{n})$
-   空间复杂度：O(n)
