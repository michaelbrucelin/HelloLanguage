#### [](https://leetcode.cn/problems/bulb-switcher/solution/deng-pao-kai-guan-by-leetcode-solution-rrgp//#方法一：数学)方法一：数学

**思路与算法**

如果我们将所有的灯泡从左到右依次编号为 1,2,⋯ ,n 那么可以发现：

> 在第 i 轮时，我们会将所有编号为 i 的倍数的灯泡进行切换。

因此，对于第 k 个灯泡，它被切换的次数恰好就是 k 的约数个数。如果 k 有偶数个约数，那么最终第 k 个灯泡的状态为暗；如果 k 有奇数个约数，那么最终第 k 个灯泡的状态为亮。

对于 k 而言，如果它有约数 x，那么一定有约数 k/x。因此只要当 x2≠k 时，约数都是「成对」出现的。这就说明，只有当 k 是「完全平方数」时，它才会有奇数个约数，否则一定有偶数个约数。

因此我们只需要找出 1,2,⋯ ,n 中的完全平方数的个数即可，答案即为 ⌊n⌋，其中 ⌊⋅⌋ 表示向下取整。

**细节**

由于 n 涉及到浮点数运算，为了保证不出现精度问题，我们可以计算 n+12，这样可以保证计算出来的结果向下取整在 32 位整数范围内一定正确。

**代码**

```C++
class Solution {
public:
    int bulbSwitch(int n) {
        return sqrt(n + 0.5);
    }
};

```

```Java
class Solution {
    public int bulbSwitch(int n) {
        return (int) Math.sqrt(n + 0.5);
    }
}

```

```C#
public class Solution {
    public int BulbSwitch(int n) {
        return (int) Math.Sqrt(n + 0.5);
    }
}

```

```Python
class Solution:
    def bulbSwitch(self, n: int) -> int:
        return int(sqrt(n + 0.5))

```

```JavaScript
var bulbSwitch = function(n) {
    return Math.floor(Math.sqrt(n + 0.5));
};

```

```Go
func bulbSwitch(n int) int {
    return int(math.Sqrt(float64(n) + 0.5))
}

```

**复杂度分析**

-   时间复杂度：O(1)。

-   空间复杂度：O(1)。
