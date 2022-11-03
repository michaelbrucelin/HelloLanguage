#### ��������KMP �㷨 + ��̬�滮

**˼·���㷨**

����һ������ valid �����Ͼ��Ǳ�����ַ��� word ���ַ��� sequence �����г��ֵ�λ�á������ǿ���ʹ�ø���Ч�� [KMP �㷨](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fstring%2Fkmp%2F) �� O(m+n) ��ʱ���ڵõ����� valid������ KMP �㷨������ƪ��ⲻ��׸��������Ȥ�Ķ��߿�������ͨ�����ӽ���ѧϰ��

**����**

```C++
class Solution {
public:
    int maxRepeating(string sequence, string word) {
        int n = sequence.size(), m = word.size();
        if (n < m) {
            return 0;
        }

        vector<int> fail(m, -1);
        for (int i = 1; i < m; ++i) {
            int j = fail[i - 1];
            while (j != -1 && word[j + 1] != word[i]) {
                j = fail[j];
            }
            if (word[j + 1] == word[i]) {
                fail[i] = j + 1;
            }
        }

        vector<int> f(n);
        int j = -1;
        for (int i = 0; i < n; ++i) {
            while (j != -1 && word[j + 1] != sequence[i]) {
                j = fail[j];
            }
            if (word[j + 1] == sequence[i]) {
                ++j;
                if (j == m - 1) {
                    f[i] = (i >= m ? f[i - m] : 0) + 1;
                    j = fail[j];
                }
            }
        }

        return *max_element(f.begin(), f.end());
    }
};
```

```Java
class Solution {
    public int maxRepeating(String sequence, String word) {
        int n = sequence.length(), m = word.length();
        if (n < m) {
            return 0;
        }

        int[] fail = new int[m];
        Arrays.fill(fail, -1);
        for (int i = 1; i < m; ++i) {
            int j = fail[i - 1];
            while (j != -1 && word.charAt(j + 1) != word.charAt(i)) {
                j = fail[j];
            }
            if (word.charAt(j + 1) == word.charAt(i)) {
                fail[i] = j + 1;
            }
        }

        int[] f = new int[n];
        int j = -1;
        for (int i = 0; i < n; ++i) {
            while (j != -1 && word.charAt(j + 1) != sequence.charAt(i)) {
                j = fail[j];
            }
            if (word.charAt(j + 1) == sequence.charAt(i)) {
                ++j;
                if (j == m - 1) {
                    f[i] = (i >= m ? f[i - m] : 0) + 1;
                    j = fail[j];
                }
            }
        }

        return Arrays.stream(f).max().getAsInt();
    }
}
```

```C#
public class Solution {
    public int MaxRepeating(string sequence, string word) {
        int n = sequence.Length, m = word.Length;
        if (n < m) {
            return 0;
        }

        int[] fail = new int[m];
        Array.Fill(fail, -1);
        int j;
        for (int i = 1; i < m; ++i) {
            j = fail[i - 1];
            while (j != -1 && word[j + 1] != word[i]) {
                j = fail[j];
            }
            if (word[j + 1] == word[i]) {
                fail[i] = j + 1;
            }
        }

        int[] f = new int[n];
        j = -1;
        for (int i = 0; i < n; ++i) {
            while (j != -1 && word[j + 1] != sequence[i]) {
                j = fail[j];
            }
            if (word[j + 1] == sequence[i]) {
                ++j;
                if (j == m - 1) {
                    f[i] = (i >= m ? f[i - m] : 0) + 1;
                    j = fail[j];
                }
            }
        }

        return f.Max();
    }
}
```

```Python
class Solution:
    def maxRepeating(self, sequence: str, word: str) -> int:
        n, m = len(sequence), len(word)
        if n < m:
            return 0

        fail = [-1] * m
        for i in range(1, m):
            j = fail[i - 1]
            while j != -1 and word[j + 1] != word[i]:
                j = fail[j]
            if word[j + 1] == word[i]:
                fail[i] = j + 1
        
        f = [0] * n
        j = -1
        for i in range(n):
            while j != -1 and word[j + 1] != sequence[i]:
                j = fail[j]
            if word[j + 1] == sequence[i]:
                j += 1
                if j == m - 1:
                    f[i] = (0 if i == m - 1 else f[i - m]) + 1
                    j = fail[j]
        
        return max(f)
```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int maxRepeating(char * sequence, char * word){
    int n = strlen(sequence), m = strlen(word);
    if (n < m) {
        return 0;
    }

    int fail[m];
    memset(fail, -1, sizeof(fail));
    for (int i = 1; i < m; ++i) {
        int j = fail[i - 1];
        while (j != -1 && word[j + 1] != word[i]) {
            j = fail[j];
        }
        if (word[j + 1] == word[i]) {
            fail[i] = j + 1;
        }
    }

    int f[n];
    memset(f, 0, sizeof(f));
    for (int i = 0, j = -1; i < n; ++i) {
        while (j != -1 && word[j + 1] != sequence[i]) {
            j = fail[j];
        }
        if (word[j + 1] == sequence[i]) {
            ++j;
            if (j == m - 1) {
                f[i] = (i >= m ? f[i - m] : 0) + 1;
                j = fail[j];
            }
        }
    }
    int res = 0;
    for (int i = 0; i < n; i++) {
        res = MAX(res, f[i]);
    }
    return res;
}
```

```JavaScript
var maxRepeating = function(sequence, word) {
    const n = sequence.length, m = word.length;
    if (n < m) {
        return 0;
    }

    const fail = new Array(n).fill(-1);
    for (let i = 1; i < m; ++i) {
        let j = fail[i - 1];
        while (j !== -1 && word[j + 1] !== word[i]) {
            j = fail[j];
        }
        if (word[j + 1] === word[i]) {
            fail[i] = j + 1;
        }
    }

    const f = new Array(n).fill(0);
    let j = -1;
    for (let i = 0; i < n; ++i) {
        while (j !== -1 && word[j + 1] !== sequence[i]) {
            j = fail[j];
        }
        if (word[j + 1] === sequence[i]) {
            ++j;
            if (j === m - 1) {
                f[i] = (i >= m ? f[i - m] : 0) + 1;
                j = fail[j];
            }
        }
    }

    return _.max(f)
};
```

```Go
func maxRepeating(sequence, word string) (ans int) {
    n, m := len(sequence), len(word)
    if n < m {
        return
    }
    fail := make([]int, m)
    for i := range fail {
        fail[i] = -1
    }
    for i := 1; i < m; i++ {
        j := fail[i-1]
        for j != -1 && word[j+1] != word[i] {
            j = fail[j]
        }
        if word[j+1] == word[i] {
            fail[i] = j + 1
        }
    }

    f := make([]int, n)
    j := -1
    for i := 0; i < n; i++ {
        for j != -1 && word[j+1] != sequence[i] {
            j = fail[j]
        }
        if word[j+1] == sequence[i] {
            j++
            if j == m-1 {
                if i < m {
                    f[i] = 1
                } else {
                    f[i] = f[i-m] + 1
                }
                if f[i] > ans {
                    ans = f[i]
                }
                j = fail[j]
            }
        }
    }
    return
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(m+n)������ n �� m �ֱ����ַ��� sequence �� word �ĳ��ȡ�
-   �ռ临�Ӷȣ�O(m+n)����Ϊ KMP �㷨�е����� fail �Լ����� f ��Ҫʹ�õĿռ䡣
