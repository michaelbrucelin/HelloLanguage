/* ͼ�Ľ��� */
#include <stddef.h>
#include "01ͼ�Ĵ洢�ṹ.c"


/* �ڽӾ��󴴽�����ͼ */
void CreateMGraph(MGraph* G)
{
    int i, j, k, w;
    printf("���붥�����ͱ���:\n");
    scanf("%d,%d", &G->numVertexes, &G->numEdges);        // ���붥�����ͱ���
    for (i = 0; i < G->numVertexes; i++)                  // ���붥����Ϣ,���������
        scanf(&G->vexs[i]);
    for (i = 0; i < G->numVertexes; i++)
        for (j = 0; j < G->numVertexes; j++)
            G->arc[i][j] = INFINITY;                      // �ڽӾ����ʼ��
    for (k = 0; k < G->numEdges; k++)                     // ����numEdges���ߣ������ڽӾ���
    {
        printf("�����(vi,vj)�ϵ��±�i���±�j��Ȩw:\n");
        scanf("%d,%d,%d", &i, &j, &w);                    // �����(vi,vj)�ϵ�Ȩw
        G->arc[i][j] = w;
        G->arc[j][i] = G->arc[i][j];                      // ��Ϊ������ͼ������Գ�
    }
}


/* �ڽӱ�������ͼ */
void CreateALGraph(GraphAdjList* G)
{
    int i, j, k;
    EdgeNode* e;
    printf("���붥�����ͱ���:\n");
    scanf("%d,%d", &G->numVertexes, &G->numEdges);        // ���붥�����ͱ���
    for (i = 0; i < G->numVertexes; i++)                  // ���붥����Ϣ,���������
    {
        scanf(&G->adjList[i].data);                       // ���붥����Ϣ
        G->adjList[i].firstedge = NULL;                   // ���߱���Ϊ�ձ�
    }

    for (k = 0; k < G->numEdges; k++)                     // �����߱�
    {
        printf("�����(vi,vj)�ϵĶ������:\n");
        scanf("%d,%d", &i, &j);                           // �����(vi,vj)�ϵĶ������
        e = (EdgeNode*)malloc(sizeof(EdgeNode));          // ���ڴ�����ռ�,���ɱ߱���
        e->adjvex = j;                                    // �ڽ����Ϊj
        e->next = G->adjList[i].firstedge;                // ��e��ָ��ָ��ǰ������ָ��Ľ��
        G->adjList[i].firstedge = e;                      // ����ǰ�����ָ��ָ��e
        e = (EdgeNode*)malloc(sizeof(EdgeNode));          // ���ڴ�����ռ�,���ɱ߱���
        e->adjvex = i;                                    // �ڽ����Ϊi
        e->next = G->adjList[j].firstedge;                // ��e��ָ��ָ��ǰ������ָ��Ľ��
        G->adjList[j].firstedge = e;                      // ����ǰ�����ָ��ָ��e
    }
}
