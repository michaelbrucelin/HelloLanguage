/* ͼ����С������ */
#include "01ͼ�Ĵ洢�ṹ.c"


/* Prim�㷨������С������ */
void MiniSpanTree_Prim(MGraph G)
{
    int min, i, j, k;
    int adjvex[MAXVEX];                                       // ������ض����ߵ�Ȩֵ���±�
    int lowcost[MAXVEX];                                      // ������ض����ߵ�Ȩֵ
    lowcost[0] = 0;                                           // ��ʼ����һ��ȨֵΪ0����v0����������
    adjvex[0] = 0;                                            // ��ʼ����һ�������±�Ϊ0
    for (i = 1; i < G.numVertexes; i++)                       // ѭ�����±�Ϊ0���ȫ������
    {
        lowcost[i] = G.arc[0][i];                             // ��v0������֮�бߵ�Ȩֵ��������
        adjvex[i] = 0;                                        // ��ʼ����Ϊv0���±�
    }
    for (i = 1; i < G.numVertexes; i++)
    {
        min = INFINITY;                                       // ��ʼ����СȨֵΪ�ޣ������ǽϴ�������65535��
        j = 1;
        k = 0;
        while (j < G.numVertexes)                             // ѭ��ȫ������
        {
            if (lowcost[j] != 0 && lowcost[j] < min)
            {                                                 // ���Ȩֵ��Ϊ0��ȨֵС��min
                min = lowcost[j];                             // ���õ�ǰȨֵ��Ϊ��Сֵ
                k = j;                                        // ����ǰ��Сֵ���±����k
            }
            j++;
        }
        printf("(%d, %d)\n", adjvex[k], k);                   // ��ӡ��ǰ�������Ȩֵ��С�ı�
        lowcost[k] = 0;                                       // ����ǰ����Ȩֵ����Ϊ0,�˶������������
        for (j = 1; j < G.numVertexes; j++)                      // ѭ�����ж���
        {                                                     // ����±�Ϊk�������ȨֵС�ڴ�ǰ��Щ����δ������������Ȩֵ
            if (lowcost[j] != 0 && G.arc[k][j] < lowcost[j])
            {
                lowcost[j] = G.arc[k][j];                     // ����С��Ȩֵ����lowcost��Ӧλ��
                adjvex[j] = k;                                // ���±�Ϊk�Ķ������adjvex
            }
        }
    }
}


/* Kruskal�㷨������С������ */
void MiniSpanTree_Kruskal(MGraph G)
{
    int i, n, m;
    Edge edges[MAXEDGE];                                      // ����߼�����,edge�ĽṹΪbegin,end,weight,��Ϊ����
    int parent[MAXVEX];                                       // ����һ���������жϱ�����Ƿ��γɻ�·

    /* �˴�ʡ�Խ��ڽӾ���Gת��Ϊ�߼�����edges����Ȩ��С��������Ĵ���*/

    for (i = 0; i < G.numVertexes; i++)
        parent[i] = 0;                                        // ��ʼ������ֵΪ0
    for (i = 0; i < G.numEdges; i++)                          // ѭ��ÿһ����
    {
        n = Find(parent, edges[i].begin);
        m = Find(parent, edges[i].end);
        if (n != m)                                           // ����n��m���ȣ�˵���˱�û�������е��������γɻ�·
        {                                                     // ���˱ߵĽ�β��������±�Ϊ����parent�С���ʾ�˶����Ѿ���������������
            parent[n] = m;
            printf("(%d, %d) %d\n", edges[i].begin, edges[i].end, edges[i].weight);
        }
    }
}

/* �������߶����β���±� */
int Find(int* parent, int f)
{
    while (parent[f] > 0)
    {
        f = parent[f];
    }
    return f;
}
