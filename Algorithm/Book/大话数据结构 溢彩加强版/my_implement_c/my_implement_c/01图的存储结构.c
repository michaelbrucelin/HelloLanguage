/* ͼ�Ĵ���ṹ */
typedef char VertexType;  // ��������Ӧ���û�����
typedef int EdgeType;     // ���ϵ�Ȩֵ����Ӧ���û�����

#define MAXVEX   100      // ��󶥵�����Ӧ���û�����
#define MAXEDGE  100      // ��������Ӧ���û�����
#define INFINITY 65535    // ��65535�������


/* �ڽӾ����ʾ�� */
// �ڽӾ����ʾ�����ṹ����
typedef struct
{
	VertexType vexs[MAXVEX];       // �����
	EdgeType arc[MAXVEX][MAXVEX];  // �ڽӾ��󣬿ɿ����߱�
	int numNodes, numEdges;        // ͼ�е�ǰ�Ķ������ͱ���
} MGraph;


/* �ڽӱ��ʾ�� */
// �ڽӱ��ʾ�����ṹ����
typedef struct EdgeNode            // �߱���
{
	int adjvex;                    // �ڽӵ���,�洢�ö����Ӧ���±�
	EdgeType info;                 // ���ڴ洢Ȩֵ,���ڷ���ͼ���Բ���Ҫ
	struct EdgeNode* next;         // ����,ָ����һ���ڽӵ�
} EdgeNode;

typedef struct VertexNode          // ������� */
{
	VertexType data;               // ������,�洢������Ϣ
	EdgeNode* firstedge;           // �߱�ͷָ��
} VertexNode, AdjList[MAXVEX];

typedef struct
{
	AdjList adjList;
	int numNodes, numEdges;        // ͼ�е�ǰ�������ͱ���
} GraphAdjList;


/* �Ա߼�����Edge�ṹ�Ķ��� */
// ĳЩͼ�۵��㷨������Kruskal����³˹�������㷨����Ҫ�ô����ݽṹ
typedef struct
{
	int begin;
	int end;
	int weight;
} Edge;
