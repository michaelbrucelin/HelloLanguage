#### [方法二：记忆化搜索](https://leetcode.cn/problems/soup-servings/solutions/1981704/fen-tang-by-leetcode-solution-0yxs/)

**思路与算法**

同样动态规划的解题思路我们还可以采用自顶向下的记忆化搜索的方法来实现，与自底向上的动态规划相比记忆化搜索会减少许多无效状态的计算。

**代码**

```python
class Solution:
    def soupServings(self, n: int) -> float:
        n = (n + 24) // 25
        if n >= 179:
            return 1.0
        @cache
        def dfs(a: int, b: int) -> float:
            if a <= 0 and b <= 0:
                return 0.5
            if a <= 0:
                return 1.0
            if b <= 0:
                return 0.0
            return (dfs(a - 4, b) + dfs(a - 3, b - 1) +
                    dfs(a - 2, b - 2) + dfs(a - 1, b - 3)) / 4
        return dfs(n, n)
```

```cpp
class Solution {
public:
    double soupServings(int n) {
        n = ceil((double) n / 25);
        if (n >= 179) {
            return 1.0;
        }
        memo = vector<vector<double>>(n + 1, vector<double>(n + 1));
        return dfs(n, n);
    }

    double dfs(int a, int b) {
        if (a <= 0 && b <= 0) {
            return 0.5;
        } else if (a <= 0) {
            return 1;
        } else if (b <= 0) {
            return 0;
        }
        if (memo[a][b] > 0) {
            return memo[a][b];
        }
        memo[a][b] = 0.25 * (dfs(a - 4, b) + dfs(a - 3, b - 1) + 
                             dfs(a - 2, b - 2) + dfs(a - 1, b - 3));
        return memo[a][b];
    }
private:
    vector<vector<double>> memo;
};
```

```java
class Solution {
    private double[][] memo;

    public double soupServings(int n) {
        n = (int) Math.ceil((double) n / 25);
        if (n >= 179) {
            return 1.0;
        }
        memo = new double[n + 1][n + 1];
        return dfs(n, n);
    }

    public double dfs(int a, int b) {
        if (a <= 0 && b <= 0) {
            return 0.5;
        } else if (a <= 0) {
            return 1;
        } else if (b <= 0) {
            return 0;
        }
        if (memo[a][b] == 0) {
            memo[a][b] = 0.25 * (dfs(a - 4, b) + dfs(a - 3, b - 1) + dfs(a - 2, b - 2) + dfs(a - 1, b - 3));
        }
        return memo[a][b];
    }
}
```

```c#
public class Solution {
    private double[][] memo;

    public double SoupServings(int n) {
        n = (int) Math.Ceiling((double) n / 25);
        if (n >= 179) {
            return 1.0;
        }
        memo = new double[n + 1][];
        for (int i = 0; i <= n; i++) {
            memo[i] = new double[n + 1];
        }
        return DFS(n, n);
    }

    public double DFS(int a, int b) {
        if (a <= 0 && b <= 0) {
            return 0.5;
        } else if (a <= 0) {
            return 1;
        } else if (b <= 0) {
            return 0;
        }
        if (memo[a][b] == 0) {
            memo[a][b] = 0.25 * (DFS(a - 4, b) + DFS(a - 3, b - 1) + DFS(a - 2, b - 2) + DFS(a - 1, b - 3));
        }
        return memo[a][b];
    }
}
```

```c
double dfs(int a, int b, double **memo) {
    if (a <= 0 && b <= 0) {
        return 0.5;
    } else if (a <= 0) {
        return 1;
    } else if (b <= 0) {
        return 0;
    }
    if (memo[a][b] > 0) {
        return memo[a][b];
    }
    memo[a][b] = 0.25 * (dfs(a - 4, b, memo) + dfs(a - 3, b - 1, memo) + \
                         dfs(a - 2, b - 2, memo) + dfs(a - 1, b - 3, memo));
    return memo[a][b];
}

double soupServings(int n){
    n = ceil((double) n / 25);
    if (n >= 179) {
        return 1.0;
    }
    double **memo = (double **)malloc(sizeof(double *) * (n + 1));
    for (int i = 0; i <= n; i++) {
        memo[i] = (double *)malloc(sizeof(double) * (n + 1));
        memset(memo[i], 0, sizeof(double) * (n + 1));
    }
    double ret = dfs(n, n, memo);
    for (int i = 0; i <= n; i++) {
        free(memo[i]);
    }
    free(memo);
    return ret;
}
```

```javascript
var soupServings = function(n) {
    n = Math.ceil(n / 25);
    if (n >= 179) {
        return 1.0;
    }
    const memo = new Array(n + 1).fill(0).map(() => new Array(n + 1).fill(0));
    const dfs = (a, b) => {
        if (a <= 0 && b <= 0) {
            return 0.5;
        } else if (a <= 0) {
            return 1;
        } else if (b <= 0) {
            return 0;
        }
        if (memo[a][b] === 0) {
            memo[a][b] = 0.25 * (dfs(a - 4, b) + dfs(a - 3, b - 1) + dfs(a - 2, b - 2) + dfs(a - 1, b - 3));
        }
        return memo[a][b];
    };
    return dfs(n, n);
}
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
    var dfs func(int, int) float64
    dfs = func(a, b int) float64 {
        if a <= 0 && b <= 0 {
            return 0.5
        }
        if a <= 0 {
            return 1
        }
        if b <= 0 {
            return 0
        }
        dv := &dp[a][b]
        if *dv > 0 {
            return *dv
        }
        res := (dfs(a-4, b) + dfs(a-3, b-1) +
            dfs(a-2, b-2) + dfs(a-1, b-3)) / 4
        *dv = res
        return res
    }
    return dfs(n, n)
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(C^2)$。因为存在常数 C，在这里我们可以取 C = 192，使得当 $n > C$ 时，所求的概率和 1 的误差在 $10^{-5}$ 以内，我们可以直接返回，需要的时间为 O(1)；当 $n \le C$ 时，我们需要的时间复杂度为 $O(n^2)$，因此总的时间复杂度为 $O(C^2)$。
-   空间复杂度：$O(C^2)$。因为存在常数 C，在这里我们可以取 C = 192，使得当 $n > C$ 时，所求的概率和 1 的误差在 $10^{-5}$ 以内，我们可以直接返回，需要的空间为 O(1)；当 $n \le C$ 时，我们需要的空间为 $O(n^2)$，因此总的空间复杂度为 $O(C^2)$。
