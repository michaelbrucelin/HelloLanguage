#### [����һ��ģ��](https://leetcode.cn/problems/minimum-changes-to-make-alternating-binary-string/solutions/1995159/sheng-cheng-jiao-ti-er-jin-zhi-zi-fu-chu-91c5/)

**˼·**

�������⣬������β�����s ���ܻ������ֲ�ͬ�Ľ���������ַ���������
-   ��ͷΪ 0������������ַ�����
-   ��ͷΪ 1������������ַ�����

ע�⵽����������ֲ�ͬ�Ľ���������ַ�������Ҫ�����ٲ��������������� s �ĳ��ȣ�����ֻ��Ҫ�������Ϊ����һ���ַ��������ٲ��������Ϳ����Ƴ���һ�����ٲ�������Ȼ��ȡ��Сֵ���ɡ�

**����**

```python
class Solution:
    def minOperations(self, s: str) -> int:
        cnt = sum(int(c) != i % 2 for i, c in enumerate(s))
        return min(cnt, len(s) - cnt)
```

```java
class Solution {
    public int minOperations(String s) {
        int cnt = 0;
        for (int i = 0; i < s.length(); i++) {
            char c = s.charAt(i);
            if (c != (char) ('0' + i % 2)) {
                cnt++;
            }
        }
        return Math.min(cnt, s.length() - cnt);
    }
}
```

```c#
public class Solution {
    public int MinOperations(string s) {
        int cnt = 0;
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (c != (char) ('0' + i % 2)) {
                cnt++;
            }
        }
        return Math.Min(cnt, s.Length - cnt);
    }
}
```

```cpp
class Solution {
public:
    int minOperations(string s) {
        int cnt = 0;
        for (int i = 0; i < s.size(); i++) {
            char c = s[i];
            if (c != ('0' + i % 2)) {
                cnt++;
            }
        }
        return min(cnt, (int)s.size() - cnt);
    }
};
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int minOperations(char * s) {
    int cnt = 0, len = strlen(s);
    for (int i = 0; i < len; i++) {
        char c = s[i];
        if (c != ('0' + i % 2)) {
            cnt++;
        }
    }
    return MIN(cnt, len - cnt);
}
```

```javascript
var minOperations = function(s) {
    let cnt = 0;
    for (let i = 0; i < s.length; i++) {
        const c = s[i];
        if (c !== (String.fromCharCode('0'.charCodeAt() + i % 2))) {
            cnt++;
        }
    }
    return Math.min(cnt, s.length - cnt);
};
```

```go
func minOperations(s string) int {
    cnt := 0
    for i, c := range s {
        if i%2 != int(c-'0') {
            cnt++
        }
    }
    return min(cnt, len(s)-cnt)
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ���� s �ĳ��ȣ��������һ���ַ�����
-   �ռ临�Ӷȣ�O(1)��ֻ��Ҫ��������ռ䡣
