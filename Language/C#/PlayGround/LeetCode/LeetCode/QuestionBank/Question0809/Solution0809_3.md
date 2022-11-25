#### [����һ��˫ָ��](https://leetcode.cn/problems/expressive-words/solutions/1988726/qing-gan-feng-fu-de-wen-zi-by-leetcode-s-vmnm/)

**˼·���㷨**

���ǿ��������ж����� words �е�ÿһ���ַ����Ƿ�������ųɸ������ַ��� s��

����������Ҫ�ж� t �Ƿ�������ų� s�����ǿ���ʹ��˫ָ�������������⡣����ָ�� i �� j ��ʼʱ�ֱ�ָ���ַ��� s �� t ���׸�λ�á���˫ָ������Ĺ����У�
-   ����������Ҫ��֤ s[i]=t[j]�������������ֲ�����ͬ����ĸ���޷��������ţ�
-   ������ǲ��ϵ������ƶ�����ָ�룬ֱ���ƶ�����֮ǰ��ͬ����ĸ�����߳����ַ����ı߽硣�����ַ��� s �� $cnt_i$ ����ͬ����ĸ��t �� $cnt_j$ ����ͬ����ĸ����ô���Ǳ��뱣֤ $cnt_i \geq cnt_j$����Ϊ���Ų����ܼ����ַ����������� $cnt_i = cnt_j$ ʱ����������������ţ�����Ҳ������Ҫ��ģ�$cnt_i > cnt_j$�������������ٻ�ﵽ���� 3 �����ϣ������Ҫ��֤ $cnt_i \geq 3$ ���ɡ�

��ĳһ��ָ�볬���߽�ʱ�����ǾͿ����˳������ı������̡���ʱ�������һ��ָ��Ҳ�����߽磬˵�������ַ���ͬʱ������ɣ��� t �������ų� s��

**����**

```cpp
class Solution {
public:
    int expressiveWords(string s, vector<string>& words) {
        int ans = 0;
        for (const string& word: words) {
            if (expand(s, word)) {
                ++ans;
            }
        }
        return ans;
    }

private:
    bool expand(const string& s, const string& t) {
        int i = 0, j = 0;
        while (i < s.size() && j < t.size()) {
            if (s[i] != t[j]) {
                return false;
            }
            char ch = s[i];
            int cnti = 0;
            while (i < s.size() && s[i] == ch) {
                ++cnti;
                ++i;
            }
            int cntj = 0;
            while (j < t.size() && t[j] == ch) {
                ++cntj;
                ++j;
            }
            if (cnti < cntj) {
                return false;
            }
            if (cnti != cntj && cnti < 3) {
                return false;
            }
        }
        return i == s.size() && j == t.size();
    }
};
```

```java
class Solution {
    public int expressiveWords(String s, String[] words) {
        int ans = 0;
        for (String word : words) {
            if (expand(s, word)) {
                ++ans;
            }
        }
        return ans;
    }

    private boolean expand(String s, String t) {
        int i = 0, j = 0;
        while (i < s.length() && j < t.length()) {
            if (s.charAt(i) != t.charAt(j)) {
                return false;
            }
            char ch = s.charAt(i);
            int cnti = 0;
            while (i < s.length() && s.charAt(i) == ch) {
                ++cnti;
                ++i;
            }
            int cntj = 0;
            while (j < t.length() && t.charAt(j) == ch) {
                ++cntj;
                ++j;
            }
            if (cnti < cntj) {
                return false;
            }
            if (cnti != cntj && cnti < 3) {
                return false;
            }
        }
        return i == s.length() && j == t.length();
    }
}
```

```c#
public class Solution {
    public int ExpressiveWords(string s, string[] words) {
        int ans = 0;
        foreach (string word in words) {
            if (Expand(s, word)) {
                ++ans;
            }
        }
        return ans;
    }

    private bool Expand(string s, string t) {
        int i = 0, j = 0;
        while (i < s.Length && j < t.Length) {
            if (s[i] != t[j]) {
                return false;
            }
            char ch = s[i];
            int cnti = 0;
            while (i < s.Length && s[i] == ch) {
                ++cnti;
                ++i;
            }
            int cntj = 0;
            while (j < t.Length && t[j] == ch) {
                ++cntj;
                ++j;
            }
            if (cnti < cntj) {
                return false;
            }
            if (cnti != cntj && cnti < 3) {
                return false;
            }
        }
        return i == s.Length && j == t.Length;
    }
}
```

```python
class Solution:
    def expressiveWords(self, s: str, words: List[str]) -> int:
        def expand(s: str, t: str) -> bool:
            i = j = 0
            while i < len(s) and j < len(t):
                if s[i] != t[j]:
                    return False
                ch = s[i]
                cnti = 0
                while i < len(s) and s[i] == ch:
                    cnti += 1
                    i += 1
                cntj = 0
                while j < len(t) and t[j] == ch:
                    cntj += 1
                    j += 1
                
                if cnti < cntj:
                    return False
                if cnti != cntj and cnti < 3:
                    return False
            
            return i == len(s) and j == len(t)
        
        return sum(int(expand(s, word)) for word in words)
```

```c
bool expand(const char *s, const char *t) {
    int i = 0, j = 0;
    while (s[i] != '\0' && t[j] != '\0') {
        if (s[i] != t[j]) {
            return false;
        }
        char ch = s[i];
        int cnti = 0;
        while (s[i] != '\0' && s[i] == ch) {
            ++cnti;
            ++i;
        }
        int cntj = 0;
        while (t[j] != '\0' && t[j] == ch) {
            ++cntj;
            ++j;
        }
        if (cnti < cntj) {
            return false;
        }
        if (cnti != cntj && cnti < 3) {
            return false;
        }
    }
    return s[i] == '\0' && t[j] == '\0';
}

int expressiveWords(char * s, char ** words, int wordsSize){
    int ans = 0;
    for (int i = 0; i < wordsSize; i++) {
        if (expand(s, words[i])) {
            ++ans;
        }
    }
    return ans;
}
```

```javascript
var expressiveWords = function(s, words) {
    let ans = 0;
    for (const word of words) {
        if (expand(s, word)) {
            ++ans;
        }
    }
    return ans;
}

const expand = (s, t) => {
    let i = 0, j = 0;
    while (i < s.length && j < t.length) {
        if (s[i] !== t[j]) {
            return false;
        }
        const ch = s[i];
        let cnti = 0;
        while (i < s.length && s[i] === ch) {
            ++cnti;
            ++i;
        }
        let cntj = 0;
        while (j < t.length && t[j] === ch) {
            ++cntj;
            ++j;
        }
        if (cnti < cntj) {
            return false;
        }
        if (cnti !== cntj && cnti < 3) {
            return false;
        }
    }
    return i === s.length && j === t.length;
};
```

```go
func expand(s, t string) bool {
    n, m := len(s), len(t)
    i, j := 0, 0
    for i < n && j < m {
        if s[i] != t[j] {
            return false
        }
        ch := s[i]
        cntI := 0
        for i < n && s[i] == ch {
            cntI++
            i++
        }
        cntJ := 0
        for j < m && t[j] == ch {
            cntJ++
            j++
        }
        if cntI < cntJ || cntI > cntJ && cntI < 3 {
            return false
        }
    }
    return i == n && j == m
}

func expressiveWords(s string, words []string) (ans int) {
    for _, word := range words {
        if expand(s, word) {
            ans++
        }
    }
    return
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n|s| + \sum_i |words_i|)$������ n ������ words �ĳ��ȣ��Os�O �� $words_i$ �ֱ����ַ��� s ������ words �е� i ���ַ����ĳ��ȡ�
-   �ռ临�Ӷȣ�O(1)��
