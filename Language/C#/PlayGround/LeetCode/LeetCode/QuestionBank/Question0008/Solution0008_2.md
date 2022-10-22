### �������

#### [](https://leetcode.cn/problems/string-to-integer-atoi//#����һ���Զ���)����һ���Զ���

**˼·**

�ַ����������Ŀ�����漰���ӵ������Լ�������������ֱ������д����һ��С�ľͻ�д������ӷ�׵Ĵ��롣

��ˣ�Ϊ��������ط���ÿ�������ַ��Ĵ����������ǿ���ʹ���Զ���������

���ǵĳ�����ÿ��ʱ����һ��״̬ `s`��ÿ�δ�����������һ���ַ� `c`���������ַ� `c` ת�Ƶ���һ��״̬ `s'`������������ֻ��Ҫ����һ��������������Ĵ� `s` �� `c` ӳ�䵽 `s'` �ı�񼴿ɽ����Ŀ�е����⡣

**�㷨**

������Խ�������ͼ��ʾ���Զ�����

![](./assets/img/Solution0008_2.png)

����Ҳ����������ı������ʾ����Զ�����

|  | ' ' | +/- | number | other |
| --- | --- | --- | --- | --- |
| **start** | start | signed | in\_number | end |
| **signed** | end | end | in\_number | end |
| **in\_number** | end | end | in\_number | end |
| **end** | end | end | end | end |

��������̲��־ͷǳ����ˣ�����ֻ��Ҫ���������״̬ת���������뼴�ɡ�

�����Զ���Ҳ��Ҫ��¼��ǰ�Ѿ���������֣�ֻҪ�� `s'` Ϊ `in_number` ʱ������������������֣��������յõ���������֡�

```Python
INT_MAX = 2 ** 31 - 1
INT_MIN = -2 ** 31

class Automaton:
    def __init__(self):
        self.state = 'start'
        self.sign = 1
        self.ans = 0
        self.table = {
            'start': ['start', 'signed', 'in_number', 'end'],
            'signed': ['end', 'end', 'in_number', 'end'],
            'in_number': ['end', 'end', 'in_number', 'end'],
            'end': ['end', 'end', 'end', 'end'],
        }
        
    def get_col(self, c):
        if c.isspace():
            return 0
        if c == '+' or c == '-':
            return 1
        if c.isdigit():
            return 2
        return 3

    def get(self, c):
        self.state = self.table[self.state][self.get_col(c)]
        if self.state == 'in_number':
            self.ans = self.ans * 10 + int(c)
            self.ans = min(self.ans, INT_MAX) if self.sign == 1 else min(self.ans, -INT_MIN)
        elif self.state == 'signed':
            self.sign = 1 if c == '+' else -1

class Solution:
    def myAtoi(self, str: str) -> int:
        automaton = Automaton()
        for c in str:
            automaton.get(c)
        return automaton.sign * automaton.ans
```

```C++
class Automaton {
    string state = "start";
    unordered_map<string, vector<string>> table = {
        {"start", {"start", "signed", "in_number", "end"}},
        {"signed", {"end", "end", "in_number", "end"}},
        {"in_number", {"end", "end", "in_number", "end"}},
        {"end", {"end", "end", "end", "end"}}
    };

    int get_col(char c) {
        if (isspace(c)) return 0;
        if (c == '+' or c == '-') return 1;
        if (isdigit(c)) return 2;
        return 3;
    }
public:
    int sign = 1;
    long long ans = 0;

    void get(char c) {
        state = table[state][get_col(c)];
        if (state == "in_number") {
            ans = ans * 10 + c - '0';
            ans = sign == 1 ? min(ans, (long long)INT_MAX) : min(ans, -(long long)INT_MIN);
        }
        else if (state == "signed")
            sign = c == '+' ? 1 : -1;
    }
};

class Solution {
public:
    int myAtoi(string str) {
        Automaton automaton;
        for (char c : str)
            automaton.get(c);
        return automaton.sign * automaton.ans;
    }
};
```

```Java
class Solution {
    public int myAtoi(String str) {
        Automaton automaton = new Automaton();
        int length = str.length();
        for (int i = 0; i < length; ++i) {
            automaton.get(str.charAt(i));
        }
        return (int) (automaton.sign * automaton.ans);
    }
}

class Automaton {
    public int sign = 1;
    public long ans = 0;
    private String state = "start";
    private Map<String, String[]> table = new HashMap<String, String[]>() {{
        put("start", new String[]{"start", "signed", "in_number", "end"});
        put("signed", new String[]{"end", "end", "in_number", "end"});
        put("in_number", new String[]{"end", "end", "in_number", "end"});
        put("end", new String[]{"end", "end", "end", "end"});
    }};

    public void get(char c) {
        state = table.get(state)[get_col(c)];
        if ("in_number".equals(state)) {
            ans = ans * 10 + c - '0';
            ans = sign == 1 ? Math.min(ans, (long) Integer.MAX_VALUE) : Math.min(ans, -(long) Integer.MIN_VALUE);
        } else if ("signed".equals(state)) {
            sign = c == '+' ? 1 : -1;
        }
    }

    private int get_col(char c) {
        if (c == ' ') {
            return 0;
        }
        if (c == '+' || c == '-') {
            return 1;
        }
        if (Character.isDigit(c)) {
            return 2;
        }
        return 3;
    }
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ�ַ����ĳ��ȡ�����ֻ��Ҫ���δ������е��ַ�������ÿ���ַ���Ҫ��ʱ��Ϊ O(1)��
-   �ռ临�Ӷȣ�O(1)���Զ�����״ֻ̬��Ҫ�����ռ�洢��
