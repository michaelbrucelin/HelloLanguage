#### [](https://leetcode.cn/problems/generate-parentheses/solution/gua-hao-sheng-cheng-by-leetcode-solution//#�����������ݷ�)�����������ݷ�

**˼·���㷨**

����һ���иĽ�����أ����ǿ���ֻ��������Ȼ������Чʱ����� ��(�� �� ��)������������ [����һ](https://leetcode.cn/problems/generate-parentheses/solution/gua-hao-sheng-cheng-by-leetcode-solution//#%E6%96%B9%E6%B3%95%E4%B8%80%EF%BC%9A%E6%9A%B4%E5%8A%9B%E6%B3%95) ����ÿ����ӡ����ǿ���ͨ�����ٵ�ĿǰΪֹ���õ������ź������ŵ���Ŀ��������һ�㣬

������������������� n�����ǿ��Է�һ�������š��������������С�������ŵ����������ǿ��Է�һ�������š�

```Java
class Solution {
    public List<String> generateParenthesis(int n) {
        List<String> ans = new ArrayList<String>();
        backtrack(ans, new StringBuilder(), 0, 0, n);
        return ans;
    }

    public void backtrack(List<String> ans, StringBuilder cur, int open, int close, int max) {
        if (cur.length() == max * 2) {
            ans.add(cur.toString());
            return;
        }
        if (open < max) {
            cur.append('(');
            backtrack(ans, cur, open + 1, close, max);
            cur.deleteCharAt(cur.length() - 1);
        }
        if (close < open) {
            cur.append(')');
            backtrack(ans, cur, open, close + 1, max);
            cur.deleteCharAt(cur.length() - 1);
        }
    }
}
```

```Python
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        ans = []
        def backtrack(S, left, right):
            if len(S) == 2 * n:
                ans.append(''.join(S))
                return
            if left < n:
                S.append('(')
                backtrack(S, left+1, right)
                S.pop()
            if right < left:
                S.append(')')
                backtrack(S, left, right+1)
                S.pop()

        backtrack([], 0, 0)
        return ans
```

```C++
class Solution {
    void backtrack(vector<string>& ans, string& cur, int open, int close, int n) {
        if (cur.size() == n * 2) {
            ans.push_back(cur);
            return;
        }
        if (open < n) {
            cur.push_back('(');
            backtrack(ans, cur, open + 1, close, n);
            cur.pop_back();
        }
        if (close < open) {
            cur.push_back(')');
            backtrack(ans, cur, open, close + 1, n);
            cur.pop_back();
        }
    }
public:
    vector<string> generateParenthesis(int n) {
        vector<string> result;
        string current;
        backtrack(result, current, 0, 0, n);
        return result;
    }
};
```

**���Ӷȷ���**

���ǵĸ��Ӷȷ������������ generateParenthesis(n) ���ж��ٸ�Ԫ�ء�������������˱��ĵķ��룬����ʵ֤�����ǵ� n ���������� $\frac{1}{n+1}\left(\begin{array}{l} 2n\\ n \end{array}\right)$�������� $\frac{4^n}{n\sqrt{n}}$ �����綨�ġ�
-   ʱ�临�Ӷȣ�$\frac{4^n}{\sqrt{n}}$���ڻ��ݹ����У�ÿ������Ҫ O(n) ��ʱ�临�Ƶ��������С�
-   �ռ临�Ӷȣ�O(n)�����˴�����֮�⣬��������Ҫ�Ŀռ�ȡ���ڵݹ�ջ����ȣ�ÿһ��ݹ麯����Ҫ O(1) �Ŀռ䣬���ݹ� 2n �㣬��˿ռ临�Ӷ�Ϊ O(n)��
