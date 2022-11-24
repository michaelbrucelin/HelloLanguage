#### [方法二：计数](https://leetcode.cn/problems/number-of-subarrays-with-bounded-maximum/solutions/1986565/qu-jian-zi-shu-zu-ge-shu-by-leetcode-sol-7it1/)

**思路与算法**

方法一提到，我们要计算的合法子区间不包含 2 且至少包含一个 1。所以，我们可以先求出只包含 0 或 1 的子区间数目，再减去只包括 0 的子区间数目。

设函数 $count(nums, lower)$ 可以求出数组 nums 中所有元素小于等于 lower 的子数组数目，那么题目所求就是 $count(nums,right)−count(nums,left)$。

关于 $count(nums,lower)$ 的实现，我们用 $i$ 遍历 $nums[i]$，$cur$ 表示 $i$ 左侧有多少个连续的元素小于等于 $lower$：

1.  如果 $nums[i] \le lower$，令 $cur = cur + 1$；
2.  否则，令 $cur = 0$。

每次将 $cur$ 加到答案中，最终的和即为 $count$ 函数返回值。

**代码**

```python
class Solution:
    def numSubarrayBoundedMax(self, nums: List[int], left: int, right: int) -> int:
        def count(lower: int) -> int:
            res = cur = 0
            for x in nums:
                if x <= lower:
                    cur += 1
                else:
                    cur = 0
                res += cur
            return res
        return count(right) - count(left - 1)
```

```cpp
class Solution {
public:
    int numSubarrayBoundedMax(vector<int>& nums, int left, int right) {
        return count(nums, right) - count(nums, left - 1);
    }

    int count(vector<int>& nums, int lower) {
        int res = 0, cur = 0;
        for (auto x : nums) {
            cur = x <= lower ? cur + 1 : 0;
            res += cur;
        }
        return res;
    }
};
```

```java
class Solution {
    public int numSubarrayBoundedMax(int[] nums, int left, int right) {
        return count(nums, right) - count(nums, left - 1);
    }

    public int count(int[] nums, int lower) {
        int res = 0, cur = 0;
        for (int x : nums) {
            cur = x <= lower ? cur + 1 : 0;
            res += cur;
        }
        return res;
    }
}
```

```c#
public class Solution {
    public int NumSubarrayBoundedMax(int[] nums, int left, int right) {
        return Count(nums, right) - Count(nums, left - 1);
    }

    public int Count(int[] nums, int lower) {
        int res = 0, cur = 0;
        foreach (int x in nums) {
            cur = x <= lower ? cur + 1 : 0;
            res += cur;
        }
        return res;
    }
}
```

```go
func numSubarrayBoundedMax(nums []int, left int, right int) int {
    count := func(lower int) (res int) {
        cur := 0
        for _, x := range nums {
            if x <= lower {
                cur++
            } else {
                cur = 0
            }
            res += cur
        }
        return
    }
    return count(right) - count(left-1)
}
```

```javascript
var numSubarrayBoundedMax = function(nums, left, right) {
    return count(nums, right) - count(nums, left - 1);
}

const count = (nums, lower) => {
    let res = 0, cur = 0;
    for (const x of nums) {
        cur = x <= lower ? cur + 1 : 0;
        res += cur;
    }
    return res;
};  
```

```c
int count(const int *nums, int numsSize, int lower) {
    int res = 0, cur = 0;
    for (int i = 0; i < numsSize; i++) {
        cur = nums[i] <= lower ? cur + 1 : 0;
        res += cur;
    }
    return res;
}

int numSubarrayBoundedMax(int* nums, int numsSize, int left, int right) {
    return count(nums, numsSize, right) - count(nums, numsSize, left - 1);
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是 nums 的长度。整个求解过程需要遍历两次 nums。
-   空间复杂度：O(1)。只使用到常数个变量。
