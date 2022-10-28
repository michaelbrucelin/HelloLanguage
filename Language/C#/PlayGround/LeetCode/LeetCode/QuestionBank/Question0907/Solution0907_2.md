#### [](https://leetcode.cn/problems/sum-of-subarray-minimums/solution/zi-shu-zu-de-zui-xiao-zhi-zhi-he-by-leet-bp3k//#方法一：单调栈)方法一：单调栈

考虑所有满足以数组 arr 中的某个元素 arr[i] 为最右且最小的元素的子序列个数 C[i]，那么题目要求求连续子数组的最小值之和即为$\sum\limits_{i=0}^{n-1}arr[i] \times C[i]$，其中数组 arr 的长度为 n。我们必须假设当前元素为最右边且最小的元素，这样才可以构造互不相交的子序列，否则会出现多次计算，因为一个数组的最小值可能不唯一。

经过以上思考，我们只需要找到每个元素 arr[i] 以该元素为最右且最小的子序列的数目 left[i]，以及以该元素为最左且最小的子序列的数目 right[i]，则以 arr[i] 为最小元素的子序列的数目合计为 left[i]×right[i]。当然为了防止重复计算，我们可以设 arr[i] 左边的元素都必须满足小于等于 arr[i]，arr[i] 右边的元素必须满足严格小于 arr[i]。当然这就变成求最小的下标 j≤i，且连续子序列中的元素 arr[j],arr[j+1],⋯ ,arr[i] 都满足大于等于 arr[i]，以及最大的下标 k>i 满足连续子序列 arr[i+1],arr[i+1],⋯ ,arr[k] 都满足严格大于 arr[i]。上述即转化为经典的单调栈问题，即求数组中当前元素 x 左边第一个小于 x 的元素以及右边第一个小于等于 x 的元素，关于「[单调栈](https://leetcode.cn/link/?target=https://oi-wiki.org/ds/monotonous-stack/)」的算法细节，可以参考「[496\. 下一个更大元素 I 题解](https://leetcode.cn/problems/next-greater-element-i/solutions/1065517/xia-yi-ge-geng-da-yuan-su-i-by-leetcode-bfcoj/)」。

对于数组中每个元素 arr[i]，具体做法如下：

-   求左边第一个小于 arr[i] 的元素：从左向右遍历数组，并维护一个单调递增的栈，遍历当前元素 arr[i]，如果遇到当前栈顶的元素大于等于 arr[i] 则将其弹出，直到栈顶的元素小于 arr[i]，栈顶的元素即为左边第一个小于 arr[i] 的元素 arr[j]，此时 left[i]=i−j。
-   求右边第一个大于等于 arr[i] 的元素：从右向左遍历数组，维护一个单调递增的栈，遍历当前元素 arr[i]，如果遇到当前栈顶的元素大于 arr[i] 则将其弹出，直到栈顶的元素小于等于 arr[i]，栈顶的元素即为右边第一个小于等于 arr[i] 的元素 arr[k]，此时 right[i]=k−i。
-   连续子数组 arr[j],arr[j+1],⋯ ,arr[k] 的最小元素即为 arr[i]，以 arr[i] 为最小元素的连续子序列的数量为 (i−j)×(k−i)。

根据以上结论可以知道，所有子数组的最小值之和即为$\sum\limits_{i=0}^{n-1} arr[i] \times left[i] \times right[i]$。维护单调栈的过程线性的，因为只进行了线性次的入栈和出栈。

```Python
MOD = 10 ** 9 + 7

class Solution:
    def sumSubarrayMins(self, arr: List[int]) -> int:
        n = len(arr)
        monoStack = []
        left = [0] * n
        right = [0] * n
        for i, x in enumerate(arr):
            while monoStack and x <= arr[monoStack[-1]]:
                monoStack.pop()
            left[i] = i - (monoStack[-1] if monoStack else -1)
            monoStack.append(i)
        monoStack = []
        for i in range(n - 1, -1, -1):
            while monoStack and arr[i] < arr[monoStack[-1]]:
                monoStack.pop()
            right[i] = (monoStack[-1] if monoStack else n) - i
            monoStack.append(i)
        ans = 0
        for l, r, x in zip(left, right, arr):
            ans = (ans + l * r * x) % MOD
        return ans
```

```C++
class Solution {
public:
    int sumSubarrayMins(vector<int>& arr) {
        int n = arr.size();
        vector<int> monoStack;
        vector<int> left(n), right(n);
        for (int i = 0; i < n; i++) {
            while (!monoStack.empty() && arr[i] <= arr[monoStack.back()]) {
                monoStack.pop_back();
            }
            left[i] = i - (monoStack.empty() ? -1 : monoStack.back());
            monoStack.emplace_back(i);
        }
        monoStack.clear();
        for (int i = n - 1; i >= 0; i--) {
            while (!monoStack.empty() && arr[i] < arr[monoStack.back()]) {
                monoStack.pop_back();
            }
            right[i] = (monoStack.empty() ? n : monoStack.back()) - i;
            monoStack.emplace_back(i);
        }
        long long ans = 0;
        long long mod = 1e9 + 7;
        for (int i = 0; i < n; i++) {
            ans = (ans + (long long)left[i] * right[i] * arr[i]) % mod; 
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int sumSubarrayMins(int[] arr) {
        int n = arr.length;
        Deque<Integer> monoStack = new ArrayDeque<Integer>();
        int[] left = new int[n];
        int[] right = new int[n];
        for (int i = 0; i < n; i++) {
            while (!monoStack.isEmpty() && arr[i] <= arr[monoStack.peek()]) {
                monoStack.pop();
            }
            left[i] = i - (monoStack.isEmpty() ? -1 : monoStack.peek());
            monoStack.push(i);
        }
        monoStack.clear();
        for (int i = n - 1; i >= 0; i--) {
            while (!monoStack.isEmpty() && arr[i] < arr[monoStack.peek()]) {
                monoStack.pop();
            }
            right[i] = (monoStack.isEmpty() ? n : monoStack.peek()) - i;
            monoStack.push(i);
        }
        long ans = 0;
        final int MOD = 1000000007;
        for (int i = 0; i < n; i++) {
            ans = (ans + (long) left[i] * right[i] * arr[i]) % MOD; 
        }
        return (int) ans;
    }
}
```

```C#
public class Solution {
    public int SumSubarrayMins(int[] arr) {
        int n = arr.Length;
        Stack<int> monoStack = new Stack<int>();
        int[] left = new int[n];
        int[] right = new int[n];
        for (int i = 0; i < n; i++) {
            while (monoStack.Count > 0 && arr[i] <= arr[monoStack.Peek()]) {
                monoStack.Pop();
            }
            left[i] = i - (monoStack.Count == 0 ? -1 : monoStack.Peek());
            monoStack.Push(i);
        }
        monoStack.Clear();
        for (int i = n - 1; i >= 0; i--) {
            while (monoStack.Count > 0 && arr[i] < arr[monoStack.Peek()]) {
                monoStack.Pop();
            }
            right[i] = (monoStack.Count == 0 ? n : monoStack.Peek()) - i;
            monoStack.Push(i);
        }
        long ans = 0;
        const int MOD = 1000000007;
        for (int i = 0; i < n; i++) {
            ans = (ans + (long) left[i] * right[i] * arr[i]) % MOD; 
        }
        return (int) ans;
    }
}
```

```C
int sumSubarrayMins(int* arr, int arrSize) {
    int monoStack[arrSize], left[arrSize], right[arrSize];
    int top = 0;
    for (int i = 0; i < arrSize; i++) {
        while (top != 0 && arr[i] <= arr[monoStack[top - 1]]) {
            top--;
        }
        left[i] = i - (top == 0 ? -1 : monoStack[top - 1]);
        monoStack[top++] = i;
    }
    top = 0;
    for (int i = arrSize - 1; i >= 0; i--) {
        while (top != 0 && arr[i] < arr[monoStack[top - 1]]) {
            top--;
        }
        right[i] = (top == 0 ? arrSize : monoStack[top - 1]) - i;
        monoStack[top++] = i;
    }
    long long ans = 0;
    long long mod = 1e9 + 7;
    for (int i = 0; i < arrSize; i++) {
        ans = (ans + (long long)left[i] * right[i] * arr[i]) % mod; 
    }
    return ans;
}
```

```JavaScript
var sumSubarrayMins = function(arr) {
    const n = arr.length;
    let monoStack = [];
    const left = new Array(n).fill(0);
    const right = new Array(n).fill(0);
    for (let i = 0; i < n; i++) {
        while (monoStack.length !== 0 && arr[i] <= arr[monoStack[monoStack.length - 1]]) {
            monoStack.pop();
        }
        left[i] = i - (monoStack.length === 0 ? -1 : monoStack[monoStack.length - 1]);
        monoStack.push(i);
    }
    monoStack = [];
    for (let i = n - 1; i >= 0; i--) {
        while (monoStack.length !== 0 && arr[i] < arr[monoStack[monoStack.length - 1]]) {
            monoStack.pop();
        }
        right[i] = (monoStack.length === 0 ? n : monoStack[monoStack.length - 1]) - i;
        monoStack.push(i);
    }
    let ans = 0;
    const MOD = 1000000007;
    for (let i = 0; i < n; i++) {
        ans = (ans + left[i] * right[i] * arr[i]) % MOD; 
    }
    return ans;
};
```

```Go
func sumSubarrayMins(arr []int) (ans int) {
    const mod int = 1e9 + 7
    n := len(arr)
    left := make([]int, n)
    right := make([]int, n)
    monoStack := []int{}
    for i, x := range arr {
        for len(monoStack) > 0 && x <= arr[monoStack[len(monoStack)-1]] {
            monoStack = monoStack[:len(monoStack)-1]
        }
        if len(monoStack) == 0 {
            left[i] = i + 1
        } else {
            left[i] = i - monoStack[len(monoStack)-1]
        }
        monoStack = append(monoStack, i)
    }
    monoStack = []int{}
    for i := n - 1; i >= 0; i-- {
        for len(monoStack) > 0 && arr[i] < arr[monoStack[len(monoStack)-1]] {
            monoStack = monoStack[:len(monoStack)-1]
        }
        if len(monoStack) == 0 {
            right[i] = n - i
        } else {
            right[i] = monoStack[len(monoStack)-1] - i
        }
        monoStack = append(monoStack, i)
    }
    for i, x := range arr {
        ans = (ans + left[i]*right[i]*x) % mod
    }
    return
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 为数组的长度。利用单调栈求出每个元素为最小值的子序列长度需要的时间为 O(n)，求出连续子数组的最小值的总和需要的时间为 O(n)，因此总的时间复杂度为 O(n)。
-   空间复杂度：O(n)。其中 n 为数组的长度。我们需要保存以每个元素为最小元素的子序列长度，所需的空间为 O(n)。
