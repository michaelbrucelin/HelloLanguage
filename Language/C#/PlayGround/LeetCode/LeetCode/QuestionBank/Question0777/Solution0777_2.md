#### [](https://leetcode.cn/problems/swap-adjacent-in-lr-string/solution/zai-lrzi-fu-chuan-zhong-jiao-huan-xiang-rjaw8//#����һ��˫ָ��)����һ��˫ָ��

ÿ���ƶ������� "XL" �滻�� "LX"���� "RX" �滻�� "XR"���ȼ������²�����

-   ���һ���ַ� ��L�� ���������ַ��� ��X�������ַ� ��L�� �����ƶ�һλ���������� ��X�� �����ƶ�һλ��

-   ���һ���ַ� ��R�� �Ҳ�������ַ��� ��X�������ַ� ��R�� �����ƶ�һλ�������Ҳ�� ��X�� �����ƶ�һλ��


����ÿ���ƶ�����ֻ�ǽ������������ַ����������ӻ�ɾ���ַ������������Ծ���һϵ���ƶ������� start ת���� end���� start �� end ����ÿһ���ַ��������ֱ���ͬ���ַ� ��L�� �� ��R�� �����˳����ͬ����ÿ�� ��L�� �� end �е��±�С�ڵ��ڶ�Ӧ�� ��L�� �� start �е��±꣬�Լ�ÿ�� ��R�� �� end �е��±���ڵ��ڶ�Ӧ�� ��R�� �� start �е��±ꡣ

��ˣ�����ͨ���ж� start �� end �е����� ��L�� �� ��R�� �Ƿ�����滻��Ĺ����ж��Ƿ���Ծ���һϵ���ƶ������� start ת���� end��

�� n ��ʾ start �� end �ĳ��ȣ��� i �� j �ֱ��ʾ start �� end �е��±꣬�����ұ��� start �� end���������е� ��X������ i �� j ��С�� n ʱ���ȽϷ� ��X�� ���ַ���

-   ��� start[i]��end[j]���� start �� end �еĵ�ǰ�ַ���ƥ�䣬���� false��

-   ��� start[i]=end[j]����ǰ�ַ��� ��L�� ʱӦ�� i��j����ǰ�ַ��� ��R�� ʱӦ�� i��j�������ǰ�ַ��������±�Ĺ�ϵ�����ϸù��򣬷��� false��


��� i �� j ����һ���±���ڵ��� n������һ���ַ����Ѿ�������ĩβ������������һ���ַ����е������ַ�����������ַ��г��ַ� ��X�� ���ַ�������ַ������������ַ�ƥ�䣬���� false��

��� start �� end ��������֮��û�г��ֲ������ƶ����������������Ծ���һϵ���ƶ������� start ת���� end������ true��

```Python
class Solution:
    def canTransform(self, start: str, end: str) -> bool:
        n = len(start)
        i = j = 0
        while i < n and j < n:
            while i < n and start[i] == 'X':
                i += 1
            while j < n and end[j] == 'X':
                j += 1
            if i < n and j < n:
                if start[i] != end[j]:
                    return False
                c = start[i]
                if c == 'L' and i < j or c == 'R' and i > j:
                    return False
                i += 1
                j += 1
        while i < n:
            if start[i] != 'X':
                return False
            i += 1
        while j < n:
            if end[j] != 'X':
                return False
            j += 1
        return True

```

```Java
class Solution {
    public boolean canTransform(String start, String end) {
        int n = start.length();
        int i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && start.charAt(i) == 'X') {
                i++;
            }
            while (j < n && end.charAt(j) == 'X') {
                j++;
            }
            if (i < n && j < n) {
                if (start.charAt(i) != end.charAt(j)) {
                    return false;
                }
                char c = start.charAt(i);
                if ((c == 'L' && i < j) || (c == 'R' && i > j)) {
                    return false;
                }
                i++;
                j++;
            }
        }
        while (i < n) {
            if (start.charAt(i) != 'X') {
                return false;
            }
            i++;
        }
        while (j < n) {
            if (end.charAt(j) != 'X') {
                return false;
            }
            j++;
        }
        return true;
    }
}

```

```C#
public class Solution {
    public bool CanTransform(string start, string end) {
        int n = start.Length;
        int i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && start[i] == 'X') {
                i++;
            }
            while (j < n && end[j] == 'X') {
                j++;
            }
            if (i < n && j < n) {
                if (start[i] != end[j]) {
                    return false;
                }
                char c = start[i];
                if ((c == 'L' && i < j) || (c == 'R' && i > j)) {
                    return false;
                }
                i++;
                j++;
            }
        }
        while (i < n) {
            if (start[i] != 'X') {
                return false;
            }
            i++;
        }
        while (j < n) {
            if (end[j] != 'X') {
                return false;
            }
            j++;
        }
        return true;
    }
}

```

```C++
class Solution {
public:
    bool canTransform(string start, string end) {
        int n = start.length();
        int i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && start[i] == 'X') {
                i++;
            }
            while (j < n && end[j] == 'X') {
                j++;
            }
            if (i < n && j < n) {
                if (start[i] != end[j]) {
                    return false;
                }
                char c = start[i];
                if ((c == 'L' && i < j) || (c == 'R' && i > j)) {
                    return false;
                }
                i++;
                j++;
            }
        }
        while (i < n) {
            if (start[i] != 'X') {
                return false;
            }
            i++;
        }
        while (j < n) {
            if (end[j] != 'X') {
                return false;
            }
            j++;
        }
        return true;
    }
};

```

```C
bool canTransform(char * start, char * end) {
    int n = strlen(start);
    int i = 0, j = 0;
    while (i < n && j < n) {
        while (i < n && start[i] == 'X') {
            i++;
        }
        while (j < n && end[j] == 'X') {
            j++;
        }
        if (i < n && j < n) {
            if (start[i] != end[j]) {
                return false;
            }
            char c = start[i];
            if ((c == 'L' && i < j) || (c == 'R' && i > j)) {
                return false;
            }
            i++;
            j++;
        }
    }
    while (i < n) {
        if (start[i] != 'X') {
            return false;
        }
        i++;
    }
    while (j < n) {
        if (end[j] != 'X') {
            return false;
        }
        j++;
    }
    return true;
}

```

```JavaScript
var canTransform = function(start, end) {
    const n = start.length;
    let i = 0, j = 0;
    while (i < n && j < n) {
        while (i < n && start[i] === 'X') {
            i++;
        }
        while (j < n && end[j] === 'X') {
            j++;
        }
        if (i < n && j < n) {
            if (start[i] !== end[j]) {
                return false;
            }
            const c = start[i];
            if ((c === 'L' && i < j) || (c === 'R' && i > j)) {
                return false;
            }
            i++;
            j++;
        }
    }
    while (i < n) {
        if (start[i] !== 'X') {
            return false;
        }
        i++;
    }
    while (j < n) {
        if (end[j] !== 'X') {
            return false;
        }
        j++;
    }
    return true;
};

```

```Go
func canTransform(start, end string) bool {
    i, j, n := 0, 0, len(start)
    for i < n && j < n {
        for i < n && start[i] == 'X' {
            i++
        }
        for j < n && end[j] == 'X' {
            j++
        }
        if i < n && j < n {
            if start[i] != end[j] {
                return false
            }
            c := start[i]
            if c == 'L' && i < j || c == 'R' && i > j {
                return false
            }
            i++
            j++
        }
    }
    for i < n {
        if start[i] != 'X' {
            return false
        }
        i++
    }
    for j < n {
        if end[j] != 'X' {
            return false
        }
        j++
    }
    return true
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ���ַ��� start �� end �ĳ��ȡ���Ҫ���������ַ�����һ�Ρ�

-   �ռ临�Ӷȣ�O(1)��ֻ��Ҫʹ�ó����Ķ���ռ䡣
