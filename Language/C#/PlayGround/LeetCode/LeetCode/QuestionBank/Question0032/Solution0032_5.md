#### [������������Ҫ����Ŀռ�](https://leetcode.cn/problems/longest-valid-parentheses/solutions/314683/zui-chang-you-xiao-gua-hao-by-leetcode-solution/)

**˼·���㷨**

�ڴ˷����У������������������� left �� right �����ȣ����Ǵ����ұ����ַ���������������ÿ�� ��(������������ left ������������������ÿ�� ��)�� ���������� right ��������ÿ�� left �������� right ���������ʱ�����Ǽ��㵱ǰ��Ч�ַ����ĳ��ȣ����Ҽ�¼ĿǰΪֹ�ҵ�������ַ������� right �������� left ��������ʱ�����ǽ� left �� right ������ͬʱ��� 0��

����������̰�ĵؿ������Ե�ǰ�ַ��±��β����Ч���ų��ȣ�ÿ�ε���������������������������ʱ��֮ǰ���ַ����Ƕ��ӵ����ٿ��ǣ����´���һ���ַ���ʼ���㣬��������©��һ����������Ǳ�����ʱ�������ŵ�����ʼ�մ��������ŵ��������� `(()` ������ʱ�����Ч�������󲻳����ġ�

����ķ���Ҳ�ܼ򵥣�����ֻ��Ҫ����������������Ƶķ������㼴�ɣ�ֻ�����ʱ���ж��������˹�����
-   �� left �������� right ��������ʱ�����ǽ� left �� right ������ͬʱ��� 0
-   �� left �������� right ���������ʱ�����Ǽ��㵱ǰ��Ч�ַ����ĳ��ȣ����Ҽ�¼ĿǰΪֹ�ҵ�������ַ���

�������Ǿ��ܺ�����������Ӷ������𰸡�

![](./assets/img/Solution0032_5_01.png)
![](./assets/img/Solution0032_5_02.png)
![](./assets/img/Solution0032_5_03.png)
![](./assets/img/Solution0032_5_04.png)
![](./assets/img/Solution0032_5_05.png)
![](./assets/img/Solution0032_5_06.png)
![](./assets/img/Solution0032_5_07.png)
![](./assets/img/Solution0032_5_08.png)
![](./assets/img/Solution0032_5_09.png)
![](./assets/img/Solution0032_5_10.png)
![](./assets/img/Solution0032_5_11.png)
![](./assets/img/Solution0032_5_12.png)
![](./assets/img/Solution0032_5_13.png)
![](./assets/img/Solution0032_5_14.png)
![](./assets/img/Solution0032_5_15.png)
![](./assets/img/Solution0032_5_16.png)
![](./assets/img/Solution0032_5_17.png)

```java
class Solution {
    public int longestValidParentheses(String s) {
        int left = 0, right = 0, maxlength = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == '(') {
                left++;
            } else {
                right++;
            }
            if (left == right) {
                maxlength = Math.max(maxlength, 2 * right);
            } else if (right > left) {
                left = right = 0;
            }
        }
        left = right = 0;
        for (int i = s.length() - 1; i >= 0; i--) {
            if (s.charAt(i) == '(') {
                left++;
            } else {
                right++;
            }
            if (left == right) {
                maxlength = Math.max(maxlength, 2 * left);
            } else if (left > right) {
                left = right = 0;
            }
        }
        return maxlength;
    }
}
```

```cpp
class Solution {
public:
    int longestValidParentheses(string s) {
        int left = 0, right = 0, maxlength = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s[i] == '(') {
                left++;
            } else {
                right++;
            }
            if (left == right) {
                maxlength = max(maxlength, 2 * right);
            } else if (right > left) {
                left = right = 0;
            }
        }
        left = right = 0;
        for (int i = (int)s.length() - 1; i >= 0; i--) {
            if (s[i] == '(') {
                left++;
            } else {
                right++;
            }
            if (left == right) {
                maxlength = max(maxlength, 2 * left);
            } else if (left > right) {
                left = right = 0;
            }
        }
        return maxlength;
    }
};
```

```c
int longestValidParentheses(char* s) {
    int n = strlen(s);
    int left = 0, right = 0, maxlength = 0;
    for (int i = 0; i < n; i++) {
        if (s[i] == '(') {
            left++;
        } else {
            right++;
        }
        if (left == right) {
            maxlength = fmax(maxlength, 2 * right);
        } else if (right > left) {
            left = right = 0;
        }
    }
    left = right = 0;
    for (int i = n - 1; i >= 0; i--) {
        if (s[i] == '(') {
            left++;
        } else {
            right++;
        }
        if (left == right) {
            maxlength = fmax(maxlength, 2 * left);
        } else if (left > right) {
            left = right = 0;
        }
    }
    return maxlength;
}
```

```go
func longestValidParentheses(s string) int {
    left, right, maxLength := 0, 0, 0
    for i := 0; i < len(s); i++ {
        if s[i] == '(' {
            left++
        } else {
            right++
        }
        if left == right {
            maxLength = max(maxLength, 2 * right)
        } else if right > left {
            left, right = 0, 0
        }
    }
    left, right = 0, 0
    for i := len(s) - 1; i >= 0; i-- {
        if s[i] == '(' {
            left++
        } else {
            right++
        }
        if left == right {
            maxLength = max(maxLength, 2 * left)
        } else if left > right {
            left, right = 0, 0
        }
    }
    return maxLength
}

func max(x, y int) int {
    if x > y {
        return x
    }
    return y
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ� O(n)������ n Ϊ�ַ������ȡ�����ֻҪ�������������ַ������ɡ�
-   �ռ临�Ӷȣ� O(1)������ֻ��Ҫ�����ռ������ɱ�����
