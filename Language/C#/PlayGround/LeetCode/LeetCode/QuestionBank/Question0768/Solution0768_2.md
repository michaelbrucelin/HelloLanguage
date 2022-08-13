#### 方法一：排序 + 哈希表

**思路**

记数组 arr 长度为 n，排完序的数组为 sortedArr。首先，将原数组分为一块，肯定是可行的。原数组直接排序，和将它分为一块后再排序，得到的数组是相同的。那么，如何判断一个数组是否能分为符合题意的两块呢？如果一个数组能分为两块，那么一定能找到一个下标 k，这个下标将数组分为两个非空子数组 arr\[0,…,k\] 和 arr\[k+1,…,n−1\]，使得 arr\[0,…,k\] 和 sortedArr\[0,…,k\] 的元素频次相同，arr\[k+1,…,n−1\] 和 sortedArr\[k+1,…,n−1\] 的元素频次相同。判断能否分为更多的块时同理。这个判断过程可以从左至右同时遍历 arr 和 sortedArr，并用一个哈希表 cnt 来记录两个数组元素频次之差。当遍历到某个下标时，如果 cnt 内所有键的值均为 0，则表示划分出了一个新的块，最后记录有多少下标可以使得 cnt 内所有键的值均为 0 即可。

**代码**

```Python3
class Solution:
    def maxChunksToSorted(self, arr: List[int]) -> int:
        cnt = Counter()
        res = 0
        for x, y in zip(arr, sorted(arr)):
            cnt[x] += 1
            if cnt[x] == 0:
                del cnt[x]
            cnt[y] -= 1
            if cnt[y] == 0:
                del cnt[y]
            if len(cnt) == 0:
                res += 1
        return res

```

```Java
class Solution {
    public int maxChunksToSorted(int[] arr) {
        Map<Integer, Integer> cnt = new HashMap<Integer, Integer>();
        int res = 0;
        int[] sortedArr = new int[arr.length];
        System.arraycopy(arr, 0, sortedArr, 0, arr.length);
        Arrays.sort(sortedArr);
        for (int i = 0; i < sortedArr.length; i++) {
            int x = arr[i], y = sortedArr[i];
            cnt.put(x, cnt.getOrDefault(x, 0) + 1);
            if (cnt.get(x) == 0) {
                cnt.remove(x);
            }
            cnt.put(y, cnt.getOrDefault(y, 0) - 1);
            if (cnt.get(y) == 0) {
                cnt.remove(y);
            }
            if (cnt.isEmpty()) {
                res++;
            }
        }
        return res;
    }
}

```

```C#
public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        int res = 0;
        int[] sortedArr = new int[arr.Length];
        Array.Copy(arr, 0, sortedArr, 0, arr.Length);
        Array.Sort(sortedArr);
        for (int i = 0; i < sortedArr.Length; i++) {
            int x = arr[i], y = sortedArr[i];
            if (!cnt.ContainsKey(x)) {
                cnt.Add(x, 0);
            }
            cnt[x]++;
            if (cnt[x] == 0) {
                cnt.Remove(x);
            }
            if (!cnt.ContainsKey(y)) {
                cnt.Add(y, 0);
            }
            cnt[y]--;
            if (cnt[y] == 0) {
                cnt.Remove(y);
            }
            if (cnt.Count == 0) {
                res++;
            }
        }
        return res;
    }
}

```

```C++
class Solution {
public:
    int maxChunksToSorted(vector<int>& arr) {
        unordered_map<int, int> cnt;
        int res = 0;
        vector<int> sortedArr = arr;
        sort(sortedArr.begin(), sortedArr.end());
        for (int i = 0; i < sortedArr.size(); i++) {
            int x = arr[i], y = sortedArr[i];
            cnt[x]++;
            if (cnt[x] == 0) {
                cnt.erase(x);
            }
            cnt[y]--;
            if (cnt[y] == 0) {
                cnt.erase(y);
            }
            if (cnt.size() == 0) {
                res++;
            }
        }
        return res;
    }
};

```

```C
typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem;

static inline int cmp(const void *pa, const void *pb) {
    return *(int *)pa - *(int *)pb;
}

int maxChunksToSorted(int* arr, int arrSize){
    HashItem *cnt = NULL;
    int res = 0;
    int *sortedArr = (int *)malloc(sizeof(int) * arrSize);
    memcpy(sortedArr, arr, sizeof(int) * arrSize);
    qsort(sortedArr, arrSize, sizeof(int), cmp);
    for (int i = 0; i < arrSize; i++) {
        int x = arr[i], y = sortedArr[i];
        HashItem *pEntry = NULL;
        HASH_FIND_INT(cnt, &x, pEntry);
        if (pEntry == NULL) {
            pEntry = (HashItem *)malloc(sizeof(HashItem));
            pEntry->key = x;
            pEntry->val = 0;
            HASH_ADD_INT(cnt, key, pEntry);
        }
        pEntry->val++;
        if (pEntry->val == 0) {
            HASH_DEL(cnt, pEntry);
            free(pEntry);
        }
        pEntry = NULL;
        HASH_FIND_INT(cnt, &y, pEntry);
        if (pEntry == NULL) {
            pEntry = (HashItem *)malloc(sizeof(HashItem));
            pEntry->key = y;
            pEntry->val = 0;
            HASH_ADD_INT(cnt, key, pEntry);
        }
        pEntry->val--;
        if (pEntry->val == 0) {
            HASH_DEL(cnt, pEntry);
            free(pEntry);
        }
        if (HASH_COUNT(cnt) == 0) {
            res++;
        }
    }
    HashItem *cur = NULL, *tmp = NULL;
    HASH_ITER(hh, cnt, cur, tmp) {
        HASH_DEL(cnt, cur);  
        free(cur);  
    }
    return res;
}

```

```Golang
func maxChunksToSorted(arr []int) (ans int) {
    cnt := map[int]int{}
    b := append([]int{}, arr...)
    sort.Ints(b)
    for i, x := range arr {
        cnt[x]++
        if cnt[x] == 0 {
            delete(cnt, x)
        }
        y := b[i]
        cnt[y]--
        if cnt[y] == 0 {
            delete(cnt, y)
        }
        if len(cnt) == 0 {
            ans++
        }
    }
    return
}

```

```JavaScript
var maxChunksToSorted = function(arr) {
    const cnt = new Map();
    let res = 0;
    const sortedArr = new Array(arr.length).fill(0);
    sortedArr.splice(0, arr.length, ...arr);
    sortedArr.sort((a, b) => a - b);
    for (let i = 0; i < sortedArr.length; i++) {
        const x = arr[i], y = sortedArr[i];
        cnt.set(x, (cnt.get(x) || 0) + 1);
        if (cnt.get(x) === 0) {
            cnt.delete(x);
        }
        cnt.set(y, (cnt.get(y) || 0) - 1);
        if (cnt.get(y) === 0) {
            cnt.delete(y);
        }
        if (cnt.size === 0) {
            res++;
        }
    }
    return res;
};

```

**复杂度分析**

-   时间复杂度：O(nlog⁡n)O(n \\log n)O(nlogn)，其中 nnn 是输入数组 arr\\textit{arr}arr 的长度。排序需要消耗 O(nlog⁡n)O(n \\log n)O(nlogn) 的时间复杂度，遍历一遍消耗 O(n)O(n)O(n) 的时间复杂度。
    
-   空间复杂度：O(n)O(n)O(n)。排序完的数组和哈希表均需要消耗 O(n)O(n)O(n) 的空间复杂度。
