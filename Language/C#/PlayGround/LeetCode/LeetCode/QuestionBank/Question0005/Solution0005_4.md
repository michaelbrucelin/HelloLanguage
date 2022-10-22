#### [](https://leetcode.cn/problems/longest-palindromic-substring/solution/zui-chang-hui-wen-zi-chuan-by-leetcode-solution//#��������-�㷨)��������Manacher\\text{Manacher}Manacher �㷨

����һ�����Ӷ�Ϊ O(n) �� Manacher �㷨��Ȼ�����㷨ʮ�ָ��ӣ�һ�㲻��Ϊ�������ݡ������������������Ȥ��ͬѧ��ս�Լ���

Ϊ�˱������㣬���Ƕ���һ���¸���**�۳�**����ʾ������չ�㷨������չ�ĳ��ȡ����һ��λ�õ��������ַ�������Ϊ `2 * length + 1` ����۳�Ϊ `length`��

���������ֻ�漰����Ϊ�����Ļ����ַ���������Ϊż���Ļ����ַ������ǽ���������볤��Ϊ���������ͳһ������

**˼·���㷨**

��������չ�㷨�Ĺ����У������ܹ��ó�ÿ��λ�õı۳�����ô������Ҫ�ó�����һ��λ�� `i` �ı۳�ʱ���ܲ�������֮ǰ�õ�����Ϣ�أ�

���ǿ϶��ġ�������˵�����λ�� `j` �ı۳�Ϊ `length`�������� `j + length > i`������ͼ��ʾ��

![](./assets/img/Solution0005_4.png)

����λ�� `i` ��ʼ����������չʱ�����ǿ������ҵ� `i` ���� `j` �ĶԳƵ� `2 * j - i`����ô����� `2 * j - i` �ı۳����� `n`�����ǾͿ���֪������ `i` �ı۳�����Ϊ `min(j + length - i, n)`����ô���ǾͿ���ֱ������ `i` �� `i + min(j + length - i, n)` �ⲿ�֣��� `i + min(j + length - i, n) + 1` ��ʼ��չ��

����ֻ��Ҫ��������չ���Ĺ����м�¼�ұ������ұߵĻ����ַ���������������Ϊ `j`���ڼ�������о�������޶ȵر����ظ����㡣

��ô���ڻ���һ�����⣺��δ�����Ϊż���Ļ����ַ����أ�

���ǿ���ͨ��һ���ر�Ĳ�������ż�������ͳһ�������������ַ�����ͷβ�Լ�ÿ�����ַ��м����һ�������ַ� `#`�������ַ��� `aaba` �������� `#a#a#b#a#`����ôԭ�ȳ���Ϊż���Ļ����ַ��� `aa` ���ɳ���Ϊ�����Ļ����ַ��� `#a#a#`��������Ϊ�����Ļ����ַ��� `aba` ���ɳ�����ȻΪ�����Ļ����ַ��� `#a#b#a#`�����ǾͲ���Ҫ�ٿ��ǳ���Ϊż���Ļ����ַ����ˡ�

ע������������ַ�����Ҫ��û�г��ֹ�����ĸ�����ǿ���ʹ���κ�һ���ַ�����Ϊ��������ַ���������Ϊ��������ֻ���ǳ���Ϊ�����Ļ����ַ���ʱ��ÿ�����ǱȽϵ������ַ���ż��һ������ͬ�ģ�����ԭ���ַ����е��ַ����������������ַ�����Ƚϣ�������˲������⡣

```Java
class Solution {
    public String longestPalindrome(String s) {
        int start = 0, end = -1;
        StringBuffer t = new StringBuffer("#");
        for (int i = 0; i < s.length(); ++i) {
            t.append(s.charAt(i));
            t.append('#');
        }
        t.append('#');
        s = t.toString();

        List<Integer> arm_len = new ArrayList<Integer>();
        int right = -1, j = -1;
        for (int i = 0; i < s.length(); ++i) {
            int cur_arm_len;
            if (right >= i) {
                int i_sym = j * 2 - i;
                int min_arm_len = Math.min(arm_len.get(i_sym), right - i);
                cur_arm_len = expand(s, i - min_arm_len, i + min_arm_len);
            } else {
                cur_arm_len = expand(s, i, i);
            }
            arm_len.add(cur_arm_len);
            if (i + cur_arm_len > right) {
                j = i;
                right = i + cur_arm_len;
            }
            if (cur_arm_len * 2 + 1 > end - start) {
                start = i - cur_arm_len;
                end = i + cur_arm_len;
            }
        }

        StringBuffer ans = new StringBuffer();
        for (int i = start; i <= end; ++i) {
            if (s.charAt(i) != '#') {
                ans.append(s.charAt(i));
            }
        }
        return ans.toString();
    }

    public int expand(String s, int left, int right) {
        while (left >= 0 && right < s.length() && s.charAt(left) == s.charAt(right)) {
            --left;
            ++right;
        }
        return (right - left - 2) / 2;
    }
}
```

```Python
class Solution:
    def expand(self, s, left, right):
        while left >= 0 and right < len(s) and s[left] == s[right]:
            left -= 1
            right += 1
        return (right - left - 2) // 2

    def longestPalindrome(self, s: str) -> str:
        end, start = -1, 0
        s = '#' + '#'.join(list(s)) + '#'
        arm_len = []
        right = -1
        j = -1
        for i in range(len(s)):
            if right >= i:
                i_sym = 2 * j - i
                min_arm_len = min(arm_len[i_sym], right - i)
                cur_arm_len = self.expand(s, i - min_arm_len, i + min_arm_len)
            else:
                cur_arm_len = self.expand(s, i, i)
            arm_len.append(cur_arm_len)
            if i + cur_arm_len > right:
                j = i
                right = i + cur_arm_len
            if 2 * cur_arm_len + 1 > end - start:
                start = i - cur_arm_len
                end = i + cur_arm_len
        return s[start+1:end+1:2]
```

```C++
class Solution {
public:
    int expand(const string& s, int left, int right) {
        while (left >= 0 && right < s.size() && s[left] == s[right]) {
            --left;
            ++right;
        }
        return (right - left - 2) / 2;
    }

    string longestPalindrome(string s) {
        int start = 0, end = -1;
        string t = "#";
        for (char c: s) {
            t += c;
            t += '#';
        }
        t += '#';
        s = t;

        vector<int> arm_len;
        int right = -1, j = -1;
        for (int i = 0; i < s.size(); ++i) {
            int cur_arm_len;
            if (right >= i) {
                int i_sym = j * 2 - i;
                int min_arm_len = min(arm_len[i_sym], right - i);
                cur_arm_len = expand(s, i - min_arm_len, i + min_arm_len);
            } else {
                cur_arm_len = expand(s, i, i);
            }
            arm_len.push_back(cur_arm_len);
            if (i + cur_arm_len > right) {
                j = i;
                right = i + cur_arm_len;
            }
            if (cur_arm_len * 2 + 1 > end - start) {
                start = i - cur_arm_len;
                end = i + cur_arm_len;
            }
        }

        string ans;
        for (int i = start; i <= end; ++i) {
            if (s[i] != '#') {
                ans += s[i];
            }
        }
        return ans;
    }
};
```

```Go
func longestPalindrome(s string) string {
    start, end := 0, -1
    t := "#"
    for i := 0; i < len(s); i++ {
        t += string(s[i]) + "#"
    }
    t += "#"
    s = t
    arm_len := []int{}
    right, j := -1, -1
    for i := 0; i < len(s); i++ {
        var cur_arm_len int
        if right >= i {
            i_sym := j * 2 - i
            min_arm_len := min(arm_len[i_sym], right-i)
            cur_arm_len = expand(s, i-min_arm_len, i+min_arm_len)
        } else {
            cur_arm_len = expand(s, i, i)
        }
        arm_len = append(arm_len, cur_arm_len)
        if i + cur_arm_len > right {
            j = i
            right = i + cur_arm_len
        }
        if cur_arm_len * 2 + 1 > end - start {
            start = i - cur_arm_len
            end = i + cur_arm_len
        }
    }
    ans := ""
    for i := start; i <= end; i++ {
        if s[i] != '#' {
            ans += string(s[i])
        }
    }
    return ans
}

func expand(s string, left, right int) int {
    for ; left >= 0 && right < len(s) && s[left] == s[right]; left, right = left-1, right+1 { }
    return (right - left - 2) / 2
}

func min(x, y int) int {
    if x < y {
        return x
    }
    return y
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ���ַ����ĳ��ȡ����ڶ���ÿ��λ�ã���չҪô�ӵ�ǰ�����Ҳ�۳� `right` ��ʼ��Ҫôֻ�����һ������ `right` �����ǰ�� O(n) ��������㷨�ĸ��Ӷ�Ϊ O(n)��
-   �ռ临�Ӷȣ�O(n)��������Ҫ O(n) �Ŀռ��¼ÿ��λ�õı۳���
