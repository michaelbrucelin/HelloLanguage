#### [](https://leetcode.cn/problems/k-similar-strings/solution/xiang-si-du-wei-k-de-zi-fu-chuan-by-leet-8z10//#方法二：深度优先搜索)方法二：深度优先搜索

与方法一同样的交换思路，我们也可以采用深度优先搜索来实现，每次遇到不同的字符 s1[i]≠s2[i] 时，则从 s1[i+1,⋯ ] 中选择处于不同位置的字符 s1[j]=s2[i]，将其与 s1[i] 进行交换，然后保持当前子状态，搜索下一个位置 i+1，直到所有字符串 s1 全部与 s2 匹配完成；当前子状态搜索完成后，然后恢复字符串，继续搜索下一个与 s2[i] 相等的字符，并进行替换即可。在进行深度优先搜索时，由于每个搜索时每个子树的状态都是不同的，所以也可以不用哈希表去重，但是可以用一些特殊的减枝技巧。我们可以得到相似字符串交换次数的上限与下限：

-   对于长度为 n 的两个相似的字符串 s1,s2，s1 最多需要 n−1 次交换变为 s2，因为每进行一次有效交换时，我们可以将 s1 的中的一个字符调整到与 s2 相同，我们只需要将 s1 的前 n−1 个字符调整到与 s2 的前 n−1 个字符相同，则 s1 的第 n 个字符此时也一定与 s2 的第 n 个字符相同，因此我们最多需要 n−1 次交换，即可使得 s1,s2 相等。

-   对于长度为 n 的两个相似的字符串 s1,s2，且对于字符串中任意位置的字符均满足 s1[i]≠s2[i]。我们可以观察到此时 s1 最少需要 $floor(\frac{n+1}{2})$ 次交换变为 s2。每进行一次有效交换时，我们最多可以将 s1 的中的两个字符调整到与 s2 相同。比如当满足 s1[i]=s2[j],s1[j]=s2[i]，此时我们交换位置 (i,j)，可以将两个字符调整到正确的位置，我们分两种情况进行讨论：

    -   当 n 为偶数时，由于每次交换时最多可以将两个字符同时移动到正确的位置，因此最少需要 $\frac{n}{2}$ 次交换可以使得 s1 与 s2 相等。
    -   当 n 为奇数数时，每次交换时最多可以将两个字符同时移动到正确的位置，当最终剩下 3 个字符时，此时我们再交换一次时无法交换两个字符到正确的位置。根据前置条件所有位置的字符均满足 s1[i]≠s2[i]，假设此时还剩余 3 个字符满足 s1[i]≠s2[i],s1[j]≠s2[j],s1[k]≠s2[k] 时，则此时任意交换一次两个字符使得 s1[i]=s2[i],s1[j]=s2[j]，还剩余一个字符 s1[k],s2[k] 不相等，这与两个字符串相似矛盾，因此还需 2 次交换才能使得 s1,s2 中剩余的 3 个字符相等。因此当 n 为奇数时，最少需要 $\frac{n+1}{2}$ 次交换可以使得 s1 与 s2 相等。

根据以上结论，我们可以进行如下减枝:

-   我们只需要计算两个字符 s1,s2 中同一位置不同的字符的交换次数即可，同一位置相同的字符直接可以跳过。
-   根据之前的结论，假设当前已经通过计算得到的最少交换次数为 ans，假设当前字符字符串 s1 已经过 cost 次交换变为了 s1′，此时我们计算出字符串 s1′ 变为 s2 还需要进行交换次数的下限为 minSwap(s1′)，则字符串 s1 经过交换变为中间状态 s1′，然后交换变为 s2 所需的交换次数的下限为 cur=cost+minSwap(s1′)，如果当前最少交换次数下限满足 cur≥ans 时，则表明当前的字符串 s1′ 已经不是更优的搜索状态，可直接提前终止搜索。

```Python
class Solution:
    def kSimilarity(self, s1: str, s2: str) -> int:
        s, t = [], []
        for x, y in zip(s1, s2):
            if x != y:
                s.append(x)
                t.append(y)
        n = len(s)
        if n == 0:
            return 0

        ans = n - 1
        def dfs(i: int, cost: int) -> None:
            nonlocal ans
            if cost > ans:
                return
            while i < n and s[i] == t[i]:
                i += 1
            if i == n:
                ans = min(ans, cost)
                return
            diff = sum(s[j] != t[j] for j in range(i, len(s)))
            min_swap = (diff + 1) // 2
            if cost + min_swap >= ans:  # 当前状态的交换次数下限大于等于当前的最小交换次数
                return
            for j in range(i + 1, n):
                if s[j] == t[i]:
                    s[i], s[j] = s[j], s[i]
                    dfs(i + 1, cost + 1)
                    s[i], s[j] = s[j], s[i]
        dfs(0, 0)
        return ans

```

```C++
class Solution {
public:
    int minSwap(const string &s1, const string &s2, const int &pos) {
        int tot = 0;
        for (int i = pos; i < s1.size(); i++) {
            tot += s1[i] != s2[i];
        }
        return (tot + 1) / 2;
    }

    int kSimilarity(string s1, string s2) {
        string str1, str2;
        for (int i = 0; i < s1.size(); i++) {
            if (s1[i] != s2[i]) {
                str1.push_back(s1[i]);
                str2.push_back(s2[i]);
            }
        }
        int n = str1.size();
        if (n == 0) {
            return 0;
        }

        int ans = n - 1;
        function<void(int, int)> dfs = [&](int pos, int cost) {
            if (cost > ans) {
                return;
            }
            while (pos < n && str1[pos] == str2[pos]) {
                pos++;
            }
            if (pos == n) {
                ans = min(ans, cost);
                return;
            }
            /* 当前状态的交换次数下限大于等于当前的最小交换次数 */
            if (cost + minSwap(str1, str2, pos) >= ans) {
                return;
            }
            for (int i = pos + 1; i < n; i++) {
                if (str1[i] == str2[pos]) {
                    swap(str1[i], str1[pos]);
                    dfs(pos + 1, cost + 1);
                    swap(str1[i], str1[pos]);
                }
            }
        };
        dfs(0, 0);
        return ans;
    }
};

```

```Java
class Solution {
    int ans;

    public int kSimilarity(String s1, String s2) {
        StringBuilder str1 = new StringBuilder();
        StringBuilder str2 = new StringBuilder();
        for (int i = 0; i < s1.length(); i++) {
            if (s1.charAt(i) != s2.charAt(i)) {
                str1.append(s1.charAt(i));
                str2.append(s2.charAt(i));
            }
        }
        if (str1.length() == 0) {
            return 0;
        }
        ans = str1.length() - 1;
        dfs(0, 0, str1.length(), str1.toString(), str2.toString());
        return ans;
    }

    public void dfs(int pos, int cost, int len, String str1, String str2) {
        if (cost > ans) {
            return;
        }
        while (pos < str1.length() && str1.charAt(pos) == str2.charAt(pos)) {
            pos++;
        }
        if (pos == str1.length()) {
            ans = Math.min(ans, cost);
            return;
        }  
        /* 当前状态的交换次数下限大于等于当前的最小交换次数 */      
        if (cost + minSwap(str1, str2, pos) >= ans) {
            return;
        }
        for (int i = pos + 1; i < str1.length(); i++) {
            if (str1.charAt(i) == str2.charAt(pos)) {
                String str1Next = swap(str1, i, pos);
                dfs(pos + 1, cost + 1, len, str1Next, str2);
            }
        }
    }

    public int minSwap(String s1, String s2, int pos) {
        int tot = 0;
        for (int i = pos; i < s1.length(); i++) {
            tot += s1.charAt(i) != s2.charAt(i) ? 1 : 0;
        }
        return (tot + 1) / 2;
    }

    public String swap(String cur, int i, int j) {
        char[] arr = cur.toCharArray();
        char c = arr[i];
        arr[i] = arr[j];
        arr[j] = c;
        return new String(arr);
    }
}

```

```C#
public class Solution {
    int ans;

    public int KSimilarity(string s1, string s2) {
        StringBuilder str1 = new StringBuilder();
        StringBuilder str2 = new StringBuilder();
        for (int i = 0; i < s1.Length; i++) {
            if (s1[i] != s2[i]) {
                str1.Append(s1[i]);
                str2.Append(s2[i]);
            }
        }
        if (str1.Length == 0) {
            return 0;
        }
        ans = str1.Length - 1;
        DFS(0, 0, str1.Length, str1.ToString(), str2.ToString());
        return ans;
    }

    public void DFS(int pos, int cost, int len, string str1, string str2) {
        if (cost > ans) {
            return;
        }
        while (pos < str1.Length && str1[pos] == str2[pos]) {
            pos++;
        }
        if (pos == str1.Length) {
            ans = Math.Min(ans, cost);
            return;
        }  
        /* 当前状态的交换次数下限大于等于当前的最小交换次数 */      
        if (cost + MinSwap(str1, str2, pos) >= ans) {
            return;
        }
        for (int i = pos + 1; i < str1.Length; i++) {
            if (str1[i] == str2[pos]) {
                string str1Next = Swap(str1, i, pos);
                DFS(pos + 1, cost + 1, len, str1Next, str2);
            }
        }
    }

    public int MinSwap(string s1, string s2, int pos) {
        int tot = 0;
        for (int i = pos; i < s1.Length; i++) {
            tot += s1[i] != s2[i] ? 1 : 0;
        }
        return (tot + 1) / 2;
    }

    public string Swap(string cur, int i, int j) {
        char[] arr = cur.ToCharArray();
        char c = arr[i];
        arr[i] = arr[j];
        arr[j] = c;
        return new string(arr);
    }
}

```

```C
#define MAX_STR_LEN 24
#define MIN(a, b) ((a) < (b) ? (a) : (b))

static inline void swap(char *pa, char *pb) {
    char c = *pa;
    *pa = *pb;
    *pb = c;
}

int minSwap(const char *s1, const char *s2, int pos) {
    int tot = 0;
    for (int i = pos; s1[i]; i++) {
        tot += s1[i] != s2[i];
    }
    return (tot + 1) / 2;
}

void dfs(int pos, int cost, int len, char* str1, const char *str2, int *res) {
    if (cost > *res) {
        return;
    }
    while (pos < len && str1[pos] == str2[pos]) {
        pos++;
    }
    if (pos == len) {
        *res = MIN(*res, cost);
        return;
    }
    /* 当前状态的交换次数下限大于等于当前的最小交换次数 */ 
    if (cost + minSwap(str1, str2, pos) >= *res) {
        return;
    }
    for (int i = pos + 1; i < len; i++) {
        if (str1[i] == str2[pos]) {
            swap(&str1[i], &str1[pos]);
            dfs(pos + 1, cost + 1, len, str1, str2, res);
            swap(&str1[i], &str1[pos]);
        }
    }
};

int kSimilarity(char * s1, char * s2) {
    char str1[MAX_STR_LEN], str2[MAX_STR_LEN];
    int pos = 0, len = strlen(s1);
    for (int i = 0; i < len; i++) {
        if (s1[i] != s2[i]) {
            str1[pos] = s1[i];
            str2[pos] = s2[i];
            pos++;
        }
    }
    str1[pos] = '\0';
    str2[pos] = '\0';
    if (pos == 0) {
        return 0;
    }
    int res = pos - 1;
    dfs(0, 0, pos, str1, str2, &res);
    return res;
}

```

```JavaScript
var kSimilarity = function(s1, s2) {
    let str1 = '';
    let str2 = '';
    for (let i = 0; i < s1.length; i++) {
        if (s1[i] !== s2[i]) {
            str1 += s1[i];
            str2 += s2[i];
        }
    }
    if (str1.length === 0) {
        return 0;
    }
    let ans = str1.length - 1;

    const dfs = (pos, cost, len, str1, str2) => {
        if (cost > ans) {
            return;
        }
        while (pos < str1.length && str1[pos] === str2[pos]) {
            pos++;
        }
        if (pos === str1.length) {
            ans = Math.min(ans, cost);
            return;
        }  
        /* 当前状态的交换次数下限大于等于当前的最小交换次数 */      
        if (cost + minSwap(str1, str2, pos) >= ans) {
            return;
        }
        for (let i = pos + 1; i < str1.length; i++) {
            if (str1[i] === str2[pos]) {
                const str1Next = swap(str1, i, pos);
                dfs(pos + 1, cost + 1, len, str1Next, str2);
            }
        }
    }

    const minSwap = (s1, s2, pos) => {
        let tot = 0;
        for (let i = pos; i < s1.length; i++) {
            tot += s1[i] !== s2[i] ? 1 : 0;
        }
        return Math.floor((tot + 1) / 2);
    }

    const swap = (cur, i, j) => {
        const arr = [...cur];
        const c = arr[i];
        arr[i] = arr[j];
        arr[j] = c;
        return arr.join('');
    }
    
    dfs(0, 0, str1.length, str1, str2);
    return ans;
}

```

```Go
func kSimilarity(s1, s2 string) int {
    var s, t []byte
    for i := range s1 {
        if s1[i] != s2[i] {
            s = append(s, s1[i])
            t = append(t, s2[i])
        }
    }
    n := len(s)
    if n == 0 {
        return 0
    }

    minSwap := func(i int) int {
        diff := 0
        for j := i; j < n; j++ {
            if s[j] != t[j] {
                diff++
            }
        }
        return (diff + 1) / 2
    }

    ans := n - 1
    var dfs func(int, int)
    dfs = func(i, cost int) {
        if cost > ans {
            return
        }
        for i < n && s[i] == t[i] {
            i++
        }
        if i == n {
            ans = min(ans, cost)
            return
        }
        // 当前状态的交换次数下限大于等于当前的最小交换次数
        if cost+minSwap(i) >= ans {
            return
        }
        for j := i + 1; j < n; j++ {
            if s[j] == t[i] {
                s[i], s[j] = s[j], s[i]
                dfs(i+1, cost+1)
                s[i], s[j] = s[j], s[i]
            }
        }
    }
    dfs(0, 0)
    return ans
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

```

**复杂度分析**

该方法时空复杂度分析较为复杂，暂不讨论。
