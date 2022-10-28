﻿#### [](https://leetcode.cn/problems/sum-of-subarray-minimums/solution/gong-xian-fa-dan-diao-zhan-san-chong-shi-gxa5//#提示-1：计算以-为最小值的子数组的个数)提示 1：计算以 arr[i] 为最小值的子数组的个数

暴力做法是枚举所有子数组，算出每个子数组的最小值，但这太慢了。

不妨换个视角，对每个数，算出它是哪些子数组的最小值。

例如 arr=[1,4,2,3,1]，其中 2 是子数组 [2],[4,2],[2,3],[4,2,3] 的最小值，那么 2 对答案的**贡献**就是 2⋅4=8。

由于以 2 为最小值的子数组，绝对不能包含比 2 小的数字，因此我们可以找到 2 左右两侧比它小的数的下标，从而确定子数组的**边界**。2 对应的边界为开区间 (0,4)，即闭区间 [1,3]，只要在闭区间 [1,3] 范围内且包含下标 2 的子数组，就是以 2 为最小值的子数组。

一般地，设 arr[i] 对应的边界为**开区间** (L,R)，由于子数组必须包含 arr[i]：
-   子数组的左端点可以是 L+1,L+2,⋯ ,i，共有 i−L 个；
-   子数组的右端点可以是 i,i+1,⋯ ,R−1，共有 R−i 个。

因此，**在 arr 不含重复元素的前提下**，根据**乘法原理**，我们可以得出如下结论：

以 arr[i] 为最小值的子数组的个数为 (i−L)⋅(R−i)，对答案的贡献为 arr[i]⋅(i−L)⋅(R−i)。

> 注：如果左侧没有比 arr[i] 小的元素，则 L=−1；如果右侧没有比 arr[i] 小的元素，则 R=n。

下文讨论的边界均指的是开区间 (L,R)。

#### [](https://leetcode.cn/problems/sum-of-subarray-minimums/solution/gong-xian-fa-dan-diao-zhan-san-chong-shi-gxa5//#提示-2：修改边界定义，避免重复统计子数组)提示 2：修改边界定义，避免重复统计子数组

如果 arr 有重复元素，例如 arr=[1,2,4,2,3,1]，其中第一个 2 和第二个 2 对应的边界都是开区间 (0,5)，子数组 [2,4,2,3] 都包含这两个 2，这样在计算答案时就会重复统计同一个子数组，算出错误的结果。

为避免重复统计，可以修改边界的定义，把右边界改为「找**小于或等于** arr[i] 的数的下标」，那么：
-   第一个 2 对应的边界是 (0,3)，子数组需要在 (0,3) 范围内且包含下标 1；
-   第二个 2 对应的边界是 (0,5)，子数组需要在 (0,5) 范围内且包含下标 3。

这样以第一个 2 为最小值的子数组，就不会「越界」包含第二个 2 了，从而解决了重复统计子数组的问题。

> 注：也可以把左边界改为 ≤，右边界不变（仍为 <）。根据对称性，算出来的答案是一样的。

#### [](https://leetcode.cn/problems/sum-of-subarray-minimums/solution/gong-xian-fa-dan-diao-zhan-san-chong-shi-gxa5//#提示-3：高效计算边界)提示 3：高效计算边界

最后需要解决的问题是，如何高效计算每个 arr[i] 对应的左右边界？

以计算左边界为例，从左到右遍历 arr，同时用某个合适的数据结构维护遍历过的元素，并**及时移除无用的元素**，如下图（arr 简写为 a）：

![](./assets/img/Solution0907_4.png)

移除无用元素后，再把 arr[i] 加到这个数据结构中。

由于该优化保证了数据结构中的元素会形成一个递增的序列，因此我们移除的是数据结构中的最右端的若干元素。我们需要一个数据结构，它支持移除最右端的元素，以及在最右端添加元素，故选用**栈**。

移除栈中 ≥arr[i] 的元素后，栈顶的下标就是 arr[i] 的左边界，如果此时栈为空，那么左边界为 −1。

> 注 1：在遍历过程中会维护一个栈，移除的是当前的栈顶元素。遍历到 arr[i] 时，arr[i] 及其右侧元素尚未入栈。
> 注 2：由于栈内元素始终保持单调递增，因此这种数据结构也叫做**单调栈**。

右边界的计算是类似的，从右往左遍历 arr 可以算出（根据提示 2，需要修改一下比较的符号，具体见代码）。

算出左右边界后，根据提示 1 的公式累加每个 arr[i] 的贡献，即为答案。

代码实现时，有三种实现版本。注意实际入栈的是元素的下标。

#### [](https://leetcode.cn/problems/sum-of-subarray-minimums/solution/gong-xian-fa-dan-diao-zhan-san-chong-shi-gxa5//#版本一：三次遍历)版本一：三次遍历

```Python
class Solution:
    def sumSubarrayMins(self, arr: List[int]) -> int:
        n = len(arr)
        # 左边界 left[i] 为左侧严格小于 arr[i] 的最近元素位置（不存在时为 -1）
        left, st = [-1] * n, []
        for i, x in enumerate(arr):
            while st and arr[st[-1]] >= x:
                st.pop()  # 移除无用数据
            if st: left[i] = st[-1]
            st.append(i)

        # 右边界 right[i] 为右侧小于等于 arr[i] 的最近元素位置（不存在时为 n）
        right, st = [n] * n, []
        for i in range(n - 1, -1, -1):
            while st and arr[st[-1]] > arr[i]:
                st.pop()  # 移除无用数据
            if st: right[i] = st[-1]
            st.append(i)

        ans = 0
        for i, (x, l, r) in enumerate(zip(arr, left, right)):
            ans += x * (i - l) * (r - i)  # 累加贡献
        return ans % (10 ** 9 + 7)
```

```Java
class Solution {
    private static final long MOD = (long) 1e9 + 7;

    public int sumSubarrayMins(int[] arr) {
        var n = arr.length;
        // 左边界 left[i] 为左侧严格小于 arr[i] 的最近元素位置（不存在时为 -1）
        var left = new int[n];
        var st = new ArrayDeque<Integer>();
        st.push(-1); // 方便赋值 left
        for (var i = 0; i < n; ++i) {
            while (st.size() > 1 && arr[st.peek()] >= arr[i])
                st.pop(); // 移除无用数据
            left[i] = st.peek();
            st.push(i);
        }

        // 右边界 right[i] 为右侧小于等于 arr[i] 的最近元素位置（不存在时为 n）
        var right = new int[n];
        st.clear();
        st.push(n); // 方便赋值 right
        for (var i = n - 1; i >= 0; --i) {
            while (st.size() > 1 && arr[st.peek()] > arr[i])
                st.pop(); // 移除无用数据
            right[i] = st.peek();
            st.push(i);
        }

        var ans = 0L;
        for (var i = 0; i < n; ++i)
            ans += (long) arr[i] * (i - left[i]) * (right[i] - i); // 累加贡献
        return (int) (ans % MOD);
    }
}
```

```C++
class Solution {
    const int MOD = 1e9 + 7;
public:
    int sumSubarrayMins(vector<int> &arr) {
        int n = arr.size();
        // 左边界 left[i] 为左侧严格小于 arr[i] 的最近元素位置（不存在时为 -1）
        vector<int> left(n, -1);
        stack<int> st;
        for (int i = 0; i < n; ++i) {
            while (!st.empty() && arr[st.top()] >= arr[i])
                st.pop(); // 移除无用数据
            if (!st.empty()) left[i] = st.top();
            st.push(i);
        }

        // 右边界 right[i] 为右侧小于等于 arr[i] 的最近元素位置（不存在时为 n）
        vector<int> right(n, n);
        while (!st.empty()) st.pop();
        for (int i = n - 1; i >= 0; --i) {
            while (!st.empty() && arr[st.top()] > arr[i])
                st.pop(); // 移除无用数据
            if (!st.empty()) right[i] = st.top();
            st.push(i);
        }

        long ans = 0L;
        for (int i = 0; i < n; ++i)
            ans += (long) arr[i] * (i - left[i]) * (right[i] - i); // 累加贡献
        return ans % MOD;
    }
};
```

```Go
func sumSubarrayMins(arr []int) (ans int) {
    n := len(arr)
    // 左边界 left[i] 为左侧严格小于 arr[i] 的最近元素位置（不存在时为 -1）
    left := make([]int, n)
    st := []int{-1} // 方便赋值 left
    for i, x := range arr {
        for len(st) > 1 && arr[st[len(st)-1]] >= x {
            st = st[:len(st)-1] // 移除无用数据
        }
        left[i] = st[len(st)-1]
        st = append(st, i)
    }

    // 右边界 right[i] 为右侧小于等于 arr[i] 的最近元素位置（不存在时为 n）
    right := make([]int, n)
    st = []int{n} // 方便赋值 right
    for i := n - 1; i >= 0; i-- {
        for len(st) > 1 && arr[st[len(st)-1]] > arr[i] {
            st = st[:len(st)-1] // 移除无用数据
        }
        right[i] = st[len(st)-1]
        st = append(st, i)
    }

    for i, x := range arr {
        ans += x * (i - left[i]) * (right[i] - i) // 累加贡献
    }
    return ans % (1e9 + 7)
}
```

#### [](https://leetcode.cn/problems/sum-of-subarray-minimums/solution/gong-xian-fa-dan-diao-zhan-san-chong-shi-gxa5//#版本二：两次遍历)版本二：两次遍历

注意到在计算 left 的过程中，如果栈顶元素 ≥arr[i]，那么 i 就是栈顶元素的右边界，因此前两个循环可以合并。

更详细的解释：对于栈顶元素 t，如果 t 右侧有多个小于或等于 t 的元素，那么 t 只会因为**右侧第一个**小于或等于 t 的元素而出栈，这恰好符合右边界的定义。

```Python
class Solution:
    def sumSubarrayMins(self, arr: List[int]) -> int:
        n = len(arr)
        left, right, st = [-1] * n, [n] * n, []
        for i, x in enumerate(arr):
            while st and arr[st[-1]] >= x:
                right[st.pop()] = i  # i 恰好是栈顶的右边界
            if st: left[i] = st[-1]
            st.append(i)

        ans = 0
        for i, (x, l, r) in enumerate(zip(arr, left, right)):
            ans += x * (i - l) * (r - i)  # 累加贡献
        return ans % (10 ** 9 + 7)
```

```Java
class Solution {
    private static final long MOD = (long) 1e9 + 7;

    public int sumSubarrayMins(int[] arr) {
        var n = arr.length;
        var left = new int[n];
        var right = new int[n];
        Arrays.fill(right, n);
        var st = new ArrayDeque<Integer>();
        st.push(-1); // 方便赋值 left
        for (var i = 0; i < n; ++i) {
            while (st.size() > 1 && arr[st.peek()] >= arr[i])
                right[st.pop()] = i; // i 恰好是栈顶的右边界
            left[i] = st.peek();
            st.push(i);
        }

        var ans = 0L;
        for (var i = 0; i < n; ++i)
            ans += (long) arr[i] * (i - left[i]) * (right[i] - i); // 累加贡献
        return (int) (ans % MOD);
    }
}
```

```C++
class Solution {
    const int MOD = 1e9 + 7;
public:
    int sumSubarrayMins(vector<int> &arr) {
        int n = arr.size();
        vector<int> left(n, -1), right(n, n);
        stack<int> st;
        for (int i = 0; i < n; ++i) {
            while (!st.empty() && arr[st.top()] >= arr[i]) {
                right[st.top()] = i; // i 恰好是栈顶的右边界
                st.pop();
            }
            if (!st.empty()) left[i] = st.top();
            st.push(i);
        }

        long ans = 0L;
        for (int i = 0; i < n; ++i)
            ans += (long) arr[i] * (i - left[i]) * (right[i] - i); // 累加贡献
        return ans % MOD;
    }
};
```

```Go
func sumSubarrayMins(arr []int) (ans int) {
    n := len(arr)
    left := make([]int, n)
    right := make([]int, n)
    for i := range right {
        right[i] = n
    }
    st := []int{-1} // 方便赋值 left
    for i, x := range arr {
        for len(st) > 1 && arr[st[len(st)-1]] >= x {
            right[st[len(st)-1]] = i // i 恰好是栈顶的右边界
            st = st[:len(st)-1]
        }
        left[i] = st[len(st)-1]
        st = append(st, i)
    }

    for i, x := range arr {
        ans += x * (i - left[i]) * (right[i] - i) // 累加贡献
    }
    return ans % (1e9 + 7)
}
```

#### [](https://leetcode.cn/problems/sum-of-subarray-minimums/solution/gong-xian-fa-dan-diao-zhan-san-chong-shi-gxa5//#版本三：一次遍历)版本三：一次遍历

进一步地，由于栈顶下面的元素正好也是栈顶的左边界，所以甚至连 left 和 right 数组都可以不要，直接在出栈的时候计算贡献。

为简化代码逻辑，可以在遍历前，往 arr 末尾和栈顶分别加一个 −1，当作哨兵。

```Python
class Solution:
    def sumSubarrayMins(self, arr: List[int]) -> int:
        arr.append(-1)
        ans, st = 0, [-1]  # 哨兵
        for r, x in enumerate(arr):
            # 也可以 while arr[st[-1]] > x，效率略高一点
            while len(st) > 1 and arr[st[-1]] >= x:
                i = st.pop()
                ans += arr[i] * (i - st[-1]) * (r - i)  # 累加贡献
            st.append(r)
        return ans % (10 ** 9 + 7)
```

```Java
class Solution {
    private static final long MOD = (long) 1e9 + 7;

    public int sumSubarrayMins(int[] arr) {
        var ans = 0L;
        var st = new ArrayDeque<Integer>();
        st.push(-1); // 哨兵
        for (var r = 0; r <= arr.length; ++r) {
            var x = r < arr.length ? arr[r] : -1; // 假设 arr 末尾有个 -1
            while (st.size() > 1 && arr[st.peek()] >= x) {
                var i = st.pop();
                ans += (long) arr[i] * (i - st.peek()) * (r - i); // 累加贡献
            }
            st.push(r);
        }
        return (int) (ans % MOD);
    }
}
```

```C++
class Solution {
    const int MOD = 1e9 + 7;
public:
    int sumSubarrayMins(vector<int> &arr) {
        long ans = 0L;
        arr.push_back(-1);
        stack<int> st;
        st.push(-1); // 哨兵
        for (int r = 0; r < arr.size(); ++r) {
            while (st.size() > 1 && arr[st.top()] >= arr[r]) {
                int i = st.top();
                st.pop();
                ans += (long) arr[i] * (i - st.top()) * (r - i); // 累加贡献
            }
            st.push(r);
        }
        return ans % MOD;
    }
};
```

```Go
func sumSubarrayMins(arr []int) (ans int) {
    arr = append(arr, -1)
    st := []int{-1} // 哨兵
    for r, x := range arr {
        for len(st) > 1 && arr[st[len(st)-1]] >= x {
            i := st[len(st)-1]
            st = st[:len(st)-1]
            ans += arr[i] * (i - st[len(st)-1]) * (r - i) // 累加贡献
        }
        st = append(st, r)
    }
    return ans % (1e9 + 7)
}
```

#### [](https://leetcode.cn/problems/sum-of-subarray-minimums/solution/gong-xian-fa-dan-diao-zhan-san-chong-shi-gxa5//#复杂度分析)复杂度分析

-   时间复杂度：O(n)，其中 n 为 arr 的长度。虽然我们写了个二重循环，但站在 arr[i] 的视角看，i 在二重循环中最多入栈出栈各一次，因此整个二重循环的时间复杂度为 O(n)。
-   空间复杂度：O(n)。最坏情况下，栈里面有 O(n) 个元素。
