#### [](https://leetcode.cn/problems/merge-strings-alternately/solution/jiao-ti-he-bing-zi-fu-chuan-by-leetcode-ac4ih//#����һ��˫ָ��)����һ��˫ָ��

**˼·���㷨**

����ֱ�Ӱ�����Ŀ��Ҫ��ģ�⼴�ɡ�����ʹ������ָ�� i �� j����ʼʱ�ֱ�ָ�������ַ������׸�λ�á�����ÿ��ѭ���У����ν������µ�����������
-   ��� i û�г��� word1 �ķ�Χ���ͽ� word1[i] ����𰸣����ҽ� i �ƶ�һ��λ�ã�
-   ��� j û�г��� word2 �ķ�Χ���ͽ� word2[j] ����𰸣����ҽ� j �ƶ�һ��λ�á�

�� i �� j ��������Ӧ�ķ�Χ�󣬽���ѭ�������ش𰸼��ɡ�

**����**

```C++
class Solution {
public:
    string mergeAlternately(string word1, string word2) {
        int m = word1.size(), n = word2.size();
        int i = 0, j = 0;
        
        string ans;
        ans.reserve(m + n);
        while (i < m || j < n) {
            if (i < m) {
                ans.push_back(word1[i]);
                ++i;
            }
            if (j < n) {
                ans.push_back(word2[j]);
                ++j;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public String mergeAlternately(String word1, String word2) {
        int m = word1.length(), n = word2.length();
        int i = 0, j = 0;

        StringBuilder ans = new StringBuilder();
        while (i < m || j < n) {
            if (i < m) {
                ans.append(word1.charAt(i));
                ++i;
            }
            if (j < n) {
                ans.append(word2.charAt(j));
                ++j;
            }
        }
        return ans.toString();
    }
}
```

```C#
public class Solution {
    public string MergeAlternately(string word1, string word2) {
        int m = word1.Length, n = word2.Length;
        int i = 0, j = 0;

        StringBuilder ans = new StringBuilder();
        while (i < m || j < n) {
            if (i < m) {
                ans.Append(word1[i]);
                ++i;
            }
            if (j < n) {
                ans.Append(word2[j]);
                ++j;
            }
        }
        return ans.ToString();
    }
}
```

```Python
class Solution:
    def mergeAlternately(self, word1: str, word2: str) -> str:
        m, n = len(word1), len(word2)
        i = j = 0

        ans = list()
        while i < m or j < n:
            if i < m:
                ans.append(word1[i])
                i += 1
            if j < n:
                ans.append(word2[j])
                j += 1
        
        return "".join(ans)
```

```JavaScript
var mergeAlternately = function(word1, word2) {
    const m = word1.length, n = word2.length;
    let i = 0, j = 0;

    const ans = [];
    while (i < m || j < n) {
        if (i < m) {
            ans.push(word1[i]);
            ++i;
        }
        if (j < n) {
            ans.push(word2[j]);
            ++j;
        }
    }
    return ans.join('');
};
```

```Go
func mergeAlternately(word1, word2 string) string {
    n, m := len(word1), len(word2)
    ans := make([]byte, 0, n+m)
    for i := 0; i < n || i < m; i++ {
        if i < n {
            ans = append(ans, word1[i])
        }
        if i < m {
            ans = append(ans, word2[i])
        }
    }
    return string(ans)
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(m+n)������ m �� n �ֱ����ַ��� word1 �� word2 �ĳ��ȡ�
-   �ռ临�Ӷȣ�O(1) �� O(m+n)�����ʹ�õ�����֧�ֿ��޸ĵ��ַ�������ô�ռ临�Ӷ�Ϊ O(1)������Ϊ O(m+n)��ע�����ﲻ���뷵��ֵ��Ҫ�Ŀռ䡣
