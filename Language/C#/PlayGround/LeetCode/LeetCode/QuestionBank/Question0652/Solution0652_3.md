#### ����һ��ʹ�����л�����Ψһ��ʾ

**˼·���㷨**

һ�������뵽�ķ����ǽ�ÿһ�������������л�����һ���ַ��������ұ�֤��

-   ��ͬ�������ᱻ���л�����ͬ���Ӵ���
-   ��ͬ�������ᱻ���л��ɲ�ͬ���Ӵ���

��ô����ֻҪʹ��һ����ϣ��洢�������������л���������ĳһ����������˳���һ�Σ����Ǿͷ�����һ���ظ�������

���л�һ�ö������ķ������Բο�[����ָ Offer 37. ���л����������Ĺٷ����](https://leetcode.cn/problems/xu-lie-hua-er-cha-shu-lcof/solution/xu-lie-hua-er-cha-shu-by-leetcode-soluti-4duq/)������Ҳ�������ֳ��õ����л�������

-   ��һ�ַ�����ʹ�ò�������ķ����������л�������**ʾ�� 1**�еĶ������������л�Ϊ��

    1,2,3,4,null,2,4,null,null,4

    ��Ҳ������ƽ̨�ϲ��Դ���ʱ����һ�ö�������Ĭ�Ϸ�����

-   �ڶ��ַ�����ʹ�õݹ�ķ����������л������ǿ��Խ�һ���� xxx Ϊ���ڵ�ֵ���������л�Ϊ��

    x(�����������л����)(�����������л����)

    ���������ֱ�ݹ�ؽ������л����������Ϊ�գ���ô���л����Ϊ�մ���**ʾ�� 1**�еĶ������������л�Ϊ��

    1(2(4()())())(3(2(4()())())(4()()))


����Ĵ���ʹ�õ��ǵڶ��ַ�����������Ҫʹ��һ����ϣӳ�� seen �洢���е�������ӳ�䡣����ڼ�������ʱ��ͨ�� seen ���ҵ����Ѿ����ֹ������У���ô�Ϳ��԰Ѷ�Ӧ�������ŵ���ϣ���� repeat �У������Ϳ��Ա�֤ͬһ����ظ�����ֻ�ᱻ�洢�ڴ���һ�Ρ�

**����**

```C++
class Solution {
public:
    vector<TreeNode*> findDuplicateSubtrees(TreeNode* root) {
        dfs(root);
        return {repeat.begin(), repeat.end()};
    }

    string dfs(TreeNode* node) {
        if (!node) {
            return "";
        }
        string serial = to_string(node->val) + "(" + dfs(node->left) + ")(" + dfs(node->right) + ")";
        if (auto it = seen.find(serial); it != seen.end()) {
            repeat.insert(it->second);
        }
        else {
            seen[serial] = node;
        }
        return serial;
    }

private:
    unordered_map<string, TreeNode*> seen;
    unordered_set<TreeNode*> repeat;
};

```

```Java
class Solution {
    Map<String, TreeNode> seen = new HashMap<String, TreeNode>();
    Set<TreeNode> repeat = new HashSet<TreeNode>();

    public List<TreeNode> findDuplicateSubtrees(TreeNode root) {
        dfs(root);
        return new ArrayList<TreeNode>(repeat);
    }

    public String dfs(TreeNode node) {
        if (node == null) {
            return "";
        }
        StringBuilder sb = new StringBuilder();
        sb.append(node.val);
        sb.append("(");
        sb.append(dfs(node.left));
        sb.append(")(");
        sb.append(dfs(node.right));
        sb.append(")");
        String serial = sb.toString();
        if (seen.containsKey(serial)) {
            repeat.add(seen.get(serial));
        } else {
            seen.put(serial, node);
        }
        return serial;
    }
}

```

```C#
public class Solution {
    Dictionary<string, TreeNode> seen = new Dictionary<string, TreeNode>();
    ISet<TreeNode> repeat = new HashSet<TreeNode>();

    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        DFS(root);
        return new List<TreeNode>(repeat);
    }

    public string DFS(TreeNode node) {
        if (node == null) {
            return "";
        }
        StringBuilder sb = new StringBuilder();
        sb.Append(node.val);
        sb.Append("(");
        sb.Append(DFS(node.left));
        sb.Append(")(");
        sb.Append(DFS(node.right));
        sb.Append(")");
        string serial = sb.ToString();
        if (seen.ContainsKey(serial)) {
            repeat.Add(seen[serial]);
        } else {
            seen.Add(serial, node);
        }
        return serial;
    }
}

```

```Python3
class Solution:
    def findDuplicateSubtrees(self, root: Optional[TreeNode]) -> List[Optional[TreeNode]]:
        def dfs(node: Optional[TreeNode]) -> str:
            if not node:
                return ""
            
            serial = "".join([str(node.val), "(", dfs(node.left), ")(", dfs(node.right), ")"])
            if (tree := seen.get(serial, None)):
                repeat.add(tree)
            else:
                seen[serial] = node
            
            return serial
        
        seen = dict()
        repeat = set()

        dfs(root)
        return list(repeat)

```

```C
typedef struct {
    char *key;
    struct TreeNode *val;
    UT_hash_handle hh;
} HashMapItem; 

typedef struct {
    void *key;
    UT_hash_handle hh;
} HashSetItem; 

char* dfs(struct TreeNode* node, HashMapItem **seen, HashSetItem **repeat) {
    if (!node) {
        return "";
    }
    char *str1 = dfs(node->left, seen, repeat);
    char *str2 = dfs(node->right, seen, repeat);
    char *serial = (char *)malloc(sizeof(char *) * (8 + strlen(str1) + strlen(str2)));
    sprintf(serial, "%d(%s)(%s)", node->val, str1, str2);
    HashMapItem *pHashMapEntry = NULL;
    HASH_FIND_STR(*seen, serial, pHashMapEntry);
    if (pHashMapEntry) {
        HashSetItem *pHashSetEntry = NULL;
        HASH_FIND_PTR(*repeat, &(pHashMapEntry->val), pHashSetEntry);
        if (pHashSetEntry == NULL) {
            pHashSetEntry = (HashSetItem *)malloc(sizeof(HashSetItem));
            pHashSetEntry->key = (void *)pHashMapEntry->val;
            HASH_ADD_PTR(*repeat, key, pHashSetEntry);
        }
    } else {
        pHashMapEntry = (HashMapItem *)malloc(sizeof(HashMapItem));
        pHashMapEntry->key = serial;
        pHashMapEntry->val = node;
        HASH_ADD_STR(*seen, key, pHashMapEntry);
    }
    return serial;
}

struct TreeNode** findDuplicateSubtrees(struct TreeNode* root, int* returnSize){
    HashMapItem *seen = NULL;
    HashSetItem *repeat = NULL;
    dfs(root, &seen, &repeat);

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
        free(curMap->key);
        free(curMap);             
    }
    return ret;
}

```

```Golang
func findDuplicateSubtrees(root *TreeNode) []*TreeNode {
    repeat := map[*TreeNode]struct{}{}
    seen := map[string]*TreeNode{}
    var dfs func(*TreeNode) string
    dfs = func(node *TreeNode) string {
        if node == nil {
            return ""
        }
        serial := fmt.Sprintf("%d(%s)(%s)", node.Val, dfs(node.Left), dfs(node.Right))
        if n, ok := seen[serial]; ok {
            repeat[n] = struct{}{}
        } else {
            seen[serial] = node
        }
        return serial
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
    const dfs = (node) => {
        if (!node) {
            return "";
        }
        let sb = '';
        sb += node.val;
        sb += "(";
        sb += dfs(node.left);
        sb += ")(";
        sb += dfs(node.right);
        sb += ")";
        if (seen.has(sb)) {
            repeat.add(seen.get(sb));
        } else {
            seen.set(sb, node);
        }
        return sb;
    }
    dfs(root);
    return [...repeat];
};

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n^2)������ n �����нڵ����Ŀ���������£���������״�Ľṹ����ÿһ���ڵ㶼�����������������еĻ�������������� 9 ���ַ������������Լ��ڵ㱾���ֵ������ô�������������г���֮��Ϊ ��i\=1n9n\=O(n^2^)���������Щ���о���Ҫ O(n^2) ��ʱ�䡣

-   �ռ临�Ӷȣ�O(n^2)����Ϊ��ϣ����Ҫʹ�õĿռ䡣
