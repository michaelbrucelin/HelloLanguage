#### [](https://leetcode.cn/problems/swap-nodes-in-pairs/solution/liang-liang-jiao-huan-lian-biao-zhong-de-jie-di-91//#������������)������������

**˼·���㷨**

Ҳ����ͨ�������ķ�ʽʵ���������������еĽڵ㡣

�����ƽ�� `dummyHead`���� `dummyHead.next = head`���� `temp` ��ʾ��ǰ����Ľڵ㣬��ʼʱ `temp = dummyHead`��ÿ����Ҫ���� `temp` ����������ڵ㡣

��� `temp` �ĺ���û�нڵ����ֻ��һ���ڵ㣬��û�и���Ľڵ���Ҫ��������˽������������򣬻�� `temp` ����������ڵ� `node1` �� `node2`��ͨ�����½ڵ��ָ���ϵʵ�����������ڵ㡣

������ԣ�����֮ǰ�Ľڵ��ϵ�� `temp -> node1 -> node2`������֮��Ľڵ��ϵҪ��� `temp -> node2 -> node1`�������Ҫ�������²�����

```
temp.next = node2
node1.next = node2.next
node2.next = node1
```

�����������֮�󣬽ڵ��ϵ����� `temp -> node2 -> node1`������ `temp = node1`���������е�����ڵ��������������ֱ��ȫ���ڵ㶼������������

�������������еĽڵ�֮���µ������ͷ�ڵ��� `dummyHead.next`�������µ������ͷ�ڵ㼴�ɡ�

![](./assets/img/Solution0024_3_01.png)
![](./assets/img/Solution0024_3_02.png)
![](./assets/img/Solution0024_3_03.png)
![](./assets/img/Solution0024_3_04.png)
![](./assets/img/Solution0024_3_05.png)
![](./assets/img/Solution0024_3_06.png)
![](./assets/img/Solution0024_3_07.png)
![](./assets/img/Solution0024_3_08.png)
![](./assets/img/Solution0024_3_09.png)
![](./assets/img/Solution0024_3_10.png)
![](./assets/img/Solution0024_3_11.png)
![](./assets/img/Solution0024_3_12.png)
![](./assets/img/Solution0024_3_13.png)

**����**

```Java
class Solution {
    public ListNode swapPairs(ListNode head) {
        ListNode dummyHead = new ListNode(0);
        dummyHead.next = head;
        ListNode temp = dummyHead;
        while (temp.next != null && temp.next.next != null) {
            ListNode node1 = temp.next;
            ListNode node2 = temp.next.next;
            temp.next = node2;
            node1.next = node2.next;
            node2.next = node1;
            temp = node1;
        }
        return dummyHead.next;
    }
}
```

```C++
class Solution {
public:
    ListNode* swapPairs(ListNode* head) {
        ListNode* dummyHead = new ListNode(0);
        dummyHead->next = head;
        ListNode* temp = dummyHead;
        while (temp->next != nullptr && temp->next->next != nullptr) {
            ListNode* node1 = temp->next;
            ListNode* node2 = temp->next->next;
            temp->next = node2;
            node1->next = node2->next;
            node2->next = node1;
            temp = node1;
        }
        return dummyHead->next;
    }
};
```

```JavaScript
var swapPairs = function(head) {
    const dummyHead = new ListNode(0);
    dummyHead.next = head;
    let temp = dummyHead;
    while (temp.next !== null && temp.next.next !== null) {
        const node1 = temp.next;
        const node2 = temp.next.next;
        temp.next = node2;
        node1.next = node2.next;
        node2.next = node1;
        temp = node1;
    }
    return dummyHead.next;
};
```

```Python
class Solution:
    def swapPairs(self, head: ListNode) -> ListNode:
        dummyHead = ListNode(0)
        dummyHead.next = head
        temp = dummyHead
        while temp.next and temp.next.next:
            node1 = temp.next
            node2 = temp.next.next
            temp.next = node2
            node1.next = node2.next
            node2.next = node1
            temp = node1
        return dummyHead.next
```

```Go
func swapPairs(head *ListNode) *ListNode {
    dummyHead := &ListNode{0, head}
    temp := dummyHead
    for temp.Next != nil && temp.Next.Next != nil {
        node1 := temp.Next
        node2 := temp.Next.Next
        temp.Next = node2
        node1.Next = node2.Next
        node2.Next = node1
        temp = node1
    }
    return dummyHead.Next
}
```

```C
struct ListNode* swapPairs(struct ListNode* head) {
    struct ListNode dummyHead;
    dummyHead.next = head;
    struct ListNode* temp = &dummyHead;
    while (temp->next != NULL && temp->next->next != NULL) {
        struct ListNode* node1 = temp->next;
        struct ListNode* node2 = temp->next->next;
        temp->next = node2;
        node1->next = node2->next;
        node2->next = node1;
        temp = node1;
    }
    return dummyHead.next;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ������Ľڵ���������Ҫ��ÿ���ڵ���и���ָ��Ĳ�����
-   �ռ临�Ӷȣ�O(1)��
