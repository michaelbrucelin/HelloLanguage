/* ͼ���������� */
#include "my_macro.h"
#include "01ͼ�Ĵ洢�ṹ.c"

/* ����������GL�޻�·������������������в�����1�����л�·����0�� */
Status TopologicalSort(GraphAdjList GL)
{
	EdgeNode* e;
	int i, k, gettop;
	int top = 0;                                                 // ����ջָ���±�
	int count = 0;                                               // ����ͳ���������ĸ���
	int* stack;                                                  // ��ջ�����Ϊ0�Ķ�����ջ
	stack = (int*)malloc(GL->numVertexes * sizeof(int));
	for (i = 0; i < GL->numVertexes; i++)
		if (0 == GL->adjList[i].in)                              // �����Ϊ0�Ķ�����ջ
			stack[++top] = i;
	while (top != 0)
	{
		gettop = stack[top--];                                   // ��ջ
		printf("%d -> ", GL->adjList[gettop].data);              // ��ӡ�˶���
		count++;                                                 // ͳ�����������
		for (e = GL->adjList[gettop].firstedge; e; e = e->next)  // �Դ˶��㻡�����
		{
			k = e->adjvex;
			if (!(--GL->adjList[k].in))                          // ��k�Ŷ����ڽӵ����ȼ�1
				stack[++top] = k;                                // ��Ϊ0����ջ���Ա��´�ѭ�����
		}
	}
	if (count < GL->numVertexes)                                 // countС�ڶ�������˵�����ڻ�
		return ERROR;
	else
		return OK;
}
