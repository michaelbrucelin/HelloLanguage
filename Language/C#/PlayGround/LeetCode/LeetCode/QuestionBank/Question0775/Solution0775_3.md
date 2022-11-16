#### [方法二：归纳证明](https://leetcode.cn/problems/global-and-local-inversions/solutions/1971259/quan-ju-dao-zhi-yu-ju-bu-dao-zhi-by-leet-bmjp/)

**思路与算法**

nums 是一个由 $0 \sim n-1$ 组成的排列，设不存在非局部倒置的排列为「理想排列」。由于非局部倒置表示存在一个 $j > i + 1$ 使得 $nums[i] > nums[j]$ 成立，所以对于最小的元素 0 来说，它的下标不能够大于等于 2。所以有：
1.  若 nums[0] = 0，那么问题转换为 [1, n - 1] 区间的一个子问题。
2.  若 nums[1] = 0，那么 nums[0] 只能为 1，因为如果是大于 1 的任何元素，都将会与后面的 1 构成非局部倒置。此时，问题转换为了 [2, n - 1] 区间的一个子问题。

根据上述讨论，不难归纳出「理想排列」的充分必要条件为对于每个元素 nums[i] 都满足 $\big| nums[i] - i \big| \le 1$。

**代码**

```python
class Solution:
    def isIdealPermutation(self, nums: List[int]) -> bool:
        return all(abs(x - i) <= 1 for i, x in enumerate(nums))
```

```cpp
class Solution {
public:
    bool isIdealPermutation(vector<int>& nums) {
        for (int i = 0; i < nums.size(); i++) {
            if (abs(nums[i] - i) > 1) {
                return false;
            }
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean isIdealPermutation(int[] nums) {
        for (int i = 0; i < nums.length; i++) {
            if (Math.abs(nums[i] - i) > 1) {
                return false;
            }
        }
        return true;
    }
}
```

```c#
public class Solution {
    public bool IsIdealPermutation(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            if (Math.Abs(nums[i] - i) > 1) {
                return false;
            }
        }
        return true;
    }
}
```

```go
func isIdealPermutation(nums []int) bool {
    for i, x := range nums {
        if abs(x-i) > 1 {
            return false
        }
    }
    return true
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```javascript
var isIdealPermutation = function(nums) {
    for (let i = 0; i < nums.length; i++) {
        if (Math.abs(nums[i] - i) > 1) {
            return false;
        }
    }
    return true;
};
```

```c
bool isIdealPermutation(int* nums, int numsSize){
    for (int i = 0; i < numsSize; i++) {
        if (abs(nums[i] - i) > 1) {
            return false;
        }
    }
    return true;
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是 nums 的长度。
-   空间复杂度：O(1)，只使用到常数个变量空间。
