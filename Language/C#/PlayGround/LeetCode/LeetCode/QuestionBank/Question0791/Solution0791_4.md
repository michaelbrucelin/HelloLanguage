#### [方法二：计数排序](https://leetcode.cn/problems/custom-sort-string/solutions/1963410/zi-ding-yi-zi-fu-chuan-pai-xu-by-leetcod-1qvf/)

**思路与算法**

由于字符集的大小为 26，我们也可以考虑使用计数排序代替普通的排序方法。

我们首先遍历字符串 s，使用数组或哈希表统计每个字符出现的次数。随后遍历字符串 order 中的每个字符 c，如果其在 s 中出现了 k 次，就在答案的末尾添加 k 个 c，并将数组或哈希表中对应的次数置为 0。最后我们遍历一次哈希表，对于所有次数 k 非 0 的键值对 (c,k)，在答案的末尾添加 k 个 c 即可。

**代码**

```cpp
class Solution {
public:
    string customSortString(string order, string s) {
        vector<int> freq(26);
        for (char ch: s) {
            ++freq[ch - 'a'];
        }
        string ans;
        for (char ch: order) {
            if (freq[ch - 'a'] > 0) {
                ans += string(freq[ch - 'a'], ch);
                freq[ch - 'a'] = 0;
            }
        }
        for (int i = 0; i < 26; ++i) {
            if (freq[i] > 0) {
                ans += string(freq[i], i + 'a');
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public String customSortString(String order, String s) {
        int[] freq = new int[26];
        for (int i = 0; i < s.length(); ++i) {
            char ch = s.charAt(i);
            ++freq[ch - 'a'];
        }
        StringBuilder ans = new StringBuilder();
        for (int i = 0; i < order.length(); ++i) {
            char ch = order.charAt(i);
            while (freq[ch - 'a'] > 0) {
                ans.append(ch);
                freq[ch - 'a']--;
            }
        }
        for (int i = 0; i < 26; ++i) {
            while (freq[i] > 0) {
                ans.append((char) (i + 'a'));
                freq[i]--;
            }
        }
        return ans.toString();
    }
}
```

```c#
public class Solution {
    public string CustomSortString(string order, string s) {
        int[] freq = new int[26];
        foreach (char ch in s) {
            ++freq[ch - 'a'];
        }
        StringBuilder ans = new StringBuilder();
        foreach (char ch in order) {
            while (freq[ch - 'a'] > 0) {
                ans.Append(ch);
                freq[ch - 'a']--;
            }
        }
        for (int i = 0; i < 26; ++i) {
            while (freq[i] > 0) {
                ans.Append((char) (i + 'a'));
                freq[i]--;
            }
        }
        return ans.ToString();
    }
}
```

```python
class Solution:
    def customSortString(self, order: str, s: str) -> str:
        freq = Counter(s)
        ans = list()
        for ch in order:
            if ch in freq:
                ans.extend([ch] * freq[ch])
                freq[ch] = 0
        for (ch, k) in freq.items():
            if k > 0:
                ans.extend([ch] * k)
        return "".join(ans)
```

```c
char * customSortString(char * order, char * s) {
    int freq[26];
    memset(freq, 0, sizeof(freq));
    for (int i = 0; s[i] != '\0'; i++) {
        ++freq[s[i] - 'a'];
    }
    char *ans = (char *)malloc(sizeof(char) * (strlen(s) + 1));
    int pos = 0;
    for (int i = 0; order[i] != '\0'; i++) {
        if (freq[order[i] - 'a'] > 0) {
            for (int j = 0; j < freq[order[i] - 'a']; j++) {
                ans[pos++] = order[i];
            }
            freq[order[i] - 'a'] = 0;
        }
    }
    for (int i = 0; i < 26; ++i) {
        if (freq[i] > 0) {
            for (int j = 0; j < freq[i]; j++) {
                ans[pos++] = i + 'a';
            }
        }
    }
    ans[pos] = '\0';
    return ans;
}
```

```go
func customSortString(order, s string) string {
    freq := [26]int{}
    for _, c := range s {
        freq[c-'a']++
    }
    t := &strings.Builder{}
    for _, c := range order {
        if freq[c-'a'] > 0 {
            t.WriteString(strings.Repeat(string(c), freq[c-'a']))
            freq[c-'a'] = 0
        }
    }
    for i, k := range freq {
        if k > 0 {
            t.WriteString(strings.Repeat(string('a'+i), k))
        }
    }
    return t.String()
}
```

```javascript
var customSortString = function(order, s) {
    const freq = new Array(26).fill(0);
    for (let i = 0; i < s.length; ++i) {
        const ch = s[i];
        ++freq[ch.charCodeAt() - 'a'.charCodeAt()];
    }
    let ans = '';
    for (let i = 0; i < order.length; ++i) {
        const ch = order[i];
        while (freq[ch.charCodeAt() - 'a'.charCodeAt()] > 0) {
            ans += ch;
            freq[ch.charCodeAt() - 'a'.charCodeAt()]--;
        }
    }
    for (let i = 0; i < 26; ++i) {
        while (freq[i] > 0) {
            ans += String.fromCharCode(i + 'a'.charCodeAt());
            freq[i]--;
        }
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(n + |\Sigma|)$，其中 n 是字符串 s 的长度，$\Sigma$ 是字符集，在本题中 $|\Sigma|=26$。
-   空间复杂度：$O(|\Sigma|)$。即为数组或哈希表需要使用的空间。
