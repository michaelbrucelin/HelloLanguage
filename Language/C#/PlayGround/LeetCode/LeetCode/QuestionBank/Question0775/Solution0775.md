#### [数学解](https://leetcode.cn/problems/global-and-local-inversions/description/)

由题目知，全局倒置一定是局部倒置，所以如果存在非局部倒置的全局倒置（`i+1 < j && nums[i] > nums[j]`）结果为`false`，否则为`true`。

假定`nums`升序排列为数组中元素的原本位置，每个位置的满足`nums[i] == i`，然后观察`nums`的真实元素布局，如果`nums`的每一个位置都满足`ABS(nums[i] - i) <= 1`，则结果为`true`，否则结果为`false`，下面进行证明这个结论。

**证明**
1. **如果存在`k`满足`ABS(nums[k] - k) > 1`，则结果为`false`**
    - 如果`nums[k] - k > 1`，即`nums[k] >= k+2`，那么如果右边的元素与`nums[k]`不产生全局倒置就要保证`nums[k+2] ... nums[n-1]`均大于`nums[k]`，即均大于`k+2`，由抽屉原理知，这是不可能的；
    - 如果`nums[k] - k < -1`，即`nums[k] <= k-2`，那么如果左边的元素与`nums[k]`不产生全局倒置就要保证`nums[0] ... nums[k-2]`均小于`nums[k]`，即均小于`k-2`，由抽屉原理知，这是不可能的；
2. **如果不存在`k`满足`ABS(nums[k] - k) > 1`，即每一个`k`均满足`ABS(nums[k] - k) <= 1`，则结果为`true`**
    - 对于任意`k`，`nums[k]`的值只能是`k`, `k-1`, `k+1`3者之一；
        - 如果是`k`，由于每一个`k`均满足`ABS(nums[k] - k) <= 1`，所以`k`左边的元素均小于`k`，如果存在`k`左边的元素大于`k`，那么此元素必不满足`ABS(nums[k] - k) <= 1`，同理`k`右边的元素均大于`k`，所以`k`不会产生全局倒置；
        - 如果是`k+1`，那么`nums[k+1]`必然是`k`，假设`nums[k+1] != k`，由于`ABS(nums[k] - k) <= 1`，`nums[k+1]`只能是`k+2`，进而`nums[k+2]`只能是`k+3` ... ，最后`nums[n-1]`就无法满足`ABS(nums[k] - k) <= 1`了；
        - 如果是`k-1`，同`k+1`；
