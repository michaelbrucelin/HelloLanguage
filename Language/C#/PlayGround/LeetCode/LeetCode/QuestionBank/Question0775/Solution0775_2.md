#### [方法一：维护后缀最小值](https://leetcode.cn/problems/global-and-local-inversions/solutions/1971259/quan-ju-dao-zhi-yu-ju-bu-dao-zhi-by-leet-bmjp/)

**思路与算法**

一个局部倒置一定是一个全局倒置，因此要判断数组中局部倒置的数量是否与全局倒置的数量相等，只需要检查有没有非局部倒置就可以了。这里的非局部倒置指的是 $nums[i] \gt nums[j]$，其中 $i < j - 1$。

朴素的判断方法需要两层循环，设 n 是 nums 的长度，那么该方法的时间复杂度为 $O(n^2)$，无法通过。

进一步的，对于每一个 nums[i] 判断是否存在一个 $j~(j \gt i + 1)$ 使得 $nums[i] \gt nums[j]$ 即可。这和检查 $nums[i] \gt \min(nums[i+2],\dots,nums[n-1])$ 是否成立是一致的。因此我们维护一个变量 $minSuffix = \min(nums[i+2],\dots,nums[n-1])$，倒序遍历 [0, n-3] 中的每个 i, 如有一个 i 使得 $nums[i] \gt minSuffix$ 成立，返回 false，若结束遍历都没有返回 false，则返回 true。

**代码**

```python
class Solution:
    def isIdealPermutation(self, nums: List[int]) -> bool:
        min_suf = nums[-1]
        for i in range(len(nums) - 2, 0, -1):
            if nums[i - 1] > min_suf:
                return False
            min_suf = min(min_suf, nums[i])
        return True
```

```cpp
class Solution {
public:
    bool isIdealPermutation(vector<int>& nums) {
        int n = nums.size(), minSuff = nums[n - 1];
        for (int i = n - 3; i >= 0; i--) {
            if (nums[i] > minSuff) {
                return false;
            }
            minSuff = min(minSuff, nums[i + 1]);
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean isIdealPermutation(int[] nums) {
        int n = nums.length, minSuff = nums[n - 1];
        for (int i = n - 3; i >= 0; i--) {
            if (nums[i] > minSuff) {
                return false;
            }
            minSuff = Math.min(minSuff, nums[i + 1]);
        }
        return true;
    }
}
```

```c#
public class Solution {
    public bool IsIdealPermutation(int[] nums) {
        int n = nums.Length, minSuff = nums[n - 1];
        for (int i = n - 3; i >= 0; i--) {
            if (nums[i] > minSuff) {
                return false;
            }
            minSuff = Math.Min(minSuff, nums[i + 1]);
        }
        return true;
    }
}
```

```go
func isIdealPermutation(nums []int) bool {
    n := len(nums)
    minSuf := nums[n-1]
    for i := n - 2; i > 0; i-- {
        if nums[i-1] > minSuf {
            return false
        }
        minSuf = min(minSuf, nums[i])
    }
    return true
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

```javascript
var isIdealPermutation = function(nums) {
    let n = nums.length, minSuff = nums[n - 1];
    for (let i = n - 3; i >= 0; i--) {
        if (nums[i] > minSuff) {
            return false;
        }
        minSuff = Math.min(minSuff, nums[i + 1]);
    }
    return true;
};
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

bool isIdealPermutation(int* nums, int numsSize) {
    int minSuff = nums[numsSize - 1];
    for (int i = numsSize - 3; i >= 0; i--) {
        if (nums[i] > minSuff) {
            return false;
        }
        minSuff = MIN(minSuff, nums[i + 1]);
    }
    return true;
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是 nums 的长度。
-   空间复杂度：O(1)，只使用到常数个变量空间。
