#### [方法一：二分查找](https://leetcode.cn/problems/number-of-matching-subsequences/solutions/1973995/pi-pei-zi-xu-lie-de-dan-ci-shu-by-leetco-vki7/)

**思路与算法**

首先题目给出字符串 s 和一个字符串数组 words，我们需要统计字符串数组中有多少个字符串是字符串 s 的子序列。 那么最朴素的方法就是我们对于字符串数组 words 中的每一个字符串和字符串 s 尝试进行匹配，我们可以用「双指针」的方法来进行匹配——用 i 指向字符串 s 当前遍历到的字符，j 指向当前需要匹配的字符串 t 需要匹配的字符，初始 i = 0，j = 0，如果 s[i] = t[j] 那么将指针 i 和 j 同时往后移动一个单位，否则仅 i 移动 i 往后移动一个单位，并在 i 指向字符串 s 结尾或者 j 指向 t 结尾时结束匹配过程，然后判断 j 是否指向 t 的结尾，若指向结尾则说明 t 为字符串 s 的子序列，否则不是。但是这个方法的时间复杂度会为 $O(n \times m + \sum_{i = 0}^{m - 1} size_i)$，其中 n 为字符串 s 的长度，m 是字符串数组 words 的大小，$size_i$ 为字符串数组 words 中索引为 i 的字符串长度。该时间复杂度在本题中将会超时。所以我们考虑是否可以在朴素方法的基础上进行优化。

在朴素方法的匹配的过程中，对于每一个需要匹配的字符 t[j]，我们都需要将字符串 s 中的指针 i 在当前位置不断往后移动直至找到字符 s[i] 使得 s[i] = t[j]，或者移至结尾，我们现在考虑能否加速这个过程——如果我们将字符串 s 中的全部的字符的位置按照对应的字符进行存储，令其为数组 pos，其中 pos[c] 存储的是字符串 s 中字符为 c 的从小到大排列的位置。那么对于需要匹配的字符 t[j] 我们就可以通过在对应的 pos 数组中进行「二分查找」来找到第一个大于当前 i 指针的位置，若不存在则说明匹配不成功，否则就将指针 i 直接移到找到的对应位置，并将指针 j 后移一个单位，这样就加速了指针 i 的移动。

**代码**

```python
class Solution:
    def numMatchingSubseq(self, s: str, words: List[str]) -> int:
        pos = defaultdict(list)
        for i, c in enumerate(s):
            pos[c].append(i)
        ans = len(words)
        for w in words:
            if len(w) > len(s):
                ans -= 1
                continue
            p = -1
            for c in w:
                ps = pos[c]
                j = bisect_right(ps, p)
                if j == len(ps):
                    ans -= 1
                    break
                p = ps[j]
        return ans
```

```cpp
class Solution {
public:
    int numMatchingSubseq(string s, vector<string> &words) {
        vector<vector<int>> pos(26);
        for (int i = 0; i < s.size(); ++i) {
            pos[s[i] - 'a'].push_back(i);
        }
        int res = words.size();
        for (auto &w : words) {
            if (w.size() > s.size()) {
                --res;
                continue;
            }
            int p = -1;
            for (char c : w) {
                auto &ps = pos[c - 'a'];
                auto it = upper_bound(ps.begin(), ps.end(), p);
                if (it == ps.end()) {
                    --res;
                    break;
                }
                p = *it;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int numMatchingSubseq(String s, String[] words) {
        List<Integer>[] pos = new List[26];
        for (int i = 0; i < 26; ++i) {
            pos[i] = new ArrayList<Integer>();
        }
        for (int i = 0; i < s.length(); ++i) {
            pos[s.charAt(i) - 'a'].add(i);
        }
        int res = words.length;
        for (String w : words) {
            if (w.length() > s.length()) {
                --res;
                continue;
            }
            int p = -1;
            for (int i = 0; i < w.length(); ++i) {
                char c = w.charAt(i);
                if (pos[c - 'a'].isEmpty() || pos[c - 'a'].get(pos[c - 'a'].size() - 1) <= p) {
                    --res;
                    break;
                }
                p = binarySearch(pos[c - 'a'], p);
            }
        }
        return res;
    }

    public int binarySearch(List<Integer> list, int target) {
        int left = 0, right = list.size() - 1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list.get(mid) > target) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return list.get(left);
    }
}
```

```c#
public class Solution {
    public int NumMatchingSubseq(string s, string[] words) {
        IList<int>[] pos = new IList<int>[26];
        for (int i = 0; i < 26; ++i) {
            pos[i] = new List<int>();
        }
        for (int i = 0; i < s.Length; ++i) {
            pos[s[i] - 'a'].Add(i);
        }
        int res = words.Length;
        foreach (string w in words) {
            if (w.Length > s.Length) {
                --res;
                continue;
            }
            int p = -1;
            for (int i = 0; i < w.Length; ++i) {
                char c = w[i];
                if (pos[c - 'a'].Count == 0 || pos[c - 'a'][pos[c - 'a'].Count - 1] <= p) {
                    --res;
                    break;
                }
                p = BinarySearch(pos[c - 'a'], p);
            }
        }
        return res;
    }

    public int BinarySearch(IList<int> list, int target) {
        int left = 0, right = list.Count - 1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list[mid] > target) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return list[left];
    }
}
```

```c
int binarySearch(const int *list, int listSize, int target) {
    int left = 0, right = listSize - 1;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (list[mid] > target) {
            right = mid;
        } else {
            left = mid + 1;
        }
    }
    return list[left];
}

int numMatchingSubseq(char * s, char ** words, int wordsSize) {
    int cnt[26], *pos[26], posSize[26];
    for (int i = 0; i < 26; ++i) {
        pos[i] = NULL;
        cnt[i] = 0;
        posSize[i] = 0;
    }
    int len = strlen(s);
    for (int i = 0; i < len; ++i) {
        posSize[s[i] - 'a']++;
    }
    for (int i = 0; i < 26; i++) {
        pos[i] = (int *)malloc(sizeof(int) * posSize[i]);
    }
    for (int i = 0; i < len; ++i) {
        pos[s[i] - 'a'][cnt[s[i] - 'a']] = i;
        cnt[s[i] - 'a']++;
    }
    int res = wordsSize;
    for (int i = 0; i < wordsSize; i++) {
        if (strlen(words[i]) > len) {
            --res;
            continue;
        }
        int p = -1;
        for (int j = 0; words[i][j] != '\0' ; ++j) {
            char c = words[i][j];
            int m = posSize[c - 'a'];
            if (m == 0 || pos[c - 'a'][m - 1] <= p) {
                --res;
                break;
            }
            p = binarySearch(pos[c - 'a'], posSize[c - 'a'], p);
        }
    }
    for (int i = 0; i < 26; i++) {
        free(pos[i]);
    }
    return res;
}
```

```javascript
var numMatchingSubseq = function(s, words) {
    const pos = new Array(26).fill(0).map(() => new Array());
    for (let i = 0; i < s.length; ++i) {
        pos[s[i].charCodeAt() - 'a'.charCodeAt()].push(i);
    }
    let res = words.length;
    for (const w of words) {
        if (w.length > s.length) {
            --res;
            continue;
        }
        let p = -1;
        for (let i = 0; i < w.length; ++i) {
            const c = w[i];
            if (pos[c.charCodeAt() - 'a'.charCodeAt()].length === 0 || pos[c.charCodeAt() - 'a'.charCodeAt()][pos[c.charCodeAt() - 'a'.charCodeAt()].length - 1] <= p) {
                --res;
                break;
            }
            p = binarySearch(pos[c.charCodeAt() - 'a'.charCodeAt()], p);
        }
    }
    return res;
}

const binarySearch = (list, target) => {
    let left = 0, right = list.length - 1;
    while (left < right) {
        const mid = left + Math.floor((right - left) / 2);
        if (list[mid] > target) {
            right = mid;
        } else {
            left = mid + 1;
        }
    }
    return list[left];
};
```

```go
func numMatchingSubseq(s string, words []string) int {
    pos := [26][]int{}
    for i, c := range s {
        pos[c-'a'] = append(pos[c-'a'], i)
    }
    ans := len(words)
    for _, w := range words {
        if len(w) > len(s) {
            ans--
            continue
        }
        p := -1
        for _, c := range w {
            ps := pos[c-'a']
            j := sort.SearchInts(ps, p+1)
            if j == len(ps) {
                ans--
                break
            }
            p = ps[j]
        }
    }
    return ans
}
```

**复杂度分析**

-   时间复杂度：$O(\sum_{i = 0}^{m - 1} size_i \times \log n)$，其中 n 为字符串 s 的长度，m 是字符串数组 words 的大小，$size_i$ 为字符串数组 words 中索引为 i 的字符串长度，对于字符串数组中某一个字符串 words[i] 的查询匹配的时间开销为 $size_i \times \log n$。
-   空间复杂度：O(n)，其中 n 为字符串 s 的长度，主要为存储字符串 s 中每一个字符位置的空间开销。
