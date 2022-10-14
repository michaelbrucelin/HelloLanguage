#### [](https://leetcode.cn/problems/distinct-subsequences-ii/solution/bu-tong-de-zi-xu-lie-ii-by-leetcode-solu-k2h5//#�������������Ż��Ķ�̬�滮)�������������Ż��Ķ�̬�滮

**˼·���㷨**

�۲췽�����е�״̬ת�Ʒ��̣�

$g[o_i] = 1 + \sum\_{0 \leq k < 26} g[k]$

�������ǵĴ������� g �ĺͣ������� s[i] ��ֻ�� $g[o_i]$ ��ֵ�����˱仯��������ǿ���ʹ��һ������ total ֱ��ά������ g �ĺͣ�ÿ�ν� $g[o_i]$ ��ֵ����Ϊ 1+total���ٽ� total ��ֵ���� $g[o_i]$ �ı仯�����ɡ�

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n+�O���O)������ n ���ַ��� s �ĳ��ȣ��� ���ַ������ڱ����� �O���O=26����ʼ����Ҫ��ʱ��Ϊ O(�O���O)����̬�滮��Ҫ��ʱ���Ϊ O(n)��
-   �ռ临�Ӷȣ�O(�O���O)����Ϊ���� g ��Ҫ�Ŀռ䡣
