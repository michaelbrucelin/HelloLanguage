#### ��������KMP �㷨

**˼·���㷨**

�ڷ���һ�У�ÿһ��ƥ�䶼��Ҫ�����Ƚ���������Ϊ m ���ַ�����ʱ�临�Ӷ�Ϊ O(m)�����ǿ��ԶԱ����ȽϵĹ��̽����Ż������������ʹ�� KMP �㷨��ƥ����̽����Ż���������߲���Ϥ KMP �㷨�������Ķ�[��28. ʵ�� strStr() �Ĺٷ���⡹](https://leetcode-cn.com/problems/implement-strstr/solution/shi-xian-strstr-by-leetcode-solution-ds6y/) �еķ�������

�����������Ҫ���� part ��ǰ׺�������飬���ǻ���Ҫ���� res ��ǰ׺�������顣���²����ַ���Ӧ��ǰ׺����ֵ���� m ʱ������ res �г���Ϊ m �ĺ�׺�� part ��ȣ���ʱ������Ҫɾȥ�ú�׺�Լ���Ӧ��ǰ׺����ֵ��

���⣬���� Python �����Բ�֧��ɾ���ַ�����Ԫ�أ�������Ҫ���ַ���ת��Ϊ������в�����

**����**

```C++
class Solution {
public:
    string removeOccurrences(string s, string part) {
        int m = part.size();
        vector<int> pi1(m);   // part ��ǰ׺����
        // ���� part ��ǰ׺����
        for (int i = 1, j = 0; i < m; i++) {
            while (j > 0 && part[i] != part[j]) {
                j = pi1[j-1];
            }
            if (part[i] == part[j]) {
                j++;
            }
            pi1[i] = j;
        }

        string res;
        vector<int> pi2 = {0};   // res ��ǰ׺����
        for (const char ch: s) {
            // ģ���������ƥ��Ĺ���
            res.push_back(ch);
            // ���� res ��ǰ׺����
            int j = pi2.back();
            while (j > 0 && ch != part[j]) {
                j = pi1[j-1];
            }
            if (ch == part[j]){
                ++j;
            }
            pi2.push_back(j);
            if (j == m) {
                // ���ƥ��ɹ�����ôɾȥ��Ӧ��׺
                pi2.erase(pi2.end() - m, pi2.end());
                res.erase(res.end() - m, res.end());
            }
        }
        return res;
    }
};

```

```Python3
class Solution:
    def removeOccurrences(self, s: str, part: str) -> str:
        m = len(part)
        pi1 = [0] * m   # part ��ǰ׺����
        # ���� part ��ǰ׺����
        j = 0
        for i in range(1, m):
            while j > 0 and part[i] != part[j]:
                j = pi1[j-1]
            if part[i] == part[j]:
                j += 1
            pi1[i] = j
        
        res = []
        pi2 = [0]   # res ��ǰ׺����
        for ch in s:
            # ģ���������ƥ��Ĺ���
            res.append(ch)
            # ���� res ��ǰ׺����
            j = pi2[-1]
            while j > 0 and ch != part[j]:
                j = pi1[j-1]
            if ch == part[j]:
                j += 1
            pi2.append(j)
            if j == m:
                # ���ƥ��ɹ�����ôɾȥ��Ӧ��׺
                pi2[-m:] = []
                res[-m:] = []
        return "".join(res)

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n+m)������ n Ϊ�ַ��� s �ĳ��ȣ�m Ϊ�ַ��� part �ĳ��ȡ����� s �� res ��ǰ׺�����ʱ�临�Ӷ�Ϊ O(n+m)������ s �е�ÿ���ַ����ᱻ�����ɾ����һ�Σ����ά�� res ��ʱ�临�Ӷ�Ϊ O(n)��
    
-   �ռ临�Ӷȣ�O(n+m)��
