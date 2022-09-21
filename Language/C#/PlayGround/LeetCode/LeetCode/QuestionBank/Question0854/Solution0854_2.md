#### [](https://leetcode.cn/problems/k-similar-strings/solution/xiang-si-du-wei-k-de-zi-fu-chuan-by-leet-8z10//#方法一：广度优先搜索)方法一：广度优先搜索

由于题目中给定的字符串的长度范围为 [1,20] 且只包含 6 种不同的字符，因此我们可以枚举所有可能的交换方案，在搜索时进行减枝从而提高搜索效率，最终找到最小的交换次数。

设字符串的长度为 n，如果当前第 i 个字符满足 s1[i]≠s2[i]，则从 s1[i+1,⋯ ] 选择一个合适的字符 s1[j] 进行交换，其中满足 s1[j]=s2[i],j∈[i+1,n−1]。每次我们进行交换时，可将字符串 s1 的前 x 个字符通过交换使得 s1[0,⋯ ,x−1]\=s2[0,⋯ ,x−1]，最终使得 s1 的所有字符与 s2 相等即可。我们通过以上变换，找到最小的交换次数使得 s1 与 s2 相等。

在搜索时，我们需要进行减枝，我们设当前的通过交换后的字符串 s1^′^ 为一个中间状态，用哈希表记录这些中间状态，当通过交换时发现当前状态已经计算过，则此时我们可以直接跳过该状态。

```Python
class Solution:
    def kSimilarity(self, s1: str, s2: str) -> int:
        step, n = 0, len(s1)
        q, vis = [(s1, 0)], {s1}
        while True:
            tmp = q
            q = []
            for s, i in tmp:
                if s == s2:
                    return step
                while i < n and s[i] == s2[i]:
                    i += 1
                for j in range(i + 1, n):
                    if s[j] == s2[i] != s2[j]:  # 剪枝，只在 s[j] != s2[j] 时去交换
                        t = list(s)
                        t[i], t[j] = t[j], t[i]
                        t = ''.join(t)
                        if t not in vis:
                            vis.add(t)
                            q.append((t, i + 1))
            step += 1

```

```C++
class Solution {
public:
    int kSimilarity(string s1, string s2) {
        int n = s1.size();
        queue<pair<string, int>> qu;
        unordered_set<string> visit;
        qu.emplace(s1, 0);
        visit.emplace(s1);
        for (int step = 0;; step++) {
            int sz = qu.size();
            for (int i = 0; i < sz; i++) {
                auto [cur, pos] = qu.front();
                qu.pop();
                if (cur == s2) {
                    return step;
                }
                while (pos < n && cur[pos] == s2[pos]) {
                    pos++;
                }
                for (int j = pos + 1; j < n; j++) {
                    if (cur[j] != s2[j] && cur[j] == s2[pos]) { // 剪枝，只在 cur[j] != s2[j] 时去交换
                        swap(cur[pos], cur[j]);
                        if (!visit.count(cur)) {
                            visit.emplace(cur);
                            qu.emplace(cur, pos + 1);
                        }
                        swap(cur[pos], cur[j]);
                    }
                }
            }
        }
    }
};

```

```Java
class Solution {
    public int kSimilarity(String s1, String s2) {
        int n = s1.length();
        Queue<Pair<String, Integer>> queue = new ArrayDeque<Pair<String, Integer>>();
        Set<String> visit = new HashSet<String>();
        queue.offer(new Pair<String, Integer>(s1, 0));
        visit.add(s1);
        int step = 0;
        while (!queue.isEmpty()) {
            int sz = queue.size();
            for (int i = 0; i < sz; i++) {
                Pair<String, Integer> pair = queue.poll();
                String cur = pair.getKey();
                int pos = pair.getValue();
                if (cur.equals(s2)) {
                    return step;
                }
                while (pos < n && cur.charAt(pos) == s2.charAt(pos)) {
                    pos++;
                }
                for (int j = pos + 1; j < n; j++) {
                    if (s2.charAt(j) == cur.charAt(j)) {
                        continue;
                    }
                    if (s2.charAt(pos) == cur.charAt(j)) {
                        String next = swap(cur, pos, j);
                        if (!visit.contains(next)) {
                            visit.add(next);
                            queue.offer(new Pair<String, Integer>(next, pos + 1));
                        }
                    }
                }
            }
            step++;
        } 
        return step;
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
    public int KSimilarity(string s1, string s2) {
        int n = s1.Length;
        Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
        ISet<string> visit = new HashSet<string>();
        queue.Enqueue(new Tuple<string, int>(s1, 0));
        visit.Add(s1);
        int step = 0;
        while (queue.Count > 0) {
            int sz = queue.Count;
            for (int i = 0; i < sz; i++) {
                Tuple<string, int> tuple = queue.Dequeue();
                string cur = tuple.Item1;
                int pos = tuple.Item2;
                if (cur.Equals(s2)) {
                    return step;
                }
                while (pos < n && cur[pos] == s2[pos]) {
                    pos++;
                }
                for (int j = pos + 1; j < n; j++) {
                    if (s2[j] == cur[j]) {
                        continue;
                    }
                    if (s2[pos] == cur[j]) {
                        string next = Swap(cur, pos, j);
                        if (!visit.Contains(next)) {
                            visit.Add(next);
                            queue.Enqueue(new Tuple<string, int>(next, pos + 1));
                        }
                    }
                }
            }
            step++;
        } 
        return step;
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

typedef struct Node {
    char str[MAX_STR_LEN];
    int pos;
    struct Node* next;
} Node;

typedef struct {
    char key[MAX_STR_LEN];
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, const char* key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, const char* key) {
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    strcpy(pEntry->key, key);
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

static inline void swap(char *pa, char *pb) {
    char c = *pa;
    *pa = *pb;
    *pb = c;
}

int kSimilarity(char * s1, char * s2) {
    int n = strlen(s1);
    Node *head = NULL, *tail = NULL;
    HashItem *visit = NULL;
    hashAddItem(&visit, s1);
    head = tail = (Node *)malloc(sizeof(Node));
    strcpy(tail->str, s1);
    tail->pos = 0;
    tail->next = NULL;
    int step = 0, queueSize = 1;
    while (queueSize > 0) {
        int sz = queueSize;
        char cur[MAX_STR_LEN];
        for (int i = 0; i < sz; i++) {
            char *cur = head->str;
            int pos = head->pos;
            if (!strcmp(cur, s2)) {
                return step;
            }
            while (pos < n && cur[pos] == s2[pos]) {
                pos++;
            }
            for (int j = pos + 1; j < n; j++) {
                if (s2[j] == cur[j]) {
                    continue;
                }
                if (s2[pos] == cur[j]) {
                    swap(&cur[pos], &cur[j]);
                    if (!hashFindItem(&visit, cur)) {
                        hashAddItem(&visit, cur);
                        tail->next = (Node *)malloc(sizeof(Node));
                        tail = tail->next;
                        strcpy(tail->str, cur);
                        tail->pos = pos + 1;
                        tail->next = NULL;
                        queueSize++;
                    }
                    swap(&cur[pos], &cur[j]);
                }
            }
            Node *p = head;
            head = head->next;
            queueSize--;
            free(p);
        }
        step++;
    } 
    hashFree(&visit);
    return step;
}

```

```JavaScript
var kSimilarity = function(s1, s2) {
    const n = s1.length;
    const queue = [];
    const visit = new Set();
    queue.push([s1, 0]);
    visit.add(s1);
    let step = 0;
    while (queue.length) {
        const sz = queue.length;
        for (let i = 0; i < sz; i++) {
            let [cur, pos] = queue.shift();
            if (cur === s2) {
                return step;
            }
            while (pos < n && cur[pos] === s2[pos]) {
                pos++;
            }
            for (let j = pos + 1; j < n; j++) {
                if (s2[j] === cur[j]) {
                    continue;
                }
                if (s2[pos] === cur[j]) {
                    const next = swap(cur, pos, j);
                    if (!visit.has(next)) {
                        visit.add(next);
                        queue.push([next, pos + 1]);
                    }
                }
            }
        }
        step++;
    } 
    return step;
}

const swap = (cur, i, j) => {
    const arr = [...cur];
    const c = arr[i];
    arr[i] = arr[j];
    arr[j] = c;
    return arr.join('');
};

```

```Go
func kSimilarity(s1, s2 string) (step int) {
    type pair struct {
        s string
        i int
    }
    q := []pair{{s1, 0}}
    vis := map[string]bool{s1: true}
    for n := len(s1); ; step++ {
        tmp := q
        q = nil
        for _, p := range tmp {
            s, i := p.s, p.i
            if s == s2 {
                return
            }
            for i < n && s[i] == s2[i] {
                i++
            }
            t := []byte(s)
            for j := i + 1; j < n; j++ {
                if s[j] == s2[i] && s[j] != s2[j] { // 剪枝，只在 s[j] != s2[j] 时去交换
                    t[i], t[j] = t[j], t[i]
                    if t := string(t); !vis[t] {
                        vis[t] = true
                        q = append(q, pair{t, i + 1})
                    }
                    t[i], t[j] = t[j], t[i]
                }
            }
        }
    }
}

```

**复杂度分析**

该方法时空复杂度分析较为复杂，暂不讨论。
