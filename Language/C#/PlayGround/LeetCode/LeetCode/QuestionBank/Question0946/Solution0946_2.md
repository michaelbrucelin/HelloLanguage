## 双指针

我们也可以直接利用 `pushed` 充当栈，使用变量 `idx` 代指栈顶下标，变量 `j` 指向 `popped` 中待弹出的元素。

该做法好处无须额外空间，坏处是会修改入参数组。

代码：

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

-   时间复杂度：O(n)
-   空间复杂度：O(1)
