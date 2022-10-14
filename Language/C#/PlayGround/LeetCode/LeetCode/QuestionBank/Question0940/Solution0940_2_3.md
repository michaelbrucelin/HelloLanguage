#### [](https://leetcode.cn/problems/distinct-subsequences-ii/solution/bu-tong-de-zi-xu-lie-ii-by-leetcode-solu-k2h5//#方法三：继续优化的动态规划)方法三：继续优化的动态规划

**思路与算法**

观察方法二中的状态转移方程：

$g[o_i] = 1 + \sum\_{0 \leq k < 26} g[k]$

由于我们的答案是数组 g 的和，而遍历 s[i] 后只有 $g[o_i]$ 的值发生了变化。因此我们可以使用一个变量 total 直接维护数组 g 的和，每次将 $g[o_i]$ 的值更新为 1+total，再将 total 的值增加 $g[o_i]$ 的变化量即可。

**代码**

```C++
class Solution {
public:
    int distinctSubseqII(string s) {
        vector<int> g(26, 0);
        int n = s.size(), total = 0;
        for (int i = 0; i < n; ++i) {
            int oi = s[i] - 'a';
            int prev = g[oi];
            g[oi] = (total + 1) % mod;
            total = ((total + g[oi] - prev) % mod + mod) % mod;
        }
        return total;
    }

private:
    static constexpr int mod = 1000000007;
};

```

```Java
class Solution {
    public int distinctSubseqII(String s) {
        final int MOD = 1000000007;
        int[] g = new int[26];
        int n = s.length(), total = 0;
        for (int i = 0; i < n; ++i) {
            int oi = s.charAt(i) - 'a';
            int prev = g[oi];
            g[oi] = (total + 1) % MOD;
            total = ((total + g[oi] - prev) % MOD + MOD) % MOD;
        }
        return total;
    }
}

```

```C#
public class Solution {
    public int DistinctSubseqII(string s) {
        const int MOD = 1000000007;
        int[] g = new int[26];
        int n = s.Length, total = 0;
        for (int i = 0; i < n; ++i) {
            int oi = s[i] - 'a';
            int prev = g[oi];
            g[oi] = (total + 1) % MOD;
            total = ((total + g[oi] - prev) % MOD + MOD) % MOD;
        }
        return total;
    }
}

```

```Python
class Solution:
    def distinctSubseqII(self, s: str) -> int:
        mod = 10**9 + 7

        g = [0] * 26
        total = 0
        for i, ch in enumerate(s):
            oi = ord(s[i]) - ord("a")
            g[oi], total = (total + 1) % mod, (total * 2 + 1 - g[oi]) % mod
        
        return total

```

```C
const int mod = 1e9 + 7;

int distinctSubseqII(char * s) {
    int g[26];
    memset(g, 0, sizeof(g));
    int n = strlen(s), total = 0;
    for (int i = 0; i < n; ++i) {
        int oi = s[i] - 'a';
        int prev = g[oi];
        g[oi] = (total + 1) % mod;
        total = ((total + g[oi] - prev) % mod + mod) % mod;
    }
    return total;
}

```

```JavaScript
var distinctSubseqII = function(s) {
    const MOD = 1000000007;
    const g = new Array(26).fill(0);
    let n = s.length, total = 0;
    for (let i = 0; i < n; ++i) {
        let oi = s[i].charCodeAt() - 'a'.charCodeAt();
        let prev = g[oi];
        g[oi] = (total + 1) % MOD;
        total = ((total + g[oi] - prev) % MOD + MOD) % MOD;
    }
    return total;
};

```

```Go
func distinctSubseqII(s string) (total int) {
    const mod int = 1e9 + 7
    g := make([]int, 26)
    for _, c := range s {
        oi := c - 'a'
        prev := g[oi]
        g[oi] = (total + 1) % mod
        total = ((total+g[oi]-prev)%mod + mod) % mod
    }
    return
}

```

**复杂度分析**

-   时间复杂度：O(n+∣Σ∣)。其中 n 是字符串 s 的长度，Σ 是字符集，在本题中 ∣Σ∣=26。初始化需要的时间为 O(∣Σ∣)，动态规划需要的时间的为 O(n)。
-   空间复杂度：O(∣Σ∣)。即为数组 g 需要的空间。
