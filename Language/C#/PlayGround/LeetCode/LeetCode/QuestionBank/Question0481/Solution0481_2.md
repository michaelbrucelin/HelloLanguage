#### ����һ��˫ָ��

**˼·���㷨**

������Ŀ���������ַ��� sss �Ķ��壺

-   ���� 1 �� 2 ��ɡ�
-   �����ַ����� 1 �� 2 ���������ֵĴ����������ɸ��ַ�����

���������ַ��� s ��ǰ����Ԫ�أ�1221121221221121122��������Ҫ����� s ��ǰ n �������� 1 ����Ŀ��$1 \le n \le 10^5$����ô���ǿ��԰��ն��������쳤��Ϊ n ���ַ��� s��Ȼ��ͳ�� s �� 1 �ĸ������ɡ���ô���ͨ�����еĿ�ͷ�ַ���������ʣ�µ��ַ����ء������ǿ��Գ�ʼ���ַ��� s=122����ָ�� i ��ָ��������Ҫ����Ķ�Ӧ����Ĵ�С����ָ�� j ��ָ��������Ҫ����Ķ�Ӧ���λ�ã���ʱ i=2��j=3����Ϊ�������е�����һ��������ͬ���������ǿ���ͨ�� j ��ǰһ��λ�õ������жϵ�ǰ��Ҫ��������е����֡�����Ϊÿ��Ĵ�СֻΪ 1 ���� 2���Ᵽ֤�� j>i �ڹ���Ĺ�����һ������������ָ�� j ��������ʱһ����ȷ����ʱ��Ҫ�������Ĵ�С���������ǾͿ��Բ������½��й���ֱ���ַ������ȵ��� n��

�����Ĺ��������ǳ�ʼ���ַ��� s=122�����Ե� n<4 ʱ�������������¹��죬��ʱֱ�ӷ��� 1 ���ɡ�

**����**

```Python
class Solution:
    def magicalString(self, n: int) -> int:
        if n < 4:
            return 1
        s = [''] * n
        s[:3] = "122"
        res = 1
        i, j = 2, 3
        while j < n:
            size = int(s[i])
            num = 3 - int(s[j - 1])
            while size and j < n:
                s[j] = str(num)
                if num == 1:
                    res += 1
                j += 1
                size -= 1
            i += 1
        return res
```

```C++
class Solution {
public:
    int magicalString(int n) {
        if (n < 4) {
            return 1;
        }
        string s(n, '0');
        s[0] = '1', s[1] = '2', s[2] = '2';
        int res = 1;
        int i = 2;
        int j = 3;
        while (j < n) {
            int size = s[i] - '0';
            int num = 3 - (s[j - 1] - '0');
            while (size > 0 && j < n) {
                s[j] = '0' + num;
                if (num == 1) {
                    ++res;
                }
                ++j;
                --size;
            }
            ++i;
        }
        return res;
    }
};
```

```Java
class Solution {
    public int magicalString(int n) {
        if (n < 4) {
            return 1;
        }
        char[] s = new char[n];
        s[0] = '1';
        s[1] = '2';
        s[2] = '2';
        int res = 1;
        int i = 2;
        int j = 3;
        while (j < n) {
            int size = s[i] - '0';
            int num = 3 - (s[j - 1] - '0');
            while (size > 0 && j < n) {
                s[j] = (char) ('0' + num);
                if (num == 1) {
                    ++res;
                }
                ++j;
                --size;
            }
            ++i;
        }
        return res;
    }
}
```

```C#
public class Solution {
    public int MagicalString(int n) {
        if (n < 4) {
            return 1;
        }
        char[] s = new char[n];
        s[0] = '1';
        s[1] = '2';
        s[2] = '2';
        int res = 1;
        int i = 2;
        int j = 3;
        while (j < n) {
            int size = s[i] - '0';
            int num = 3 - (s[j - 1] - '0');
            while (size > 0 && j < n) {
                s[j] = (char) ('0' + num);
                if (num == 1) {
                    ++res;
                }
                ++j;
                --size;
            }
            ++i;
        }
        return res;
    }
}
```

```C
int magicalString(int n){
    if (n < 4) {
        return 1;
    }
    char s[n + 1];
    memset(s, '0', sizeof(s));
    s[0] = '1', s[1] = '2', s[2] = '2';
    int res = 1;
    int i = 2;
    int j = 3;
    while (j < n) {
        int size = s[i] - '0';
        int num = 3 - (s[j - 1] - '0');
        while (size > 0 && j < n) {
            s[j] = '0' + num;
            if (num == 1) {
                ++res;
            }
            ++j;
            --size;
        }
        ++i;
    }
    return res;
}
```

```JavaScript
var magicalString = function(n) {
    if (n < 4) {
        return 1;
    }
    const s = new Array(n).fill(0);
    s[0] = '1';
    s[1] = '2';
    s[2] = '2';
    let res = 1;
    let i = 2;
    let j = 3;
    while (j < n) {
        let size = s[i].charCodeAt() - '0'.charCodeAt();
        const num = 3 - (s[j - 1].charCodeAt() - '0'.charCodeAt());
        while (size > 0 && j < n) {
            s[j] = String.fromCharCode('0'.charCodeAt() + num);
            if (num === 1) {
                ++res;
            }
            ++j;
            --size;
        }
        ++i;
    }
    return res;
};
```

```Go
func magicalString(n int) int {
    if n < 4 {
        return 1
    }
    s := make([]byte, n)
    copy(s, "122")
    res := 1
    i, j := 2, 3
    for j < n {
        size := s[i] - '0'
        num := 3 - (s[j-1] - '0')
        for size > 0 && j < n {
            s[j] = '0' + num
            if num == 1 {
                res++
            }
            j++
            size--
        }
        i++
    }
    return res
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ�ַ��� s �ĳ��ȡ�
-   �ռ临�Ӷȣ�O(n)����Ҫ���쳤��Ϊ n ���ַ�����
