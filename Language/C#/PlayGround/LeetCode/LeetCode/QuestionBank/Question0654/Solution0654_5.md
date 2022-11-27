## 单调栈

更进一步，根据题目对树的构建的描述可知，`nums` 中的任二节点所在构建树的水平截面上的位置仅由下标大小决定。

不难想到可抽象为找最近元素问题，可使用单调栈求解。

具体的，我们可以从前往后处理所有的 nums[i]，若存在栈顶元素并且栈顶元素的值比当前值要小，根据我们从前往后处理的逻辑，可确定栈顶元素可作为当前 nums[i] 对应节点的左节点，同时为了确保最终 nums[i] 的左节点为 [0,i−1] 范围的最大值，我们需要确保在构建 nums[i] 节点与其左节点的关系时，[0,i−1] 中的最大值最后出队，此时可知容器栈具有「单调递减」特性。基于此，我们可以分析出，当处理完 nums[i] 节点与其左节点关系后，可明确 nums[i] 可作为未出栈的栈顶元素的右节点。

> 一些细节：`Java` 容易使用 `ArrayDeque` 充当容器，但为与 `TS` 保存一致，两者均使用数组充当容器。

代码：

```Java
class Solution {
    static TreeNode[] stk = new TreeNode[1010];
    public TreeNode constructMaximumBinaryTree(int[] nums) {
        int he = 0, ta = 0;
        for (int x : nums) {
            TreeNode node = new TreeNode(x);
            while (he < ta && stk[ta - 1].val < x) node.left = stk[--ta];
            if (he < ta) stk[ta - 1].right = node;
            stk[ta++] = node;
        }
        return stk[0];
    }
}

```

```TypeScript
const stk = new Array<TreeNode>(1010)
function constructMaximumBinaryTree(nums: number[]): TreeNode | null {
    let he = 0, ta = 0
    for (const x of nums) {
        const node = new TreeNode(x)
        while (he < ta && stk[ta - 1].val < x) node.left = stk[--ta]
        if (he < ta) stk[ta - 1].right = node
        stk[ta++] = node
    }
    return stk[0]
};

```

-   时间复杂度：O(n)
-   空间复杂度：O(n)
