#define MAXSIZE 9 /* 存储空间初始分配量 */
#define MAXVEX 9
#define TRUE 1
#define FALSE 0

typedef int Boolean;     /* Boolean是布尔类型,其值是TRUE或FALSE */
typedef char VertexType; /* 顶点类型应由用户定义 */
typedef int EdgeType;    /* 边上的权值类型应由用户定义 */

Boolean visited[MAXVEX]; /* 访问标志的数组 */

/* 邻接表结构****************** */
typedef struct EdgeNode /* 边表结点 */
{
    int adjvex;            /* 邻接点域,存储该顶点对应的下标 */
    int weight;            /* 用于存储权值,对于非网图可以不需要 */
    struct EdgeNode *next; /* 链域,指向下一个邻接点 */
} EdgeNode;

typedef struct VertexNode /* 顶点表结点 */
{
    int in;              /* 顶点入度 */
    char data;           /* 顶点域,存储顶点信息 */
    EdgeNode *firstedge; /* 边表头指针 */
} VertexNode, AdjList[MAXVEX];

typedef struct
{
    AdjList adjList;
    int numVertexes, numEdges; /* 图中当前顶点数和边数 */
} graphAdjList, *GraphAdjList;
/* **************************** */

/* 用到的队列结构与函数********************************** */
/* 循环队列的顺序存储结构 */
typedef struct
{
    int data[MAXSIZE];
    int front; /* 头指针 */
    int rear;  /* 尾指针,若队列不空,指向队列尾元素的下一个位置 */
} Queue;

/* 邻接表的广度遍历算法 */
void BFSTraverse(GraphAdjList GL)
{
    int i;
    EdgeNode *p;
    Queue Q;
    for (i = 0; i < GL->numVertexes; i++)
        visited[i] = FALSE;
    InitQueue(&Q);
    for (i = 0; i < GL->numVertexes; i++)
    {
        if (!visited[i])
        {
            visited[i] = TRUE;
            printf("%c ", GL->adjList[i].data); /* 打印顶点,也可以其它操作 */
            EnQueue(&Q, i);
            while (!QueueEmpty(Q))
            {
                DeQueue(&Q, &i);
                p = GL->adjList[i].firstedge; /* 找到当前顶点的边表链表头指针 */
                while (p)
                {
                    if (!visited[p->adjvex]) /* 若此顶点未被访问 */
                    {
                        visited[p->adjvex] = TRUE;
                        printf("%c ", GL->adjList[p->adjvex].data);
                        EnQueue(&Q, p->adjvex); /* 将此顶点入队列 */
                    }
                    p = p->next; /* 指针指向下一个邻接点 */
                }
            }
        }
    }
}
