#### [方法二：多指针](https://leetcode.cn/problems/number-of-matching-subsequences/solutions/1973995/pi-pei-zi-xu-lie-de-dan-ci-shu-by-leetco-vki7/)

**思路与算法**

同样我们还可以在朴素方法的基础上进行优化，因为朴素方法中是每一个单词分别和字符串 s 进行匹配，这样对于每一次匹配都需要从头开始遍历字符串 s，这增加了额外的时间开销。所以我们考虑将字符串数组 words 中的全部字符串和字符串 s 同时进行匹配——同样对于每一个需要匹配的字符串我们用一个指针来指向它需要匹配的字符，那么在遍历字符串 s 的过程中，对于当前遍历到的字符如果有可以匹配的字符串，那么将对应的字符串指针往后移动一单位即可。那么当字符串 s 遍历结束时，字符串数组中全部字符串的匹配情况也就全部知道了。

**代码**

```python
class Solution:
    def numMatchingSubseq(self, s: str, words: List[str]) -> int:
        p = defaultdict(list)
        for i, w in enumerate(words):
            p[w[0]].append((i, 0))
        ans = 0
        for c in s:
            q = p[c]
            p[c] = []
            for i, j in q:
                j += 1
                if j == len(words[i]):
                    ans += 1
                else:
                    p[words[i][j]].append((i, j))
        return ans
```

```cpp
class Solution {
public:
    int numMatchingSubseq(string s, vector<string> &words) {
        vector<queue<pair<int, int>>> queues(26);
        for (int i = 0; i < words.size(); ++i) {
            queues[words[i][0] - 'a'].emplace(i, 0);
        }
        int res = 0;
        for (char c : s) {
            auto &q = queues[c - 'a'];
            int size = q.size();
            while (size--) {
                auto [i, j] = q.front();
                q.pop();
                ++j;
                if (j == words[i].size()) {
                    ++res;
                } else {
                    queues[words[i][j] - 'a'].emplace(i, j);
                }
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int numMatchingSubseq(String s, String[] words) {
        Queue<int[]>[] p = new Queue[26];
        for (int i = 0; i < 26; ++i) {
            p[i] = new ArrayDeque<int[]>();
        }
        for (int i = 0; i < words.length; ++i) {
            p[words[i].charAt(0) - 'a'].offer(new int[]{i, 0});
        }
        int res = 0;
        for (int i = 0; i < s.length(); ++i) {
            char c = s.charAt(i);
            int len = p[c - 'a'].size();
            while (len > 0) {
                int[] t = p[c - 'a'].poll();
                if (t[1] == words[t[0]].length() - 1) {
                    ++res;
                } else {
                    ++t[1];
                    p[words[t[0]].charAt(t[1]) - 'a'].offer(t);
                }
                --len;
            }
        }
        return res;
    }
}
```

```c#
public class Solution {
    public int NumMatchingSubseq(string s, string[] words) {
        Queue<int[]>[] p = new Queue<int[]>[26];
        for (int i = 0; i < 26; ++i) {
            p[i] = new Queue<int[]>();
        }
        for (int i = 0; i < words.Length; ++i) {
            p[words[i][0] - 'a'].Enqueue(new int[]{i, 0});
        }
        int res = 0;
        for (int i = 0; i < s.Length; ++i) {
            char c = s[i];
            int len = p[c - 'a'].Count;
            while (len > 0) {
                int[] t = p[c - 'a'].Dequeue();
                if (t[1] == words[t[0]].Length - 1) {
                    ++res;
                } else {
                    ++t[1];
                    p[words[t[0]][t[1]] - 'a'].Enqueue(t);
                }
                --len;
            }
        }
        return res;
    }
}
```

```c
typedef struct Node {
    int idx;
    int size;
    struct Node *next;
} Node;

typedef struct {
    struct Node *head;
    struct Node *tail;
    int size;
} myQueue;

myQueue* myQueueCreate() {
    myQueue *obj = (myQueue *)malloc(sizeof(myQueue));
    obj->size = 0;
    obj->head = obj->tail = NULL;
    return obj;
}

bool myQueueEnQueue(myQueue* obj, int idx, int size) {
    struct Node *node = (struct Node *)malloc(sizeof(struct Node));
    node->idx = idx;
    node->size = size;
    node->next = NULL;
    if (!obj->head) {
        obj->head = obj->tail = node;
    } else {
        obj->tail->next = node;
        obj->tail = node;
    }
    obj->size++;
    return true;
}

bool myQueueDeQueue(myQueue* obj) {
    if (obj->size == 0) {
        return false;
    }
    struct Node *node = obj->head;
    obj->head = obj->head->next;  
    obj->size--;
    free(node);
    return true;
}

Node * myQueueFront(myQueue* obj) {
    if (obj->size == 0) {
        return NULL;
    }
    return obj->head;
}

bool myQueueIsEmpty(myQueue* obj) {
    return obj->size == 0;
}

void myQueueQueueFree(myQueue* obj) {
    for (struct Node *curr = obj->head; curr;) {
        struct Node *node = curr;
        curr = curr->next;
        free(node);
    }
    free(obj);
}

int numMatchingSubseq(char * s, char ** words, int wordsSize) {
    myQueue *p[26];
    for (int i = 0; i < 26; ++i) {
        p[i] = myQueueCreate();
    }
    for (int i = 0; i < wordsSize; ++i) {
        myQueueEnQueue(p[words[i][0] - 'a'], i, 0);
    }
    int res = 0;
    for (int i = 0; s[i] != '\0'; i++) {
        char c = s[i];
        int len = p[s[i] - 'a']->size;
        while (len) {
            len--;
            Node *t = myQueueFront(p[c - 'a']);
            int idx = t->idx, size = t->size;
            myQueueDeQueue(p[c - 'a']);
            if (size == strlen(words[idx]) - 1) {
                ++res;
            } else {
                ++size;
                myQueueEnQueue(p[words[idx][size] - 'a'], idx, size);
            }
        }
    }
    for (int i = 0; i < 26; i++) {
        myQueueQueueFree(p[i]);
    }
    return res;
}
```

```javascript
var numMatchingSubseq = function(s, words) {
    const p = new Array(26).fill(0).map(() => new Array());
    for (let i = 0; i < words.length; ++i) {
        p[words[i][0].charCodeAt() - 'a'.charCodeAt()].push([i, 0]);
    }
    let res = 0;
    for (let i = 0; i < s.length; ++i) {
        const c = s[i];
        let len = p[c.charCodeAt() - 'a'.charCodeAt()].length;
        while (len > 0) {
            const t = p[c.charCodeAt() - 'a'.charCodeAt()].shift();
            if (t[1] === words[t[0]].length - 1) {
                ++res;
            } else {
                ++t[1];
                p[words[t[0]][t[1]].charCodeAt() - 'a'.charCodeAt()].push(t);
            }
            --len;
        }
    }
    return res;
}
```

```go
func numMatchingSubseq(s string, words []string) (ans int) {
    type pair struct{ i, j int }
    ps := [26][]pair{}
    for i, w := range words {
        ps[w[0]-'a'] = append(ps[w[0]-'a'], pair{i, 0})
    }
    for _, c := range s {
        q := ps[c-'a']
        ps[c-'a'] = nil
        for _, p := range q {
            p.j++
            if p.j == len(words[p.i]) {
                ans++
            } else {
                w := words[p.i][p.j] - 'a'
                ps[w] = append(ps[w], p)
            }
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(n + \sum_{i = 0}^{m - 1}size_i)$，其中 n 为字符串 s 的长度，m 是字符串数组 words 的大小，$size_i$ 为字符串数组 words 中索引为 i 的字符串长度。
-   空间复杂度：O(m)，m 为字符串数组 words 的大小，主要为存储字符串数组中每一个字符串现在的对应匹配指针的空间开销。
