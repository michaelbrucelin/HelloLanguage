#### [](https://leetcode.cn/problems/fruit-into-baskets/solution/shui-guo-cheng-lan-by-leetcode-solution-1uyu//#����һ����������)����һ����������

**˼·���㷨**

���ǿ���ʹ�û������ڽ�����⣬left �� right �ֱ��ʾ����Ҫ��Ĵ��ڵ����ұ߽磬ͬʱ����ʹ�ù�ϣ��洢��������ڵ����Լ����ֵĴ�����

����ÿ�ν� right �ƶ�һ��λ�ã����� fruits[right] �����ϣ�������ʱ��ϣ������Ҫ�󣨼���ϣ���г��ֳ���������ֵ�ԣ�����ô������Ҫ�����ƶ� left������ fruits[left] �ӹ�ϣ�����Ƴ���ֱ����ϣ������Ҫ��Ϊֹ��

��Ҫע����ǣ��� fruits[left] �ӹ�ϣ�����Ƴ������ fruits[left] �ڹ�ϣ���еĳ��ִ�������Ϊ 0����Ҫ����Ӧ�ļ�ֵ�Դӹ�ϣ�����Ƴ���

**����**

```C++
class Solution {
public:
    int totalFruit(vector<int>& fruits) {
        int n = fruits.size();
        unordered_map<int, int> cnt;

        int left = 0, ans = 0;
        for (int right = 0; right < n; ++right) {
            ++cnt[fruits[right]];
            while (cnt.size() > 2) {
                auto it = cnt.find(fruits[left]);
                --it->second;
                if (it->second == 0) {
                    cnt.erase(it);
                }
                ++left;
            }
            ans = max(ans, right - left + 1);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int totalFruit(int[] fruits) {
        int n = fruits.length;
        Map<Integer, Integer> cnt = new HashMap<Integer, Integer>();

        int left = 0, ans = 0;
        for (int right = 0; right < n; ++right) {
            cnt.put(fruits[right], cnt.getOrDefault(fruits[right], 0) + 1);
            while (cnt.size() > 2) {
                cnt.put(fruits[left], cnt.get(fruits[left]) - 1);
                if (cnt.get(fruits[left]) == 0) {
                    cnt.remove(fruits[left]);
                }
                ++left;
            }
            ans = Math.max(ans, right - left + 1);
        }
        return ans;
    }
}
```

```C#
public class Solution {
    public int TotalFruit(int[] fruits) {
        int n = fruits.Length;
        IDictionary<int, int> cnt = new Dictionary<int, int>();

        int left = 0, ans = 0;
        for (int right = 0; right < n; ++right) {
            cnt.TryAdd(fruits[right], 0);
            ++cnt[fruits[right]];
            while (cnt.Count > 2) {
                --cnt[fruits[left]];
                if (cnt[fruits[left]] == 0) {
                    cnt.Remove(fruits[left]);
                }
                ++left;
            }
            ans = Math.Max(ans, right - left + 1);
        }
        return ans;
    }
}
```

```Python
class Solution:
    def totalFruit(self, fruits: List[int]) -> int:
        cnt = Counter()

        left = ans = 0
        for right, x in enumerate(fruits):
            cnt[x] += 1
            while len(cnt) > 2:
                cnt[fruits[left]] -= 1
                if cnt[fruits[left]] == 0:
                    cnt.pop(fruits[left])
                left += 1
            ans = max(ans, right - left + 1)
        
        return ans
```

```JavaScript
var totalFruit = function(fruits) {
    const n = fruits.length;
    const cnt = new Map();

    let left = 0, ans = 0;
    for (let right = 0; right < n; ++right) {
        cnt.set(fruits[right], (cnt.get(fruits[right]) || 0) + 1);
        while (cnt.size > 2) {
            cnt.set(fruits[left], cnt.get(fruits[left]) - 1);
            if (cnt.get(fruits[left]) == 0) {
                cnt.delete(fruits[left]);
            }
            ++left;
        }
        ans = Math.max(ans, right - left + 1);
    }
    return ans;
};
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

int totalFruit(int* fruits, int fruitsSize){
    HashItem *cnt = NULL;
    int left = 0, ans = 0;
    for (int right = 0; right < fruitsSize; ++right) {
        hashSetItem(&cnt, fruits[right], hashGetItem(&cnt, fruits[right], 0) + 1);
        while (HASH_COUNT(cnt) > 2) {
            HashItem *pEntry = hashFindItem(&cnt, fruits[left]);
            pEntry->val--;
            if (pEntry->val == 0) {
                HASH_DEL(cnt, pEntry);
                free(pEntry);
            }
            ++left;
        }
        ans = MAX(ans, right - left + 1);
    }
    hashFree(&cnt);
    return ans;
}
```

```Go
func totalFruit(fruits []int) (ans int) {
    cnt := map[int]int{}
    left := 0
    for right, x := range fruits {
        cnt[x]++
        for len(cnt) > 2 {
            y := fruits[left]
            cnt[y]--
            if cnt[y] == 0 {
                delete(cnt, y)
            }
            left++
        }
        ans = max(ans, right-left+1)
    }
    return
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ������ fruits �ĳ��ȡ�
-   �ռ临�Ӷȣ�O(1)����ϣ����������������ֵ�ԣ����Կ���ʹ���˳�������Ŀռ䡣
