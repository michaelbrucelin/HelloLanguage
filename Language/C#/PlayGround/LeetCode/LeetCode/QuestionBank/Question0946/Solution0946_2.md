## ˫ָ��

����Ҳ����ֱ������ `pushed` �䵱ջ��ʹ�ñ��� `idx` ��ָջ���±꣬���� `j` ָ�� `popped` �д�������Ԫ�ء�

�������ô��������ռ䣬�����ǻ��޸�������顣

���룺

```Java
class Solution {
    public boolean validateStackSequences(int[] pushed, int[] popped) {
        int n = pushed.length, idx = 0;
        for (int i = 0, j = 0; i < n; i++) {
            pushed[idx++] = pushed[i];
            while (idx > 0 && pushed[idx - 1] == popped[j] && ++j >= 0) idx--;
        }
        return idx == 0;
    }
}

```

```TypeScript
function validateStackSequences(pushed: number[], popped: number[]): boolean {
    let n = pushed.length, idx = 0
    for (let i = 0, j = 0; i < n; i++) {
        pushed[idx++] = pushed[i]
        while (idx > 0 && pushed[idx - 1] == popped[j] && ++j >= 0) idx--
    }
    return idx == 0
};

```

-   ʱ�临�Ӷȣ�O(n)
-   �ռ临�Ӷȣ�O(1)
