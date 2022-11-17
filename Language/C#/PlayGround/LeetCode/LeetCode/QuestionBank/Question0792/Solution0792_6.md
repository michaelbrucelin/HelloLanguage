#### [方法一：分桶](https://leetcode.cn/problems/number-of-matching-subsequences/solutions/1975527/by-lcbin-gwyj/)

题目中字符串 s 的数据规模最高达到 $5 \times 10^4$，如果暴力枚举 words 中的每个字符串 w，判断其是否为 s 的子序列，很有可能会超时。

我们不妨将 words 中的所有单词根据首字母来分桶，即：把所有单词按照首字母分到 26 个桶中，每个桶中存储的是所有以该字母开头的所有单词。

比如对于 `words = ["a", "bb", "acd", "ace"]`，我们得到以下的分桶结果：

```json
a: ["a", "acd", "ace"]
b: ["bb"]
```

然后我们从 s 的第一个字符开始遍历，假设当前字符为 `'a'`，我们从 `'a'` 开头的桶中取出所有单词。对于取出的每个单词，如果此时单词长度为 1，说明该单词已经匹配完毕，我们将答案加 1；否则我们将单词的首字母去掉，然后放入下一个字母开头的桶中，比如对于单词 `"acd"`，去掉首字母 `'a'` 后，我们将其放入 `'c'` 开头的桶中。这一轮结束后，分桶结果变为：

```json
c: ["cd", "ce"]
b: ["bb"]
```

遍历完 s 后，我们就得到了答案。

```python
class Solution:
    def numMatchingSubseq(self, s: str, words: List[str]) -> int:
        d = defaultdict(deque)
        for w in words:
            d[w[0]].append(w)
        ans = 0
        for c in s:
            for _ in range(len(d[c])):
                t = d[c].popleft()
                if len(t) == 1:
                    ans += 1
                else:
                    d[t[1]].append(t[1:])
        return ans
```

```java
class Solution {
    public int numMatchingSubseq(String s, String[] words) {
        Deque<String>[] d = new Deque[26];
        for (int i = 0; i < 26; ++i) {
            d[i] = new ArrayDeque<>();
        }
        for (String w : words) {
            d[w.charAt(0) - 'a'].add(w);
        }
        int ans = 0;
        for (char c : s.toCharArray()) {
            var q = d[c - 'a'];
            for (int k = q.size(); k > 0; --k) {
                String t = q.pollFirst();
                if (t.length() == 1) {
                    ++ans;
                } else {
                    d[t.charAt(1) - 'a'].offer(t.substring(1));
                }
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int numMatchingSubseq(string s, vector<string>& words) {
        vector<queue<string>> d(26);
        for (auto& w : words) d[w[0] - 'a'].emplace(w);
        int ans = 0;
        for (char& c : s) {
            auto& q = d[c - 'a'];
            for (int k = q.size(); k; --k) {
                auto t = q.front();
                q.pop();
                if (t.size() == 1) ++ans;
                else d[t[1] - 'a'].emplace(t.substr(1));
            }
        }
        return ans;
    }
};
```

```go
func numMatchingSubseq(s string, words []string) (ans int) {
    d := [26][]string{}
    for _, w := range words {
        d[w[0]-'a'] = append(d[w[0]-'a'], w)
    }
    for _, c := range s {
        q := d[c-'a']
        d[c-'a'] = nil
        for _, t := range q {
            if len(t) == 1 {
                ans++
            } else {
                d[t[1]-'a'] = append(d[t[1]-'a'], t[1:])
            }
        }
    }
    return
}
```

实际上，每个桶可以只存储单词的下标 i 以及该单词当前匹配到的位置 j，这样可以节省空间。

```python
class Solution:
    def numMatchingSubseq(self, s: str, words: List[str]) -> int:
        d = defaultdict(deque)
        for i, w in enumerate(words):
            d[w[0]].append((i, 0))
        ans = 0
        for c in s:
            for _ in range(len(d[c])):
                i, j = d[c].popleft()
                j += 1
                if j == len(words[i]):
                    ans += 1
                else:
                    d[words[i][j]].append((i, j))
        return ans
```

```java
class Solution {
    public int numMatchingSubseq(String s, String[] words) {
        Deque<int[]>[] d = new Deque[26];
        for (int i = 0; i < 26; ++i) {
            d[i] = new ArrayDeque<>();
        }
        for (int i = 0; i < words.length; ++i) {
            d[words[i].charAt(0) - 'a'].offer(new int[] {i, 0});
        }
        int ans = 0;
        for (char c : s.toCharArray()) {
            var q = d[c - 'a'];
            for (int t = q.size(); t > 0; --t) {
                var p = q.pollFirst();
                int i = p[0], j = p[1] + 1;
                if (j ==  words[i].length()) {
                    ++ans;
                } else {
                    d[words[i].charAt(j) - 'a'].offer(new int[] {i, j});
                }
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int numMatchingSubseq(string s, vector<string>& words) {
        vector<queue<pair<int, int>>> d(26);
        for (int i = 0; i < words.size(); ++i) d[words[i][0] - 'a'].emplace(i, 0);
        int ans = 0;
        for (char& c : s) {
            auto& q = d[c - 'a'];
            for (int t = q.size(); t; --t) {
                auto [i, j] = q.front();
                q.pop();
                if (++j == words[i].size()) ++ans;
                else d[words[i][j] - 'a'].emplace(i, j);
            }
        }
        return ans;
    }
};
```

```go
func numMatchingSubseq(s string, words []string) (ans int) {
    type pair struct{ i, j int }
    d := [26][]pair{}
    for i, w := range words {
        d[w[0]-'a'] = append(d[w[0]-'a'], pair{i, 0})
    }
    for _, c := range s {
        q := d[c-'a']
        d[c-'a'] = nil
        for _, p := range q {
            i, j := p.i, p.j+1
            if j == len(words[i]) {
                ans++
            } else {
                d[words[i][j]-'a'] = append(d[words[i][j]-'a'], pair{i, j})
            }
        }
    }
    return
}
```

时间复杂度 $O(n + \sum_{i=0}^{m-1} |w_i|)$，空间复杂度 O(m)。其中 n 和 m 分别为 s 和 words 的长度，而 $|w_i|$ 为 words[i] 的长度。
