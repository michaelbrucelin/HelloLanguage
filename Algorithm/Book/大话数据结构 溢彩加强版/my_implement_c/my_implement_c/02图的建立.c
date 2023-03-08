/* 图的建立 */
#include <stddef.h>
#include "01图的存储结构.c"


/* 邻接矩阵创建无向图 */
void CreateMGraph(MGraph* G)
{
    int i, j, k, w;
    printf("输入顶点数和边数:\n");
    scanf("%d,%d", &G->numVertexes, &G->numEdges);        // 输入顶点数和边数
    for (i = 0; i < G->numVertexes; i++)                  // 读入顶点信息,建立顶点表
        scanf(&G->vexs[i]);
    for (i = 0; i < G->numVertexes; i++)
        for (j = 0; j < G->numVertexes; j++)
            G->arc[i][j] = INFINITY;                      // 邻接矩阵初始化
    for (k = 0; k < G->numEdges; k++)                     // 读入numEdges条边，建立邻接矩阵
    {
        printf("输入边(vi,vj)上的下标i，下标j和权w:\n");
        scanf("%d,%d,%d", &i, &j, &w);                    // 输入边(vi,vj)上的权w
        G->arc[i][j] = w;
        G->arc[j][i] = G->arc[i][j];                      // 因为是无向图，矩阵对称
    }
}


/* 邻接表创建无向图 */
void CreateALGraph(GraphAdjList* G)
{
    int i, j, k;
    EdgeNode* e;
    printf("输入顶点数和边数:\n");
    scanf("%d,%d", &G->numVertexes, &G->numEdges);        // 输入顶点数和边数
    for (i = 0; i < G->numVertexes; i++)                  // 读入顶点信息,建立顶点表
    {
        scanf(&G->adjList[i].data);                       // 输入顶点信息
        G->adjList[i].firstedge = NULL;                   // 将边表置为空表
    }

    for (k = 0; k < G->numEdges; k++)                     // 建立边表
    {
        printf("输入边(vi,vj)上的顶点序号:\n");
        scanf("%d,%d", &i, &j);                           // 输入边(vi,vj)上的顶点序号
        e = (EdgeNode*)malloc(sizeof(EdgeNode));          // 向内存申请空间,生成边表结点
        e->adjvex = j;                                    // 邻接序号为j
        e->next = G->adjList[i].firstedge;                // 将e的指针指向当前顶点上指向的结点
        G->adjList[i].firstedge = e;                      // 将当前顶点的指针指向e
        e = (EdgeNode*)malloc(sizeof(EdgeNode));          // 向内存申请空间,生成边表结点
        e->adjvex = i;                                    // 邻接序号为i
        e->next = G->adjList[j].firstedge;                // 将e的指针指向当前顶点上指向的结点
        G->adjList[j].firstedge = e;                      // 将当前顶点的指针指向e
    }
}
