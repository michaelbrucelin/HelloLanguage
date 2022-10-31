#### [](https://leetcode.cn/problems/letter-case-permutation/solution/zi-mu-da-xiao-xie-quan-pai-lie-by-leetco-cwpx//#����һ�������������)����һ�������������

�����������α����ַ����ڶ����д洢��ǰΪ�ѱ������ַ�����ĸ��Сȫ���С����統ǰ�ַ���Ϊ:
> s\="abc"

�������ǵ�ǰ�Ѿ��������ַ��ĵ� 2 ���ַ� 'b' ʱ�����ʱ�������Ѿ��洢������Ϊ:
> "ab","Ab","aB","AB"

�����Ǳ�����һ���ַ� ccc ʱ��
-   ��� c Ϊһ�����֣�����������е����е�ĩβ������ c�����޸ĺ�������ٴν��뵽�����У�
-   ��� c Ϊһ����ĸ����ʱ�������������е�ĩβ���ηֱ���� c ��Сд��ʽ lowercase(c) �� c �Ĵ�д��ʽ uppercase(c) ���ٴν��������з�����У�
-   ��������е�ǰ���еĳ��ȵ��� s �ĳ��ȣ����ʾ��ǰ�����Ѿ�������ɣ�������Ϊȫ�����е�һ���Ϸ����У�

����ÿ���ַ��Ĵ�Сд��ʽ�պò��� 32������ڴ�Сдת��ʱ������ c^32��������㣩 ������ת����

```Python
class Solution:
    def letterCasePermutation(self, s: str) -> List[str]:
        ans = []
        q = deque([''])
        while q:
            cur = q[0]
            pos = len(cur)
            if pos == len(s):
                ans.append(cur)
                q.popleft()
            else:
                if s[pos].isalpha():
                    q.append(cur + s[pos].swapcase())
                q[0] += s[pos]
        return ans
```

```C++
class Solution {
public:
    vector<string> letterCasePermutation(string s) {
        vector<string> ans;
        queue<string> qu;
        qu.emplace("");
        while (!qu.empty()) {
            string &curr = qu.front();
            if (curr.size() == s.size()) {
                ans.emplace_back(curr);
                qu.pop();
            } else {
                int pos = curr.size();
                if (isalpha(s[pos])) {
                    string next = curr;
                    next.push_back(s[pos] ^ 32);
                    qu.emplace(next);
                }
                curr.push_back(s[pos]);                
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<String> letterCasePermutation(String s) {
        List<String> ans = new ArrayList<String>();
        Queue<StringBuilder> queue = new ArrayDeque<StringBuilder>();
        queue.offer(new StringBuilder());
        while (!queue.isEmpty()) {
            StringBuilder curr = queue.peek();
            if (curr.length() == s.length()) {
                ans.add(curr.toString());
                queue.poll();
            } else {
                int pos = curr.length();
                if (Character.isLetter(s.charAt(pos))) {
                    StringBuilder next = new StringBuilder(curr);
                    next.append((char) (s.charAt(pos) ^ 32));
                    queue.offer(next);
                }
                curr.append(s.charAt(pos));
            }
        }
        return ans;
    }
}
```

```C#
public class Solution {
    public IList<string> LetterCasePermutation(string s) {
        IList<string> ans = new List<string>();
        Queue<StringBuilder> queue = new Queue<StringBuilder>();
        queue.Enqueue(new StringBuilder());
        while (queue.Count > 0) {
            StringBuilder curr = queue.Peek();
            if (curr.Length == s.Length) {
                ans.Add(curr.ToString());
                queue.Dequeue();
            } else {
                int pos = curr.Length;
                if (char.IsLetter(s[pos])) {
                    StringBuilder next = new StringBuilder(curr.ToString());
                    next.Append((char) (s[pos] ^ 32));
                    queue.Enqueue(next);
                }
                curr.Append(s[pos]);
            }
        }
        return ans;
    }
}
```

```C
#define MAX_STR_LEN 16

typedef struct Node {
    char str[MAX_STR_LEN];
    struct Node *next;
} Node;

Node *creatNode(const char *str) {
    Node * node = (Node *)malloc(sizeof(Node));
    memset(node->str, 0, sizeof(node->str));
    strcpy(node->str, str);
    node->next = NULL;
    return node;
}

char ** letterCasePermutation(char * s, int* returnSize) {
    int n = strlen(s);
    char **ans = (char **)malloc(sizeof(char *) * (1 << n));
    int pos = 0;
    Node *head = NULL, *tail = NULL;
    head = tail = creatNode("");
    while (head) {
        char *curr = head->str;
        int len = strlen(curr);
        if (len == n) {
            ans[pos] = (char *)malloc(sizeof(char) * MAX_STR_LEN);
            strcpy(ans[pos], curr);
            pos++;
            Node *node = head;
            head = head->next;
            free(node);
        } else {
            if (isalpha(s[len])) {
                tail->next = creatNode(curr);
                tail = tail->next;
                tail->str[len] = s[len] ^ 32;
            }
            curr[len] = s[len];
        }
       
    }
    *returnSize = pos;
    return ans;
}
```

```Go
func letterCasePermutation(s string) (ans []string) {
    q := []string{""}
    for len(q) > 0 {
        cur := q[0]
        pos := len(cur)
        if pos == len(s) {
            ans = append(ans, cur)
            q = q[1:]
        } else {
            if unicode.IsLetter(rune(s[pos])) {
                q = append(q, cur+string(s[pos]^32))
            }
            q[0] += string(s[pos])
        }
    }
    return
}
```

```JavaScript
var letterCasePermutation = function(s) {
    const ans = [];
    const q = [""];
    while (q.length !== 0) {
        let cur = q[0];
        const pos = cur.length;
        if (pos === s.length) {
            ans.push(cur);
            q.shift();
        } else {
            if (isLetter(s[pos])) {
                q.push(cur + swapCase(s[pos]));
            }
            q[0] += s[pos];
        }
    }
    return ans;
};

const swapCase = (ch) => {
    if ('a' <= ch && ch <= 'z') {
        return ch.toUpperCase();
    }
    if ('A' <= ch && ch <= 'Z') {
        return ch.toLowerCase();
    }
}

const isLetter = (ch) => {
    return 'a' <= ch && ch <= 'z' || 'A' <= ch && ch <= 'Z';
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n \times 2^n)$������ n ��ʾ�ַ����ĳ��ȡ�ȫ���е���Ŀ���Ϊ $2^n$ ����ÿ������һ���µ����е�ʱ��Ϊ O(n)�����ʱ�临�Ӷ�Ϊ $O(n \times 2^n)$��
-   �ռ临�Ӷȣ�$O(n \times 2^n)$������ n ��ʾ�ַ����ĳ��ȡ������е�Ԫ����Ŀ���Ϊ $2^n$ ����ÿ��������Ҫ�Ŀռ�Ϊ O(n)����˿ռ临�Ӷ�Ϊ $O(n \times 2^n)$��
