/* �������Ľ��� */
#include <stddef.h>
#include "my_macro.h"

typedef int TElemType;                 // �������������ͣ�Ŀǰ�ݶ�Ϊ����


/* �������Ķ���������ṹ���� */
typedef struct BiTNode                 // ���ṹ
{
	TElemType data;                    // �������
	struct BiTNode* lchild, * rchild;  // ���Һ���ָ��
} BiTNode, * BiTree;


// ��ǰ������������н���ֵ��һ���ַ���
// #��ʾ������������������ʾ������T
void CreateBiTree(BiTree* T)
{
	TElemType ch;

	scanf("%c", &ch);
	// ch = str[index++];              // ���д���û��������ʲô�ã���ʱ�ȸ�ע�͵�

	if (ch == '#')
		*T = NULL;
	else
	{
		*T = (BiTree)malloc(sizeof(BiTNode));
		if (!*T)
			exit(OVERFLOW);
		(*T)->data = ch;               // ���ɸ����
		CreateBiTree(&(*T)->lchild);   // ����������
		CreateBiTree(&(*T)->rchild);   // ����������
	}
}
