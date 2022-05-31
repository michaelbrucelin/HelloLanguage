/* 对边集数组Edge结构的定义 */
typedef struct
{
    int begin;
    int end;
    int weight;
} Edge;

/* Kruskal算法生成最小生成树 */
void MiniSpanTree_Kruskal(MGraph G)
{
    int i, n, m;
    Edge edges[MAXEDGE]; /* 定义边集数组,edge的结构为begin,end,weight,均为整型 */
    int parent[MAXVEX];  /* 定义一数组用来判断边与边是否形成环路 */

    /* 此处省略将邻接矩阵G转化为边集数组edges并按权由小到大排序的代码*/

    for (i = 0; i < G.numVertexes; i++)
        parent[i] = 0;               /* 初始化数组值为0 */
    for (i = 0; i < G.numEdges; i++) /* 循环每一条边 */
    {
        n = Find(parent, edges[i].begin);
        m = Find(parent, edges[i].end);
        if (n != m) /* 假如n与m不等，说明此边没有与现有的生成树形成环路 */
        {           /* 将此边的结尾顶点放入下标为起点的parent中。表示此顶点已经在生成树集合中 */
            parent[n] = m;
            printf("(%d, %d) %d\n", edges[i].begin, edges[i].end, edges[i].weight);
        }
    }
}

/* 查找连线顶点的尾部下标 */
int Find(int *parent, int f)
{
    while (parent[f] > 0)
    {
        f = parent[f];
    }
    return f;
}
