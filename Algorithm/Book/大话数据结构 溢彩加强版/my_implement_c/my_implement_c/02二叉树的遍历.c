/* 二叉树的遍历 */
#include <cstddef>

typedef int TElemType;                 // 树结点的数据类型，目前暂定为整型

#define OVERFLOW -2                    // 堆溢出

/* 二叉树的二叉链表结点结构定义 */
typedef struct BiTNode                 // 结点结构
{
	TElemType data;                    // 结点数据
	struct BiTNode* lchild, * rchild;  // 左右孩子指针
} BiTNode, * BiTree;


/* 二叉树的前序遍历递归算法 */
// 初始条件: 二叉树T存在
// 操作结果: 前序递归遍历T
void PreOrderTraverse(BiTree T)
{
	if (T == NULL)
		return;
	printf("%c", T->data);             // 显示结点数据，可以更改为其它对结点操作
	PreOrderTraverse(T->lchild);       // 再先序遍历左子树
	PreOrderTraverse(T->rchild);       // 最后先序遍历右子树
}


/* 二叉树的中序遍历递归算法 */
// 初始条件: 二叉树T存在
// 操作结果: 中序递归遍历T
void InOrderTraverse(BiTree T)
{
	if (T == NULL)
		return;
	InOrderTraverse(T->lchild);        // 中序遍历左子树
	printf("%c", T->data);             // 显示结点数据，可以更改为其它对结点操作
	InOrderTraverse(T->rchild);        // 最后中序遍历右子树
}


/* 二叉树的后序遍历递归算法 */
// 初始条件: 二叉树T存在
// 操作结果: 后序递归遍历T
void PostOrderTraverse(BiTree T)
{
	if (T == NULL)
		return;
	PostOrderTraverse(T->lchild);      // 先后序遍历左子树
	PostOrderTraverse(T->rchild);      // 再后序遍历右子树
	printf("%c", T->data);             // 显示结点数据，可以更改为其它对结点操作
}
