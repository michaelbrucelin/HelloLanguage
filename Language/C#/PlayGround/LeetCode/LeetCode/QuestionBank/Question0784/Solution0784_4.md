#### [](https://leetcode.cn/problems/letter-case-permutation/solution/zi-mu-da-xiao-xie-quan-pai-lie-by-leetco-cwpx//#������������)������������

ͬ����˼·���ǻ����Բ��û��ݵ�˼�룬�����������α����ַ������ڽ�������ʱ���������ַ��� s �ĵ� i ���ַ� c ʱ:
-   ��� c Ϊһ�����֣������Ǽ��������һ���ַ���
-   ��� c Ϊһ����ĸ�����ǽ��ַ��еĵ� i ���ַ� c �ı��Сд��ʽ�����������������ɸ�д��ʽ����״̬���������ǽ� c ���лָ�����������������
-   �����ǰ����ַ������������ʾ��ǰ����״̬�Ѿ�������ɣ�������Ϊȫ�����е�һ����

����ÿ���ַ��Ĵ�Сд��ʽ�պò��� 32������ڴ�Сдװ��ʱ������ c^32��������㣩 ������ת���ͻָ���

```Python
class Solution:
    def letterCasePermutation(self, s: str) -> List[str]:
        ans = []
        def dfs(s: List[str], pos: int) -> None:
            while pos < len(s) and s[pos].isdigit():
                pos += 1
            if pos == len(s):
                ans.append(''.join(s))
                return
            dfs(s, pos + 1)
            s[pos] = s[pos].swapcase()
            dfs(s, pos + 1)
            s[pos] = s[pos].swapcase()
        dfs(list(s), 0)
        return ans
```

```C++
class Solution {
public:
    void dfs(string &s, int pos, vector<string> &res) {
        while (pos < s.size() && isdigit(s[pos])) {
            pos++;
        }
        if (pos == s.size()) {
            res.emplace_back(s);
            return;
        }
        s[pos] ^= 32;
        dfs(s, pos + 1, res);
        s[pos] ^= 32;
        dfs(s, pos + 1, res);
    }

    vector<string> letterCasePermutation(string s) {
        vector<string> ans;
        dfs(s, 0, ans);
        return ans;
    }
};
```

```Java
class Solution {
    public List<String> letterCasePermutation(String s) {
        List<String> ans = new ArrayList<String>();
        dfs(s.toCharArray(), 0, ans);
        return ans;
    }

    public void dfs(char[] arr, int pos, List<String> res) {
        while (pos < arr.length && Character.isDigit(arr[pos])) {
            pos++;
        }
        if (pos == arr.length) {
            res.add(new String(arr));
            return;
        }
        arr[pos] ^= 32;
        dfs(arr, pos + 1, res);
        arr[pos] ^= 32;
        dfs(arr, pos + 1, res);
    }
}
```

```C#
public class Solution {
    public IList<string> LetterCasePermutation(string s) {
        IList<string> ans = new List<string>();
        DFS(s.ToCharArray(), 0, ans);
        return ans;
    }

    public void DFS(char[] arr, int pos, IList<string> res) {
        while (pos < arr.Length && char.IsDigit(arr[pos])) {
            pos++;
        }
        if (pos == arr.Length) {
            res.Add(new string(arr));
            return;
        }
        arr[pos] = (char) (arr[pos] ^ 32);
        DFS(arr, pos + 1, res);
        arr[pos] = (char) (arr[pos] ^ 32);
        DFS(arr, pos + 1, res);
    }
}
```

```C
void dfs(char *s, int pos, char **res,int* returnSize) {
    while (s[pos] != '\0' && isdigit(s[pos])) {
        pos++;
    }
    if (s[pos] == '\0') {
        res[*returnSize] = (char *)malloc(sizeof(char) * (strlen(s) + 1));
        strcpy(res[*returnSize], s);
        (*returnSize)++;
        return;
    }
    s[pos] ^= 32;
    dfs(s, pos + 1, res, returnSize);
    s[pos] ^= 32;
    dfs(s, pos + 1, res, returnSize);
}

char ** letterCasePermutation(char * s, int* returnSize) {
    int n = strlen(s);
    *returnSize = 0;
    char **ans = (char **)malloc(sizeof(char *) * (1 << n));
    dfs(s, 0, ans, returnSize);
    return ans;
}
```

```Go
func letterCasePermutation(s string) (ans []string) {
    var dfs func([]byte, int)
    dfs = func(s []byte, pos int) {
        for pos < len(s) && unicode.IsDigit(rune(s[pos])) {
            pos++
        }
        if pos == len(s) {
            ans = append(ans, string(s))
            return
        }
        dfs(s, pos+1)
        s[pos] ^= 32
        dfs(s, pos+1)
        s[pos] ^= 32
    }
    dfs([]byte(s), 0)
    return
}
```

```JavaScript
var letterCasePermutation = function(s) {
    const ans = [];
    const dfs = (arr, pos, res) => {
        while (pos < arr.length && isDigit(arr[pos])) {
            pos++;
        }
        if (pos === arr.length) {
            res.push(arr.join(""));
            return;
        }
        arr[pos] = String.fromCharCode(arr[pos].charCodeAt() ^ 32);
        dfs(arr, pos + 1, res);
        arr[pos] = String.fromCharCode(arr[pos].charCodeAt() ^ 32);
        dfs(arr, pos + 1, res);
        }
    dfs([...s], 0, ans);
    return ans;
};

const isDigit = (ch) => {
    return parseFloat(ch).toString() === "NaN" ? false : true;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n \times 2^n)$������ n ��ʾ�ַ����ĳ��ȡ��ݹ�������Ϊ n�����п��ܵĵݹ���״̬���Ϊ $2^n$ ����ÿ�θ���״̬������ʱ��Ϊ O(n)�����ʱ�临�Ӷ�Ϊ $O(n \times 2^n)$��
-   �ռ临�Ӷȣ�$O(n \times 2^n)$���ݹ�������Ϊ n�����п��ܵĵݹ���״̬���Ϊ $2^n$ ����ÿ�θ���״̬������ʱ��Ϊ O(n)�����ʱ�临�Ӷ�Ϊ $O(n \times 2^n)$��
