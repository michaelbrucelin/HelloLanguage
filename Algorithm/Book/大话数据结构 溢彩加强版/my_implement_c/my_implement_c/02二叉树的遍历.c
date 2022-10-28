/* �������ı��� */
#include <cstddef>

typedef int TElemType;                 // �������������ͣ�Ŀǰ�ݶ�Ϊ����

#define OVERFLOW -2                    // �����

/* �������Ķ���������ṹ���� */
typedef struct BiTNode                 // ���ṹ
{
	TElemType data;                    // �������
	struct BiTNode* lchild, * rchild;  // ���Һ���ָ��
} BiTNode, * BiTree;


/* ��������ǰ������ݹ��㷨 */
// ��ʼ����: ������T����
// �������: ǰ��ݹ����T
void PreOrderTraverse(BiTree T)
{
	if (T == NULL)
		return;
	printf("%c", T->data);             // ��ʾ������ݣ����Ը���Ϊ�����Խ�����
	PreOrderTraverse(T->lchild);       // ���������������
	PreOrderTraverse(T->rchild);       // ����������������
}


/* ����������������ݹ��㷨 */
// ��ʼ����: ������T����
// �������: ����ݹ����T
void InOrderTraverse(BiTree T)
{
	if (T == NULL)
		return;
	InOrderTraverse(T->lchild);        // �������������
	printf("%c", T->data);             // ��ʾ������ݣ����Ը���Ϊ�����Խ�����
	InOrderTraverse(T->rchild);        // ����������������
}


/* �������ĺ�������ݹ��㷨 */
// ��ʼ����: ������T����
// �������: ����ݹ����T
void PostOrderTraverse(BiTree T)
{
	if (T == NULL)
		return;
	PostOrderTraverse(T->lchild);      // �Ⱥ������������
	PostOrderTraverse(T->rchild);      // �ٺ������������
	printf("%c", T->data);             // ��ʾ������ݣ����Ը���Ϊ�����Խ�����
}
