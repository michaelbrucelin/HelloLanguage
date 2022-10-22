#### [](https://leetcode.cn/problems/merge-k-sorted-lists/solution/he-bing-kge-pai-xu-lian-biao-by-leetcode-solutio-2//#方法二：分治合并)方法二：分治合并

**思路**

考虑优化方法一，用分治的方法进行合并。

-   将 k 个链表配对并将同一对中的链表合并；
-   第一轮合并以后， k 个链表被合并成了 k/2 个链表，平均长度为 (2n)/k，然后是 k/4 个链表， k/8 个链表等等；
-   重复这一过程，直到我们得到了最终的有序链表。

![](./assets/img/Solution0023_3.png)

**代码**

```C++
class Solution {
public:
    ListNode* mergeTwoLists(ListNode *a, ListNode *b) {
        if ((!a) || (!b)) return a ? a : b;
        ListNode head, *tail = &head, *aPtr = a, *bPtr = b;
        while (aPtr && bPtr) {
            if (aPtr->val < bPtr->val) {
                tail->next = aPtr; aPtr = aPtr->next;
            } else {
                tail->next = bPtr; bPtr = bPtr->next;
            }
            tail = tail->next;
        }
        tail->next = (aPtr ? aPtr : bPtr);
        return head.next;
    }

    ListNode* merge(vector <ListNode*> &lists, int l, int r) {
        if (l == r) return lists[l];
        if (l > r) return nullptr;
        int mid = (l + r) >> 1;
        return mergeTwoLists(merge(lists, l, mid), merge(lists, mid + 1, r));
    }

    ListNode* mergeKLists(vector<ListNode*>& lists) {
        return merge(lists, 0, lists.size() - 1);
    }
};
```

```Java
class Solution {
    public ListNode mergeKLists(ListNode[] lists) {
        return merge(lists, 0, lists.length - 1);
    }

    public ListNode merge(ListNode[] lists, int l, int r) {
        if (l == r) {
            return lists[l];
        }
        if (l > r) {
            return null;
        }
        int mid = (l + r) >> 1;
        return mergeTwoLists(merge(lists, l, mid), merge(lists, mid + 1, r));
    }

    public ListNode mergeTwoLists(ListNode a, ListNode b) {
        if (a == null || b == null) {
            return a != null ? a : b;
        }
        ListNode head = new ListNode(0);
        ListNode tail = head, aPtr = a, bPtr = b;
        while (aPtr != null && bPtr != null) {
            if (aPtr.val < bPtr.val) {
                tail.next = aPtr;
                aPtr = aPtr.next;
            } else {
                tail.next = bPtr;
                bPtr = bPtr.next;
            }
            tail = tail.next;
        }
        tail.next = (aPtr != null ? aPtr : bPtr);
        return head.next;
    }
}
```

**复杂度分析**

-   时间复杂度：考虑递归「向上回升」的过程——第一轮合并 k/2 组链表，每一组的时间代价是 O(2n)；第二轮合并 k/4 组链表，每一组的时间代价是 O(4n)......所以总的时间代价是 $O(\sum_{i=1}^{\infty} \frac{k}{2^i} \times 2^in)=O(kn \times logk)$，故渐进时间复杂度为 $O(kn \times logk)$。
-   空间复杂度：递归会使用到 O(log⁡k) 空间代价的栈空间。
