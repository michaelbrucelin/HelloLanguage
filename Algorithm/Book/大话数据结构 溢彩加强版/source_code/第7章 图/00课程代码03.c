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

/* 邻接矩阵的深度优先递归算法 */
void DFS(MGraph G, int i)
{
    int j;
    visited[i] = TRUE;
    printf("%c ", G.vexs[i]); /* 打印顶点，也可以其它操作 */
    for (j = 0; j < G.numVertexes; j++)
        if (G.arc[i][j] == 1 && !visited[j])
            DFS(G, j); /* 对为访问的邻接顶点递归调用 */
}

/* 邻接矩阵的深度遍历操作 */
void DFSTraverse(MGraph G)
{
    int i;
    for (i = 0; i < G.numVertexes; i++)
        visited[i] = FALSE; /* 初始所有顶点状态都是未访问过状态 */
    for (i = 0; i < G.numVertexes; i++)
        if (!visited[i]) /* 对未访问过的顶点调用DFS，若连通图仅执行一次 */
            DFS(G, i);
}
