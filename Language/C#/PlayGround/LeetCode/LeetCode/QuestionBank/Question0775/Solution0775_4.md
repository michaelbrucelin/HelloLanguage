#### [方法一：维护前缀最大值](https://leetcode.cn/problems/global-and-local-inversions/solutions/1973202/by-lcbin-6qe7/)

根据题意，我们可以发现，一个数组中的局部倒置一定是全局倒置，但是全局倒置不一定是局部倒置。也就是说，全局倒置的数量一定大于等于局部倒置的数量。

因此，我们枚举每个数 `nums[i]`，其中 $2 \leq i \leq n - 1$，维护前缀数组 nums[0,..i−2] 中的最大值，记为 mx。如果存在 mx 大于 nums[i]，说明全局倒置的数量大于局部倒置的数量，返回 `false` 即可。

遍历结束后，返回 `true`。

```python
class Solution:
    def isIdealPermutation(self, nums: List[int]) -> bool:
        mx = 0
        for i in range(2, len(nums)):
            if (mx := max(mx, nums[i - 2])) > nums[i]:
                return False
        return True
```

```java
class Solution {
    public boolean isIdealPermutation(int[] nums) {
        int mx = 0;
        for (int i = 2; i < nums.length; ++i) {
            mx = Math.max(mx, nums[i - 2]);
            if (mx > nums[i]) {
                return false;
            }
        }
        return true;
    }
}
```

```cpp
class Solution {
public:
    bool isIdealPermutation(vector<int>& nums) {
        int mx = 0;
        for (int i = 2; i < nums.size(); ++i) {
            mx = max(mx, nums[i - 2]);
            if (mx > nums[i]) return false;
        }
        return true;
    }
};
```

```go
func isIdealPermutation(nums []int) bool {
    mx := 0
    for i := 2; i < len(nums); i++ {
        mx = max(mx, nums[i-2])
        if mx > nums[i] {
            return false
        }
    }
    return true
}

func max(a, b int) int {
    if a > b {
        return a
    }
    return b
}
```

时间复杂度 O(n)，空间复杂度 O(1)。其中 n 为数组 `nums` 的长度。
