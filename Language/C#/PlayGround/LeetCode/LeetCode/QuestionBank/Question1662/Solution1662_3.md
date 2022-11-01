#### [](https://leetcode.cn/problems/check-if-two-string-arrays-are-equivalent/solution/jian-cha-liang-ge-zi-fu-chuan-shu-zu-shi-9iuo//#������������)������������

**˼·���㷨**

����һ�����뷨�����ǿ���ֱ���� word1 �� word2 �Ͻ��жԱȣ�������ⴴ���ַ�����

��������ָ�� p1 �� p2 �ֱ��ʾ�������� word1[p1] �� word2[p2]�����⻹����������ָ�� i �� j����ʾ���ڶԱ� word1[p1][i] �� word2[p2][j]��

��� word1[p1][i]��word2[p2][j]����ֱ�ӷ��� false������ i+1���� i=word1[p1].length ʱ����ʾ�Աȵ���ǰ�ַ���ĩβ����Ҫ�� p1+1��i ��ֵΪ 0��j �� p2 ͬ��

�� p1<word1.length ���� p2<word2.length ������ʱ���㷨���������������������������Ϊ p1=word1.length ���� p2=word2.length��

**����**

```Python
class Solution:
    def arrayStringsAreEqual(self, word1: List[str], word2: List[str]) -> bool:
        p1 = p2 = i = j = 0
        while p1 < len(word1) and p2 < len(word2):
            if word1[p1][i] != word2[p2][j]:
                return False
            i += 1
            if i == len(word1[p1]):
                p1 += 1
                i = 0
            j += 1
            if j == len(word2[p2]):
                p2 += 1
                j = 0
        return p1 == len(word1) and p2 == len(word2)
```

```C++
class Solution {
public:
    bool arrayStringsAreEqual(vector<string>& word1, vector<string>& word2) {
        int p1 = 0, p2 = 0, i = 0, j = 0;
        while (p1 < word1.size() && p2 < word2.size()) {
            if (word1[p1][i] != word2[p2][j]) {
                return false;
            }
            i++;
            if (i == word1[p1].size()) {
                p1++;
                i = 0;
            }
            j++;
            if (j == word2[p2].size()) {
                p2++;
                j = 0;
            }
        }
        return p1 == word1.size() && p2 == word2.size();
    }
};
```

```Java
class Solution {
    public boolean arrayStringsAreEqual(String[] word1, String[] word2) {
        int p1 = 0, p2 = 0, i = 0, j = 0;
        while (p1 < word1.length && p2 < word2.length) {
            if (word1[p1].charAt(i) != word2[p2].charAt(j)) {
                return false;
            }
            i++;
            if (i == word1[p1].length()) {
                p1++;
                i = 0;
            }
            j++;
            if (j == word2[p2].length()) {
                p2++;
                j = 0;
            }
        }
        return p1 == word1.length && p2 == word2.length;
    }
}
```

```C#
public class Solution {
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) {
        int p1 = 0, p2 = 0, i = 0, j = 0;
        while (p1 < word1.Length && p2 < word2.Length) {
            if (word1[p1][i] != word2[p2][j]) {
                return false;
            }
            i++;
            if (i == word1[p1].Length) {
                p1++;
                i = 0;
            }
            j++;
            if (j == word2[p2].Length) {
                p2++;
                j = 0;
            }
        }
        return p1 == word1.Length && p2 == word2.Length;
    }
}
```

```Go
func arrayStringsAreEqual(word1, word2 []string) bool {
    var p1, p2, i, j int
    for p1 < len(word1) && p2 < len(word2) {
        if word1[p1][i] != word2[p2][j] {
            return false
        }
        i++
        if i == len(word1[p1]) {
            p1++
            i = 0
        }

        j++
        if j == len(word2[p2]) {
            p2++
            j = 0
        }
    }
    return p1 == len(word1) && p2 == len(word2)
}
```

```JavaScript
var arrayStringsAreEqual = function(word1, word2) {
    let p1 = 0, p2 = 0, i = 0, j = 0;
    while (p1 < word1.length && p2 < word2.length) {
        if (word1[p1][i] !== word2[p2][j]) {
            return false;
        }
        i++;
        if (i === word1[p1].length) {
            p1++;
            i = 0;
        }
        j++;
        if (j === word2[p2].length) {
            p2++;
            j = 0;
        }
    }
    return p1 == word1.length && p2 == word2.length;
};
```

```C
bool arrayStringsAreEqual(char ** word1, int word1Size, char ** word2, int word2Size) {
    int p1 = 0, p2 = 0, i = 0, j = 0;
    while (p1 < word1Size && p2 < word2Size) {
        if (word1[p1][i] != word2[p2][j]) {
            return false;
        }
        i++;
        if (word1[p1][i] == '\0') {
            p1++;
            i = 0;
        }
        j++;
        if (word2[p2][j] == '\0') {
            p2++;
            j = 0;
        }
    }
    return p1 == word1Size && p2 == word2Size;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n+m)������ n �� m �ֱ���$\sum word1[i].length$��$\sum word2[i].length$��
-   �ռ临�Ӷȣ�O(1)���㷨ֻʹ���˳�������������ʾָ�롣
