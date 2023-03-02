typedef char VertexType; /* 顶点类型应由用户定义 */
typedef int EdgeType;    /* 边上的权值类型应由用户定义 */

#define MAXSIZE 9 /* 存储空间初始分配量 */
#define MAXEDGE 15
#define MAXVEX 9
#define INFINITY 65535 /* 用65535来代表∞ */

typedef struct
{
    int vexs[MAXVEX];
    int arc[MAXVEX][MAXVEX];
    int numVertexes, numEdges;
} MGraph;

typedef int Patharc[MAXVEX][MAXVEX];
typedef int ShortPathTable[MAXVEX][MAXVEX];

/* Floyd算法，求网图G中各顶点v到其余顶点w的最短路径P[v][w]及带权长度D[v][w]。 */
void ShortestPath_Floyd(MGraph G, Patharc *P, ShortPathTable *D)
{
    int v, w, k;
    for (v = 0; v < G.numVertexes; ++v) /* 初始化D与P */
    {
        for (w = 0; w < G.numVertexes; ++w)
        {
            (*D)[v][w] = G.arc[v][w]; /* D[v][w]值即为对应点间的权值 */
            (*P)[v][w] = w;           /* 初始化P */
        }
    }
    for (k = 0; k < G.numVertexes; ++k)
    {
        for (v = 0; v < G.numVertexes; ++v)
        {
            for (w = 0; w < G.numVertexes; ++w)
            {
                if ((*D)[v][w] > (*D)[v][k] + (*D)[k][w])
                {                                         /* 如果经过下标为k顶点路径比原两点间路径更短 */
                    (*D)[v][w] = (*D)[v][k] + (*D)[k][w]; /* 将当前两点间权值设更小一个 */
                    (*P)[v][w] = (*P)[v][k];              /* 路径设置为经过下标为k的顶点 */
                }
            }
        }
    }
}

int main()
{
    int v, w, k;
    MGraph G;

    Patharc P;
    ShortPathTable D; /* 求某点到其余各点的最短路径 */

    printf("各顶点间最短路径如下:\n");
    for (v = 0; v < G.numVertexes; ++v)
    {
        for (w = v + 1; w < G.numVertexes; w++)
        {
            printf("v%d-v%d weight: %d ", v, w, D[v][w]);
            k = P[v][w];            /* 获得第一个路径顶点下标 */
            printf(" path: %d", v); /* 打印源点 */
            while (k != w)          /* 如果路径顶点下标不是终点 */
            {
                printf(" -> %d", k); /* 打印路径顶点 */
                k = P[k][w];         /* 获得下一个路径顶点下标 */
            }
            printf(" -> %d\n", w); /* 打印终点 */
        }
        printf("\n");
    }
}
