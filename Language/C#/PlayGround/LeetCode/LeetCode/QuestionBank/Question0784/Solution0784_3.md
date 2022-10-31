#### [](https://leetcode.cn/problems/letter-case-permutation/solution/zi-mu-da-xiao-xie-quan-pai-lie-by-leetco-cwpx//#方法一：广度优先搜索)方法一：广度优先搜索

从左往右依次遍历字符，在队列中存储当前为已遍历过字符的字母大小全排列。例如当前字符串为:
> s\="abc"

假设我们当前已经遍历到字符的第 2 个字符 'b' 时，则此时队列中已经存储的序列为:
> "ab","Ab","aB","AB"

当我们遍历下一个字符 ccc 时：
-   如果 c 为一个数字，则队列中所有的序列的末尾均加上 c，将修改后的序列再次进入到队列中；
-   如果 c 为一个字母，此时我们在上述序列的末尾依次分别加上 c 的小写形式 lowercase(c) 和 c 的大写形式 uppercase(c) 后，再次将上述数列放入队列；
-   如果队列中当前序列的长度等于 s 的长度，则表示当前序列已经搜索完成，该序列为全排列中的一个合法序列；

由于每个字符的大小写形式刚好差了 32，因此在大小写转换时可以用 c^32（异或运算） 来进行转换。

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

**复杂度分析**

-   时间复杂度：$O(n \times 2^n)$，其中 n 表示字符串的长度。全排列的数目最多为 $2^n$ 个，每次生成一个新的序列的时间为 O(n)，因此时间复杂度为 $O(n \times 2^n)$。
-   空间复杂度：$O(n \times 2^n)$。其中 n 表示字符串的长度。队列中的元素数目最多为 $2^n$ 个，每个序列需要的空间为 O(n)，因此空间复杂度为 $O(n \times 2^n)$。
