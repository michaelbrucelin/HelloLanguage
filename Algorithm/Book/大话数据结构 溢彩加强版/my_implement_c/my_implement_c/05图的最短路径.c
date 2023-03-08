/* 图的最短路径 */
#include "01图的存储结构.c"


/* Dijkstra算法，求有向网G的v0顶点到其余顶点v的最短路径P[v]及带权长度D[v] */
/* P[v]的值为前驱顶点下标,D[v]表示v0到v的最短路径长度和 */
typedef int Patharc_Dijkstra[MAXVEX];                        // 用于存储最短路径下标的数组
typedef int ShortPathTable_Dijkstra[MAXVEX];                 // 用于存储到各点最短路径的权值和

void ShortestPath_Dijkstra(MGraph G, int v0, Patharc_Dijkstra* P, ShortPathTable_Dijkstra* D)
{
    int v, w, k, min;
    int final[MAXVEX];                                       // final[w]=1表示求得顶点v0至vw的最短路径
    for (v = 0; v < G.numVertexes; v++)                      // 初始化数据
    {
        final[v] = 0;                                        // 全部顶点初始化为未知最短路径状态
        (*D)[v] = G.arc[v0][v];                              // 将与v0点有连线的顶点加上权值
        (*P)[v] = -1;                                        // 初始化路径数组P为-1
    }

    (*D)[v0] = 0;                                            // v0至v0路径为0
    final[v0] = 1;                                           // v0至v0不需要求路径
    // 开始主循环，每次求得v0到某个v顶点的最短路径
    for (v = 1; v < G.numVertexes; v++)
    {
        min = INFINITY;                                      // 当前所知离v0顶点的最近距离
        for (w = 0; w < G.numVertexes; w++)                  // 寻找离v0最近的顶点
        {
            if (!final[w] && (*D)[w] < min)
            {
                k = w;
                min = (*D)[w];                               // w顶点离v0顶点更近
            }
        }
        final[k] = 1;                                        // 将目前找到的最近的顶点置为1
        for (w = 0; w < G.numVertexes; w++)                  // 修正当前最短路径及距离
        {
            // 如果经过v顶点的路径比现在这条路径的长度短的话
            if (!final[w] && (min + G.arc[k][w] < (*D)[w]))
            {                                                // 说明找到了更短的路径，修改D[w]和P[w]
                (*D)[w] = min + G.arc[k][w];                 // 修改当前路径长度
                (*P)[w] = k;
            }
        }
    }
}


/* Floyd算法，求网图G中各顶点v到其余顶点w的最短路径P[v][w]及带权长度D[v][w]。 */
typedef int Patharc_Floyd[MAXVEX][MAXVEX];
typedef int ShortPathTable_Floyd[MAXVEX][MAXVEX];

void ShortestPath_Floyd(MGraph G, Patharc_Floyd* P, ShortPathTable_Floyd* D)
{
    int v, w, k;
    for (v = 0; v < G.numVertexes; ++v)                      // 初始化D与P
    {
        for (w = 0; w < G.numVertexes; ++w)
        {
            (*D)[v][w] = G.arc[v][w];                        // D[v][w]值即为对应点间的权值
            (*P)[v][w] = w;                                  // 初始化P
        }
    }
    for (k = 0; k < G.numVertexes; ++k)
    {
        for (v = 0; v < G.numVertexes; ++v)
        {
            for (w = 0; w < G.numVertexes; ++w)
            {
                if ((*D)[v][w] > (*D)[v][k] + (*D)[k][w])
                {                                            // 如果经过下标为k顶点路径比原两点间路径更短
                    (*D)[v][w] = (*D)[v][k] + (*D)[k][w];    // 将当前两点间权值设更小一个
                    (*P)[v][w] = (*P)[v][k];                 // 路径设置为经过下标为k的顶点
                }
            }
        }
    }
}

int main()
{
    int v, w, k;
    MGraph G;

    Patharc_Floyd P;
    ShortPathTable_Floyd D;                                  // 求某点到其余各点的最短路径

    printf("各顶点间最短路径如下:\n");
    for (v = 0; v < G.numVertexes; ++v)
    {
        for (w = v + 1; w < G.numVertexes; w++)
        {
            printf("v%d-v%d weight: %d ", v, w, D[v][w]);
            k = P[v][w];                                     // 获得第一个路径顶点下标
            printf(" path: %d", v);                          // 打印源点
            while (k != w)                                   // 如果路径顶点下标不是终点
            {
                printf(" -> %d", k);                         // 打印路径顶点
                k = P[k][w];                                 // 获得下一个路径顶点下标
            }
            printf(" -> %d\n", w);                           // 打印终点
        }
        printf("\n");
    }
}
