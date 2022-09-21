#### [](https://leetcode.cn/problems/k-similar-strings/solution/xiang-si-du-wei-k-de-zi-fu-chuan-by-leet-8z10//#��������a-����ʽ����)��������A\* ����ʽ����

�������ǻ�����ʹ�� A* ����ʽ�������ɲο���� A* �㷨�Ļ���֪ʶ�����硸[Wikipedia - A\* search algorithm](https://leetcode.cn/link/?target=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FA*_search_algorithm)���� ��[oi-wiki - A\*](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fsearch%2Fastar%2F)����������Ҳ���Բο�������⡸[752\. ��ת����](https://leetcode.cn/problems/open-the-lock/solution/da-kai-zhuan-pan-suo-by-leetcode-solutio-l0xo/)����

����ƺ���Ϊ f(x)\=g(x)+h(x)������ g(x) ��ʾ��ʼ״̬����״̬ x ��ʵ�ʽ���������h(x) Ϊ���������������������� h(x) ��ʾ״̬ x ������̬���ܵ���С���������������������ᵽ�ĵ�ǰ״̬ x ����Ҫ�Ľ������������� minSwap(x)��h(x) ����С�ڵ���ʵ�ʵ���С������ʵ�������ǹ۲쵽��������������Ϊһ��̰�Ĳ��ԣ���ͬ����״̬�¾����ܵ�ѡ��һ�ν��� (i,j) ʹ�� s1 ������λ�� (i,j) ���ַ��� s2 ��ȣ���������ʹ���������� h(x) �����ܵ�С��

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

**���Ӷȷ���**

����ʽ����������ʱ�ո��Ӷȡ�
