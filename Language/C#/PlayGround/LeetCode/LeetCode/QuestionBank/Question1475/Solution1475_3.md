#### ������������ջ

������Բ��á�[����ջ](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fds%2Fmonotonous-stack%2F)���Ľⷨ�����Բο���[496\. ��һ������Ԫ�� I �Ĺٷ����](https://leetcode.cn/problems/next-greater-element-i/solution/xia-yi-ge-geng-da-yuan-su-i-by-leetcode-bfcoj/)����ʹ�õ���ջ��Ԥ���� prices��ʹ�ò�ѯ prices ��ÿ��Ԫ�ض�Ӧλ�õ��ұߵĵ�һ����С��Ԫ��ֵʱ����Ҫ�ٱ��� prices���ⷨ���ص����ڿ�����θ���Ч�ؼ��� prices ��ÿ��Ԫ���ұߵ�һ����С��ֵ��������� prices�����õ���ջ��ά����ǰλ���ұߵĸ�С��Ԫ���б���ջ�׵�ջ����Ԫ���ǵ��������ġ�����ÿ�������ƶ���������һ���µ�λ�� i���ͽ�����ջ�����д��� prices\[i\] ��Ԫ�ص�������ջ����ǰλ���ұߵĵ�һ��С�ڵ��� prices\[i\] ��Ԫ�ؼ�Ϊջ��Ԫ�أ����ջΪ����˵����ǰλ���ұ�û�и����Ԫ�أ�������ǽ�λ�� i ��Ԫ����ջ��

�������� i ��Ԫ�� prices\[i\] ʱ��

-   �����ǰջ����Ԫ�ش��� prices\[i\]����ջ��Ԫ�س�ջ��ֱ��ջ����Ԫ��С�ڵ��� prices\[i\]��ջ����Ԫ�ؼ�Ϊ�ұߵ�һ��С�� prices\[i\] ��Ԫ�أ�

-   �����ǰջ����Ԫ��С�ڵ��� prices\[i\]����ʱ����֪����ǰջ��Ԫ�ؼ�Ϊ i ���ұߵ�һ��С�ڵ��� prices\[i\] ��Ԫ�أ���ʱ�� i ����Ʒ�ۺ�ļ۸�Ϊ prices\[i\] ��ջ����Ԫ�صĲ

-   �����ǰջ�е�Ԫ��Ϊ�գ����ʱ�ۿ�Ϊ 0����Ʒ�ļ۸�Ϊԭ�� prices\[i\]��
    
-   �� prices\[i\] ѹ��ջ�У���֤ prices\[i\] Ϊ��ǰջ�е����ֵ��

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ����ĳ��ȡ�ֻ�����һ�����鼴�ɡ�
    
-   �ռ临�Ӷȣ�O(n)����Ҫջ�ռ�洢�м��������Ҫ�Ŀռ�Ϊ O(n)��
