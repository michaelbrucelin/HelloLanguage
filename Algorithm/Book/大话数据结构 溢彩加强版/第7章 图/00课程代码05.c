#define MAXSIZE 9 /* 存储空间初始分配量 */
#define MAXVEX 9
#define TRUE 1
#define FALSE 0

typedef int Boolean;     /* Boolean是布尔类型,其值是TRUE或FALSE */
typedef char VertexType; /* 顶点类型应由用户定义 */
typedef int EdgeType;    /* 边上的权值类型应由用户定义 */

Boolean visited[MAXVEX]; /* 访问标志的数组 */

typedef struct
{
    VertexType vexs[MAXVEX];      /* 顶点表 */
    EdgeType arc[MAXVEX][MAXVEX]; /* 邻接矩阵，可看作边表 */
    int numVertexes, numEdges;    /* 图中当前的顶点数和边数 */
} MGraph;

/* 用到的队列结构与函数********************************** */

/* 循环队列的顺序存储结构 */
typedef struct
{
    int data[MAXSIZE];
    int front; /* 头指针 */
    int rear;  /* 尾指针，若队列不空，指向队列尾元素的下一个位置 */
} Queue;

/* 邻接矩阵的广度遍历算法 */
void BFSTraverse(MGraph G)
{
    int i, j;
    Queue Q;
    for (i = 0; i < G.numVertexes; i++)
        visited[i] = FALSE;
    InitQueue(&Q);                      /* 初始化一辅助用的队列 */
    for (i = 0; i < G.numVertexes; i++) /* 对每一个顶点做循环 */
    {
        if (!visited[i]) /* 若是未访问过就处理 */
        {
            visited[i] = TRUE;        /* 设置当前顶点访问过 */
            printf("%c ", G.vexs[i]); /* 打印顶点，也可以其它操作 */
            EnQueue(&Q, i);           /* 将此顶点入队列 */
            while (!QueueEmpty(Q))    /* 若当前队列不为空 */
            {
                DeQueue(&Q, &i); /* 将队首元素出队列，赋值给i */
                for (j = 0; j < G.numVertexes; j++)
                {
                    /* 判断其它顶点若与当前顶点存在 */
                    /* 边且未访问过 */
                    if (G.arc[i][j] == 1 && !visited[j])
                    {
                        visited[j] = TRUE;        /* 将找到的此顶点标记为已访问 */
                        printf("%c ", G.vexs[j]); /* 打印顶点 */
                        EnQueue(&Q, j);           /* 将找到的此顶点入队列  */
                    }
                }
            }
        }
    }
}
