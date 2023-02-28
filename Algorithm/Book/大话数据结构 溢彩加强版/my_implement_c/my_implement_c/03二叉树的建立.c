/* 二叉树的建立 */
#include <stddef.h>
#include "my_macro.h"

typedef int TElemType;                 // 树结点的数据类型，目前暂定为整型


/* 二叉树的二叉链表结点结构定义 */
typedef struct BiTNode                 // 结点结构
{
	TElemType data;                    // 结点数据
	struct BiTNode* lchild, * rchild;  // 左右孩子指针
} BiTNode, * BiTree;


// 按前序输入二叉树中结点的值（一个字符）
// #表示空树，构造二叉链表表示二叉树T
void CreateBiTree(BiTree* T)
{
	TElemType ch;

	scanf("%c", &ch);
	// ch = str[index++];              // 这行代码没看出来有什么用，暂时先给注释掉

	if (ch == '#')
		*T = NULL;
	else
	{
		*T = (BiTree)malloc(sizeof(BiTNode));
		if (!*T)
			exit(OVERFLOW);
		(*T)->data = ch;               // 生成根结点
		CreateBiTree(&(*T)->lchild);   // 构造左子树
		CreateBiTree(&(*T)->rchild);   // 构造右子树
	}
}
