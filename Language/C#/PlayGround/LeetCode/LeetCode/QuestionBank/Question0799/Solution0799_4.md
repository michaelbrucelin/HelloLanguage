﻿#### [线性 DP](https://leetcode.cn/problems/champagne-tower/solutions/1981121/by-ac_oier-c8jn/)

为了方便，我们令 `poured` 为 `k`，`query_row` 和 `query_glass` 分别为 $n$ 和 $m$。

定义 $f[i][j]$ 为第 $i$ 行第 $j$ 列杯子所经过的水的流量（而不是最终剩余的水量）。

起始我们有 $f[0][0]=k$，最终答案为 $\min(f[n][m], 1)$。

不失一般性考虑 $f[i][j]$ 能够更新哪些状态：显然当 $f[i][j]$ 不足 $1$ 的时候，不会有水从杯子里溢出，即 $f[i][j]$ 将不能更新其他状态；当 $f[i][j]$ 大于 $1$ 时，将会有 $f[i][j] − 1$ 的水会等量留到下一行的杯子里，所流向的杯子分别是「第 $i + 1$ 行第 $j$ 列的杯子」和「第 $i + 1$ 行第 $j + 1$ 列的杯子」，增加流量均为 $\frac{f[i][j] - 1}{2}$，即有 $f[i + 1][j] += \frac{f[i][j] - 1}{2}$ 和 $f[i + 1][j + 1] += \frac{f[i][j] - 1}{2}$。

代码：

```java
class Solution {
    public double champagneTower(int k, int n, int m) {
        double[][] f = new double[n + 10][n + 10];
        f[0][0] = k;
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= i; j++) {
                if (f[i][j] <= 1) continue;
                f[i + 1][j] += (f[i][j] - 1) / 2;
                f[i + 1][j + 1] += (f[i][j] - 1) / 2;
            }
        }
        return Math.min(f[n][m], 1);
    }
}
```

```typescript
function champagneTower(k: number, n: number, m: number): number {
    const f = new Array<Array<number>>()
    for (let i = 0; i < n + 10; i++) f.push(new Array<number>(n + 10).fill(0))
    f[0][0] = k
    for (let i = 0; i <= n; i++) {
        for (let j = 0; j <= i; j++) {
            if (f[i][j] <= 1) continue
            f[i + 1][j] += (f[i][j] - 1) / 2
            f[i + 1][j + 1] += (f[i][j] - 1) / 2
        }
    }
    return Math.min(f[n][m], 1)
}
```

```python
class Solution:
    def champagneTower(self, k: int, n: int, m: int) -> float:
        f = [[0] * (n + 10) for _ in range(n + 10)]
        f[0][0] = k
        for i in range(n + 1):
            for j in range(i + 1):
                if f[i][j] <= 1:
                    continue
                f[i + 1][j] += (f[i][j] - 1) / 2
                f[i + 1][j + 1] += (f[i][j] - 1) / 2
        return min(f[n][m], 1)
```

-   时间复杂度：$O(n^2)$
-   空间复杂度：$O(n^2)$
