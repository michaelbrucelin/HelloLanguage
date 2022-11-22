#### [方法一：动态规划](https://leetcode.cn/problems/soup-servings/solutions/1981704/fen-tang-by-leetcode-solution-0yxs/)

**思路与算法**

首先，由于四种分配操作都是 25 的倍数，因此我们可以将 n 除以 25（如果有余数，则补 1），并将四种分配操作变为 (4, 0),(3, 1),(2, 2),(1, 3)，且每种操作的概率均为 0.25。

当 n 较小时，我们可以用动态规划来解决这个问题。设 dp(i,j) 表示汤 A 和汤 B 分别剩下 i 和 j 份时所求的概率值，即汤 A 先分配完的概率 + 汤 A 和汤 B 同时分配完的概率除以 2 。 状态转移方程为：
$dp(i, j) = \dfrac{1}{4} \times (dp(i - 4, y) + dp(i - 3, y - 1) + dp(i - 2, y - 2) + dp(i - 1, y - 3))$

我们仔细考虑一下边界条件：
-   当满足 $i > 0, j = 0$，此时无法再分配，而汤 A 还未分配完成，汤 A 永远无法完成分配，此时 $dp(i,j) = 0$；
-   当满足 $i = 0, j = 0$，此时汤 A 和汤 B 同时分配完的概率为 1.0，汤 A 先分配完的概率为 0，因此 $dp(i, j) = 1.0 \times 0.5 = 0.5$；
-   当满足 $i = 0, j > 0$，此时无法再分配，汤 A 先分配完的概率为 1.0，汤 B 永远无法完成分配，因此 $dp(i, j) = 1.0$；

因此综上，我们可以得到边界条件如下：

$dp(i,j) = \begin{cases} 0, & i > 0, j = 0 \\ 0.5, & i = 0, j = 0 \\ 1, & i = 0, j > 0 \\ \end{cases}$

我们可以看到这个动态规划的时间复杂度是 $O(n^2)$，即使将 n 除以 25 之后，仍然没法在短时间内得到答案，因此我们需要尝试一些别的思路。 我们可以发现，每次分配操作有 (4, 0),(3, 1),(2, 2),(1, 3) 四种，那么在一次分配中，汤 A 平均会被分配的份数期望为 $E(A) = (4 + 3 + 2 + 1) \times 0.25 = 2.5$ ，汤 BBB 平均会被分配的份数期望为 $E(B) = (0 + 1 + 2 + 3) \times 0.25 = 1.5$。因此在 n 非常大的时候，汤 A 会有很大的概率比 B 先分配完，汤 A 被先取完的概率应该非常接近 1。事实上，当我们进行实际计算时发现，当 $n \ge 4475$ 时，所求概率已经大于 0.99999 了（可以通过上面的动态规划方法求出），它和 1 的误差（无论是绝对误差还是相对误差）都小于 $10^{-5}$。实际我们在进行测算时发现：
$ n = 4475, \quad p \approx 0.999990211307 \\ n = 4476, \quad p \approx 0.999990468596$

因此在 $n \ge 179 \times 25$ 时，我们只需要输出 1 作为答案即可。在其它的情况下，我们使用动态规划计算出答案。

**代码**

```python
class Solution:
    def soupServings(self, n: int) -> float:
        n = (n + 24) // 25
        if n >= 179:
            return 1.0
        dp = [[0.0] * (n + 1) for _ in range(n + 1)]
        dp[0] = [0.5] + [1.0] * n
        for i in range(1, n + 1):
            for j in range(1, n + 1):
                dp[i][j] = (dp[max(0, i - 4)][j] + dp[max(0, i - 3)][max(0, j - 1)] +
                            dp[max(0, i - 2)][max(0, j - 2)] + dp[max(0, i - 1)][max(0, j - 3)]) / 4
        return dp[n][n]
```

```cpp
class Solution {
public:
    double soupServings(int n) {
        n = ceil((double) n / 25);
        if (n >= 179) {
            return 1.0;
        }
        vector<vector<double>> dp(n + 1, vector<double>(n + 1));
        dp[0][0] = 0.5;
        for (int i = 1; i <= n; i++) {
            dp[0][i] = 1.0;
        }
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                dp[i][j] = (dp[max(0, i - 4)][j] + dp[max(0, i - 3)][max(0, j - 1)] +
                           dp[max(0, i - 2)][max(0, j - 2)] + dp[max(0, i - 1)][max(0, j - 3)]) / 4.0;
            }
        }
        return dp[n][n];
    }
};
```

```java
class Solution {
    public double soupServings(int n) {
        n = (int) Math.ceil((double) n / 25);
        if (n >= 179) {
            return 1.0;
        }
        double[][] dp = new double[n + 1][n + 1];
        dp[0][0] = 0.5;
        for (int i = 1; i <= n; i++) {
            dp[0][i] = 1.0;
        }
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                dp[i][j] = (dp[Math.max(0, i - 4)][j] + dp[Math.max(0, i - 3)][Math.max(0, j - 1)] + dp[Math.max(0, i - 2)][Math.max(0, j - 2)] + dp[Math.max(0, i - 1)][Math.max(0, j - 3)]) / 4.0;
            }
        }
        return dp[n][n];
    }
}
```

```c#
public class Solution {
    public double SoupServings(int n) {
        n = (int) Math.Ceiling((double) n / 25);
        if (n >= 179) {
            return 1.0;
        }
        double[][] dp = new double[n + 1][];
        for (int i = 0; i <= n; i++) {
            dp[i] = new double[n + 1];
        }
        dp[0][0] = 0.5;
        for (int i = 1; i <= n; i++) {
            dp[0][i] = 1.0;
        }
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                dp[i][j] = (dp[Math.Max(0, i - 4)][j] + dp[Math.Max(0, i - 3)][Math.Max(0, j - 1)] + dp[Math.Max(0, i - 2)][Math.Max(0, j - 2)] + dp[Math.Max(0, i - 1)][Math.Max(0, j - 3)]) / 4.0;
            }
        }
        return dp[n][n];
    }
}
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

double soupServings(int n) {
     n = n = ceil((double) n / 25);
    if (n >= 179) {
        return 1.0;
    }
    double dp[n + 1][n + 1];
    dp[0][0] = 0.5;
    for (int i = 1; i <= n; i++) {
        dp[0][i] = 1.0;
        dp[i][0] = 0.0;
    }
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= n; j++) {
            dp[i][j] = (dp[MAX(0, i - 4)][j] + dp[MAX(0, i - 3)][MAX(0, j - 1)] + \
                        dp[MAX(0, i - 2)][MAX(0, j - 2)] + dp[MAX(0, i - 1)][MAX(0, j - 3)]) / 4.0;
        }
    }
    return dp[n][n];
}
```

```javascript
var soupServings = function(n) {
    n = Math.ceil(n / 25);
    if (n >= 179) {
        return 1.0;
    }
    const dp = new Array(n + 1).fill(0).map(() => new Array(n + 1).fill(0));
    dp[0][0] = 0.5;
    for (let i = 1; i <= n; i++) {
        dp[0][i] = 1.0;
    }
    for (let i = 1; i <= n; i++) {
        for (let j = 1; j <= n; j++) {
            dp[i][j] = (dp[Math.max(0, i - 4)][j] + dp[Math.max(0, i - 3)][Math.max(0, j - 1)] + dp[Math.max(0, i - 2)][Math.max(0, j - 2)] + dp[Math.max(0, i - 1)][Math.max(0, j - 3)]) / 4.0;
        }
    }
    return dp[n][n];
};
```

```go
func soupServings(n int) float64 {
    n = (n + 24) / 25
    if n >= 179 {
        return 1
    }
    dp := make([][]float64, n+1)
    for i := range dp {
        dp[i] = make([]float64, n+1)
    }
    dp[0][0] = 0.5
    for i := 1; i <= n; i++ {
        dp[0][i] = 1
    }
    for i := 1; i <= n; i++ {
        for j := 1; j <= n; j++ {
            dp[i][j] = (dp[max(0, i-4)][j] + dp[max(0, i-3)][max(0, j-1)] +
                dp[max(0, i-2)][max(0, j-2)] + dp[max(0, i-1)][max(0, j-3)]) / 4
        }
    }
    return dp[n][n]
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(C^2)$。因为存在常数 C，在这里我们可以取 C = 192，使得当 n > C 时，所求的概率和 1 的误差在 $10^{-5}$ 以内，我们可以直接返回，需要的时间为 O(1)；当 $n \le C$ 时，我们需要的时间复杂度为 $O(n^2)$，因此总的时间复杂度为 $O(C^2)$。
-   空间复杂度：$O(C^2)$。因为存在常数 C，在这里我们可以取 C = 192，使得当 n > C 时，所求的概率和 1 的误差在 $10^{-5}$ 以内，我们可以直接返回，需要的空间为 O(1)；当 $n \le C$ 时，我们需要的空间为 $O(n^2)$，因此总的空间复杂度为 $O(C^2)$。
