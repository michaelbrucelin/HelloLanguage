#### [方法一：一次遍历](https://leetcode.cn/problems/number-of-subarrays-with-bounded-maximum/solutions/1986565/qu-jian-zi-shu-zu-ge-shu-by-leetcode-sol-7it1/)

**思路与算法**

一个子数组的最大值范围在 $[left,right]$ 表示子数组中不能含有大于 $right$ 的元素，且至少含有一个处于 $[left,right]$ 区间的元素。

我们可以将数组中的元素分为三类，并分别用 0, 1, 2 来表示：
-   小于 $left$，用 0 表示；
-   大于等于 $left$ 且小于等于 $right$，用 1 表示；
-   大于 $right$，用 2 表示。

那么本题可以转换为求解不包含 2，且至少包含一个 1 的子数组数目。我们遍历 i，并将右端点固定在 i，求解有多少合法的子区间。过程中需要维护两个变量：
1.  $last_1$，表示上一次 1 出现的位置，如果不存在则为 −1；
2.  $last_2$，表示上一次 2 出现的位置，如果不存在则为 −1。

如果 $last_1 \neq -1$，那么子数组若以 i 为右端点，合法的左端点可以落在 $(last_2, last_1]$ 之间。这样的左端点共有 $last1 − last2$ 个。

因此，我们遍历 i：
1.  如果 $left \le nums[i] \le right$，令 $last_1 = i$；
2.  否则如果 $nums[i] \gt right$，令 $last_2 = i$，$last_1 = -1$。

然后将 $last_1 - last_2$ 累加到答案中即可。最后的总和即为题目所求。

**代码**

```python
class Solution:
    def numSubarrayBoundedMax(self, nums: List[int], left: int, right: int) -> int:
        res = 0
        last2 = last1 = -1
        for i, x in enumerate(nums):
            if left <= x <= right:
                last1 = i
            elif x > right:
                last2 = i
                last1 = -1
            if last1 != -1:
                res += last1 - last2
        return res
```

```cpp
class Solution {
public:
    int numSubarrayBoundedMax(vector<int>& nums, int left, int right) {
        int res = 0, last2 = -1, last1 = -1;
        for (int i = 0; i < nums.size(); i++) {
            if (nums[i] >= left && nums[i] <= right) {
                last1 = i;
            } else if (nums[i] > right) {
                last2 = i;
                last1 = -1;
            }
            if (last1 != -1) {
                res += last1 - last2;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int numSubarrayBoundedMax(int[] nums, int left, int right) {
        int res = 0, last2 = -1, last1 = -1;
        for (int i = 0; i < nums.length; i++) {
            if (nums[i] >= left && nums[i] <= right) {
                last1 = i;
            } else if (nums[i] > right) {
                last2 = i;
                last1 = -1;
            }
            if (last1 != -1) {
                res += last1 - last2;
            }
        }
        return res;
    }
}
```

```c#
public class Solution {
    public int NumSubarrayBoundedMax(int[] nums, int left, int right) {
        int res = 0, last2 = -1, last1 = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] >= left && nums[i] <= right) {
                last1 = i;
            } else if (nums[i] > right) {
                last2 = i;
                last1 = -1;
            }
            if (last1 != -1) {
                res += last1 - last2;
            }
        }
        return res;
    }
}
```

```go
func numSubarrayBoundedMax(nums []int, left int, right int) (res int) {
    last2, last1 := -1, -1
    for i, x := range nums {
        if left <= x && x <= right {
            last1 = i
        } else if x > right {
            last2 = i
            last1 = -1
        }
        if last1 != -1 {
            res += last1 - last2
        }
    }
    return
}
```

```javascript
var numSubarrayBoundedMax = function(nums, left, right) {
    let res = 0, last2 = -1, last1 = -1;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] >= left && nums[i] <= right) {
            last1 = i;
        } else if (nums[i] > right) {
            last2 = i;
            last1 = -1;
        }
        if (last1 !== -1) {
            res += last1 - last2;
        }
    }
    return res;
};  
```

```c
int numSubarrayBoundedMax(int* nums, int numsSize, int left, int right) {
    int res = 0, last2 = -1, last1 = -1;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] >= left && nums[i] <= right) {
            last1 = i;
        } else if (nums[i] > right) {
            last2 = i;
            last1 = -1;
        }
        if (last1 != -1) {
            res += last1 - last2;
        }
    }
    return res;
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是 nums 的长度。整个过程只需要遍历一次 nums。
-   空间复杂度：O(1)。只使用到常数个变量。
