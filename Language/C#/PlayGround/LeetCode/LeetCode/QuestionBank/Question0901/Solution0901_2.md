#### [](https://leetcode.cn/problems/online-stock-span/solution/gu-piao-jie-ge-kua-du-by-leetcode//#����һ������ջ)����һ������ջ

**����**

���С�ڻ���ڽ���۸��������������ȼ�����������һ�����ڽ��ռ۸�����ӡ������ `i` ��ļ۸�Ϊ `A[i]`���� `j` ��ļ۸�Ϊ `A[j]`������ `i < j` �� `A[i] <= A[j]`����ô�ڵ� `j` ��֮�󣬵� `i` �첻�����κ�һ��ѯ�ʵĴ𰸣���Ϊ������ڵ� `k, k > j` ����ԣ��� `i` ���������һ�����ڽ��ռ۸�����ӣ����� `j` ������ڵ� `i` ��֮���Ҽ۸񲻵��ڵ� `i` �죬��˳�����ì�ܡ�

��������һ�����ۣ�����ֻ��Ҫά��һ�������ݼ������У���֮Ϊ������ջ���������Ʊÿ��ļ۸�Ϊ `[11, 3, 9, 5, 6, 4]`����ôÿ�����֮�󣬶�Ӧ�ĵ���ջ�ֱ�Ϊ��

```
[11]
[11, 3]
[11, 9]
[11, 9, 5]
[11, 9, 6]
[11, 9, 6, 4]
```

�����ǵõ����µ�һ��ļ۸����� `7`��ʱ�����ǽ�ջ������С�ڵ��� `7` ��Ԫ��ȫ��ȡ������Ϊ����֮ǰ�Ľ��ۣ���ЩԪ�ز����Ϊ����ѯ�ʵĴ𰸡���ջ����Ԫ�ش��� `7` ʱ�����Ǿ͵õ������һ������ `7` �ļ۸�Ϊ `9`��

**�㷨**

�����õ���ջά��һ�������ݼ��ļ۸����У����Ҷ���ÿ���۸񣬴洢һ�� `weight` ��ʾ������һ���۸�֮�䣨�������һ���������ļ۸�֮�䣩�������������ջ�׵ļ۸���洢�������Ӧ������������ `[11, 3, 9, 5, 6, 4, 7]` ��Ӧ�ĵ���ջΪ `(11, weight=1), (9, weight=2), (7, weight=4)`��

�����ǵõ����µ�һ��ļ۸����� `10`�����ǽ�����ջ������С�ڵ��� `10` ��Ԫ��ȫ��ȡ���������ǵ� `weight` �����ۼӣ��ټ��� `1` �͵õ��˴𰸡�����֮�����ǰ� `10` ������Ӧ�� `weight` ����ջ�У��õ� `(11, weight=1), (10, weight=7)`��

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(Q)������ Q �ǵ��� `next()` �����Ĵ�����
-   �ռ临�Ӷȣ�O(Q)��
