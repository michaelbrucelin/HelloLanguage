#### [方法三：通项公式](https://leetcode.cn/problems/climbing-stairs/solutions/286022/pa-lou-ti-by-leetcode-solution/)

**思路**

之前的方法我们已经讨论了 f(n) 是齐次线性递推，根据递推方程 f(n)=f(n−1)+f(n−2)，我们可以写出这样的特征方程：
$x^2 = x + 1$

求得 $x_1=\frac{1+\sqrt{5}}{2}$, $x_2=\frac{1-\sqrt{5}}{2}$，设通解为 $f(n) = c_1x_1^n + c_2x_2^n$，代入初始条件 f(1)=1，f(2)=1，得 $c_1 = \frac{1}{\sqrt{5}}$，$c_2 = -\frac{1}{\sqrt{5}}$，我们得到了这个递推数列的通项公式：
$f(n) = \frac{1}{\sqrt{5}}\left[\left(\frac{1+\sqrt{5}}{2}\right)^{n} - \left(\frac{1-\sqrt{5}}{2}\right)^{n} \right]$

接着我们就可以通过这个公式直接求第 n 项了。

**代码**

```java
public class Solution {
    public int climbStairs(int n) {
        double sqrt5 = Math.sqrt(5);
        double fibn = Math.pow((1 + sqrt5) / 2, n + 1) - Math.pow((1 - sqrt5) / 2, n + 1);
        return (int) Math.round(fibn / sqrt5);
    }
}
```

```cpp
class Solution {
public:
    int climbStairs(int n) {
        double sqrt5 = sqrt(5);
        double fibn = pow((1 + sqrt5) / 2, n + 1) - pow((1 - sqrt5) / 2, n + 1);
        return (int)round(fibn / sqrt5);
    }
};
```

```javascript
var climbStairs = function(n) {
    const sqrt5 = Math.sqrt(5);
    const fibn = Math.pow((1 + sqrt5) / 2, n + 1) - Math.pow((1 - sqrt5) / 2, n + 1);
    return Math.round(fibn / sqrt5);
};
```

```go
func climbStairs(n int) int {
    sqrt5 := math.Sqrt(5)
    pow1 := math.Pow((1+sqrt5)/2, float64(n+1))
    pow2 := math.Pow((1-sqrt5)/2, float64(n+1))
    return int(math.Round((pow1 - pow2) / sqrt5))
}
```

```c
int climbStairs(int n) {
    double sqrt5 = sqrt(5);
    double fibn = pow((1 + sqrt5) / 2, n + 1) - pow((1 - sqrt5) / 2, n + 1);
    return (int) round(fibn / sqrt5);
}
```

**复杂度分析**

代码中使用的 pow 函数的时空复杂度与 CPU 支持的指令集相关，这里不深入分析。

#### 总结
这里形成的数列正好是斐波那契数列，答案要求的 f(n) 即是斐波那契数列的第 n 项（下标从 0 开始）。我们来总结一下斐波那契数列第 n 项的求解方法：
-   n 比较小的时候，可以直接使用过递归法求解，不做任何记忆化操作，时间复杂度是 $O(2^n)$，存在很多冗余计算。
-   一般情况下，我们使用「记忆化搜索」或者「迭代」的方法，实现这个转移方程，时间复杂度和空间复杂度都可以做到 O(n)。
-   为了优化空间复杂度，我们可以不用保存 f(x−2) 之前的项，我们只用三个变量来维护 f(x)、f(x−1) 和 f(x−2)，你可以理解成是把「滚动数组思想」应用在了动态规划中，也可以理解成是一种递推，这样把空间复杂度优化到了 O(1)。
-   随着 n 的不断增大 O(n) 可能已经不能满足我们的需要了，我们可以用「矩阵快速幂」的方法把算法加速到 O(log⁡n)。
-   我们也可以把 n 代入斐波那契数列的通项公式计算结果，但是如果我们用浮点数计算来实现，可能会产生精度误差。
