#### [](https://leetcode.cn/problems/distinct-subsequences-ii/solution/bu-tong-de-zi-xu-lie-ii-by-leetcode-solu-k2h5//#方法二：优化的动态规划)方法二：优化的动态规划

**思路与算法**

观察方法一中的状态转移方程：

$f[i] = 1 + \sum_{0 \leq k<26, last[k] \neq -1} f[last[k]]$

我们可以考虑使用一个长度为 ∣Σ∣=26 的数组 g 来进行动态规划，其中 g[k] 就表示上述状态转移方程中的 f[last[k]]。记 $o_i$ 表示 s[i] 是第 $o_i$ 个字母，我们可以在遍历到 s[i] 时，更新 $g[o_i]$ 的值为：

$g[o_i] = 1 + \sum_{0 \leq k < 26} g[k]$

即可。当 last[k]=−1 时我们无需进行转移，那么只要将数组 g 的初始值设为 0，在累加时就可以达到相同的效果。

**代码**

```C++
class Solution {
public:
    int distinctSubseqII(string s) {
        vector<int> g(26, 0);
        int n = s.size();
        for (int i = 0; i < n; ++i) {
            int total = 1;
            for (int j = 0; j < 26; ++j) {
                total = (total + g[j]) % mod;
            }
            g[s[i] - 'a'] = total;
        }
        
        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            ans = (ans + g[i]) % mod;
        }
        return ans;
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
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            int total = 1;
            for (int j = 0; j < 26; ++j) {
                total = (total + g[j]) % MOD;
            }
            g[s.charAt(i) - 'a'] = total;
        }

        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            ans = (ans + g[i]) % MOD;
        }
        return ans;
    }
}

```

```C#
public class Solution {
    public int DistinctSubseqII(string s) {
        const int MOD = 1000000007;
        int[] g = new int[26];
        int n = s.Length;
        for (int i = 0; i < n; ++i) {
            int total = 1;
            for (int j = 0; j < 26; ++j) {
                total = (total + g[j]) % MOD;
            }
            g[s[i] - 'a'] = total;
        }

        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            ans = (ans + g[i]) % MOD;
        }
        return ans;
    }
}

```

```Python
class Solution:
    def distinctSubseqII(self, s: str) -> int:
        mod = 10**9 + 7

        g = [0] * 26
        for i, ch in enumerate(s):
            total = (1 + sum(g)) % mod
            g[ord(s[i]) - ord("a")] = total
        
        return sum(g) % mod

```

```C
const int mod = 1e9 + 7;

int distinctSubseqII(char * s) {
    int n = strlen(s);
    int g[26];
    memset(g, 0, sizeof(g));
    for (int i = 0; i < n; ++i) {
        int total = 1;
        for (int j = 0; j < 26; ++j) {
            total = (total + g[j]) % mod;
        }
        g[s[i] - 'a'] = total;
    }
    
    int ans = 0;
    for (int i = 0; i < 26; ++i) {
        ans = (ans + g[i]) % mod;
    }
    return ans;
}

```

```JavaScript
var distinctSubseqII = function(s) {
    const MOD = 1000000007;
    const g = new Array(26).fill(0);
    const n = s.length;
    for (let i = 0; i < n; ++i) {
        let total = 1;
        for (let j = 0; j < 26; ++j) {
            total = (total + g[j]) % MOD;
        }
        g[s[i].charCodeAt() - 'a'.charCodeAt()] = total;
    }

    let ans = 0;
    for (let i = 0; i < 26; ++i) {
        ans = (ans + g[i]) % MOD;
    }
    return ans;
};

```

```Go
func distinctSubseqII(s string) (ans int) {
    const mod int = 1e9 + 7
    g := make([]int, 26)
    for _, c := range s {
        total := 1
        for _, v := range g {
            total = (total + v) % mod
        }
        g[c-'a'] = total
    }
    for _, v := range g {
        ans = (ans + v) % mod
    }
    return
}

```

**复杂度分析**

-   时间复杂度：O(n∣Σ∣)，其中 n 是字符串 s 的长度，Σ 是字符集，在本题中 ∣Σ∣=26。即为动态规划需要的时间。
-   空间复杂度：O(∣Σ∣)。即为数组 g 和 last 需要的空间。
