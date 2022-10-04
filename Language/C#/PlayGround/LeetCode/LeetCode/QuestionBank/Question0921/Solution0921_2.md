#### [](https://leetcode.cn/problems/minimum-add-to-make-parentheses-valid/solution/shi-gua-hao-you-xiao-de-zui-shao-tian-ji-gcxu//#����һ��̰��)����һ��̰��

�����������ƥ�����Ŀ��ÿ�������ű����Ӧһ�������ţ����������ű����ڶ�Ӧ��������֮ǰ��

��������ƥ�����Ŀ�����õ�������ʹ��ջ����ƥ�䣬ջ���к���ȳ����ص㣬��˿��Ա�֤�����ź�����������Ž���ƥ�䡣��ʵ����������ʹ�ü�������ջ������ƥ��ʱÿ�ζ�ȡ���뵱ǰλ����������ţ��Ϳ���ȷ��ƽ�⡣

�����ұ����ַ������ڱ���������ά�������ŵĸ����Լ���Ӵ�����

������������ţ��������ŵĸ����� 1��

������������ţ�����Ҫ��ǰ��������Ž���ƥ�䣬�����������£�

-   ��������ŵĸ������� 0����ǰ���������ſ���ƥ�䣬��˽������ŵĸ����� 1����ʾ��һ�������ź͵�ǰ������ƥ�䣻

-   ��������ŵĸ������� 0����ǰ��û�������ſ���ƥ�䣬��Ҫ���һ�������Ų���ƥ�䣬��˽���Ӵ����� 1��


������������Ҫ��������ŵĸ����Ƿ�Ϊ 0�������Ϊ 0����˵������ʣ�µ�������û��ƥ�䣬����ÿ��ʣ�µ������Ŷ���Ҫ���һ�������Ų���ƥ�䣬��ʱ��Ҫ��ӵ������Ÿ���Ϊʣ�µ������Ÿ���������Ҫ��ӵ������Ÿ����ӵ���Ӵ�����

������������ӵ���������������������޷�����ƥ�������²Ž�����ӣ�������������õ�����Ӵ��������ٵġ�

```Python
class Solution:
    def minAddToMakeValid(self, s: str) -> int:
        ans = cnt = 0
        for c in s:
            if c == '(':
                cnt += 1
            elif cnt > 0:
                cnt -= 1
            else:
                ans += 1
        return ans + cnt

```

```Java
class Solution {
    public int minAddToMakeValid(String s) {
        int ans = 0;
        int leftCount = 0;
        int length = s.length();
        for (int i = 0; i < length; i++) {
            char c = s.charAt(i);
            if (c == '(') {
                leftCount++;
            } else {
                if (leftCount > 0) {
                    leftCount--;
                } else {
                    ans++;
                }
            }
        }
        ans += leftCount;
        return ans;
    }
}

```

```C#
public class Solution {
    public int MinAddToMakeValid(string s) {
        int ans = 0;
        int leftCount = 0;
        int length = s.Length;
        for (int i = 0; i < length; i++) {
            char c = s[i];
            if (c == '(') {
                leftCount++;
            } else {
                if (leftCount > 0) {
                    leftCount--;
                } else {
                    ans++;
                }
            }
        }
        ans += leftCount;
        return ans;
    }
}

```

```C++
class Solution {
public:
    int minAddToMakeValid(string s) {
        int ans = 0;
        int leftCount = 0;
        for (auto &c : s) {
            if (c == '(') {
                leftCount++;
            } else {
                if (leftCount > 0) {
                    leftCount--;
                } else {
                    ans++;
                }
            }
        }
        ans += leftCount;
        return ans;
    }
};

```

```C
int minAddToMakeValid(char * s){
    int ans = 0;
    int leftCount = 0;
    int length = strlen(s);
    for (int i = 0; i < length; i++) {
        char c = s[i];
        if (c == '(') {
            leftCount++;
        } else {
            if (leftCount > 0) {
                leftCount--;
            } else {
                ans++;
            }
        }
    }
    ans += leftCount;
    return ans;
}

```

```JavaScript
var minAddToMakeValid = function(s) {
    let ans = 0;
    let leftCount = 0;
    let length = s.length;
    for (let i = 0; i < length; i++) {
        const c = s[i];
        if (c === '(') {
            leftCount++;
        } else {
            if (leftCount > 0) {
                leftCount--;
            } else {
                ans++;
            }
        }
    }
    ans += leftCount;
    return ans;
};

```

```Go
func minAddToMakeValid(s string) (ans int) {
    cnt := 0
    for _, c := range s {
        if c == '(' {
            cnt++
        } else if cnt > 0 {
            cnt--
        } else {
            ans++
        }
    }
    return ans + cnt
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ���ַ����ĳ��ȡ������ַ���һ�Ρ�

-   �ռ临�Ӷȣ�O(1)��ֻ��Ҫά�������Ķ���ռ䡣
