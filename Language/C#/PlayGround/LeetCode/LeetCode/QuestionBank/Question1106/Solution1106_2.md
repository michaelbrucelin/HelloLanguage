#### [����һ��ջ](https://leetcode.cn/problems/parsing-a-boolean-expression/solutions/1948172/jie-xi-bu-er-biao-da-shi-by-leetcode-sol-vmvg/)

�������ַ��� expression ����Ч�Ĳ������ʽ��ÿ����������涼��һ�����ţ���������һ���������ʽ�����У��߼���������������������һ�����ʽ���߼�����������߼������������������������������ϱ��ʽ��

����ʹ��ջʵ�ֲ������ʽ�Ľ����������ұ����������ʽ������ÿ�����͵��ַ���ִ����Ӧ�Ĳ�����
-   �����ǰ�ַ��Ƕ��ţ����������ַ���
-   �����ǰ�ַ��ǳ��˶��ź�����������������ַ����򽫸��ַ���ӵ�ջ�ڣ�
-   �����ǰ�ַ��������ţ���һ�����ʽ������������Ҫ�����ñ��ʽ��ֵ�����������ӵ�ջ�ڣ�
    1.  ��ջ���ַ����ε�����ֱ��ջ���ַ��������ţ�Ȼ�������ź��������ջ�ڵ�������¼������ ��t�� �� ��f�� �ĸ�����
    2.  ����������Լ� ��t�� �� ��f�� �ĸ���������ʽ��ֵ���������ʽ��ֵ��ӵ�ջ�ڣ�
        -   ���������� ��!���������߼�������������ʽ��ֵΪ�����ڵ�ֵȡ������˵� ��f�� �ĸ������� 1 ʱ���ʽ��ֵΪ ��t����������ʽ��ֵΪ ��f����
        -   ���������� ��&���������߼�����������������ڵ�����ֵ���� ��t�� ʱ����� ��t������������ ��f������˵� ��f�� �ĸ������� 0 ʱ���ʽ��ֵΪ ��t����������ʽ��ֵΪ ��f����
        -   ���������� ��|���������߼������������������������һ��ֵ���� ��t�� ʱ����� ��t������������ ��f������˵� ��t�� �ĸ������� 0 ʱ���ʽ��ֵΪ ��t����������ʽ��ֵΪ ��f����

��������֮��ջ��ֻ��һ���ַ������ַ�Ϊ ��t�� �� ��f��������ַ�Ϊ ��t�� �򷵻� true������ַ�Ϊ ��f�� �򷵻� false��

```Python
class Solution:
    def parseBoolExpr(self, expression: str) -> bool:
        stk = []
        for c in expression:
            if c == ',':
                continue
            if c != ')':
                stk.append(c)
                continue
            t = f = 0
            while stk[-1] != '(':
                if stk.pop() == 't':
                    t += 1
                else:
                    f += 1
            stk.pop()
            op = stk.pop()
            if op == '!':
                stk.append('t' if f == 1 else 'f')
            elif op == '&':
                stk.append('t' if f == 0 else 'f')
            elif op == '|':
                stk.append('t' if t else 'f')
        return stk[-1] == 't'
```

```Java
class Solution {
    public boolean parseBoolExpr(String expression) {
        Deque<Character> stack = new ArrayDeque<Character>();
        int n = expression.length();
        for (int i = 0; i < n; i++) {
            char c = expression.charAt(i);
            if (c == ',') {
                continue;
            } else if (c != ')') {
                stack.push(c);
            } else {
                int t = 0, f = 0;
                while (stack.peek() != '(') {
                    char val = stack.pop();
                    if (val == 't') {
                        t++;
                    } else {
                        f++;
                    }
                }
                stack.pop();
                char op = stack.pop();
                switch (op) {
                case '!':
                    stack.push(f == 1 ? 't' : 'f');
                    break;
                case '&':
                    stack.push(f == 0 ? 't' : 'f');
                    break;
                case '|':
                    stack.push(t > 0 ? 't' : 'f');
                    break;
                default:
                }
            }
        }
        return stack.pop() == 't';
    }
}
```

```C#
public class Solution {
    public bool ParseBoolExpr(string expression) {
        Stack<char> stack = new Stack<char>();
        int n = expression.Length;
        for (int i = 0; i < n; i++) {
            char c = expression[i];
            if (c == ',') {
                continue;
            } else if (c != ')') {
                stack.Push(c);
            } else {
                int t = 0, f = 0;
                while (stack.Peek() != '(') {
                    char val = stack.Pop();
                    if (val == 't') {
                        t++;
                    } else {
                        f++;
                    }
                }
                stack.Pop();
                char op = stack.Pop();
                switch (op) {
                case '!':
                    stack.Push(f == 1 ? 't' : 'f');
                    break;
                case '&':
                    stack.Push(f == 0 ? 't' : 'f');
                    break;
                case '|':
                    stack.Push(t > 0 ? 't' : 'f');
                    break;
                default:
                    break;
                }
            }
        }
        return stack.Pop() == 't';
    }
}
```

```C++
class Solution {
public:
    bool parseBoolExpr(string expression) {
        stack<char> stk;
        int n = expression.size();
        for (int i = 0; i < n; i++) {
            char c = expression[i];
            if (c == ',') {
                continue;
            } else if (c != ')') {
                stk.push(c);
            } else {
                int t = 0, f = 0;
                while (stk.top() != '(') {
                    char val = stk.top();
                    stk.pop();
                    if (val == 't') {
                        t++;
                    } else {
                        f++;
                    }
                }
                stk.pop();
                char op = stk.top();
                stk.pop();
                switch (op) {
                case '!':
                    stk.push(f == 1 ? 't' : 'f');
                    break;
                case '&':
                    stk.push(f == 0 ? 't' : 'f');
                    break;
                case '|':
                    stk.push(t > 0 ? 't' : 'f');
                    break;
                default:
                    break;
                }
            }
        }
        return stk.top() == 't';
    }
};
```

```C
bool parseBoolExpr(char * expression){
    int n = strlen(expression);
    char stack[n];
    int top = 0;
    for (int i = 0; i < n; i++) {
        char c = expression[i];
        if (c == ',') {
            continue;
        } else if (c != ')') {
            stack[top++] = c;
        } else {
            int t = 0, f = 0;
            while (stack[top - 1] != '(') {
                char val = stack[top - 1];
                top--;
                if (val == 't') {
                    t++;
                } else {
                    f++;
                }
            }
            top--;
            char op = stack[top - 1];
            top--;
            switch (op) {
            case '!':
                stack[top++] = f == 1 ? 't' : 'f';
                break;
            case '&':
                stack[top++] = f == 0 ? 't' : 'f';
                break;
            case '|':
                stack[top++] = t > 0 ? 't' : 'f';
                break;
            default:
                break;
            }
        }
    }
    return stack[top - 1] == 't';
}
```

```JavaScript
var parseBoolExpr = function(expression) {
    const stack = [];
    const n = expression.length;
    for (let i = 0; i < n; i++) {
        const c = expression[i];
        if (c === ',') {
            continue;
        } else if (c !== ')') {
            stack.push(c);
        } else {
            let t = 0, f = 0;
            while (stack[stack.length - 1] !== '(') {
                const val = stack.pop();
                if (val === 't') {
                    t++;
                } else {
                    f++;
                }
            }
            stack.pop();
            const op = stack.pop();
            switch (op) {
            case '!':
                stack.push(f === 1 ? 't' : 'f');
                break;
            case '&':
                stack.push(f === 0 ? 't' : 'f');
                break;
            case '|':
                stack.push(t > 0 ? 't' : 'f');
                break;
            default:
            }
        }
    }
    return stack.pop() === 't';
};
```

```Go
func parseBoolExpr(expression string) bool {
    stk := []rune{}
    for _, c := range expression {
        if c == ',' {
            continue
        }
        if c != ')' {
            stk = append(stk, c)
            continue
        }
        t := 0
        f := 0
        for stk[len(stk)-1] != '(' {
            val := stk[len(stk)-1]
            stk = stk[:len(stk)-1]
            if val == 't' {
                t++
            } else {
                f++
            }
        }
        stk = stk[:len(stk)-1]
        op := stk[len(stk)-1]
        stk = stk[:len(stk)-1]
        c = 't'
        switch op {
        case '!':
            if f != 1 {
                c = 'f'
            }
            stk = append(stk, c)
        case '&':
            if f != 0 {
                c = 'f'
            }
            stk = append(stk, c)
        case '|':
            if t == 0 {
                c = 'f'
            }
            stk = append(stk, c)
        }
    }
    return stk[len(stk)-1] == 't'
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n �ǲ������ʽ expression �ĳ��ȡ���Ҫ�����������ʽһ�β�������    
-   �ռ临�Ӷȣ�O(n)������ n �ǲ������ʽ expression �ĳ��ȡ��ռ临�Ӷ���Ҫȡ����ջ�ռ䣬ջ���ַ����������� n��
