#### [](https://leetcode.cn/problems/score-of-parentheses/solution/gua-hao-de-fen-shu-by-leetcode-solution-we6b//#��������ջ)��������ջ

���ǰ�ƽ���ַ��� s ������һ�����ַ������� s �������Ҷ�����ַ����ķ���Ϊ 0��ʹ��ջ st ��¼ƽ���ַ����ķ������ڿ�ʼ֮ǰҪѹ����� 0����ʾ���ַ����ķ�����

�ڱ����ַ��� s �Ĺ����У�

-   ���������ţ���ô������Ҫ������������ڲ�����ƽ�������ַ��� A �ķ���������ҲҪ��ѹ����� 0����ʾ A ǰ��Ŀ��ַ����ķ�����

-   ���������ţ�˵�����������ڲ�����ƽ�������ַ��� A �ķ����Ѿ���������ˣ����ǽ�������ջ�������浽���� v �С���� v=0����ô˵����ƽ�������ַ��� A �ǿմ���(A) �ķ���Ϊ 1������ (A) �ķ���Ϊ 2v��Ȼ�� (A) �ķ����ӵ�ջ��Ԫ���ϡ�

����������ջ��Ԫ�ر���ľ��� s �ķ�����

```Python
class Solution:
    def scoreOfParentheses(self, s: str) -> int:
        st = [0]
        for c in s:
            if c == '(':
                st.append(0)
            else:
                v = st.pop()
                st[-1] += max(2 * v, 1)
        return st[-1]

```

```C++
class Solution {
public:
    int scoreOfParentheses(string s) {
        stack<int> st;
        st.push(0);
        for (auto c : s) {
            if (c == '(') {
                st.push(0);
            } else {
                int v = st.top();
                st.pop();
                st.top() += max(2 * v, 1);
            }
        }
        return st.top();
    }
};

```

```Java
class Solution {
    public int scoreOfParentheses(String s) {
        Deque<Integer> st = new ArrayDeque<Integer>();
        st.push(0);
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == '(') {
                st.push(0);
            } else {
                int v = st.pop();
                int top = st.pop() + Math.max(2 * v, 1);
                st.push(top);
            }
        }
        return st.peek();
    }
}

```

```C#
public class Solution {
    public int ScoreOfParentheses(string s) {
        Stack<int> st = new Stack<int>();
        st.Push(0);
        foreach (char c in s) {
            if (c == '(') {
                st.Push(0);
            } else {
                int v = st.Pop();
                int top = st.Pop() + Math.Max(2 * v, 1);
                st.Push(top);
            }
        }
        return st.Peek();
    }
}

```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int scoreOfParentheses(char * s) {
    int len = strlen(s);
    int stack[len + 1], top = 0;
    stack[top++] = 0;
    for (int i = 0; i < len; i++) {
        if (s[i] == '(') {
            stack[top++] = 0;
        } else {
            int v = stack[top - 1];
            top--;
            stack[top - 1] += MAX(2 * v, 1);
        }
    }
    return stack[top - 1];
}

```

```Go
func scoreOfParentheses(s string) int {
    st := []int{0}
    for _, c := range s {
        if c == '(' {
            st = append(st, 0)
        } else {
            v := st[len(st)-1]
            st = st[:len(st)-1]
            st[len(st)-1] += max(2*v, 1)
        }
    }
    return st[0]
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}

```

```JavaScript
var scoreOfParentheses = function(s) {
    const st = [0];
    for (let i = 0; i < s.length; i++) {
        if (s[i] === '(') {
            st.push(0);
        } else {
            let v = st.pop();
            let top = st.pop() + Math.max(2 * v, 1);
            st.push(top);
        }
    }
    return st[0];
};

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ���ַ����ĳ��ȡ�
-   �ռ临�Ӷȣ�O(n)��ջ��Ҫ O(n) �Ŀռ䡣
