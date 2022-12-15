#### [��ɫ��Ƿ�-һ��ͨ���Ҽ���������������](https://leetcode.cn/problems/binary-tree-inorder-traversal/solutions/25220/yan-se-biao-ji-fa-yi-chong-tong-yong-qie-jian-ming/)

**ԭ�����ӣ�**[��ɫ��Ƿ�-һ��ͨ���Ҽ���������������](https://leetcode.cn/problems/binary-tree-inorder-traversal/solutions/25220/yan-se-biao-ji-fa-yi-chong-tong-yong-qie-jian-ming/)

�ٷ�����н��������ַ���������������������������
- �ݹ�
- ����ջ�ĵ�������
- Ī��˹����

������������ȱ����У�����ǰ�����򡢺�����������ݹ鷽����Ϊֱ���׶��������ǵ�Ч�ʣ�����ͨ�����Ƽ�ʹ�õݹ顣

ջ����������Ȼ�����Ч�ʣ�����Ƕ��ѭ��ȴ�ǳ����ԣ�������⣬������ɡ�**һ���Ͷ���һд�ͷ�**���ľ��������Ҷ��ڲ�ͬ�ı���˳��ǰ�����򡢺��򣩣�ѭ���ṹ����ܴ󣬸������˼��为����

��ˣ������������һ�֡���ɫ��Ƿ�����Ϲ������֡�������**���ջ���������ĸ�Ч������ݹ鷽��һ������׶�������Ҫ���ǣ����ַ�������ǰ�����򡢺���������ܹ�д����ȫһ�µĴ���**��

�����˼�����£�
- ǰ��
  - ʹ����ɫ��ǽڵ��״̬���½ڵ�Ϊ��ɫ���ѷ��ʵĽڵ�Ϊ��ɫ��
  - ��������Ľڵ�Ϊ��ɫ��������Ϊ��ɫ��Ȼ�������ӽڵ㡢���ӽڵ㡢����������ջ��
  - ��������Ľڵ�Ϊ��ɫ���򽫽ڵ��ֵ�����
- ����
  - ʹ����ɫ��ǽڵ��״̬���½ڵ�Ϊ��ɫ���ѷ��ʵĽڵ�Ϊ��ɫ��
  - ��������Ľڵ�Ϊ��ɫ��������Ϊ��ɫ��Ȼ�������ӽڵ㡢�������ӽڵ�������ջ��
  - ��������Ľڵ�Ϊ��ɫ���򽫽ڵ��ֵ�����
- ����
  - ʹ����ɫ��ǽڵ��״̬���½ڵ�Ϊ��ɫ���ѷ��ʵĽڵ�Ϊ��ɫ��
  - ��������Ľڵ�Ϊ��ɫ��������Ϊ��ɫ��Ȼ�����������ӽڵ㡢���ӽڵ�������ջ��
  - ��������Ľڵ�Ϊ��ɫ���򽫽ڵ��ֵ�����

ʹ�����ַ���ʵ�ֵ�����������£�

```python
def preorderTraversal(self, root: TreeNode) -> List[int]:
    WHITE, GRAY = 0, 1
    res = []
    stack = [(WHITE, root)]
    while stack:
        color, node = stack.pop()
        if node is None: continue
        if color == WHITE:
            stack.append((WHITE, node.right))
            stack.append((WHITE, node.left))
            stack.append((GRAY, node))
        else:
            res.append(node.val)
    return res

def inorderTraversal(self, root: TreeNode) -> List[int]:
    WHITE, GRAY = 0, 1
    res = []
    stack = [(WHITE, root)]
    while stack:
        color, node = stack.pop()
        if node is None: continue
        if color == WHITE:
            stack.append((WHITE, node.right))
            stack.append((GRAY, node))
            stack.append((WHITE, node.left))
        else:
            res.append(node.val)
    return res

def postorderTraversal(self, root: TreeNode) -> List[int]:
    WHITE, GRAY = 0, 1
    res = []
    stack = [(WHITE, root)]
    while stack:
        color, node = stack.pop()
        if node is None: continue
        if color == WHITE:
            stack.append((GRAY, node))
            stack.append((WHITE, node.right))
            stack.append((WHITE, node.left))
        else:
            res.append(node.val)
    return res
```

```csharp
public List<char> Traverse_Dyeing(TreeNode root)
{
    List<char> result = new List<char>();
    if (root == null) return result;

    Stack<(bool tag, TreeNode node)> stack = new Stack<(bool, TreeNode)>();  // true:��ɫ, false:��ɫ
    stack.Push((true, root));
    while (stack.Count > 0)
    {
        var item = stack.Pop();
        if (item.node == null) continue;
        if (item.tag)
        {
            stack.Push((true, item.node.Right));
            stack.Push((true, item.node.Left));
            stack.Push((false, item.node));
        }
        else
            result.Add(item.node.Value);
    }

    return result;
}

public List<char> Traverse_Dyeing(TreeNode root)
{
    List<char> result = new List<char>();
    if (root == null) return result;

    Stack<(bool tag, TreeNode node)> stack = new Stack<(bool, TreeNode)>();  // true:��ɫ, false:��ɫ
    stack.Push((true, root));
    while (stack.Count > 0)
    {
        var item = stack.Pop();
        if (item.node == null) continue;
        if (item.tag)
        {
            stack.Push((true, item.node.Right));
            stack.Push((false, item.node));
            stack.Push((true, item.node.Left));
        }
        else
            result.Add(item.node.Value);
    }

    return result;
}

public List<char> Traverse_Dyeing(TreeNode root)
{
    List<char> result = new List<char>();
    if (root == null) return result;

    Stack<(bool tag, TreeNode node)> stack = new Stack<(bool, TreeNode)>();  // true:��ɫ, false:��ɫ
    stack.Push((true, root));
    while (stack.Count > 0)
    {
        var item = stack.Pop();
        if (item.node == null) continue;
        if (item.tag)
        {
            stack.Push((false, item.node));
            stack.Push((true, item.node.Right));
            stack.Push((true, item.node.Left));
        }
        else
            result.Add(item.node.Value);
    }

    return result;
}
```
