#### [方法二：树状数组](https://leetcode.cn/problems/global-and-local-inversions/solutions/1973202/by-lcbin-6qe7/)

这道题目实际上是一个“逆序对”问题。

局部倒置的数量等于相邻元素之间逆序对的个数，可以在遍历数组 `nums` 的过程中直接求出；而全局倒置的数量等于逆序对的个数，求解逆序对个数的一个常用做法是使用树状数组。

树状数组，也称作“二叉索引树”（Binary Indexed Tree）或 Fenwick 树。 它可以高效地实现如下两个操作：
1.  单点更新：即函数 `update(x, delta)`，把序列 x 位置的数加上一个值 delta。时间复杂度 $O(\log n)$。
2.  前缀和查询：即函数 `query(x)`，查询序列 [1,..x] 区间的区间和，即位置 x 的前缀和。时间复杂度 $O(\log n)$。

对于本题，我们定义一个变量 cnt 记录局部倒置的数量与全局倒置的数量之差。如果遍历过程中，cnt 的值小于 0，则说明全局倒置的数量大于局部倒置的数量，返回 `false` 即可。

```python
class BinaryIndexedTree:
    def __init__(self, n):
        self.n = n
        self.c = [0] * (n + 1)

    def update(self, x, delta):
        while x <= self.n:
            self.c[x] += delta
            x += x & -x

    def query(self, x):
        s = 0
        while x:
            s += self.c[x]
            x -= x & -x
        return s


class Solution:
    def isIdealPermutation(self, nums: List[int]) -> bool:
        n = len(nums)
        tree = BinaryIndexedTree(n)
        cnt = 0
        for i, v in enumerate(nums):
            cnt += (i < n - 1 and v > nums[i + 1])
            cnt -= (i - tree.query(v))
            if cnt < 0:
                return False
            tree.update(v + 1, 1)
        return True
```

```java
class BinaryIndexedTree {
    private int n;
    private int[] c;

    public BinaryIndexedTree(int n) {
        this.n = n;
        c = new int[n + 1];
    }

    public void update(int x, int delta) {
        while (x <= n) {
            c[x] += delta;
            x += x & -x;
        }
    }

    public int query(int x) {
        int s = 0;
        while (x > 0) {
            s += c[x];
            x -= x & -x;
        }
        return s;
    }
}

class Solution {
    public boolean isIdealPermutation(int[] nums) {
        int n = nums.length;
        BinaryIndexedTree tree = new BinaryIndexedTree(n);
        int cnt = 0;
        for (int i = 0; i < n && cnt >= 0; ++i) {
            cnt += (i < n - 1 && nums[i] > nums[i + 1] ? 1 : 0);
            cnt -= (i - tree.query(nums[i]));
            tree.update(nums[i] + 1, 1);
        }
        return cnt == 0;
    }
}
```

```cpp
class BinaryIndexedTree {
public:
    BinaryIndexedTree(int _n) : n(_n), c(_n + 1) {}

    void update(int x, int delta) {
        while (x <= n) {
            c[x] += delta;
            x += x & -x;
        }
    }

    int query(int x) {
        int s = 0;
        while (x) {
            s += c[x];
            x -= x & -x;
        }
        return s;
    }

private:
    int n;
    vector<int> c;
};

class Solution {
public:
    bool isIdealPermutation(vector<int>& nums) {
        int n = nums.size();
        BinaryIndexedTree tree(n);
        long cnt = 0;
        for (int i = 0; i < n && ~cnt; ++i) {
            cnt += (i < n - 1 && nums[i] > nums[i + 1]);
            cnt -= (i - tree.query(nums[i]));
            tree.update(nums[i] + 1, 1);
        }
        return cnt == 0;
    }
};
```

```go
func isIdealPermutation(nums []int) bool {
    n := len(nums)
    tree := newBinaryIndexedTree(n)
    cnt := 0
    for i, v := range nums {
        if i < n-1 && v > nums[i+1] {
            cnt++
        }
        cnt -= (i - tree.query(v))
        if cnt < 0 {
            break
        }
        tree.update(v+1, 1)
    }
    return cnt == 0
}

type BinaryIndexedTree struct {
    n int
    c []int
}

func newBinaryIndexedTree(n int) BinaryIndexedTree {
    c := make([]int, n+1)
    return BinaryIndexedTree{n, c}
}

func (this BinaryIndexedTree) update(x, delta int) {
    for x <= this.n {
        this.c[x] += delta
        x += x & -x
    }
}

func (this BinaryIndexedTree) query(x int) int {
    s := 0
    for x > 0 {
        s += this.c[x]
        x -= x & -x
    }
    return s
}
```

时间复杂度 $O(n \times \log n)$，空间复杂度 O(n)。其中 n 为数组 `nums` 的长度。
