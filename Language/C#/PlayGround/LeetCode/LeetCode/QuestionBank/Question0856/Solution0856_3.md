#### [](https://leetcode.cn/problems/score-of-parentheses/solution/gua-hao-de-fen-shu-by-leetcode-solution-we6b//#方法二：栈)方法二：栈

我们把平衡字符串 s 看作是一个空字符串加上 s 本身，并且定义空字符串的分数为 0。使用栈 st 记录平衡字符串的分数，在开始之前要压入分数 0，表示空字符串的分数。

在遍历字符串 s 的过程中：

-   遇到左括号，那么我们需要计算该左括号内部的子平衡括号字符串 A 的分数，我们也要先压入分数 0，表示 A 前面的空字符串的分数。

-   遇到右括号，说明该右括号内部的子平衡括号字符串 A 的分数已经计算出来了，我们将它弹出栈，并保存到变量 v 中。如果 v=0，那么说明子平衡括号字符串 A 是空串，(A) 的分数为 1，否则 (A) 的分数为 2v，然后将 (A) 的分数加到栈顶元素上。

遍历结束后，栈顶元素保存的就是 s 的分数。

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

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是字符串的长度。
-   空间复杂度：O(n)。栈需要 O(n) 的空间。
