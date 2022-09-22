#### [](https://leetcode.cn/problems/check-array-formation-through-concatenation/solution/neng-fou-lian-jie-xing-cheng-shu-zu-by-l-rnkn//#����һ����ϣ��)����һ����ϣ��

��Ϊ���� arr ÿ������������ͬ���� pieces ������Ҳ������ͬ���������ǿ���ͨ�� arr �̶� pieces �ķ��á�ʹ�ù�ϣ�� index ��¼ pieces ���������**��Ԫ��**�������±�Ķ�Ӧ��ϵ��

���ǲ��ϵؽ� pieces �е����������� arr ���Ӧ�����ڵ�ǰ������Ԫ�� arr[i]��������������ڹ�ϣ���У�˵�������޷��� pieces ������ arr ���Ӧ��ֱ�ӷ��� false�����������ҵ���Ӧ������ pieces[j]��Ȼ������ arr[i] ��֮����������бȽϣ��ڱȽϹ����У�����ж���Ȳ�������ֱ�ӷ��� false�����ж϶���Ⱥ󣬽� i ��Ӧ������ơ�ȫ�� pieces ��ƥ��ɹ��󣬷��� true��

```Python
class Solution:
    def canFormArray(self, arr: List[int], pieces: List[List[int]]) -> bool:
        index = {p[0]: i for i, p in enumerate(pieces)}
        i = 0
        while i < len(arr):
            if arr[i] not in index:
                return False
            p = pieces[index[arr[i]]]
            if arr[i: i + len(p)] != p:
                return False
            i += len(p)
        return True

```

```C++
class Solution {
public:
    bool canFormArray(vector<int> &arr, vector<vector<int>> &pieces) {
        unordered_map<int, int> index;
        for (int i = 0; i < pieces.size(); i++) {
            index[pieces[i][0]] = i;
        }
        for (int i = 0; i < arr.size();) {
            auto it = index.find(arr[i]);
            if (it == index.end()) {
                return false;
            }
            for (int x : pieces[it->second]) {
                if (arr[i++] != x) {
                    return false;
                }
            }
        }
        return true;
    }
};

```

```Java
class Solution {
    public boolean canFormArray(int[] arr, int[][] pieces) {
        int n = arr.length, m = pieces.length;
        Map<Integer, Integer> index = new HashMap<Integer, Integer>();
        for (int i = 0; i < m; i++) {
            index.put(pieces[i][0], i);
        }
        for (int i = 0; i < n;) {
            if (!index.containsKey(arr[i])) {
                return false;
            }
            int j = index.get(arr[i]), len = pieces[j].length;
            for (int k = 0; k < len; k++) {
                if (arr[i + k] != pieces[j][k]) {
                    return false;
                }
            }
            i = i + len;
        }
        return true;
    }
}

```

```C#
public class Solution {
    public bool CanFormArray(int[] arr, int[][] pieces) {
        int n = arr.Length, m = pieces.Length;
        Dictionary<int, int> index = new Dictionary<int, int>();
        for (int i = 0; i < m; i++) {
            index.Add(pieces[i][0], i);
        }
        for (int i = 0; i < n;) {
            if (!index.ContainsKey(arr[i])) {
                return false;
            }
            int j = index[arr[i]], len = pieces[j].Length;
            for (int k = 0; k < len; k++) {
                if (arr[i + k] != pieces[j][k]) {
                    return false;
                }
            }
            i = i + len;
        }
        return true;
    }
}

```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

bool canFormArray(int* arr, int arrSize, int** pieces, int piecesSize, int* piecesColSize){
    int n = arrSize, m = piecesSize;
    HashItem *index = NULL;
    for (int i = 0; i < m; i++) {
        hashAddItem(&index, pieces[i][0], i);
    }
    for (int i = 0; i < n;) {
        if (!hashFindItem(&index, arr[i])) {
            hashFree(&index);
            return false;
        }
        int j = hashGetItem(&index, arr[i], 0);
        int len = piecesColSize[j];
        for (int k = 0; k < len; k++) {
            if (arr[i + k] != pieces[j][k]) {
                hashFree(&index);
                return false;
            }
        }
        i = i + len;
    }
    hashFree(&index);
    return true;
}

```

```JavaScript
var canFormArray = function(arr, pieces) {
    const n = arr.length, m = pieces.length;
    const index = new Map();
    for (let i = 0; i < m; i++) {
        index.set(pieces[i][0], i);
    }
    for (let i = 0; i < n;) {
        if (!index.has(arr[i])) {
            return false;
        }
        const j = index.get(arr[i]), len = pieces[j].length;
        for (let k = 0; k < len; k++) {
            if (arr[i + k] != pieces[j][k]) {
                return false;
            }
        }
        i = i + len;
    }
    return true;
};

```

```Go
func canFormArray(arr []int, pieces [][]int) bool {
    index := make(map[int]int, len(pieces))
    for i, p := range pieces {
        index[p[0]] = i
    }
    for i := 0; i < len(arr); {
        j, ok := index[arr[i]]
        if !ok {
            return false
        }
        for _, x := range pieces[j] {
            if arr[i] != x {
                return false
            }
            i++
        }
    }
    return true
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ������ arr �ĳ��ȡ�
-   �ռ临�Ӷȣ�O(n)�������ϣ����Ҫ O(n) �Ŀռ䡣
