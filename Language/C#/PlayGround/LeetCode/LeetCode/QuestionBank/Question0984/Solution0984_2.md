#### ������̰��

**˼·**

ֱ�۸о�������Ӧ����ѡ��ǰ��ʣ���Ĵ�д��ĸд���ַ����С���һ�����ӣ���� `A = 6, B = 2`����ô��������д�� `'aabaabaa'`����һ��˵���赱ǰ��ʣ���Ĵ�д��ĸΪ `x`��ֻ��ǰ�����Ѿ�д�µ���ĸ���� `x` ��ʱ����һ��д���ַ����е���ĸ�Ų�Ӧ��ѡ������

**�㷨**

���Ƕ��� `A, B`����д�� `'a'` �� `'b'` ��������

�赱ǰ����Ҫд���ַ����� `'a'` �� `'b'` �н϶����һ��Ϊ `x`����������Ѿ�����д������ `x` �ˣ���һ������Ӧ��д��һ����ĸ����������Ӧ�ü���д `x`��

```Java
class Solution {
    public String strWithout3a3b(int A, int B) {
        StringBuilder ans = new StringBuilder();

        while (A > 0 || B > 0) {
            boolean writeA = false;
            int L = ans.length();
            if (L >= 2 && ans.charAt(L-1) == ans.charAt(L-2)) {
                if (ans.charAt(L-1) == 'b')
                    writeA = true;
            } else {
                if (A >= B)
                    writeA = true;
            }

            if (writeA) {
                A--;
                ans.append('a');
            } else {
                B--;
                ans.append('b');
            }
        }

        return ans.toString();
    }
}

```

```Python
class Solution(object):
    def strWithout3a3b(self, A, B):
        ans = []

        while A or B:
            if len(ans) >= 2 and ans[-1] == ans[-2]:
                writeA = ans[-1] == 'b'
            else:
                writeA = A >= B

            if writeA:
                A -= 1
                ans.append('a')
            else:
                B -= 1
                ans.append('b')

        return "".join(ans)

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(A+B)��

-   �ռ临�Ӷȣ�O(A+B)��
