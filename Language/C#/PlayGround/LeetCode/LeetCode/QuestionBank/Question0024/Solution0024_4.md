#### [](https://leetcode.cn/problems/swap-nodes-in-pairs/solution/dong-hua-yan-shi-24-liang-liang-jiao-huan-lian-bia//#����˼·)����˼·

**����stack**
��������һ�� stack��Ȼ�󲻶ϵ�������ÿ��ȡ�������ڵ���� stack �У��ٴ� stack ���ó������ڵ㡣
���� stack ����ȳ����ص㣬�Ž�ȥ��ʱ���� 1,2 ���ó�����ʱ����� 2��1 �����ڵ��ˡ�
�ٰ��������ڵ㴮���������ظ�����߼����������������Ϳ�������������ת��Ч���ˡ�
��Ȼ�õ��� stack������Ϊֻ��������Ԫ�أ����Կռ临�ӶȻ��� O(1)��ʱ�临�Ӷ��� O(n)��
![](./assets/img/Solution0024_4_01.gif)

����ʵ�֣�

```Java
class Solution {
    public ListNode swapPairs(ListNode head) {
        if(head==null || head.next==null) {
            return head;
        }
        //��stack����ÿ�ε����������ڵ�
        Stack<ListNode> stack = new Stack<ListNode>();
        ListNode p = new ListNode(-1);
        ListNode cur = head;
        //headָ���µ�p�ڵ㣬��������ʱ����head.next����
        head = p;
        while(cur!=null && cur.next!=null) {
            //�������ڵ����stack��
            stack.add(cur);
            stack.add(cur.next);
            //��ǰ�ڵ���ǰ������
            cur = cur.next.next;
            //��stack�е��������ڵ㣬Ȼ����p�ڵ�ָ���µ����������ڵ�
            p.next = stack.pop();
            p = p.next;
            p.next = stack.pop();
            p = p.next;
        }
        //ע��߽���������������������ʱ��cur�Ͳ�Ϊ��
        if(cur!=null) {
            p.next = cur;
        } else {
            p.next = null;
        }

        return head.next;
    }
}
```

```Python
class Solution(object):
    def swapPairs(self, head):
    if not (head and head.next):
        return head
    p = ListNode(-1)
    # ��stack����ÿ�ε����������ڵ�
    # headָ���µ�p�ڵ㣬��������ʱ����head.next����
    cur,head,stack = head,p,[]
    while cur and cur.next:
        # �������ڵ����stack��
        _,_ = stack.append(cur),stack.append(cur.next)
        # ��ǰ�ڵ���ǰ������
        cur = cur.next.next
        # ��stack�е��������ڵ㣬Ȼ����p�ڵ�ָ���µ����������ڵ�
        p.next = stack.pop()
        p.next.next = stack.pop()
        p = p.next.next
    # ע��߽���������������������ʱ��cur�Ͳ�Ϊ��
    if cur:
        p.next = cur
    else:
        p.next = None

    return head.next
```

#### [](https://leetcode.cn/problems/swap-nodes-in-pairs/solution/dong-hua-yan-shi-24-liang-liang-jiao-huan-lian-bia//#����ʵ��)����ʵ��

����ʵ�־ͱ� stack ��ʽ���Ӷ��ˣ���Ҫ��С�ĵĴ���ڵ��ָ��
����������Ҫ����ָ�룬a��b��tmp��
����������
`1->2->3->4->5->6`
�ڵ�����ʱ��ÿ�δ��������ڵ㣬���ǵ�һ�� a ָ�� 1��b ָ�� 2��
�ڶ��ֵ�ʱ�� a ָ�� 3��b ָ�� 4�������ֵ�ʱ�� a ָ�� 5��b ָ�� 6��
����ͨ�� `a.next = b.next`���Լ�`b.next=a`�Ͱ�����ָ���λ�÷�ת�ˣ�����`1->2`�ͱ��`2->1`��
��������һ��ϸ����Ҫ���������ǵڶ��ֵ�����ʱ��a ָ�� 3��b ָ�� 4��������ĿҪ������Ӧ����`2->1->4->3`��
Ҳ���ǽڵ� 1 ��Ҫ���ڵ� 4 ��������ֻ������ָ���û��Ū�ˣ�������Ҫ������ָ�� tmp��������¼��һ�� a ��λ�ã�Ȼ����һ�ֵ�����ʱ�򣬽�ԭ�ȵ� a(Ҳ���ǽڵ� 1)ָ�� 4��
![](./assets/img/Solution0024_4_02.gif)

����ʵ�֣�

```Java
class Solution {
    public ListNode swapPairs(ListNode head) {
        //����һ������ڵ㷽�㴦��
        ListNode p = new ListNode(-1);
        p.next = head;
        //����a��b����ָ�룬���ﻹ��Ҫһ��tmpָ��
        ListNode a = p;
        ListNode b = p;
        ListNode tmp = p;
        while(b!=null && b.next!=null && b.next.next!=null) {
            //aǰ��һλ��bǰ����λ
            a = a.next;
            b = b.next.next;
            //�ⲽ�ܹؼ���tmpָ����������߽�������
            //����������1->2->3->4��aָ��1��bָ��2
            //�ı�a��b��ָ�����Ǿͱ��2->1������1ָ��˭�أ�
            //1�ǲ���ָ��2��next��1Ӧ��ָ��4����ѭ��������ʱ��һ�δ���2���ڵ�
            //1��2�Ĺ�ϵŪ����ˣ�3��4�Ĺ�ϵҲ��Ū���������Ҫһ��ָ��������
            //2->1��4->3�Ĺ�ϵ��tmpָ����Ǹ�����õ�
            tmp.next = b;
            a.next = b.next;
            b.next = a;
            //��������ͱ��2->1->3->4
            //tmp��b��ָ��1�ڵ㣬���´ε�����ʱ��
            //a�ͱ��3��b�ͱ��4��Ȼ��tmp��ָ��b��Ҳ����1ָ��4
            tmp = a;
            b = a;
        }
        return p.next;
    }
}
```

```Python
class Solution(object):
    def swapPairs(self, head):
    # ����һ������ڵ㷽�㴦��
    p = ListNode(-1)
    # ����a��b����ָ�룬���ﻹ��Ҫһ��tmpָ��
    a,b,p.next,tmp = p,p,head,p
    while b.next and b.next.next:
        # aǰ��һλ��bǰ����λ
        a,b = a.next,b.next.next
        # �ⲽ�ܹؼ���tmpָ����������߽�������
        # ����������1->2->3->4��aָ��1��bָ��2
        # �ı�a��b��ָ�����Ǿͱ��2->1������1ָ��˭�أ�
        # 1�ǲ���ָ��2��next��1Ӧ��ָ��4����ѭ��������ʱ��һ�δ���2���ڵ�
        # 1��2�Ĺ�ϵŪ����ˣ�3��4�Ĺ�ϵҲ��Ū���������Ҫһ��ָ��������
        # 2->1��4->3�Ĺ�ϵ��tmpָ����Ǹ�����õ�
        tmp.next,a.next,b.next = b,b.next,a
        # ��������ͱ��2->1->3->4
        # tmp��b��ָ��1�ڵ㣬���´ε�����ʱ��
        # a�ͱ��3��b�ͱ��4��Ȼ��tmp��ָ��b��Ҳ����1ָ��4
        tmp,b = a,a
    return p.next
```

#### [](https://leetcode.cn/problems/swap-nodes-in-pairs/solution/dong-hua-yan-shi-24-liang-liang-jiao-huan-lian-bia//#�ݹ�ⷨ)�ݹ�ⷨ

���˸о��ݹ�ⷨ��ʵ�ȵ���Ҫ����һЩ��û����Щ���ӵ�ָ��ָȥ�Ĺ�ϵ��
д�ݹ�Ļ�����Ҫ������ݹ����ֹ�������Լ��ݹ麯������ʲô��
������`1->2->....`��˵����
��ֹ��������ǰ�ڵ�Ϊnull��������һ���ڵ�Ϊ `null`
�����ڣ��� 2 ָ�� 1��1 ָ����һ��ĵݹ麯������󷵻ؽڵ� 2
������t�ͱ�ʾ�����ڵ���ʱ�ڵ� tmp��ͼ�нڵ� 1���ڵ� 3 ָ���һ��Ƭ�հף����ʾ���ù�ϵ��û����ȷ����Ҫ����һ��ݹ麯�����غ󣬲�������ȷ������ָ��
![](./assets/img/Solution0024_4_03.gif)

������һһ�����£����������ܳ���ż������ô�ݹ麯��ִ�е���ֹ����ʱ��head �͵��� null��������������ܳ���ż������ô�ݹ麯��ִ�е���ֹ����ʱ��head.next �͵��� null��
�ݹ麯���ڣ�����Ҫ�ı� 1->2 ��ָ�򣬽����Ϊ 2->1��
�Ǻ���Ľڵ���ô���أ����õ��ģ���������һ��ݹ麯�����������һ��ݹ麯�����غ�Ľڵ��� 4������4->3->...�������ˣ�Ҳ���Ǻ���Ľڵ㶼�Ѿ��������ˡ���������ֻ��Ҫ�� 1 �ڵ�ָ�� 4 �Ϳ�������

�������£�

```Java
class Solution {
    public ListNode swapPairs(ListNode head) {
    //�ݹ����ֹ����
        if(head==null || head.next==null) {
            return head;
        }
        //���������� 1->2->3->4
        //�����ȱ���ڵ�2
        ListNode tmp = head.next;
        //�����ݹ飬����ڵ�3->4
        //���ݹ�������غ󣬾ͱ����4->3
        //����head�ڵ��ָ����4�����1->4->3
        head.next = swapPairs(tmp.next);
        //��2�ڵ�ָ��1
        tmp.next = head;

        return tmp;
    }
}
```

```Python
class Solution(object):
    def swapPairs(self, head):
    # �ݹ����ֹ����
    if not (head and head.next):
        return head
    # ���������� 1->2->3->4
    # �����ȱ���ڵ�2
    tmp = head.next
    # �����ݹ飬����ڵ�3->4
    # ���ݹ�������غ󣬾ͱ����4->3
    # ����head�ڵ��ָ����4�����1->4->3
    head.next = self.swapPairs(tmp.next)
    # ��2�ڵ�ָ��1
    tmp.next = head

    return tmp
```
