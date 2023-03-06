/* 图的拓扑排序 */
#include "my_macro.h"
#include "01图的存储结构.c"

/* 拓扑排序，若GL无回路，则输出拓扑排序序列并返回1，若有回路返回0。 */
Status TopologicalSort(GraphAdjList GL)
{
	EdgeNode* e;
	int i, k, gettop;
	int top = 0;                                                 // 用于栈指针下标
	int count = 0;                                               // 用于统计输出顶点的个数
	int* stack;                                                  // 建栈将入度为0的顶点入栈
	stack = (int*)malloc(GL->numVertexes * sizeof(int));
	for (i = 0; i < GL->numVertexes; i++)
		if (0 == GL->adjList[i].in)                              // 将入度为0的顶点入栈
			stack[++top] = i;
	while (top != 0)
	{
		gettop = stack[top--];                                   // 出栈
		printf("%d -> ", GL->adjList[gettop].data);              // 打印此顶点
		count++;                                                 // 统计输出顶点数
		for (e = GL->adjList[gettop].firstedge; e; e = e->next)  // 对此顶点弧表遍历
		{
			k = e->adjvex;
			if (!(--GL->adjList[k].in))                          // 将k号顶点邻接点的入度减1
				stack[++top] = k;                                // 若为0则入栈，以便下次循环输出
		}
	}
	if (count < GL->numVertexes)                                 // count小于顶点数，说明存在环
		return ERROR;
	else
		return OK;
}
