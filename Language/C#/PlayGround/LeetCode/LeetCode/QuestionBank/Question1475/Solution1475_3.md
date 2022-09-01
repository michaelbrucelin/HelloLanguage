#### 方法二：单调栈

本题可以采用「[单调栈](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fds%2Fmonotonous-stack%2F)」的解法，可以参考「[496\. 下一个更大元素 I 的官方题解](https://leetcode.cn/problems/next-greater-element-i/solution/xia-yi-ge-geng-da-yuan-su-i-by-leetcode-bfcoj/)」。使用单调栈先预处理 prices，使得查询 prices 中每个元素对应位置的右边的第一个更小的元素值时不需要再遍历 prices。解法的重点在于考虑如何更高效地计算 prices 中每个元素右边第一个更小的值。倒序遍历 prices，并用单调栈中维护当前位置右边的更小的元素列表，从栈底到栈顶的元素是单调递增的。具体每次我们移动到数组中一个新的位置 i，就将单调栈中所有大于 prices\[i\] 的元素弹出单调栈，当前位置右边的第一个小于等于 prices\[i\] 的元素即为栈顶元素，如果栈为空则说明当前位置右边没有更大的元素，随后我们将位置 i 的元素入栈。

当遍历第 i 个元素 prices\[i\] 时：

-   如果当前栈顶的元素大于 prices\[i\]，则将栈顶元素出栈，直到栈顶的元素小于等于 prices\[i\]，栈顶的元素即为右边第一个小于 prices\[i\] 的元素；

-   如果当前栈顶的元素小于等于 prices\[i\]，此时可以知道当前栈顶元素即为 i 的右边第一个小于等于 prices\[i\] 的元素，此时第 i 个物品折后的价格为 prices\[i\] 与栈顶的元素的差。

-   如果当前栈中的元素为空，则此时折扣为 0，商品的价格为原价 prices\[i\]；
    
-   将 prices\[i\] 压入栈中，保证 prices\[i\] 为当前栈中的最大值；

```Python3
class Solution:
    def finalPrices(self, prices: List[int]) -> List[int]:
        n = len(prices)
        ans = [0] * n
        st = [0]
        for i in range(n - 1, -1, -1):
            p = prices[i]
            while len(st) > 1 and st[-1] > p:
                st.pop()
            ans[i] = p - st[-1]
            st.append(p)
        return ans

```

```C++
class Solution {
public:
    vector<int> finalPrices(vector<int>& prices) {
        int n = prices.size();
        vector<int> ans(n);
        stack<int> st;
        for (int i = n - 1; i >= 0; i--) {
            while (!st.empty() && st.top() > prices[i]) {
                st.pop();
            }
            ans[i] = st.empty() ? prices[i] : prices[i] - st.top();
            st.emplace(prices[i]);
        }
        return ans;
    }
};

```

```Java
class Solution {
    public int[] finalPrices(int[] prices) {
        int n = prices.length;
        int[] ans = new int[n];
        Deque<Integer> stack = new ArrayDeque<Integer>();
        for (int i = n - 1; i >= 0; i--) {
            while (!stack.isEmpty() && stack.peek() > prices[i]) {
                stack.pop();
            }
            ans[i] = stack.isEmpty() ? prices[i] : prices[i] - stack.peek();
            stack.push(prices[i]);
        }
        return ans;
    }
}

```

```C#
public class Solution {
    public int[] FinalPrices(int[] prices) {
        int n = prices.Length;
        int[] ans = new int[n];
        Stack<int> stack = new Stack<int>();
        for (int i = n - 1; i >= 0; i--) {
            while (stack.Count > 0 && stack.Peek() > prices[i]) {
                stack.Pop();
            }
            ans[i] = stack.Count == 0 ? prices[i] : prices[i] - stack.Peek();
            stack.Push(prices[i]);
        }
        return ans;
    }
}

```

```C
int* finalPrices(int* prices, int pricesSize, int* returnSize) {
    int *ans = (int *)malloc(sizeof(int) * pricesSize);
    int *stack = (int *)malloc(sizeof(int) * pricesSize);
    int top = 0;
    for (int i = pricesSize - 1; i >= 0; i--) {
        while (top > 0 && stack[top - 1] > prices[i]) {
            top--;
        }
        ans[i] = top == 0 ? prices[i] : prices[i] - stack[top - 1];
        stack[top++] = prices[i];
    }
    *returnSize = pricesSize;
    free(stack);
    return ans;
}

```

```JavaScript
var finalPrices = function(prices) {
    const n = prices.length;
    const ans = new Array(n).fill(0);
    const stack = [];
    for (let i = n - 1; i >= 0; i--) {
        while (stack.length && stack[stack.length - 1] > prices[i]) {
            stack.pop();
        }
        ans[i] = stack.length === 0 ? prices[i] : prices[i] - stack[stack.length - 1];
        stack.push(prices[i]);
    }
    return ans;
};  

```

```Golang
func finalPrices(prices []int) []int {
    n := len(prices)
    ans := make([]int, n)
    st := []int{0}
    for i := n - 1; i >= 0; i-- {
        p := prices[i]
        for len(st) > 1 && st[len(st)-1] > p {
            st = st[:len(st)-1]
        }
        ans[i] = p - st[len(st)-1]
        st = append(st, p)
    }
    return ans
}

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 为数组的长度。只需遍历一遍数组即可。
    
-   空间复杂度：O(n)。需要栈空间存储中间变量，需要的空间为 O(n)。
