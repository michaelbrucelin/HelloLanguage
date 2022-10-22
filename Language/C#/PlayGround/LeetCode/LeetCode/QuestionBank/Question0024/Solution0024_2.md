#### [](https://leetcode.cn/problems/swap-nodes-in-pairs/solution/liang-liang-jiao-huan-lian-biao-zhong-de-jie-di-91//#����һ���ݹ�)����һ���ݹ�

**˼·���㷨**

����ͨ���ݹ�ķ�ʽʵ���������������еĽڵ㡣

�ݹ����ֹ������������û�нڵ㣬����������ֻ��һ���ڵ㣬��ʱ�޷����н�����

��������������������ڵ㣬�����������������еĽڵ�֮��ԭʼ�����ͷ�ڵ����µ�����ĵڶ����ڵ㣬ԭʼ����ĵڶ����ڵ����µ������ͷ�ڵ㡣�����е�����ڵ�������������Եݹ��ʵ�֡��ڶ������е�����ڵ�ݹ����������֮�󣬸��½ڵ�֮���ָ���ϵ����������������������������

�� `head` ��ʾԭʼ�����ͷ�ڵ㣬�µ�����ĵڶ����ڵ㣬�� `newHead` ��ʾ�µ������ͷ�ڵ㣬ԭʼ����ĵڶ����ڵ㣬��ԭʼ�����е�����ڵ��ͷ�ڵ��� `newHead.next`���� `head.next = swapPairs(newHead.next)`����ʾ������ڵ����������������������µ�ͷ�ڵ�Ϊ `head` ����һ���ڵ㡣Ȼ���� `newHead.next = head`������������нڵ�Ľ�������󷵻��µ������ͷ�ڵ� `newHead`��

**����**

```Java
class Solution {
    public ListNode swapPairs(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        ListNode newHead = head.next;
        head.next = swapPairs(newHead.next);
        newHead.next = head;
        return newHead;
    }
}
```

```C++
class Solution {
public:
    ListNode* swapPairs(ListNode* head) {
        if (head == nullptr || head->next == nullptr) {
            return head;
        }
        ListNode* newHead = head->next;
        head->next = swapPairs(newHead->next);
        newHead->next = head;
        return newHead;
    }
};
```

```JavaScript
var swapPairs = function(head) {
    if (head === null|| head.next === null) {
        return head;
    }
    const newHead = head.next;
    head.next = swapPairs(newHead.next);
    newHead.next = head;
    return newHead;
};
```

```Python
class Solution:
    def swapPairs(self, head: ListNode) -> ListNode:
        if not head or not head.next:
            return head
        newHead = head.next
        head.next = self.swapPairs(newHead.next)
        newHead.next = head
        return newHead
```

```Go
func swapPairs(head *ListNode) *ListNode {
    if head == nil || head.Next == nil {
        return head
    }
    newHead := head.Next
    head.Next = swapPairs(newHead.Next)
    newHead.Next = head
    return newHead
}
```

```C
struct ListNode* swapPairs(struct ListNode* head) {
    if (head == NULL || head->next == NULL) {
        return head;
    }
    struct ListNode* newHead = head->next;
    head->next = swapPairs(newHead->next);
    newHead->next = head;
    return newHead;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ������Ľڵ���������Ҫ��ÿ���ڵ���и���ָ��Ĳ�����
-   �ռ临�Ӷȣ�O(n)������ n ������Ľڵ��������ռ临�Ӷ���Ҫȡ���ڵݹ���õ�ջ�ռ䡣
