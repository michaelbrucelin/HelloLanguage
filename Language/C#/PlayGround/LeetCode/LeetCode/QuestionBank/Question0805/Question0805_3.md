#### [方法二：动态规划](https://leetcode.cn/problems/split-array-with-same-average/solutions/1966163/shu-zu-de-jun-zhi-fen-ge-by-leetcode-sol-f630/)

**思路与算法**

根据方法一的结论，设数组 nums 的平均数为 $avg = \frac{nums}{n}$，我们移动了 k 个元素到数组 A 中，则此时已经数组 A 的平均数也为 avg，则此时数组 A 的元素之和为 $sum(A) = k \times avg$，则该问题可以等价于在数组中取 k 个数，使得其和为 $k \times avg$。对应的「[0-1背包问题](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fdp%2Fknapsack%2F)」则为是否可以取 k 件物品使得背包的重量为 $k \times avg$。我们设 dp[i][x] 表示当前已从数组 nums 取出 i 个元素构成的和为 x 的可能性：
-   如果 dp[i][x]=true，表示当前已经遍历过的元素中可以取出 i 个元素构成的和为 x；
-   如果 dp[i][x]=false，表示当前已经遍历过的元素中不存在取出 i 个元素的和等于 x；

假设前 j−1 个元素中存在长度为 i 的子集且子集的和为 x，则此时 dp[i][x]=true，我们当前遍历 nums[j] 时，则可以推出一定存在长度为 i+1 的子集且满足子集的和为 x+nums[j]，可以得到状态转移方程为：
$dp[i+1][x+nums[j]]=dp[i][x]$

根据题意可知：$\dfrac{sum(A)}{k} = \dfrac{sum(nums)}{n}$，可以变换为: $sum(A) \times n = sum(\textit{nums}) \times k$，所以我们只需要找到一个元素个数为 k 的子集 A 满足上述条件即可，因此我们利用上述递推公式求出所有可能长度的子集和组合即可，此时需要的时间复杂度约为 $n^2 \times sum(nums)$，按照题目给定的测试用例可能会超时，所以需要一些减枝技巧，具体的减枝技巧如下:
-   根据题意可以推出 $sum(A) = \dfrac{sum(nums) \times k}{n}$，则此时如果满足题目要求，则一定存在整数 $k \in [1,n]$，使得 $\big[sum(nums) \times k\big] \bmod n = 0$，因此我们可以提前是否存在 k 满足上述要求，如果不存在则可以提前终止。
-   根据题目要求可以划分为两个子数组 A,B，则可以知道两个子数组中一定存在一个数组的长度小于等于 $\dfrac{n}{2}$，因此我们只需检测数组长度小于等于 $\dfrac{n}{2}$ 的子数组中是否存在其和满足 $subsum \times n = nums \times k$ 即可。

**代码**

```python
class Solution:
    def splitArraySameAverage(self, nums: List[int]) -> bool:
        n = len(nums)
        m = n // 2
        s = sum(nums)
        if all(s * i % n for i in range(1, m + 1)):
            return False

        dp = [set() for _ in range(m + 1)]
        dp[0].add(0)
        for num in nums:
            for i in range(m, 0, -1):
                for x in dp[i - 1]:
                    curr = x + num
                    if curr * n == s * i:
                        return True
                    dp[i].add(curr)
        return False
```

```cpp
class Solution {
public:
    bool splitArraySameAverage(vector<int>& nums) {
        int n = nums.size(), m = n / 2;
        int sum = accumulate(nums.begin(), nums.end(), 0);
        bool isPossible = false;
        for (int i = 1; i <= m; i++) {
            if (sum * i % n == 0) {
                isPossible = true;
                break;
            }
        }  
        if (!isPossible) {
            return false;
        }
        vector<unordered_set<int>> dp(m + 1);
        dp[0].insert(0);
        for (int num: nums) {
            for (int i = m; i >= 1; i--) {
                for (int x: dp[i - 1]) {
                    int curr = x + num;
                    if (curr * n == sum * i) {
                        return true;
                    }
                    dp[i].emplace(curr);
                } 
            }
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean splitArraySameAverage(int[] nums) {
        if (nums.length == 1) {
            return false;
        }
        int n = nums.length, m = n / 2;
        int sum = 0;
        for (int num : nums) {
            sum += num;
        }
        boolean isPossible = false;
        for (int i = 1; i <= m; i++) {
            if (sum * i % n == 0) {
                isPossible = true;
                break;
            }
        }  
        if (!isPossible) {
            return false;
        }
        Set<Integer>[] dp = new Set[m + 1];
        for (int i = 0; i <= m; i++) {
            dp[i] = new HashSet<Integer>();
        }
        dp[0].add(0);
        for (int num : nums) {
            for (int i = m; i >= 1; i--) {
                for (int x : dp[i - 1]) {
                    int curr = x + num;
                    if (curr * n == sum * i) {
                        return true;
                    }
                    dp[i].add(curr);
                } 
            }
        }
        return false;
    }
}
```

```c#
public class Solution {
    public bool SplitArraySameAverage(int[] nums) {
        if (nums.Length == 1) {
            return false;
        }
        int n = nums.Length, m = n / 2;
        int sum = 0;
        foreach (int num in nums) {
            sum += num;
        }
        bool isPossible = false;
        for (int i = 1; i <= m; i++) {
            if (sum * i % n == 0) {
                isPossible = true;
                break;
            }
        }  
        if (!isPossible) {
            return false;
        }
        ISet<int>[] dp = new ISet<int>[m + 1];
        for (int i = 0; i <= m; i++) {
            dp[i] = new HashSet<int>();
        }
        dp[0].Add(0);
        foreach (int num in nums) {
            for (int i = m; i >= 1; i--) {
                foreach (int x in dp[i - 1]) {
                    int curr = x + num;
                    if (curr * n == sum * i) {
                        return true;
                    }
                    dp[i].Add(curr);
                } 
            }
        }
        return false;
    }
}
```

```c
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

bool splitArraySameAverage(int* nums, int numsSize) {
    int n = numsSize, m = n / 2;
    int sum = 0;
    for (int i = 0; i < numsSize; i++) {
        sum += nums[i];
    }
    bool isPossible = false;
    for (int i = 1; i <= m; i++) {
        if (sum * i % n == 0) {
            isPossible = true;
            break;
        }
    }  
    if (!isPossible) {
        return false;
    }
    HashItem *dp[m + 1];
    for (int i = 0; i <= m; i++) {
        dp[i] = NULL;
    }
    hashAddItem(&dp[0], 0);
    for (int j = 0; j < numsSize; j++) {
        for (int i = m; i >= 1; i--) {
            for (HashItem *pEntry = dp[i - 1]; pEntry != NULL; pEntry = pEntry->hh.next) {
                int curr = pEntry->key + nums[j];
                if (curr * n == sum * i) {
                    return true;
                }
                hashAddItem(&dp[i], curr);
            } 
        }
    }
    for (int i = 0; i <= m; i++) {
        hashFree(&dp[i]);
    }
    return false;
}
```

```javascript
var splitArraySameAverage = function(nums) {
    if (nums.length === 1) {
        return false;
    }
    const n = nums.length, m = Math.floor(n / 2);
    let sum = 0;
    for (const num of nums) {
        sum += num;
    }
    let isPossible = false;
    for (let i = 1; i <= m; i++) {
        if (sum * i % n === 0) {
            isPossible = true;
            break;
        }
    }  
    if (!isPossible) {
        return false;
    }
    const dp = new Array(m + 1).fill(0).map(() => new Set());
    dp[0].add(0);
    for (const num of nums) {
        for (let i = m; i >= 1; i--) {
            for (const x of dp[i - 1]) {
                let curr = x + num;
                if (curr * n === sum * i) {
                    return true;
                }
                dp[i].add(curr);
            } 
        }
    }
    return false;
};
```

```go
func splitArraySameAverage(nums []int) bool {
    sum := 0
    for _, x := range nums {
        sum += x
    }

    n := len(nums)
    m := n / 2
    isPossible := false
    for i := 1; i <= m; i++ {
        if sum*i%n == 0 {
            isPossible = true
            break
        }
    }
    if !isPossible {
        return false
    }

    dp := make([]map[int]bool, m+1)
    for i := range dp {
        dp[i] = map[int]bool{}
    }
    dp[0][0] = true
    for _, num := range nums {
        for i := m; i >= 1; i-- {
            for x := range dp[i-1] {
                curr := x + num
                if curr*n == sum*i {
                    return true
                }
                dp[i][curr] = true
            }
        }
    }
    return false
}
```

**复杂度分析**

-   时间复杂度：$O(n^2 \times sum(nums))$，其中 n 表示数组的长度，$sum(nums)$ 表示数组 nums 的和。我们需要求出给定长度下所有可能的子集元素之和，数组的长度为 n，每种长度下子集的和最多有 $sum(nums)$ 个，因此总的时间复杂度为 $O(n^2 \times sum(nums))$。
-   空间复杂度：$O(n \times sum(nums))$。一共有 n 种长度的子集，每种长度的子集和最多有 $sum(nums)$ 个，因此需要的空间为 $O(n \times sum(nums))$。
