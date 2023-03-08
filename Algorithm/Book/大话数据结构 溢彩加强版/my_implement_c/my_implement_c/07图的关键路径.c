/* 图的关键路径 */
#include "my_macro.h"
#include "01图的存储结构.c"

int* etv, * ltv;  // 事件最早发生时间和最迟发生时间数组
int* stack2;      // 用于存储拓扑序列的栈
int top2;         // 用于stack2的指针

/* 拓扑排序 */
Status TopologicalSort(GraphAdjList GL)
{   /* 若GL无回路，则输出拓扑排序序列并返回1，若有回路返回0。 */
    EdgeNode* e;
    int i, k, gettop;
    int top = 0;                                                 // 用于栈指针下标
    int count = 0;                                               // 用于统计输出顶点的个数
    int* stack;                                                  // 建栈将入度为0的顶点入栈
    stack = (int*)malloc(GL->numVertexes * sizeof(int));
    for (i = 0; i < GL->numVertexes; i++)
        if (0 == GL->adjList[i].in)                              // 将入度为0的顶点入栈
            stack[++top] = i;
    top2 = 0;                                                    // 初始化
    etv = (int*)malloc(GL->numVertexes * sizeof(int));           // 事件最早发生时间数组
    for (i = 0; i < GL->numVertexes; i++)
        etv[i] = 0;                                              // 初始化
    stack2 = (int*)malloc(GL->numVertexes * sizeof(int));        // 初始化拓扑序列栈
    while (top != 0)
    {
        gettop = stack[top--];
        count++;                                                 // 输出i号顶点，并计数
        stack2[++top2] = gettop;                                 // 将弹出的顶点序号压入拓扑序列的栈
        for (e = GL->adjList[gettop].firstedge; e; e = e->next)
        {
            k = e->adjvex;
            if (!(--GL->adjList[k].in))
                stack[++top] = k;
            if ((etv[gettop] + e->weight) > etv[k])              // 求各顶点事件的最早发生时间etv值
                etv[k] = etv[gettop] + e->weight;
        }
    }
    if (count < GL->numVertexes)
        return ERROR;
    else
        return OK;
}

int* etv, * ltv;  // 事件最早发生时间和最迟发生时间数组
int* stack2;      // 用于存储拓扑序列的栈
int top2;         // 用于stack2的指针

/* 求关键路径，GL为有向网，输出G的各项关键活动 */
void CriticalPath(GraphAdjList GL)
{
    EdgeNode* e;
    int i, gettop, k, j;
    int ete, lte;                                                // 声明活动最早发生时间和最迟发生时间变量
    TopologicalSort(GL);                                         // 求拓扑序列，计算数组etv和stack2的值
    ltv = (int*)malloc(GL->numVertexes * sizeof(int));           // 事件最晚发生时间数组
    for (i = 0; i < GL->numVertexes; i++)
        ltv[i] = etv[GL->numVertexes - 1];                       // 初始化ltv
    while (top2 != 0)                                            // 计算ltv
    {
        gettop = stack2[top2--];
        for (e = GL->adjList[gettop].firstedge; e; e = e->next)
        {
            k = e->adjvex;
            if (ltv[k] - e->weight < ltv[gettop])                // 求各顶点事件最晚发生时间ltv
                ltv[gettop] = ltv[k] - e->weight;
        }
    }
    for (j = 0; j < GL->numVertexes; j++)                        // 求ete, lte和关键活动
    {
        for (e = GL->adjList[j].firstedge; e; e = e->next)
        {
            k = e->adjvex;
            ete = etv[j];                                        // 活动最早发生时间
            lte = ltv[k] - e->weight;                            // 活动最迟发生时间
            if (ete == lte)                                      // 两者相等即在关键路径上
                printf("<v%d - v%d> length: %d \n", GL->adjList[j].data, GL->adjList[k].data, e->weight);
        }
    }
}
