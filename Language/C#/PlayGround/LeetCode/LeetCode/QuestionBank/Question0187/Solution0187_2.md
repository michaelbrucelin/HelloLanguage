#### 方法二：哈希表 + 滑动窗口 + 位运算

由于 sss 中只含有 444 种字符，我们可以将每个字符用 222 个比特表示，即：

- A 表示为二进制 `00`；
- C 表示为二进制 `01`；
- G 表示为二进制 `10`；
- T 表示为二进制 `11`。

如此一来，一个长为 10 的字符串就可以用 20 个比特表示，而一个 int 整数有 32 个比特，足够容纳该字符串，因此我们可以将 s 的每个长为 10 的子串用一个 int 整数表示（只用低 20 位）。

注意到上述字符串到整数的映射是一一映射，每个整数都对应着一个唯一的字符串，因此我们可以将方法一中的哈希表改为存储每个长为 10 的子串的整数表示。

如果我们对每个长为 10 的子串都单独计算其整数表示，那么时间复杂度仍然和方法一一样为 O(NL)。为了优化时间复杂度，我们可以用一个大小固定为 10 的滑动窗口来计算子串的整数表示。设当前滑动窗口对应的整数表示为 x，当我们要计算下一个子串时，就将滑动窗口向右移动一位，此时会有一个新的字符进入窗口，以及窗口最左边的字符离开窗口，这些操作对应的位运算，按计算顺序表示如下：

- 滑动窗口向右移动一位：`x = x << 2`，由于每个字符用 2 个比特表示，所以要左移 2 位；
- 一个新的字符 ch 进入窗口：`x = x | bin[ch]`，这里 bin[ch] 为字符 ch 的对应二进制；
- 窗口最左边的字符离开窗口：`x = x & ((1 << 20) - 1)`，由于我们只考虑 x 的低 20 位比特，需要将其余位置零，即与上 `(1 << 20) - 1`。

将这三步合并，就可以用 O(1) 的时间计算出下一个子串的整数表示，即 `x = ((x << 2) | bin[ch]) & ((1 << 20) - 1)`。

```Python3
L = 10
bin = {'A': 0, 'C': 1, 'G': 2, 'T': 3}

class Solution:
    def findRepeatedDnaSequences(self, s: str) -> List[str]:
        n = len(s)
        if n <= L:
            return []
        ans = []
        x = 0
        for ch in s[:L - 1]:
            x = (x << 2) | bin[ch]
        cnt = defaultdict(int)
        for i in range(n - L + 1):
            x = ((x << 2) | bin[s[i + L - 1]]) & ((1 << (L * 2)) - 1)
            cnt[x] += 1
            if cnt[x] == 2:
                ans.append(s[i : i + L])
        return ans

```

```C++
class Solution {
    const int L = 10;
    unordered_map<char, int> bin = {{'A', 0}, {'C', 1}, {'G', 2}, {'T', 3}};
public:
    vector<string> findRepeatedDnaSequences(string s) {
        vector<string> ans;
        int n = s.length();
        if (n <= L) {
            return ans;
        }
        int x = 0;
        for (int i = 0; i < L - 1; ++i) {
            x = (x << 2) | bin[s[i]];
        }
        unordered_map<int, int> cnt;
        for (int i = 0; i <= n - L; ++i) {
            x = ((x << 2) | bin[s[i + L - 1]]) & ((1 << (L * 2)) - 1);
            if (++cnt[x] == 2) {
                ans.push_back(s.substr(i, L));
            }
        }
        return ans;
    }
};

```

```Java
class Solution {
    static final int L = 10;
    Map<Character, Integer> bin = new HashMap<Character, Integer>() {{
        put('A', 0);
        put('C', 1);
        put('G', 2);
        put('T', 3);
    }};

    public List<String> findRepeatedDnaSequences(String s) {
        List<String> ans = new ArrayList<String>();
        int n = s.length();
        if (n <= L) {
            return ans;
        }
        int x = 0;
        for (int i = 0; i < L - 1; ++i) {
            x = (x << 2) | bin.get(s.charAt(i));
        }
        Map<Integer, Integer> cnt = new HashMap<Integer, Integer>();
        for (int i = 0; i <= n - L; ++i) {
            x = ((x << 2) | bin.get(s.charAt(i + L - 1))) & ((1 << (L * 2)) - 1);
            cnt.put(x, cnt.getOrDefault(x, 0) + 1);
            if (cnt.get(x) == 2) {
                ans.add(s.substring(i, i + L));
            }
        }
        return ans;
    }
}

```

```C#
public class Solution {
    const int L = 10;
    Dictionary<char, int> bin = new Dictionary<char, int> {
        {'A', 0}, {'C', 1}, {'G', 2}, {'T', 3}
    };

    public IList<string> FindRepeatedDnaSequences(string s) {
        IList<string> ans = new List<string>();
        int n = s.Length;
        if (n <= L) {
            return ans;
        }
        int x = 0;
        for (int i = 0; i < L - 1; ++i) {
            x = (x << 2) | bin[s[i]];
        }
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        for (int i = 0; i <= n - L; ++i) {
            x = ((x << 2) | bin[s[i + L - 1]]) & ((1 << (L * 2)) - 1);
            if (!cnt.ContainsKey(x)) {
                cnt.Add(x, 1);
            } else {
                ++cnt[x];
            }
            if (cnt[x] == 2) {
                ans.Add(s.Substring(i, L));
            }
        }
        return ans;
    }
}

```

```Golang
const L = 10
var bin = map[byte]int{'A': 0, 'C': 1, 'G': 2, 'T': 3}

func findRepeatedDnaSequences(s string) (ans []string) {
    n := len(s)
    if n <= L {
        return
    }
    x := 0
    for _, ch := range s[:L-1] {
        x = x<<2 | bin[byte(ch)]
    }
    cnt := map[int]int{}
    for i := 0; i <= n-L; i++ {
        x = (x<<2 | bin[s[i+L-1]]) & (1<<(L*2) - 1)
        cnt[x]++
        if cnt[x] == 2 {
            ans = append(ans, s[i:i+L])
        }
    }
    return ans
}

```

```JavaScript
var findRepeatedDnaSequences = function(s) {
    const L = 10;
    const bin = new Map();
    bin.set('A', 0);
    bin.set('C', 1);
    bin.set('G', 2);
    bin.set('T', 3);
    
    const ans = [];
    const n = s.length;
    if (n <= L) {
        return ans;
    }
    let x = 0;
    for (let i = 0; i < L - 1; ++i) {
        x = (x << 2) | bin.get(s[i]);
    }
    const cnt = new Map();
    for (let i = 0; i <= n - L; ++i) {
        x = ((x << 2) | bin.get(s[i + L - 1])) & ((1 << (L * 2)) - 1);
        cnt.set(x, (cnt.get(x) || 0) + 1);
        if (cnt.get(x) === 2) {
            ans.push(s.slice(i, i + L));
        }
    }
    return ans;
};

```

**复杂度分析**

- 时间复杂度：O(N)O(N)O(N)，其中 NNN 是字符串 s\\textit{s}s 的长度。
- 空间复杂度：O(N)O(N)O(N)。
