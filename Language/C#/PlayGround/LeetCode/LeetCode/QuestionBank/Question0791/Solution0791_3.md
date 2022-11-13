#### [方法一：自定义排序](https://leetcode.cn/problems/custom-sort-string/solutions/1963410/zi-ding-yi-zi-fu-chuan-pai-xu-by-leetcod-1qvf/)

**思路与算法**

最简单的方法是直接对字符串 s 进行排序。

我们首先遍历给定的字符串 order，将第一个出现的字符的权值赋值为 1，第二个出现的字符的权值赋值为 2，以此类推。在遍历完成之后，所有未出现字符的权值默认赋值为 0。

随后我们根据权值表，对字符串 s 进行排序，即可得到一种满足要求的排列方案。

**代码**

```cpp
class Solution {
public:
    string customSortString(string order, string s) {
        vector<int> val(26);
        for (int i = 0; i < order.size(); ++i) {
            val[order[i] - 'a'] = i + 1;
        }
        sort(s.begin(), s.end(), [&](char c0, char c1) {
            return val[c0 - 'a'] < val[c1 - 'a'];
        });
        return s;
    }
};
```

```java
class Solution {
    public String customSortString(String order, String s) {
        int[] val = new int[26];
        for (int i = 0; i < order.length(); ++i) {
            val[order.charAt(i) - 'a'] = i + 1;
        }
        Character[] arr = new Character[s.length()];
        for (int i = 0; i < s.length(); ++i) {
            arr[i] = s.charAt(i);
        }
        Arrays.sort(arr, (c0, c1) -> val[c0 - 'a'] - val[c1 - 'a']);
        StringBuilder ans = new StringBuilder();
        for (int i = 0; i < s.length(); ++i) {
            ans.append(arr[i]);
        }
        return ans.toString();
    }
}
```

```c#
public class Solution {
    public string CustomSortString(string order, string s) {
        int[] val = new int[26];
        for (int i = 0; i < order.Length; ++i) {
            val[order[i] - 'a'] = i + 1;
        }
        char[] arr = s.ToCharArray();
        Array.Sort(arr, (c0, c1) => val[c0 - 'a'] - val[c1 - 'a']);
        return new string(arr);
    }
}
```

```python
class Solution:
    def customSortString(self, order: str, s: str) -> str:
        val = defaultdict(int)
        for i, ch in enumerate(order):
            val[ch] = i + 1
        
        return "".join(sorted(s, key=lambda ch: val[ch]))
```

```c
int val[26];

int cmp(const void *pa, const void *pb) {
    return val[*(char *)pa - 'a'] - val[*(char *)pb - 'a'];
}

char * customSortString(char * order, char * s) {
    memset(val, 0, sizeof(val));
    for (int i = 0; order[i] != '\0'; ++i) {
        val[order[i] - 'a'] = i + 1;
    }
    qsort(s, strlen(s), sizeof(char), cmp);
    return s;
}
```

```go
func customSortString(order, s string) string {
    val := map[byte]int{}
    for i, c := range order {
        val[byte(c)] = i + 1
    }
    t := []byte(s)
    sort.Slice(t, func(i, j int) bool { return val[t[i]] < val[t[j]] })
    return string(t)
}
```

```javascript
var customSortString = function(order, s) {
    const val = new Array(26).fill(0);
    for (let i = 0; i < order.length; ++i) {
        val[order[i].charCodeAt() - 'a'.charCodeAt()] = i + 1;
    }
    const arr = new Array(s.length).fill(0).map((_, i) => s[i]);
    arr.sort((c0, c1) => val[c0.charCodeAt() - 'a'.charCodeAt()] - val[c1.charCodeAt() - 'a'.charCodeAt()])
    let ans = '';
    for (let i = 0; i < s.length; ++i) {
        ans += arr[i];
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(n \log n + |\Sigma|)$，其中 n 是字符串 s 的长度，$\Sigma$ 是字符集，在本题中 $|\Sigma|=26$。
    -   排序的时间复杂度为 $O(n \log n)$；
    -   如果我们使用数组存储权值，数组的大小为 $O(|\Sigma|)$；如果我们使用哈希表存储权值，哈希表的大小与字符串 s 和 order 中出现的字符种类数相同，为叙述方便也可以记为 $O(|\Sigma|)$。
-   空间复杂度：$O(|\Sigma|)$。即为数组或哈希表需要使用的空间。
