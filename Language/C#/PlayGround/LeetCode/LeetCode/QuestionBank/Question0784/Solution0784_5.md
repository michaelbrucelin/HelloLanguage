#### [](https://leetcode.cn/problems/letter-case-permutation/solution/zi-mu-da-xiao-xie-quan-pai-lie-by-leetco-cwpx//#��������������λͼ)��������������λͼ

�����ַ��� s �� m ����ĸ����ôȫ���о��� $2^m$ ���ַ������У��ҿ�����λ���� bits Ψһ�ر�ʾһ���ַ�����
-   bits �ĵ� i Ϊ 0 ��ʾ�ַ��� s �д������ҵ� i ����ĸΪСд��ʽ��
-   bits �ĵ� i Ϊ 1 ��ʾ�ַ��� s �д������ҵ� i ����ĸΪ��д��ʽ��

���ǲ��õ�λ����ֻ�����ַ��� s �е���ĸ������������ֱ��������ͨ��λͼ����Ӷ�������ȷ��ȫ���С��������μ���ַ����� i ���ַ��� c��
-   ����ַ��� c Ϊ���֣�������ֱ���ڵ�ǰ������������ַ��� c��
-   ����ַ��� c Ϊ��ĸ���� c Ϊ�ַ����еĵ� k ����ĸ��������� bits �еĵ� k λΪ 0��������ַ��� c ��Сд��ʽ��������� bits �еĵ� k λΪ 1��������ַ��� c �Ĵ�д��ʽ��

```Python
class Solution:
    def letterCasePermutation(self, s: str) -> List[str]:
        ans = []
        m = sum(c.isalpha() for c in s)
        for mask in range(1 << m):
            t, k = [], 0
            for c in s:
                if c.isalpha():
                    t.append(c.upper() if mask >> k & 1 else c.lower())
                    k += 1
                else:
                    t.append(c)
            ans.append(''.join(t))
        return ans
```

```C++
class Solution {
public:
    vector<string> letterCasePermutation(string s) {
        int n = s.size();
        int m = 0;
        for (auto c : s) {
            if (isalpha(c)) {
                m++;
            }
        }
        vector<string> ans;
        for (int mask = 0; mask < (1 << m); mask++) {
            string str;
            for (int j = 0, k = 0; j < n; j++) {
                if (isalpha(s[j]) && (mask & (1 << k++))) {
                    str.push_back(toupper(s[j]));
                } else {
                    str.push_back(tolower(s[j]));
                }
            }
            ans.emplace_back(str);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<String> letterCasePermutation(String s) {
        int n = s.length();
        int m = 0;
        for (int i = 0; i < n; i++) {
            if (Character.isLetter(s.charAt(i))) {
                m++;
            }
        }
        List<String> ans = new ArrayList<String>();
        for (int mask = 0; mask < (1 << m); mask++) {
            StringBuilder sb = new StringBuilder();
            for (int j = 0, k = 0; j < n; j++) {
                if (Character.isLetter(s.charAt(j)) && (mask & (1 << k++)) != 0) {
                    sb.append(Character.toUpperCase(s.charAt(j)));
                } else {
                    sb.append(Character.toLowerCase(s.charAt(j)));
                }
            }
            ans.add(sb.toString());
        }
        return ans;
    }
}
```

```C#
public class Solution {
    public IList<string> LetterCasePermutation(string s) {
        int n = s.Length;
        int m = 0;
        for (int i = 0; i < n; i++) {
            if (char.IsLetter(s[i])) {
                m++;
            }
        }
        IList<string> ans = new List<string>();
        for (int mask = 0; mask < (1 << m); mask++) {
            StringBuilder sb = new StringBuilder();
            for (int j = 0, k = 0; j < n; j++) {
                if (char.IsLetter(s[j]) && (mask & (1 << k++)) != 0) {
                    sb.Append(char.ToUpper(s[j]));
                } else {
                    sb.Append(char.ToLower(s[j]));
                }
            }
            ans.Add(sb.ToString());
        }
        return ans;
    }
}
```

```C
char ** letterCasePermutation(char * s, int* returnSize){
    int n = strlen(s);
    int m = 0;
    for (int i = 0; i < n; i++) {
        if (isalpha(s[i])) {
            m++;
        }
    }
    char **ans = (char **)malloc(sizeof(char *) * (1 << m));
    for (int mask = 0; mask < (1 << m); mask++) {
        ans[mask] = (char *)malloc(sizeof(char) * (n + 1));
        ans[mask][n] = '\0';
        for (int j = 0, k = 0; j < n; j++) {
            if (isalpha(s[j]) && (mask & (1 << k++))) {
                ans[mask][j] = toupper(s[j]);
            } else {
                ans[mask][j] = tolower(s[j]);
            }
        }
    }
    *returnSize = (1 << m);
    return ans;
}
```

```Go
func letterCasePermutation(s string) (ans []string) {
    m := 0
    for _, c := range s {
        if unicode.IsLetter(c) {
            m++
        }
    }
    for mask := 0; mask < 1<<m; mask++ {
        t, k := []rune(s), 0
        for i, c := range t {
            if unicode.IsLetter(c) {
                if mask>>k&1 > 0 {
                    t[i] = unicode.ToUpper(c)
                } else {
                    t[i] = unicode.ToLower(c)
                }
                k++
            }
        }
        ans = append(ans, string(t))
    }
    return
}
```

```JavaScript
var letterCasePermutation = function(s) {
    const n = s.length;
    let m = 0;
    for (let i = 0; i < n; i++) {
        if (isLetter(s[i])) {
            m++;
        }
    }
    const ans = [];
    for (let mask = 0; mask < (1 << m); mask++) {
        let sb = '';
        for (let j = 0, k = 0; j < n; j++) {
            if (isLetter(s[j]) && (mask & (1 << k++)) !== 0) {
                sb += s[j].toUpperCase();
            } else {
                sb += s[j].toLowerCase();
            }
        }
        ans.push(sb);
    }
    return ans;
};

const isDigit = (ch) => {
    return parseFloat(ch).toString() === "NaN" ? false : true;
}

const isLetter = (ch) => {
    return 'a' <= ch && ch <= 'z' || 'A' <= ch && ch <= 'Z';
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n \times 2^n)$������ n ��ʾ�ַ����ĳ��ȡ������ $2^n$ �����У�����ÿ�����е�ʱ��Ϊ O(n)���ܵ�ʱ�临�Ӷ�Ϊ $O(n \times 2^n)$��
-   �ռ临�Ӷȣ�O(1)��������ֵ���ⲻ��Ҫ����Ŀռ䡣
