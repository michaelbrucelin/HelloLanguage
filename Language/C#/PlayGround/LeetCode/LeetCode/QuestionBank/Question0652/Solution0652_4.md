#### 方法二：使用三元组进行唯一表示

**思路与算法**

通过方法一中的递归序列化技巧，我们可以进一步进行优化。

我们可以用一个三元组直接表示一棵子树，即 (x,l,r)，它们分别表示：

-   根节点的值为 x；

-   左子树的**序号**为 l；

-   右子树的**序号**为 r。


这里的「序号」指的是：每当我们发现一棵新的子树，就给这棵子树一个序号，用来表示其结构。那么两棵树是重复的，当且仅当它们对应的三元组完全相同。

使用「序号」的好处在于同时减少了时间复杂度和空间复杂度。方法一的瓶颈在于生成的序列会变得非常长，而使用序号替换整个左子树和右子树的序列，可以使得每一个节点只使用常数大小的空间。

**代码**

```C++
class Solution {
public:
    vector<TreeNode*> findDuplicateSubtrees(TreeNode* root) {
        dfs(root);
        return {repeat.begin(), repeat.end()};
    }

    int dfs(TreeNode* node) {
        if (!node) {
            return 0;
        }
        auto tri = tuple{node->val, dfs(node->left), dfs(node->right)};
        if (auto it = seen.find(tri); it != seen.end()) {
            repeat.insert(it->second.first);
            return it->second.second;
        }
        else {
            seen[tri] = {node, ++idx};
            return idx;
        }
    }

private:
    static constexpr auto tri_hash = [fn = hash<int>()](const tuple<int, int, int>& o) -> size_t {
        auto&& [x, y, z] = o;
        return (fn(x) << 24) ^ (fn(y) << 8) ^ fn(z);
    };

    unordered_map<tuple<int, int, int>, pair<TreeNode*, int>, decltype(tri_hash)> seen{0, tri_hash};
    unordered_set<TreeNode*> repeat;
    int idx = 0;
};

```

```Java
class Solution {
    Map<String, Pair<TreeNode, Integer>> seen = new HashMap<String, Pair<TreeNode, Integer>>();
    Set<TreeNode> repeat = new HashSet<TreeNode>();
    int idx = 0;

    public List<TreeNode> findDuplicateSubtrees(TreeNode root) {
        dfs(root);
        return new ArrayList<TreeNode>(repeat);
    }

    public int dfs(TreeNode node) {
        if (node == null) {
            return 0;
        }
        int[] tri = {node.val, dfs(node.left), dfs(node.right)};
        String hash = Arrays.toString(tri);
        if (seen.containsKey(hash)) {
            Pair<TreeNode, Integer> pair = seen.get(hash);
            repeat.add(pair.getKey());
            return pair.getValue();
        } else {
            seen.put(hash, new Pair<TreeNode, Integer>(node, ++idx));
            return idx;
        }
    }
}

```

```C#
public class Solution {
    Dictionary<string, Tuple<TreeNode, int>> seen = new Dictionary<string, Tuple<TreeNode, int>>();
    ISet<TreeNode> repeat = new HashSet<TreeNode>();
    int idx = 0;

    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        DFS(root);
        return new List<TreeNode>(repeat);
    }

    public int DFS(TreeNode node) {
        if (node == null) {
            return 0;
        }
        Tuple<int, int, int> tri = new Tuple<int, int, int>(node.val, DFS(node.left), DFS(node.right));
        string hash = tri.ToString();
        if (seen.ContainsKey(hash)) {
            Tuple<TreeNode, int> pair = seen[hash];
            repeat.Add(pair.Item1);
            return pair.Item2;
        } else {
            seen.Add(hash, new Tuple<TreeNode, int>(node, ++idx));
            return idx;
        }
    }
}

```

```Python3
class Solution:
    def findDuplicateSubtrees(self, root: Optional[TreeNode]) -> List[Optional[TreeNode]]:
        def dfs(node: Optional[TreeNode]) -> int:
            if not node:
                return 0
            
            tri = (node.val, dfs(node.left), dfs(node.right))
            if tri in seen:
                (tree, index) = seen[tri]
                repeat.add(tree)
                return index
            else:
                nonlocal idx
                idx += 1
                seen[tri] = (node, idx)
                return idx
        
        idx = 0
        seen = dict()
        repeat = set()

        dfs(root)
        return list(repeat)

```

```C
#define MAX_STR_LEN 32

static inline char* tri_hash(int x, int y, int z) {
    char *str = (char *)malloc(sizeof(char) * MAX_STR_LEN);
    sprintf(str, "%d,%d,%d", x, y, z);
    return str;
}

typedef struct {
    char key[MAX_STR_LEN];
    struct TreeNode *node;
    int idx;
    UT_hash_handle hh;
} HashMapItem; 

typedef struct {
    void *key;
    UT_hash_handle hh;
} HashSetItem; 

int dfs(struct TreeNode* node, HashMapItem **seen, HashSetItem **repeat, int *idx) {
    if (!node) {
        return 0;
    }
    int ret1 = dfs(node->left, seen, repeat, idx);
    int ret2 = dfs(node->right, seen, repeat, idx);
    HashMapItem *pHashMapEntry = NULL;
    char *hashKey = tri_hash(node->val, ret1, ret2);
    HASH_FIND_STR(*seen, hashKey, pHashMapEntry);
    if (pHashMapEntry) {
        HashSetItem *pHashSetEntry = NULL;
        HASH_FIND_PTR(*repeat, &(pHashMapEntry->node), pHashSetEntry);
        if (pHashSetEntry == NULL) {
            pHashSetEntry = (HashSetItem *)malloc(sizeof(HashSetItem));
            pHashSetEntry->key = (void *)pHashMapEntry->node;
            HASH_ADD_PTR(*repeat, key, pHashSetEntry);
        }
        free(hashKey);
        return pHashMapEntry->idx;
    } else {
        pHashMapEntry = (HashMapItem *)malloc(sizeof(HashMapItem));
        strcpy(pHashMapEntry->key, hashKey);
        pHashMapEntry->node = node;
        pHashMapEntry->idx = ++(*idx);
        HASH_ADD_STR(*seen, key, pHashMapEntry);
        free(hashKey);
        return *idx;
    }
}

struct TreeNode** findDuplicateSubtrees(struct TreeNode* root, int* returnSize){
    HashMapItem *seen = NULL;
    HashSetItem *repeat = NULL;
    int idx = 0;
    dfs(root, &seen, &repeat, &idx);

    int count = HASH_COUNT(repeat), pos = 0;
    struct TreeNode** ret = (struct TreeNode**)malloc(sizeof(struct TreeNode*) * count);
    HashSetItem *cur, *tmp;
    HASH_ITER(hh, repeat, cur, tmp) {
        ret[pos++] = (struct TreeNode*)cur->key;
        HASH_DEL(repeat, cur);
        free(cur);            
    }
    *returnSize = count;
    HashMapItem *curMap, *tmpMap;
    HASH_ITER(hh, seen, curMap, tmpMap) {
        HASH_DEL(seen, curMap);  
        free(curMap);             
    }
    return ret;
}

```

```Golang
func findDuplicateSubtrees(root *TreeNode) []*TreeNode {
    type pair struct {
        node *TreeNode
        idx  int
    }
    repeat := map[*TreeNode]struct{}{}
    seen := map[[3]int]pair{}
    idx := 0
    var dfs func(*TreeNode) int
    dfs = func(node *TreeNode) int {
        if node == nil {
            return 0
        }
        tri := [3]int{node.Val, dfs(node.Left), dfs(node.Right)}
        if p, ok := seen[tri]; ok {
            repeat[p.node] = struct{}{}
            return p.idx
        }
        idx++
        seen[tri] = pair{node, idx}
        return idx
    }
    dfs(root)
    ans := make([]*TreeNode, 0, len(repeat))
    for node := range repeat {
        ans = append(ans, node)
    }
    return ans
}

```

```JavaScript
var findDuplicateSubtrees = function(root) {
    const seen = new Map();
    const repeat = new Set();
    let idx = 0;
    const dfs = (node) => {
        if (!node) {
            return 0;
        }
        const tri = [node.val, dfs(node.left), dfs(node.right)];
        const hash = tri.toString();
        if (seen.has(hash)) {
            const pair = seen.get(hash);
            repeat.add(pair[0]);
            return pair[1];
        } else {
            seen.set(hash, [node, ++idx]);
            return idx;
        }
    }
    dfs(root);
    return [...repeat];
};

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是树中节点的数目。

-   空间复杂度：O(n)，即为哈希表需要使用的空间。
