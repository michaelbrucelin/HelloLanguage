#### [](https://leetcode.cn/problems/distinct-subsequences-ii/solution/bu-tong-de-zi-xu-lie-ii-by-leetcode-solu-k2h5//#方法一：动态规划)方法一：动态规划

**思路与算法**

我们用 f[i] 表示以 s[i] 为最后一个字符的子序列的数目。

-   如果子序列中只有 s[i] 这一个字符，那么有一种方案；

-   如果子序列中至少有两个字符，那么我们可以枚举倒数第二个字符来进行状态转移。容易想到的是：倒数第二个字符可以选择 s[0],s[1],⋯ ,s[i−1] 中的某一个，这样就可以得到如下的状态转移方程：

    f[i]=f[0]+f[1]+⋯f[i−1]

    然而这样做会产生重复计数。如果 s[j0] 和 s[j1] 这两个字符不相同，那么 f[j0] 和 f[j1] 对应的子序列是两个不相交的集合；但如果 s[j0] 和 s[j1] 这两个字符相同，那么 f[j0] 和 f[j1] 对应的子序列会包含重复的项。最简单的一个重复项就是只含有一个字符的子序列 s[j0] 或者 s[j1] 本身。

    那么我们该如何防止重复计数呢？可以发现，如果 j0<j1，那么 f[j0] 一定是 f[j1]] 的一个真子集。这是因为：

    > 每一个以 s[j0] 为最后一个字符的子序列，都可以把这个字符改成完全相同的 s[j1]，计入到 f[j1] 中。

    因此，对于每一种字符，我们只需要找到其最后一次出现的位置（并且在位置 i 之前），并将对应的 f 值累加进 f[i] 即可。由于本题中字符串只包含小写字母，我们可以用 last[k] 记录第 k (0≤k<26) 个小写字母最后一次出现的位置。如果它还没有出现过，那么 last[k]=−1。这样我们就可以写出正确的状态转移方程：

    $f[i] = \sum_{0 \leq k<26, last[k] \neq -1} f[last[k]]$

将这两种情况合并在一起，最终的状态转移方程即为：

$f[i] = 1 + \sum_{0 \leq k<26, last[k] \neq -1} f[last[k]]$

在计算完 f[i] 后，我们需要记得更新对应的 last 项。最终的答案即为：

$\sum_{0 \leq k<26, last[k] \neq -1} f[last[k]]$

**代码**

```C++
class Solution {
public:
    int distinctSubseqII(string s) {
        vector<int> last(26, -1);
        
        int n = s.size();
        vector<int> f(n, 1);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < 26; ++j) {
                if (last[j] != -1) {
                    f[i] = (f[i] + f[last[j]]) % mod;
                }
            }
            last[s[i] - 'a'] = i;
        }
        
        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            if (last[i] != -1) {
                ans = (ans + f[last[i]]) % mod;
            }
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
        int[] last = new int[26];
        Arrays.fill(last, -1);

        int n = s.length();
        int[] f = new int[n];
        Arrays.fill(f, 1);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < 26; ++j) {
                if (last[j] != -1) {
                    f[i] = (f[i] + f[last[j]]) % MOD;
                }
            }
            last[s.charAt(i) - 'a'] = i;
        }

        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            if (last[i] != -1) {
                ans = (ans + f[last[i]]) % MOD;
            }
        }
        return ans;
    }
}

```

```C#
public class Solution {
    public int DistinctSubseqII(string s) {
        const int MOD = 1000000007;
        int[] last = new int[26];
        Array.Fill(last, -1);

        int n = s.Length;
        int[] f = new int[n];
        Array.Fill(f, 1);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < 26; ++j) {
                if (last[j] != -1) {
                    f[i] = (f[i] + f[last[j]]) % MOD;
                }
            }
            last[s[i] - 'a'] = i;
        }

        int ans = 0;
        for (int i = 0; i < 26; ++i) {
            if (last[i] != -1) {
                ans = (ans + f[last[i]]) % MOD;
            }
        }
        return ans;
    }
}

```

```Python
class Solution:
    def distinctSubseqII(self, s: str) -> int:
        mod = 10**9 + 7
        last = [-1] * 26

        n = len(s)
        f = [1] * n
        for i, ch in enumerate(s):
            for j in range(26):
                if last[j] != -1:
                    f[i] = (f[i] + f[last[j]]) % mod
            last[ord(s[i]) - ord("a")] = i
        
        ans = 0
        for i in range(26):
            if last[i] != -1:
                ans = (ans + f[last[i]]) % mod
        return ans

```

```C
const int mod = 1e9 + 7;

int distinctSubseqII(char * s) {
    int n = strlen(s);
    int last[26], f[n];
    for (int i = 0; i < 26; i++) {
        last[i] = -1;
    }
    for (int i = 0; i < n; i++) {
        f[i] = 1;
    }
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < 26; ++j) {
            if (last[j] != -1) {
                f[i] = (f[i] + f[last[j]]) % mod;
            }
        }
        last[s[i] - 'a'] = i;
    }
    int ans = 0;
    for (int i = 0; i < 26; ++i) {
        if (last[i] != -1) {
            ans = (ans + f[last[i]]) % mod;
        }
    }
    return ans;
}

```

```JavaScript
var distinctSubseqII = function(s) {
    const MOD = 1000000007;
    const last = new Array(26).fill(-1);

    const n = s.length;
    const f = new Array(n).fill(1);
    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < 26; ++j) {
            if (last[j] !== -1) {
                f[i] = (f[i] + f[last[j]]) % MOD;
            }
        }
        last[s[i].charCodeAt() - 'a'.charCodeAt()] = i;
    }

    let ans = 0;
    for (let i = 0; i < 26; ++i) {
        if (last[i] !== -1) {
            ans = (ans + f[last[i]]) % MOD;
        }
    }
    return ans;
};

```

```Go
func distinctSubseqII(s string) (ans int) {
    const mod int = 1e9 + 7
    last := make([]int, 26)
    for i := range last {
        last[i] = -1
    }
    n := len(s)
    f := make([]int, n)
    for i := range f {
        f[i] = 1
    }
    for i, c := range s {
        for _, j := range last {
            if j != -1 {
                f[i] = (f[i] + f[j]) % mod
            }
        }
        last[c-'a'] = i
    }
    for _, i := range last {
        if i != -1 {
            ans = (ans + f[i]) % mod
        }
    }
    return
}

```

**复杂度分析**

-   时间复杂度：O(n∣Σ∣)，其中 n 是字符串 s 的长度，Σ 是字符集，在本题中 ∣Σ∣=26。即为动态规划需要的时间。
-   空间复杂度：O(n+∣Σ∣)。即为数组 f 和 last 需要的空间。
