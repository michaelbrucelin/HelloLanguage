#### [](https://leetcode.cn/problems/generate-parentheses/solution/gua-hao-sheng-cheng-by-leetcode-solution//#方法三：按括号序列的长度递归)方法三：按括号序列的长度递归

**思路与算法**

任何一个括号序列都一定是由 ‘(’ 开头，并且第一个 ‘(’ 一定有一个唯一与之对应的 ‘)’。这样一来，每一个括号序列可以用 (a)b 来表示，其中 a 与 b 分别是一个合法的括号序列（可以为空）。

那么，要生成所有长度为 2n 的括号序列，我们定义一个函数 generate(n) 来返回所有可能的括号序列。那么在函数 generate(n) 的过程中：

-   我们需要枚举与第一个 ‘(’ 对应的 ‘)’ 的位置 2i+1；
-   递归调用 generate(i) 即可计算 a 的所有可能性；
-   递归调用 generate(n−i−1) 即可计算 b 的所有可能性；
-   遍历 a 与 b 的所有可能性并拼接，即可得到所有长度为 2n 的括号序列。

为了节省计算时间，我们在每次 generate(i) 函数返回之前，把返回值存储起来，下次再调用 generate(i) 时可以直接返回，不需要再递归计算。

```Java
class Solution {
    ArrayList[] cache = new ArrayList[100];

    public List<String> generate(int n) {
        if (cache[n] != null) {
            return cache[n];
        }
        ArrayList<String> ans = new ArrayList<String>();
        if (n == 0) {
            ans.add("");
        } else {
            for (int c = 0; c < n; ++c) {
                for (String left: generate(c)) {
                    for (String right: generate(n - 1 - c)) {
                        ans.add("(" + left + ")" + right);
                    }
                }
            }
        }
        cache[n] = ans;
        return ans;
    }

    public List<String> generateParenthesis(int n) {
        return generate(n);
    }
}
```

```Python
class Solution:
    @lru_cache(None)
    def generateParenthesis(self, n: int) -> List[str]:
        if n == 0:
            return ['']
        ans = []
        for c in range(n):
            for left in self.generateParenthesis(c):
                for right in self.generateParenthesis(n-1-c):
                    ans.append('({}){}'.format(left, right))
        return ans
```

```C++
class Solution {
    shared_ptr<vector<string>> cache[100] = {nullptr};
public:
    shared_ptr<vector<string>> generate(int n) {
        if (cache[n] != nullptr)
            return cache[n];
        if (n == 0) {
            cache[0] = shared_ptr<vector<string>>(new vector<string>{""});
        } else {
            auto result = shared_ptr<vector<string>>(new vector<string>);
            for (int i = 0; i != n; ++i) {
                auto lefts = generate(i);
                auto rights = generate(n - i - 1);
                for (const string& left : *lefts)
                    for (const string& right : *rights)
                        result -> push_back("(" + left + ")" + right);
            }
            cache[n] = result;
        }
        return cache[n];
    }
    vector<string> generateParenthesis(int n) {
        return *generate(n);
    }
};
```

**复杂度分析**

-   时间复杂度：$O(\frac{4^n}{\sqrt{n}})$，该分析与 [方法二](https://leetcode.cn/problems/generate-parentheses/solution/gua-hao-sheng-cheng-by-leetcode-solution//#%E6%96%B9%E6%B3%95%E4%BA%8C%EF%BC%9A%E5%9B%9E%E6%BA%AF%E6%B3%95) 类似。
-   空间复杂度：$O(\frac{4^n}{\sqrt{n}})$，此方法除答案数组外，中间过程中会存储与答案数组同样数量级的临时数组，是我们所需要的空间复杂度。
