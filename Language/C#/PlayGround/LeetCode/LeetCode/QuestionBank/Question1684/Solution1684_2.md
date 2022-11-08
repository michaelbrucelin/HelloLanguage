#### [����һ������](https://leetcode.cn/problems/count-the-number-of-consistent-strings/solutions/1953831/tong-ji-yi-zhi-zi-fu-chuan-de-shu-mu-by-38356/)

�������֪���ַ��� allowed ���ַ������� words �е������ַ�����ֻ����Сд��ĸ��������ǿ�����һ�� 32 λ��������ʾһ���ַ������ֵ���ĸ���ϡ����һ����ĸ�����ˣ���ô����Ӧ������λ��Ϊ 1��ʹ�� mask ��ʾ�ַ��� allowed ���ֵ���ĸ���ϡ����α����ַ������� words������� i ���ַ��� words[i] ��Ӧ���ֵ���ĸ����Ϊ $mask_1$����ô words[i] ��һ���ַ����ȼ��� $mask_1$ �� mask ���Ӽ����� $mask_1 \cup mask = mask$��ͳ��һ���ַ�������Ŀ�����ؽ����

```python
class Solution:
    def countConsistentStrings(self, allowed: str, words: List[str]) -> int:
        mask = 0
        for c in allowed:
            mask |= 1 << (ord(c) - ord('a'))
        res = 0
        for word in words:
            mask1 = 0
            for c in word:
                mask1 |= 1 << (ord(c) - ord('a'))
            res += (mask1 | mask) == mask
        return res
```

```cpp
class Solution {
public:
    int countConsistentStrings(string allowed, vector<string>& words) {
        int mask = 0;
        for (auto c : allowed) {
            mask |= 1 << (c - 'a');
        }
        int res = 0;
        for (auto &&word : words) {
            int mask1 = 0;
            for (auto c : word) {
                mask1 |= 1 << (c - 'a');
            }
            if ((mask1 | mask) == mask) {
                res++;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int countConsistentStrings(String allowed, String[] words) {
        int mask = 0;
        for (int i = 0; i < allowed.length(); i++) {
            char c = allowed.charAt(i);
            mask |= 1 << (c - 'a');
        }
        int res = 0;
        for (String word : words) {
            int mask1 = 0;
            for (int i = 0; i < word.length(); i++) {
                char c = word.charAt(i);
                mask1 |= 1 << (c - 'a');
            }
            if ((mask1 | mask) == mask) {
                res++;
            }
        }
        return res;
    }
}
```

```c#
public class Solution {
    public int CountConsistentStrings(string allowed, string[] words) {
        int mask = 0;
        foreach (char c in allowed) {
            mask |= 1 << (c - 'a');
        }
        int res = 0;
        foreach (string word in words) {
            int mask1 = 0;
            foreach (char c in word) {
                mask1 |= 1 << (c - 'a');
            }
            if ((mask1 | mask) == mask) {
                res++;
            }
        }
        return res;
    }
}
```

```c
int countConsistentStrings(char * allowed, char ** words, int wordsSize){
    int mask = 0;
    for (int i = 0; allowed[i] != '\0'; i++) {
        mask |= 1 << (allowed[i] - 'a');
    }
    int res = 0;
    for (int i = 0; i <wordsSize; i++) {
        int mask1 = 0;
        for (int j = 0; words[i][j] != '\0'; j++) {
            mask1 |= 1 << (words[i][j] - 'a');
        }
        if ((mask1 | mask) == mask) {
            res++;
        }
    }
    return res;
}
```

```go
func countConsistentStrings(allowed string, words []string) (res int) {
    mask := 0
    for _, c := range allowed {
        mask |= 1 << (c - 'a')
    }
    for _, word := range words {
        mask1 := 0
        for _, c := range word {
            mask1 |= 1 << (c - 'a')
        }
        if mask1|mask == mask {
            res++
        }
    }
    return
}
```

```javascript
var countConsistentStrings = function(allowed, words) {
    let mask = 0;
    for (let i = 0; i < allowed.length; i++) {
        const c = allowed[i];
        mask |= 1 << (c.charCodeAt() - 'a'.charCodeAt());
    }
    let res = 0;
    for (const word of words) {
        let mask1 = 0;
        for (let i = 0; i < word.length; i++) {
            const c = word[i];
            mask1 |= 1 << (c.charCodeAt() - 'a'.charCodeAt());
        }
        if ((mask1 | mask) === mask) {
            res++;
        }
    }
    return res;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n + \sum m_i)$������ n ���ַ��� allowed �ĳ��ȣ�$m_i$ ���ַ��� words[i] �ĳ��ȡ�
-   �ռ临�Ӷȣ�O(1)��
