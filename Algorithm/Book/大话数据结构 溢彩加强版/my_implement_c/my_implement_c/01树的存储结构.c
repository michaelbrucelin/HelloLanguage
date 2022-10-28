/* ���Ĵ���ṹ */
#define MAX_TREE_SIZE 100

typedef int TElemType;            // �������������ͣ�Ŀǰ�ݶ�Ϊ����


/* ����˫�ױ�ʾ�����ṹ���� */
typedef struct PTNode             // ���ṹ
{
	TElemType data;               // �������
	int parent;                   // ˫��λ��
}PTNode;

typedef struct
{
	PTNode nodes[MAX_TREE_SIZE];  // �������
	int r, n;                     // ����λ�úͽ����
}PTree;


/* ���ĺ��ӱ�ʾ���ṹ���� */
typedef struct CTNode             // ���ӽ��
{
	int child;
	struct CTNode* next;
}*ChildPtr;

typedef struct                    // ��ͷ�ṹ
{
	TElemType data;
	ChildPtr firstchild;
}CTBox;

typedef struct                    // ���ṹ
{
	CTBox nodes[MAX_TREE_SIZE];   // �������
	int r, n;                     // ����λ�úͽ����
}CTree;


/* ���ĺ����ֵܱ�ʾ���ṹ���� */
typedef struct CSNode
{
	TElemType data;
	struct CSNode* firstchild, * rightsib;
} CSNode, * CSTree;


/* �������Ķ���������ṹ���� */
typedef struct BiTNode
{
	TElemType data;
	struct BiTNode* lchild, * rchild;
}BiTNode, * BiTree;
