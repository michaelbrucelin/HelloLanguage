#### ������������ջ

**˼·**

�����Ѿ��ֺÿ�����飬���������� 111������Եõ����½��ۣ��ұߵĿ���������־����ڻ������ߵĿ���������֡�����������⣺�����Ѿ��ֺÿ�����飬������ĩβ���һ�����֣�������������ķֿ鷽ʽ��

����ӵ����ֿ��ܻ�ı�ԭ����ķֿ鷽ʽ���������ӵ����ִ��ڻ����ԭ�������һ��������ֵ�����������ӵ����ֿ����Լ��γ�һ���顣�������ӵ�����С��ԭ�������һ��������ֵ�����������������һ���顣��������ڻ����ԭ���鵹���ڶ����飨����У������ֵ����ô������̿���ֹͣ��������ķֿ鷽ʽ�Ѿ���á��������������ں�ԭ���鵹���ڶ����飬ֱ������һ���飬ʹ�øÿ�����ֵС�ڻ�����������ӵ�����������������Ѿ��ں������п顣

�������������У�����ֻ�õ��˿�����ֵ�����бȽϣ��ȽϹ������Ǵ��ҵ��󣬷���ջ��˼�룬��˿��������Ƶ���ջ�����ݽṹ���洢������ֵ��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)O(n)O(n)������ nnn ���������� arr\\textit{arr}arr �ĳ��ȡ���Ҫ����һ�����飬��ջ�Ĳ������Ϊ nnn �Ρ�
    
-   �ռ临�Ӷȣ�O(n)O(n)O(n)��ջ�ĳ������Ϊ nnn��
