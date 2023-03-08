/* ͼ�Ĺؼ�·�� */
#include "my_macro.h"
#include "01ͼ�Ĵ洢�ṹ.c"

int* etv, * ltv;  // �¼����緢��ʱ�����ٷ���ʱ������
int* stack2;      // ���ڴ洢�������е�ջ
int top2;         // ����stack2��ָ��

/* �������� */
Status TopologicalSort(GraphAdjList GL)
{   /* ��GL�޻�·������������������в�����1�����л�·����0�� */
    EdgeNode* e;
    int i, k, gettop;
    int top = 0;                                                 // ����ջָ���±�
    int count = 0;                                               // ����ͳ���������ĸ���
    int* stack;                                                  // ��ջ�����Ϊ0�Ķ�����ջ
    stack = (int*)malloc(GL->numVertexes * sizeof(int));
    for (i = 0; i < GL->numVertexes; i++)
        if (0 == GL->adjList[i].in)                              // �����Ϊ0�Ķ�����ջ
            stack[++top] = i;
    top2 = 0;                                                    // ��ʼ��
    etv = (int*)malloc(GL->numVertexes * sizeof(int));           // �¼����緢��ʱ������
    for (i = 0; i < GL->numVertexes; i++)
        etv[i] = 0;                                              // ��ʼ��
    stack2 = (int*)malloc(GL->numVertexes * sizeof(int));        // ��ʼ����������ջ
    while (top != 0)
    {
        gettop = stack[top--];
        count++;                                                 // ���i�Ŷ��㣬������
        stack2[++top2] = gettop;                                 // �������Ķ������ѹ���������е�ջ
        for (e = GL->adjList[gettop].firstedge; e; e = e->next)
        {
            k = e->adjvex;
            if (!(--GL->adjList[k].in))
                stack[++top] = k;
            if ((etv[gettop] + e->weight) > etv[k])              // ��������¼������緢��ʱ��etvֵ
                etv[k] = etv[gettop] + e->weight;
        }
    }
    if (count < GL->numVertexes)
        return ERROR;
    else
        return OK;
}

int* etv, * ltv;  // �¼����緢��ʱ�����ٷ���ʱ������
int* stack2;      // ���ڴ洢�������е�ջ
int top2;         // ����stack2��ָ��

/* ��ؼ�·����GLΪ�����������G�ĸ���ؼ�� */
void CriticalPath(GraphAdjList GL)
{
    EdgeNode* e;
    int i, gettop, k, j;
    int ete, lte;                                                // ��������緢��ʱ�����ٷ���ʱ�����
    TopologicalSort(GL);                                         // ���������У���������etv��stack2��ֵ
    ltv = (int*)malloc(GL->numVertexes * sizeof(int));           // �¼�������ʱ������
    for (i = 0; i < GL->numVertexes; i++)
        ltv[i] = etv[GL->numVertexes - 1];                       // ��ʼ��ltv
    while (top2 != 0)                                            // ����ltv
    {
        gettop = stack2[top2--];
        for (e = GL->adjList[gettop].firstedge; e; e = e->next)
        {
            k = e->adjvex;
            if (ltv[k] - e->weight < ltv[gettop])                // ��������¼�������ʱ��ltv
                ltv[gettop] = ltv[k] - e->weight;
        }
    }
    for (j = 0; j < GL->numVertexes; j++)                        // ��ete, lte�͹ؼ��
    {
        for (e = GL->adjList[j].firstedge; e; e = e->next)
        {
            k = e->adjvex;
            ete = etv[j];                                        // ����緢��ʱ��
            lte = ltv[k] - e->weight;                            // ���ٷ���ʱ��
            if (ete == lte)                                      // ������ȼ��ڹؼ�·����
                printf("<v%d - v%d> length: %d \n", GL->adjList[j].data, GL->adjList[k].data, e->weight);
        }
    }
}
