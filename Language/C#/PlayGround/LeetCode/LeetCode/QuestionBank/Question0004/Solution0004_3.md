#### [](https://leetcode.cn/problems/median-of-two-sorted-arrays/solution/xun-zhao-liang-ge-you-xu-shu-zu-de-zhong-wei-s-114//#方法二：划分数组)方法二：划分数组

**说明**

方法一的时间复杂度已经很优秀了，但本题存在时间复杂度更低的一种方法。这里给出推导过程，勇于挑战自己的读者可以进行尝试。

**思路与算法**

为了使用划分的方法解决这个问题，需要理解「中位数的作用是什么」。在统计中，中位数被用来：

> 将一个集合划分为两个长度相等的子集，其中一个子集中的元素总是大于另一个子集中的元素。

如果理解了中位数的划分作用，就很接近答案了。

首先，在任意位置 i 将 A 划分成两个部分：

```
           left_A            |          right_A
    A[0], A[1], ..., A[i-1]  |  A[i], A[i+1], ..., A[m-1]

```

由于 A 中有 m 个元素， 所以有 m+1 种划分的方法（i∈\[0,m\]）。

> len(left\_A)\=i,len(right\_A)\=m−i.
> 
> 注意：当 i\=0 时，left\_A 为空集， 而当 i\=m 时, right\_A 为空集。

采用同样的方式，在任意位置 j 将 B 划分成两个部分：

```
           left_B            |          right_B
    B[0], B[1], ..., B[j-1]  |  B[j], B[j+1], ..., B[n-1]

```

将 left\_A 和 left\_B 放入一个集合，并将 right\_A 和 right\_B 放入另一个集合。 再把这两个新的集合分别命名为 left\_part 和 right\_part：

```
          left_part          |         right_part
    A[0], A[1], ..., A[i-1]  |  A[i], A[i+1], ..., A[m-1]
    B[0], B[1], ..., B[j-1]  |  B[j], B[j+1], ..., B[n-1]

```

当 A 和 B 的总长度是偶数时，如果可以确认：

-   len(left\_part)\=len(right\_part)
-   max⁡(left\_part)≤min⁡(right\_part)

那么，{A,B} 中的所有元素已经被划分为相同长度的两个部分，且前一部分中的元素总是小于或等于后一部分中的元素。中位数就是前一部分的最大值和后一部分的最小值的平均值：

median\=max(left\_part)+min(right\_part)2

当 A 和 B 的总长度是奇数时，如果可以确认：

-   len(left\_part)\=len(right\_part)+1
-   max⁡(left\_part)≤min⁡(right\_part)

那么，{A,B} 中的所有元素已经被划分为两个部分，前一部分比后一部分多一个元素，且前一部分中的元素总是小于或等于后一部分中的元素。中位数就是前一部分的最大值：

median\=max(left\_part)

第一个条件对于总长度是偶数和奇数的情况有所不同，但是可以将两种情况合并。第二个条件对于总长度是偶数和奇数的情况是一样的。

要确保这两个条件，只需要保证：

-   i+j\=m−i+n−j（当 m+n 为偶数）或 i+j\=m−i+n−j+1（当 m+n 为奇数）。等号左侧为前一部分的元素个数，等号右侧为后一部分的元素个数。将 i 和 j 全部移到等号左侧，我们就可以得到 i+j\=m+n+12。这里的分数结果只保留整数部分。

-   0≤i≤m 0≤j≤n。如果我们规定 A 的长度小于等于 B 的长度，即 m≤n。这样对于任意的 i∈\[0,m\]，都有 j\=m+n+12−i∈\[0,n\]，那么我们在 \[0,m\] 的范围内枚举 i 并得到 j，就不需要额外的性质了。

    -   如果 A 的长度较大，那么我们只要交换 A 和 B 即可。

    -   如果 m\>n ，那么得出的 j 有可能是负数。

-   B\[j−1\]≤A\[i\] 以及 A\[i−1\]≤B\[j\]，即前一部分的最大值小于等于后一部分的最小值。


为了简化分析，假设 A\[i−1\],B\[j−1\],A\[i\],B\[j\] 总是存在。对于 i\=0、i\=m、j\=0、j\=n 这样的临界条件，我们只需要规定 A\[−1\]\=B\[−1\]\=−∞，A\[m\]\=B\[n\]\=∞ 即可。这也是比较直观的：当一个数组不出现在前一部分时，对应的值为负无穷，就不会对前一部分的**最大值**产生影响；当一个数组不出现在后一部分时，对应的值为正无穷，就不会对后一部分的**最小值**产生影响。

所以我们需要做的是：

> 在 \[0,m\] 中找到 i，使得：
> 
> B\[j−1\]≤A\[i\] 且 A\[i−1\]≤B\[j\]，其中 j\=m+n+12−i

我们证明它等价于：

> 在 \[0,m\] 中找到最大的 i，使得：
> 
> A\[i−1\]≤B\[j\]，其中 j\=m+n+12−i

这是因为：

-   当 i 从 0∼m 递增时，A\[i−1\] 递增，B\[j\] 递减，所以一定存在一个最大的 i 满足 A\[i−1\]≤B\[j\]；

-   如果 i 是最大的，那么说明 i+1 不满足。将 i+1 带入可以得到 A\[i\]\>B\[j−1\]，也就是 B\[j−1\]<A\[i\]，就和我们进行等价变换前 i 的性质一致了（甚至还要更强）。


因此我们可以对 i 在 \[0,m\] 的区间上进行二分搜索，找到最大的满足 A\[i−1\]≤B\[j\] 的 i 值，就得到了划分的方法。此时，划分前一部分元素中的最大值，以及划分后一部分元素中的最小值，才可能作为就是这两个数组的中位数。

```Java
class Solution {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1.length > nums2.length) {
            return findMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.length;
        int n = nums2.length;
        int left = 0, right = m;
        // median1：前一部分的最大值
        // median2：后一部分的最小值
        int median1 = 0, median2 = 0;

        while (left <= right) {
            // 前一部分包含 nums1[0 .. i-1] 和 nums2[0 .. j-1]
            // 后一部分包含 nums1[i .. m-1] 和 nums2[j .. n-1]
            int i = (left + right) / 2;
            int j = (m + n + 1) / 2 - i;

            // nums_im1, nums_i, nums_jm1, nums_j 分别表示 nums1[i-1], nums1[i], nums2[j-1], nums2[j]
            int nums_im1 = (i == 0 ? Integer.MIN_VALUE : nums1[i - 1]);
            int nums_i = (i == m ? Integer.MAX_VALUE : nums1[i]);
            int nums_jm1 = (j == 0 ? Integer.MIN_VALUE : nums2[j - 1]);
            int nums_j = (j == n ? Integer.MAX_VALUE : nums2[j]);

            if (nums_im1 <= nums_j) {
                median1 = Math.max(nums_im1, nums_jm1);
                median2 = Math.min(nums_i, nums_j);
                left = i + 1;
            } else {
                right = i - 1;
            }
        }

        return (m + n) % 2 == 0 ? (median1 + median2) / 2.0 : median1;
    }
}

```

```C++
class Solution {
public:
    double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {
        if (nums1.size() > nums2.size()) {
            return findMedianSortedArrays(nums2, nums1);
        }
        
        int m = nums1.size();
        int n = nums2.size();
        int left = 0, right = m;
        // median1：前一部分的最大值
        // median2：后一部分的最小值
        int median1 = 0, median2 = 0;

        while (left <= right) {
            // 前一部分包含 nums1[0 .. i-1] 和 nums2[0 .. j-1]
            // 后一部分包含 nums1[i .. m-1] 和 nums2[j .. n-1]
            int i = (left + right) / 2;
            int j = (m + n + 1) / 2 - i;

            // nums_im1, nums_i, nums_jm1, nums_j 分别表示 nums1[i-1], nums1[i], nums2[j-1], nums2[j]
            int nums_im1 = (i == 0 ? INT_MIN : nums1[i - 1]);
            int nums_i = (i == m ? INT_MAX : nums1[i]);
            int nums_jm1 = (j == 0 ? INT_MIN : nums2[j - 1]);
            int nums_j = (j == n ? INT_MAX : nums2[j]);

            if (nums_im1 <= nums_j) {
                median1 = max(nums_im1, nums_jm1);
                median2 = min(nums_i, nums_j);
                left = i + 1;
            } else {
                right = i - 1;
            }
        }

        return (m + n) % 2 == 0 ? (median1 + median2) / 2.0 : median1;
    }
};

```

```Python
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        if len(nums1) > len(nums2):
            return self.findMedianSortedArrays(nums2, nums1)

        infinty = 2**40
        m, n = len(nums1), len(nums2)
        left, right = 0, m
        # median1：前一部分的最大值
        # median2：后一部分的最小值
        median1, median2 = 0, 0

        while left <= right:
            # 前一部分包含 nums1[0 .. i-1] 和 nums2[0 .. j-1]
            # // 后一部分包含 nums1[i .. m-1] 和 nums2[j .. n-1]
            i = (left + right) // 2
            j = (m + n + 1) // 2 - i

            # nums_im1, nums_i, nums_jm1, nums_j 分别表示 nums1[i-1], nums1[i], nums2[j-1], nums2[j]
            nums_im1 = (-infinty if i == 0 else nums1[i - 1])
            nums_i = (infinty if i == m else nums1[i])
            nums_jm1 = (-infinty if j == 0 else nums2[j - 1])
            nums_j = (infinty if j == n else nums2[j])

            if nums_im1 <= nums_j:
                median1, median2 = max(nums_im1, nums_jm1), min(nums_i, nums_j)
                left = i + 1
            else:
                right = i - 1

        return (median1 + median2) / 2 if (m + n) % 2 == 0 else median1

```

```Go
func findMedianSortedArrays(nums1 []int, nums2 []int) float64 {
    if len(nums1) > len(nums2) {
        return findMedianSortedArrays(nums2, nums1)
    }
    m, n := len(nums1), len(nums2)
    left, right := 0, m
    median1, median2 := 0, 0
    for left <= right {
        i := (left + right) / 2
        j := (m + n + 1) / 2 - i
        nums_im1 := math.MinInt32
        if i != 0 {
            nums_im1 = nums1[i-1]
        }
        nums_i := math.MaxInt32
        if i != m {
            nums_i = nums1[i]
        }
        nums_jm1 := math.MinInt32
        if j != 0 {
            nums_jm1 = nums2[j-1]
        }
        nums_j := math.MaxInt32
        if j != n {
            nums_j = nums2[j]
        }
        if nums_im1 <= nums_j {
            median1 = max(nums_im1, nums_jm1)
            median2 = min(nums_i, nums_j)
            left = i + 1
        } else {
            right = i - 1
        }
    }
    if (m + n) % 2 == 0 {
        return float64(median1 + median2) / 2.0
    }
    return  float64(median1)
}

func max(x, y int) int {
    if x > y {
        return x
    }
    return y
}

func min(x, y int) int {
    if x < y {
        return x
    }
    return y
}

```

**复杂度分析**

-   时间复杂度：O(log⁡min⁡(m,n))，其中 m 和 n 分别是数组 nums1 和 nums2 的长度。查找的区间是 \[0,m\]，而该区间的长度在每次循环之后都会减少为原来的一半。所以，只需要执行 log⁡m 次循环。由于每次循环中的操作次数是常数，所以时间复杂度为 O(log⁡m)。由于我们可能需要交换 nums1 和 nums2 使得 m≤n，因此时间复杂度是 O(log⁡min⁡(m,n))。

-   空间复杂度：O(1)。
