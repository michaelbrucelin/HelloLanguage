#### 前置知识：合并两个有序链表

**思路**  
在解决「合并K个排序链表」这个问题之前，我们先来看一个更简单的问题：如何合并两个有序链表？假设链表 a 和 b 的长度都是 n，**如何在 O(n) 的时间代价以及 O(1) 的空间代价完成合并？** 这个问题在面试中常常出现，为了达到空间代价是 O(1)，我们的宗旨是「原地调整链表元素的 next 指针完成合并」。**以下是合并的步骤和注意事项，对这个问题比较熟悉的读者可以跳过这一部分。此部分建议结合代码阅读。**

-   首先我们需要一个变量 head 来保存合并之后链表的头部，你可以把 head 设置为一个虚拟的头（也就是 head 的 val 属性不保存任何值），这是为了方便代码的书写，在整个链表合并完之后，返回它的下一位置即可。
-   我们需要一个指针 tail 来记录下一个插入位置的前一个位置，以及两个指针 aPtr 和 bPtr 来记录 a 和 b 未合并部分的第一位。**注意这里的描述，tail 不是下一个插入的位置，aPtr 和 bPtr 所指向的元素处于「待合并」的状态，也就是说它们还没有合并入最终的链表。** 当然你也可以给他们赋予其他的定义，但是定义不同实现就会不同。
-   当 aPtr 和 bPtr 都不为空的时候，取 val 熟悉较小的合并；如果 aPtr 为空，则把整个 bPtr 以及后面的元素全部合并；bPtr 为空时同理。
-   在合并的时候，应该先调整 tail 的 next 属性，再后移 tail 和 \*Ptr（aPtr 或者 bPtr）。那么这里 tail 和 \*Ptr 是否存在先后顺序呢？它们谁先动谁后动都是一样的，不会改变任何元素的 next 指针。

**代码**

```C++
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

```

```Java
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

```

**复杂度分析**

-   时间复杂度：O(n)。
-   空间复杂度：O(1)。

#### [](https://leetcode.cn/problems/merge-k-sorted-lists/solution/he-bing-kge-pai-xu-lian-biao-by-leetcode-solutio-2//#方法一：顺序合并)方法一：顺序合并

**思路**

我们可以想到一种最朴素的方法：用一个变量 ans 来维护以及合并的链表，第 i 次循环把第 i 个链表和 ans 合并，答案保存到 ans 中。

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

    ListNode* mergeKLists(vector<ListNode*>& lists) {
        ListNode *ans = nullptr;
        for (size_t i = 0; i < lists.size(); ++i) {
            ans = mergeTwoLists(ans, lists[i]);
        }
        return ans;
    }
};

```

```Java
class Solution {
    public ListNode mergeKLists(ListNode[] lists) {
        ListNode ans = null;
        for (int i = 0; i < lists.length; ++i) {
            ans = mergeTwoLists(ans, lists[i]);
        }
        return ans;
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

-   时间复杂度：假设每个链表的最长长度是 n。在第一次合并后，ans 的长度为 n；第二次合并后，ans 的长度为 2×n，第 i 次合并后，ans 的长度为 i×n。第 i 次合并的时间代价是 O(n+(i−1)×n)\=O(i×n)，那么总的时间代价为 O(∑i\=1k(i×n))\=O((1+k)⋅k2×n)\=O(k2n)，故渐进时间复杂度为 O(k2n)。
-   空间复杂度：没有用到与 k 和 n 规模相关的辅助空间，故渐进空间复杂度为 O(1)。
