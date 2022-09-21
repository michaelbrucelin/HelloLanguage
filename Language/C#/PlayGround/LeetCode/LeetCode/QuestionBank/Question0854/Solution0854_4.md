#### [](https://leetcode.cn/problems/k-similar-strings/solution/xiang-si-du-wei-k-de-zi-fu-chuan-by-leet-8z10//#方法三：a-启发式搜索)方法三：A\* 启发式搜索

本题我们还可以使用 A* 启发式搜索，可参考相关 A* 算法的基础知识，例如「[Wikipedia - A\* search algorithm](https://leetcode.cn/link/?target=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FA*_search_algorithm)」或 「[oi-wiki - A\*](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fsearch%2Fastar%2F)」，力扣上也可以参考类似题解「[752\. 打开转盘锁](https://leetcode.cn/problems/open-the-lock/solution/da-kai-zhuan-pan-suo-by-leetcode-solutio-l0xo/)」。

设估计函数为 f(x)\=g(x)+h(x)，其中 g(x) 表示起始状态到达状态 x 的实际交换次数，h(x) 为启发函数，在这里我们设 h(x) 表示状态 x 到达终态可能的最小交换次数，即方法二中提到的当前状态 x 还需要的交换次数的下限 minSwap(x)，h(x) 满足小于等于实际的最小步数。实际上我们观察到该启发函数本质为一种贪心策略，在同样的状态下尽可能的选择一次交换 (i,j) 使得 s1 中两个位置 (i,j) 的字符与 s2 相等，这样才能使得启发函数 h(x) 尽可能的小。

```C++
class Solution {
public:
    int minSwap(const string &s1, const string &s2, const int &pos) {
        int tot = 0;
        for (int i = pos; i < s1.size(); i++) {
            tot += s1[i] != s2[i];
        }
        return (tot + 1) / 2;
    }

    int kSimilarity(string s1, string s2) {
        typedef tuple<int, int, int, string> State;
        int n = s1.size();
        priority_queue<State, vector<State>, greater<State>> pq;
        unordered_set<string> visit;
        pq.emplace(0, 0, 0, s1);
        visit.emplace(s1);
        while (!pq.empty()) {
            auto [_, cost, pos, cur] = pq.top();
            pq.pop();
            if (cur == s2) {
                return cost;
            }
            while (pos < n && cur[pos] == s2[pos]) {
                pos++;
            }
            for (int j = pos + 1; j < n; j++) {
                if (s2[j] == cur[j]) {
                    continue;
                }
                if (s2[pos] == cur[j]) {
                    swap(cur[pos], cur[j]);
                    if (!visit.count(cur)) {
                        visit.emplace(cur);
                        pq.emplace(cost + 1 + minSwap(s2, cur, pos + 1), cost + 1, pos + 1, cur);
                    }
                    swap(cur[pos], cur[j]);
                }
            }
        } 
        return 0;
    }
};

```

**复杂度分析**

启发式搜索不讨论时空复杂度。
