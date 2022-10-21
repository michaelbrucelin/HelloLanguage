#### [](https://leetcode.cn/problems/online-stock-span/solution/gu-piao-jie-ge-kua-du-by-leetcode//#方法一：单调栈)方法一：单调栈

**分析**

求出小于或等于今天价格的最大连续日数等价于求出最近的一个大于今日价格的日子。如果第 `i` 天的价格为 `A[i]`，第 `j` 天的价格为 `A[j]`，满足 `i < j` 且 `A[i] <= A[j]`，那么在第 `j` 天之后，第 `i` 天不会是任何一天询问的答案，因为如果对于第 `k, k > j` 天而言，第 `i` 天是最近的一个大于今日价格的日子，但第 `j` 天出现在第 `i` 天之后且价格不低于第 `i` 天，因此出现了矛盾。

有了这样一个结论，我们只需要维护一个单调递减的序列，称之为”单调栈“。例如股票每天的价格为 `[11, 3, 9, 5, 6, 4]`，那么每天结束之后，对应的单调栈分别为：

```
[11]
[11, 3]
[11, 9]
[11, 9, 5]
[11, 9, 6]
[11, 9, 6, 4]
```

当我们得到了新的一天的价格（例如 `7`）时，我们将栈中所有小于等于 `7` 的元素全部取出，因为根据之前的结论，这些元素不会成为后续询问的答案。当栈顶的元素大于 `7` 时，我们就得到最近的一个大于 `7` 的价格为 `9`。

**算法**

我们用单调栈维护一个单调递减的价格序列，并且对于每个价格，存储一个 `weight` 表示它离上一个价格之间（即最近的一个大于它的价格之间）的天数。如果是栈底的价格，则存储它本身对应的天数。例如 `[11, 3, 9, 5, 6, 4, 7]` 对应的单调栈为 `(11, weight=1), (9, weight=2), (7, weight=4)`。

当我们得到了新的一天的价格，例如 `10`，我们将所有栈中所有小于等于 `10` 的元素全部取出，将它们的 `weight` 进行累加，再加上 `1` 就得到了答案。在这之后，我们把 `10` 和它对应的 `weight` 放入栈中，得到 `(11, weight=1), (10, weight=7)`。

```Java
class StockSpanner {
    Stack<Integer> prices, weights;

    public StockSpanner() {
        prices = new Stack();
        weights = new Stack();
    }

    public int next(int price) {
        int w = 1;
        while (!prices.isEmpty() && prices.peek() <= price) {
            prices.pop();
            w += weights.pop();
        }

        prices.push(price);
        weights.push(w);
        return w;
    }
}
```

```Python
class StockSpanner(object):
    def __init__(self):
        self.stack = []

    def next(self, price):
        weight = 1
        while self.stack and self.stack[-1][0] <= price:
            weight += self.stack.pop()[1]
        self.stack.append((price, weight))
        return weight
```

**复杂度分析**

-   时间复杂度：O(Q)，其中 Q 是调用 `next()` 函数的次数。
-   空间复杂度：O(Q)。
