typedef struct
{
    int vexs[MAXVEX];
    int arc[MAXVEX][MAXVEX];
    int numVertexes, numEdges;
} MGraph;

typedef int Patharc[MAXVEX];        /* 用于存储最短路径下标的数组 */
typedef int ShortPathTable[MAXVEX]; /* 用于存储到各点最短路径的权值和 */

/* Dijkstra算法，求有向网G的v0顶点到其余顶点v的最短路径P[v]及带权长度D[v] */
/* P[v]的值为前驱顶点下标,D[v]表示v0到v的最短路径长度和 */
void ShortestPath_Dijkstra(MGraph G, int v0, Patharc *P, ShortPathTable *D)
{
    int v, w, k, min;
    int final[MAXVEX];                  /* final[w]=1表示求得顶点v0至vw的最短路径 */
    for (v = 0; v < G.numVertexes; v++) /* 初始化数据 */
    {
        final[v] = 0;           /* 全部顶点初始化为未知最短路径状态 */
        (*D)[v] = G.arc[v0][v]; /* 将与v0点有连线的顶点加上权值 */
        (*P)[v] = -1;           /* 初始化路径数组P为-1  */
    }
    (*D)[v0] = 0;  /* v0至v0路径为0 */
    final[v0] = 1; /* v0至v0不需要求路径 */
    /* 开始主循环，每次求得v0到某个v顶点的最短路径 */
    for (v = 1; v < G.numVertexes; v++)
    {
        min = INFINITY;                     /* 当前所知离v0顶点的最近距离 */
        for (w = 0; w < G.numVertexes; w++) /* 寻找离v0最近的顶点 */
        {
            if (!final[w] && (*D)[w] < min)
            {
                k = w;
                min = (*D)[w]; /* w顶点离v0顶点更近 */
            }
        }
        final[k] = 1;                       /* 将目前找到的最近的顶点置为1 */
        for (w = 0; w < G.numVertexes; w++) /* 修正当前最短路径及距离 */
        {
            /* 如果经过v顶点的路径比现在这条路径的长度短的话 */
            if (!final[w] && (min + G.arc[k][w] < (*D)[w]))
            {                                /* 说明找到了更短的路径，修改D[w]和P[w] */
                (*D)[w] = min + G.arc[k][w]; /* 修改当前路径长度 */
                (*P)[w] = k;
            }
        }
    }
}
