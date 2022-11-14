#### [方法一：折半搜索](https://leetcode.cn/problems/split-array-with-same-average/solutions/1966163/shu-zu-de-jun-zhi-fen-ge-by-leetcode-sol-f630/)

**思路与算法**

设数组 nums 的长度为 n，假设我们移动了 k 个元素到数组 A 中，移动了 n−k 个元素到数组 B 中，此时两个数组的平均值相等。设 sum(A),sum(B),sum(nums) 分别表示数组 A,B,nums 的元素和，由于数组 A,B 的平均值相等，则有 $\frac{sum(A)}{k} = \frac{sum(B)}{n - k}$，上述等式可以进行变换为如下：
$\begin{aligned} & sum(A) \times (n - k) = sum(B) \times k \\ \Leftrightarrow~ & sum(A) \times n = (sum(A) + sum(B)) \times k \\ \Leftrightarrow~ & sum(A) \times n = (sum(nums)) \times k \\ \Leftrightarrow~ & \frac{sum(A)}{k} = \frac{sum(nums)}{n} \end{aligned}$

即数组 A 的平均值与数组 nums 的平均值相等。此时我们可以将数组 nums 中的每个元素减去 nums 的平均值，这样数组 nums 的平均值则变为 000。此时题目中的问题则可以住准变为：从 nums 中找出若干个元素组成集合 A，使得 A 的元素之和为 0，剩下的元素组成集合 B，它们的和也同样为 0。

比较容易想到的思路是，从 n 个元素中取出若干个元素形成不同的子集，则此时一共有 $2^n$ 种方法（即每个元素取或不取），我们依次判断每种方法选出的元素之和是否为 0。但题目中的 n 可以达到 30，此时 $2^{30} = 1,073,741,824$，组合的数据非常大。 因此我们考虑将数组平均分成两部分 $A_0$ 和 $B_0$，它们均含有 $\frac{n}{2}$ 个元素（不失一般性，这里假设 n 为偶数。如果 n 为奇数，在 $A_0$ 中多放一个元素即可），此时这两个数组分别有 $2^{\frac{n}{2}}$ 种不同的子集选择的方法。设 $A_0$ 中所有选择的方法得到的不同子集的元素之和的集合为 left，$B_0$ 中所有选择的方法得到的不同子集的元素之和的集合为 right，那么我们只需要在 left 中找出一个子集 $A_0^{'}$ 的元素之和为 x，同时在 right 中包含一个子集 $B_0^{'}$ 的元素之和为 −x，则子集 $A_0^{'},B_0^{'}$ 构成的集合的元素之和为 0，此时则找到了一种和为 0 的方法。

-   需要注意的是，我们不能同时选择 $A_0$ 和 $A_1$ 中的所有元素，这样数组 B 就为空了。

此外，将数组 nums 中每个元素减去它们的平均值，这一步会引入浮点数，可能会导致判断的时候出现误差。一种解决方案是使用分数代替浮点数，但这样代码编写起来较为麻烦。更好的解决方案是先将 nums 中的每个元素乘以 nums 的长度，则此时每个元素 nums[i] 变为 $n \times nums[i]$，这样数组 nums 的平均值一定为整数，同时也不影响题目中的平均值相等的要求。

**代码**

```python
class Solution:
    def splitArraySameAverage(self, nums: List[int]) -> bool:
        n = len(nums)
        if n == 1:
            return False

        s = sum(nums)
        for i in range(n):
            nums[i] = nums[i] * n - s

        m = n // 2
        left = set()
        for i in range(1, 1 << m):
            tot = sum(x for j, x in enumerate(nums[:m]) if i >> j & 1)
            if tot == 0:
                return True
            left.add(tot)

        rsum = sum(nums[m:])
        for i in range(1, 1 << (n - m)):
            tot = sum(x for j, x in enumerate(nums[m:]) if i >> j & 1)
            if tot == 0 or rsum != tot and -tot in left:
                return True
        return False
```

```cpp
class Solution {
public:
    bool splitArraySameAverage(vector<int> &nums) {
        int n = nums.size(), m = n / 2;
        if (n == 1) {
            return false;
        }

        int sum = accumulate(nums.begin(), nums.end(), 0);
        for (int &x : nums) {
            x = x * n - sum;
        }

        unordered_set<int> left;
        for (int i = 1; i < (1 << m); i++) {
            int tot = 0;
            for (int j = 0; j < m; j++) {
                if (i & (1 << j)) {
                    tot += nums[j];
                }
            }
            if (tot == 0) {
                return true;
            }
            left.emplace(tot);
        }

        int rsum = accumulate(nums.begin() + m, nums.end(), 0);
        for (int i = 1; i < (1 << (n - m)); i++) {
            int tot = 0;
            for (int j = m; j < n; j++) {
                if (i & (1 << (j - m))) {
                    tot += nums[j];
                }
            }
            if (tot == 0 || (rsum != tot && left.count(-tot))) {
                return true;
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
        for (int i = 0; i < n; i++) {
            nums[i] = nums[i] * n - sum;
        }

        Set<Integer> left = new HashSet<Integer>();
        for (int i = 1; i < (1 << m); i++) {
            int tot = 0;
            for (int j = 0; j < m; j++) {
                if ((i & (1 << j)) != 0) {
                    tot += nums[j];
                }
            }
            if (tot == 0) {
                return true;
            }
            left.add(tot);
        }
        int rsum = 0;
        for (int i = m; i < n; i++) {
            rsum += nums[i];
        }
        for (int i = 1; i < (1 << (n - m)); i++) {
            int tot = 0;
            for (int j = m; j < n; j++) {
                if ((i & (1 << (j - m))) != 0) {
                    tot += nums[j];
                }
            }
            if (tot == 0 || (rsum != tot && left.contains(-tot))) {
                return true;
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
        for (int i = 0; i < n; i++) {
            nums[i] = nums[i] * n - sum;
        }

        ISet<int> left = new HashSet<int>();
        for (int i = 1; i < (1 << m); i++) {
            int tot = 0;
            for (int j = 0; j < m; j++) {
                if ((i & (1 << j)) != 0) {
                    tot += nums[j];
                }
            }
            if (tot == 0) {
                return true;
            }
            left.Add(tot);
        }
        int rsum = 0;
        for (int i = m; i < n; i++) {
            rsum += nums[i];
        }
        for (int i = 1; i < (1 << (n - m)); i++) {
            int tot = 0;
            for (int j = m; j < n; j++) {
                if ((i & (1 << (j - m))) != 0) {
                    tot += nums[j];
                }
            }
            if (tot == 0 || (rsum != tot && left.Contains(-tot))) {
                return true;
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
    if (numsSize == 1) {
        return false;
    }
    int n = numsSize, m = n / 2;
    int sum = 0;
    for (int i = 0; i < n; i++) {
        sum += nums[i];
    }
    for (int i = 0; i < n; i++) {
        nums[i] = nums[i] * n - sum;
    }
    HashItem *left = NULL;
    for (int i = 1; i < (1 << m); i++) {
        int tot = 0;
        for (int j = 0; j < m; j++) {
            if (i & (1 << j)) {
                tot += nums[j];
            }
        }
        if (tot == 0) {
            return true;
        }
        hashAddItem(&left, tot);
    }
    int rsum = 0;
    for (int i = m; i < n; i++) {
        rsum += nums[i];
    }
    for (int i = 1; i < (1 << (n - m)); i++) {
        int tot = 0;
        for (int j = m; j < n; j++) {
            if (i & (1 << (j - m))) {
                tot += nums[j];
            }
        }
        if (tot == 0 || (tot != rsum && hashFindItem(&left, -tot))) {
            return true;
        }
    }
    hashFree(&left);
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
    for (let i = 0; i < n; i++) {
        nums[i] = nums[i] * n - sum;
    }

    const left = new Set();
    for (let i = 1; i < (1 << m); i++) {
        let tot = 0;
        for (let j = 0; j < m; j++) {
            if ((i & (1 << j)) !== 0) {
                tot += nums[j];
            }
        }
        if (tot === 0) {
            return true;
        }
        left.add(tot);
    }
    let rsum = 0;
    for (let i = m; i < n; i++) {
        rsum += nums[i];
    }
    for (let i = 1; i < (1 << (n - m)); i++) {
        let tot = 0;
        for (let j = m; j < n; j++) {
            if ((i & (1 << (j - m))) != 0) {
                tot += nums[j];
            }
        }
        if (tot === 0 || (rsum !== tot && left.has(-tot))) {
            return true;
        }
    }
    return false;
};
```

```go
func splitArraySameAverage(nums []int) bool {
    n := len(nums)
    if n == 1 {
        return false
    }

    sum := 0
    for _, x := range nums {
        sum += x
    }
    for i := range nums {
        nums[i] = nums[i]*n - sum
    }

    m := n / 2
    left := map[int]bool{}
    for i := 1; i < 1<<m; i++ {
        tot := 0
        for j, x := range nums[:m] {
            if i>>j&1 > 0 {
                tot += x
            }
        }
        if tot == 0 {
            return true
        }
        left[tot] = true
    }

    rsum := 0
    for _, x := range nums[m:] {
        rsum += x
    }
    for i := 1; i < 1<<(n-m); i++ {
        tot := 0
        for j, x := range nums[m:] {
            if i>>j&1 > 0 {
                tot += x
            }
        }
        if tot == 0 || rsum != tot && left[-tot] {
            return true
        }
    }
    return false
}
```

**复杂度分析**

-   时间复杂度：$O(n \times 2^{\frac{n}{2}})$，其中 n 表示数组的长度。我们需要求出每个子集的元素之和，数组的长度为 n，一共有 $2 \times 2^{\frac{n}{2}}$ 个子集，求每个子集的元素之和需要的时间为 O(n)，因此总的时间复杂度为 $O(n \times 2^{\frac{n}{2}})$。
-   空间复杂度：$O(2^{\frac{n}{2}})$。一共有 $2^{\frac{n}{2}}$ 个子集的元素之和需要保存，因此需要的空间为 $O(2^{\frac{n}{2}})$。
