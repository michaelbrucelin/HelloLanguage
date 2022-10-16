#### [](https://leetcode.cn/problems/possible-bipartition/solution/ke-neng-de-er-fen-fa-by-leetcode-solutio-guo7//#方法二：广度优先搜索)方法二：广度优先搜索

**思路与算法**

同样我们也可以通过「广度优先搜索」来实现「方法一」中「染色法」的过程。

**代码**

```Python
class Solution:
    def possibleBipartition(self, n: int, dislikes: List[List[int]]) -> bool:
        g = [[] for _ in range(n)]
        for x, y in dislikes:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)
        color = [0] * n  # color[x] = 0 表示未访问节点 x
        for i, c in enumerate(color):
            if c == 0:
                q = deque([i])
                color[i] = 1
                while q:
                    x = q.popleft()
                    for y in g[x]:
                        if color[y] == color[x]:
                            return False
                        if color[y] == 0:
                            color[y] = -color[x]
                            q.append(y)
        return True
```

```C++
class Solution {
public:
    bool possibleBipartition(int n, vector<vector<int>>& dislikes) {
        vector<int> color(n + 1, 0);
        vector<vector<int>> g(n + 1);
        for (auto& p : dislikes) {
            g[p[0]].push_back(p[1]);
            g[p[1]].push_back(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            if (color[i] == 0) {
                queue<int> q;
                q.push(i);
                color[i] = 1;
                while (!q.empty()) {
                    auto t = q.front();
                    q.pop();
                    for (auto& next : g[t]) {
                        if (color[next] > 0 && color[next] == color[t]) {
                            return false;
                        }
                        if (color[next] == 0) {
                            color[next] = 3 ^ color[t];
                            q.push(next);
                        }
                    }
                }
            }
        }
        return true;
    }
};
```

```Java
class Solution {
    public boolean possibleBipartition(int n, int[][] dislikes) {
        int[] color = new int[n + 1];
        List<Integer>[] g = new List[n + 1];
        for (int i = 0; i <= n; ++i) {
            g[i] = new ArrayList<Integer>();
        }
        for (int[] p : dislikes) {
            g[p[0]].add(p[1]);
            g[p[1]].add(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            if (color[i] == 0) {
                Queue<Integer> queue = new ArrayDeque<Integer>();
                queue.offer(i);
                color[i] = 1;
                while (!queue.isEmpty()) {
                    int t = queue.poll();
                    for (int next : g[t]) {
                        if (color[next] > 0 && color[next] == color[t]) {
                            return false;
                        }
                        if (color[next] == 0) {
                            color[next] = 3 ^ color[t];
                            queue.offer(next);
                        }
                    }
                }
            }
        }
        return true;
    }
}
```

```C#
public class Solution {
    public bool PossibleBipartition(int n, int[][] dislikes) {
        int[] color = new int[n + 1];
        IList<int>[] g = new IList<int>[n + 1];
        for (int i = 0; i <= n; ++i) {
            g[i] = new List<int>();
        }
        foreach (int[] p in dislikes) {
            g[p[0]].Add(p[1]);
            g[p[1]].Add(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            if (color[i] == 0) {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                color[i] = 1;
                while (queue.Count > 0) {
                    int t = queue.Dequeue();
                    foreach (int next in g[t]) {
                        if (color[next] > 0 && color[next] == color[t]) {
                            return false;
                        }
                        if (color[next] == 0) {
                            color[next] = 3 ^ color[t];
                            queue.Enqueue(next);
                        }
                    }
                }
            }
        }
        return true;
    }
}
```

```C
bool possibleBipartition(int n, int** dislikes, int dislikesSize, int* dislikesColSize) {
    int color[n + 1];
    struct ListNode *g[n + 1];
    for (int i = 0; i <= n; i++) {
        color[i] = 0;
        g[i] = NULL;
    }
    for (int i = 0; i < dislikesSize; i++) {
        int a = dislikes[i][0], b = dislikes[i][1];
        struct ListNode *node = (struct ListNode *)malloc(sizeof(struct ListNode));
        node->val = a;
        node->next = g[b];
        g[b] = node;
        node = (struct ListNode *)malloc(sizeof(struct ListNode));
        node->val = b;
        node->next = g[a];
        g[a] = node;
    }
    for (int i = 1; i <= n; ++i) {
        if (color[i] == 0) {
            int queue[n];
            int head = 0, tail = 0;
            queue[tail++] = i;
            color[i] = 1;
            while (head != tail) {
                int t = queue[head++];
                for (struct ListNode *nextNode = g[t]; nextNode; nextNode = nextNode->next) {
                    int next = nextNode->val;
                    if (color[next] > 0 && color[next] == color[t]) {
                        for (int j = 0; j <= n; j++) {
                            struct ListNode * node = g[j];
                            while (node) {
                                struct ListNode * prev = node;
                                node = node->next;
                                free(prev);
                            }
                        }
                        return false;
                    }
                    if (color[next] == 0) {
                        color[next] = 3 ^ color[t];
                        queue[tail++] = next;
                    }
                }
            }
        }
    }
    for (int j = 0; j <= n; j++) {
        struct ListNode * node = g[j];
        while (node) {
            struct ListNode * prev = node;
            node = node->next;
            free(prev);
        }
    }
    return true;
}
```

```JavaScript
var possibleBipartition = function(n, dislikes) {
    const color = new Array(n + 1).fill(0);
    const g = new Array(n + 1).fill(0);
    for (let i = 0; i <= n; ++i) {
        g[i] = [];
    }
    for (const p of dislikes) {
        g[p[0]].push(p[1]);
        g[p[1]].push(p[0]);
    }
    for (let i = 1; i <= n; ++i) {
        if (color[i] === 0) {
            const queue = [i];
            color[i] = 1;
            while (queue.length !== 0) {
                const t = queue.shift();
                for (const next of g[t]) {
                    if (color[next] > 0 && color[next] === color[t]) {
                        return false;
                    }
                    if (color[next] === 0) {
                        color[next] = 3 ^ color[t];
                        queue.push(next);
                    }
                }
            }
        }
    }
    return true;
};
```

```Go
func possibleBipartition(n int, dislikes [][]int) bool {
    g := make([][]int, n)
    for _, d := range dislikes {
        x, y := d[0]-1, d[1]-1
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }
    color := make([]int, n) // 0 表示未访问该节点
    for i, c := range color {
        if c == 0 {
            q := []int{i}
            color[i] = 1
            for len(q) > 0 {
                x := q[0]
                q = q[1:]
                for _, y := range g[x] {
                    if color[y] == color[x] {
                        return false
                    }
                    if color[y] == 0 {
                        color[y] = -color[x]
                        q = append(q, y)
                    }
                }
            }
        }
    }
    return true
}
```

**复杂度分析**

-   时间复杂度：O(n+m)，其中 n 题目给定的人数，m 为给定的 dislike 数组的大小。
-   空间复杂度：O(n+m)，其中 n 题目给定的人数，m 为给定的 dislike 数组的大小。
