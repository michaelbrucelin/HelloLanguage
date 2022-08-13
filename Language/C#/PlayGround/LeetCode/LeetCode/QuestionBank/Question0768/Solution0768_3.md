#### 方法二：单调栈

**思路**

对于已经分好块的数组，若块数大于 111，则可以得到以下结论：右边的块的所有数字均大于或等于左边的块的所有数字。考虑这个问题：对于已经分好块的数组，若在其末尾添加一个数字，如何求得新数组的分块方式？

新添加的数字可能会改变原数组的分块方式。如果新添加的数字大于或等于原数组最后一个块的最大值，则这个新添加的数字可以自己形成一个块。如果新添加的数字小于原数组最后一个块的最大值，则它必须融入最后一个块。如果它大于或等于原数组倒数第二个块（如果有）的最大值，那么这个过程可以停止，新数组的分块方式已经求得。否则，它将继续融合原数组倒数第二个块，直到遇到一个块，使得该块的最大值小于或等于这个新添加的数，或者这个数字已经融合了所有块。

上述分析过程中，我们只用到了块的最大值来进行比较，比较过程又是从右到左，符合栈的思想，因此可以用类似单调栈的数据结构来存储块的最大值。

**代码**

```Python3
class Solution:
    def maxChunksToSorted(self, arr: [int]) -> int:
        stack = []
        for a in arr:
            if len(stack) == 0 or a >= stack[-1]:
                stack.append(a)
            else:
                mx = stack.pop()
                while stack and stack[-1] > a:
                    stack.pop()
                stack.append(mx)
        return len(stack)

```

```Java
class Solution {
    public int maxChunksToSorted(int[] arr) {
        Deque<Integer> stack = new ArrayDeque<Integer>();
        for (int num : arr) {
            if (stack.isEmpty() || num >= stack.peek()) {
                stack.push(num);
            } else {
                int mx = stack.pop();
                while (!stack.isEmpty() && stack.peek() > num) {
                    stack.pop();
                }
                stack.push(mx);
            }
        }
        return stack.size();
    }
}

```

```C#
public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        Stack<int> stack = new Stack<int>();
        foreach (int num in arr) {
            if (stack.Count == 0 || num >= stack.Peek()) {
                stack.Push(num);
            } else {
                int mx = stack.Pop();
                while (stack.Count > 0 && stack.Peek() > num) {
                    stack.Pop();
                }
                stack.Push(mx);
            }
        }
        return stack.Count;
    }
}

```

```C++
class Solution {
public:
    int maxChunksToSorted(vector<int>& arr) {
        stack<int> st;
        for (auto &num : arr) {
            if (st.empty() || num >= st.top()) {
                st.emplace(num);
            } else {
                int mx = st.top();
                st.pop();
                while (!st.empty() && st.top() > num) {
                    st.pop();
                }
                st.emplace(mx);
            }
        }
        return st.size();
    }
};

```

```C
int maxChunksToSorted(int* arr, int arrSize){
    int *stack = (int *)malloc(sizeof(int) * arrSize);
    int top = 0;
    for (int i = 0; i < arrSize; i++) {
        int num = arr[i];
        if (top == 0 || num >= stack[top - 1]) {
            stack[top++] = num;
        } else {
            int mx = stack[top - 1];
            top--;
            while (top > 0 && stack[top - 1] > num) {
                top--;
            }
            stack[top++] = mx;
        }
    }
    free(stack);
    return top;
}

```

```Golang
func maxChunksToSorted(arr []int) int {
    st := []int{}
    for _, x := range arr {
        if len(st) == 0 || x >= st[len(st)-1] {
            st = append(st, x)
        } else {
            mx := st[len(st)-1]
            st = st[:len(st)-1]
            for len(st) > 0 && st[len(st)-1] > x {
                st = st[:len(st)-1]
            }
            st = append(st, mx)
        }
    }
    return len(st)
}

```

```JavaScript
var maxChunksToSorted = function(arr) {
    const stack = [];
    for (const num of arr) {
        if (stack.length === 0 || num >= stack[stack.length - 1]) {
            stack.push(num);
        } else {
            const mx = stack.pop();
            while (stack.length && stack[stack.length - 1] > num) {
                stack.pop();
            }
            stack.push(mx);
        }
    }
    return stack.length;
};

```

**复杂度分析**

-   时间复杂度：O(n)O(n)O(n)，其中 nnn 是输入数组 arr\\textit{arr}arr 的长度。需要遍历一遍数组，入栈的操作最多为 nnn 次。
    
-   空间复杂度：O(n)O(n)O(n)。栈的长度最多为 nnn。
