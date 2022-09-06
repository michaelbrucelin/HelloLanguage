#### 方法一：分别计算每个字符的贡献

**思路**

对于下标为 i 的字符 ci，当它在某个子字符串中仅出现一次时，它会对这个子字符串统计唯一字符时有贡献。只需对每个字符，计算有多少子字符串仅包含该字符一次即可。对于 ci， 记同字符上一次出现的位置为 cj，下一次出现的位置为 ck，那么这样的子字符串就一共有 (ci−cj)×(ck−ci) 种，即子字符串的起始位置有 cj（不含）到 ci（含）之间这 (ci−cj) 种可能，到结束位置有 (ck−ci) 种可能。可以预处理 s，将相同字符的下标放入数组中，方便计算。最后对所有字符进行这种计算即可。

**代码**

```Python3
class Solution:
    def uniqueLetterString(self, s: str) -> int:
        index = collections.defaultdict(list)
        for i, c in enumerate(s):
            index[c].append(i)

        res = 0
        for arr in index.values():
            arr = [-1] + arr + [len(s)]
            for i in range(1, len(arr) - 1):
                res += (arr[i] - arr[i - 1]) * (arr[i + 1] - arr[i])
        return res

```

```C++
class Solution {
public:
    int uniqueLetterString(string s) {
        unordered_map<char, vector<int>> index;
        for (int i = 0; i < s.size(); i++) {
            index[s[i]].emplace_back(i);
        }
        int res = 0;
        for (auto &&[_, arr]: index) {
            arr.insert(arr.begin(), -1);
            arr.emplace_back(s.size());
            for (int i = 1; i < arr.size() - 1; i++) {
                res += (arr[i] - arr[i - 1]) * (arr[i + 1] - arr[i]);
            }
        }
        return res;
    }
};

```

```Java
class Solution {
    public int uniqueLetterString(String s) {
        Map<Character, List<Integer>> index = new HashMap<Character, List<Integer>>();
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (!index.containsKey(c)) {
                index.put(c, new ArrayList<Integer>());
                index.get(c).add(-1);
            }
            index.get(c).add(i);
        }
        int res = 0;
        for (Map.Entry<Character, List<Integer>> entry : index.entrySet()) {
            List<Integer> arr = entry.getValue();
            arr.add(s.length());
            for (int i = 1; i < arr.size() - 1; i++) {
                res += (arr.get(i) - arr.get(i - 1)) * (arr.get(i + 1) - arr.get(i));
            }
        }
        return res;
    }
}

```

```C#
public class Solution {
    public int UniqueLetterString(string s) {
        Dictionary<char, IList<int>> index = new Dictionary<char, IList<int>>();
        for (int i = 0; i < s.Length; i++) {
            if (!index.ContainsKey(s[i])) {
                index.Add(s[i], new List<int>());
                index[s[i]].Add(-1);
            }
            index[s[i]].Add(i);
        }
        int res = 0;
        foreach (KeyValuePair<char, IList<int>> pair in index) {
            IList<int> arr = pair.Value;
            arr.Add(s.Length);
            for (int i = 1; i < arr.Count - 1; i++) {
                res += (arr[i] - arr[i - 1]) * (arr[i + 1] - arr[i]);
            }
        }
        return res;
    }
}

```

```C
int uniqueLetterString(char * s){
    struct ListNode **index = (struct ListNode **)malloc(sizeof(struct ListNode *) * 26);
    for (int i = 0; i < 26; i++) {
        index[i] = NULL;
    }
    int len = strlen(s);
    for (int i = 0; i < len; i++) {
        struct ListNode *node = (struct ListNode *)malloc(sizeof(struct ListNode));
        node->val = i;
        node->next = index[s[i] - 'A'];
        index[s[i] - 'A'] = node;
    }
    int res = 0;
    for (int i = 0; i < 26; i++) {
        if (index[i]) {
            struct ListNode *curr = index[i];
            struct ListNode *prev = NULL;
            struct ListNode *next = curr->next;
            while (curr) {
                if (prev == NULL && next == NULL) {
                    res += (curr->val + 1) * (len - curr->val);
                } else if (prev == NULL) {
                    res += (curr->val - next->val) * (len - curr->val);
                } else if (next == NULL) {
                    res += (curr->val + 1) * (prev->val - curr->val);
                } else {
                    res += (curr->val - next->val) * (prev->val - curr->val);
                }
                prev = curr;
                curr = curr->next;
                if (next) {
                    next = next->next;
                }
            }
        }
    }
    for (int i = 0; i < 26; i++) {
        if (index[i]) {
            struct ListNode *curr = NULL, *tmp = NULL;
            for (curr = index[i]; curr; ) {
                tmp = curr;
                curr = curr->next;
                free(tmp);
            }
        }
    }
    return res;
}

```

```JavaScript
var uniqueLetterString = function(s) {
    const index = new Map();
        for (let i = 0; i < s.length; i++) {
            const c = s[i];
            if (!index.has(c)) {
                index.set(c, []);
                index.get(c).push(-1);
            }
            index.get(c).push(i);
        }
        let res = 0;
        for (const [_, arr] of index.entries()) {
            arr.push(s.length);
            for (let i = 1; i < arr.length - 1; i++) {
                res += (arr[i] - arr[i - 1]) * (arr[i + 1] - arr[i]);
            }
        }
        return res;
};

```

```Golang
func uniqueLetterString(s string) (ans int) {
    idx := map[rune][]int{}
    for i, c := range s {
        idx[c] = append(idx[c], i)
    }
    for _, arr := range idx {
        arr = append(append([]int{-1}, arr...), len(s))
        for i := 1; i < len(arr)-1; i++ {
            ans += (arr[i] - arr[i-1]) * (arr[i+1] - arr[i])
        }
    }
    return
}

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是 s 的长度。每个下标会被计算一次。

-   空间复杂度：O(n)，哈希表占用 O(n) 空间。
