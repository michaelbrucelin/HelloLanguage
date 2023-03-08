/* ͼ�����·�� */
#include "01ͼ�Ĵ洢�ṹ.c"


/* Dijkstra�㷨����������G��v0���㵽���ඥ��v�����·��P[v]����Ȩ����D[v] */
/* P[v]��ֵΪǰ�������±�,D[v]��ʾv0��v�����·�����Ⱥ� */
typedef int Patharc_Dijkstra[MAXVEX];                        // ���ڴ洢���·���±������
typedef int ShortPathTable_Dijkstra[MAXVEX];                 // ���ڴ洢���������·����Ȩֵ��

void ShortestPath_Dijkstra(MGraph G, int v0, Patharc_Dijkstra* P, ShortPathTable_Dijkstra* D)
{
    int v, w, k, min;
    int final[MAXVEX];                                       // final[w]=1��ʾ��ö���v0��vw�����·��
    for (v = 0; v < G.numVertexes; v++)                      // ��ʼ������
    {
        final[v] = 0;                                        // ȫ�������ʼ��Ϊδ֪���·��״̬
        (*D)[v] = G.arc[v0][v];                              // ����v0�������ߵĶ������Ȩֵ
        (*P)[v] = -1;                                        // ��ʼ��·������PΪ-1
    }

    (*D)[v0] = 0;                                            // v0��v0·��Ϊ0
    final[v0] = 1;                                           // v0��v0����Ҫ��·��
    // ��ʼ��ѭ����ÿ�����v0��ĳ��v��������·��
    for (v = 1; v < G.numVertexes; v++)
    {
        min = INFINITY;                                      // ��ǰ��֪��v0������������
        for (w = 0; w < G.numVertexes; w++)                  // Ѱ����v0����Ķ���
        {
            if (!final[w] && (*D)[w] < min)
            {
                k = w;
                min = (*D)[w];                               // w������v0�������
            }
        }
        final[k] = 1;                                        // ��Ŀǰ�ҵ�������Ķ�����Ϊ1
        for (w = 0; w < G.numVertexes; w++)                  // ������ǰ���·��������
        {
            // �������v�����·������������·���ĳ��ȶ̵Ļ�
            if (!final[w] && (min + G.arc[k][w] < (*D)[w]))
            {                                                // ˵���ҵ��˸��̵�·�����޸�D[w]��P[w]
                (*D)[w] = min + G.arc[k][w];                 // �޸ĵ�ǰ·������
                (*P)[w] = k;
            }
        }
    }
}


/* Floyd�㷨������ͼG�и�����v�����ඥ��w�����·��P[v][w]����Ȩ����D[v][w]�� */
typedef int Patharc_Floyd[MAXVEX][MAXVEX];
typedef int ShortPathTable_Floyd[MAXVEX][MAXVEX];

void ShortestPath_Floyd(MGraph G, Patharc_Floyd* P, ShortPathTable_Floyd* D)
{
    int v, w, k;
    for (v = 0; v < G.numVertexes; ++v)                      // ��ʼ��D��P
    {
        for (w = 0; w < G.numVertexes; ++w)
        {
            (*D)[v][w] = G.arc[v][w];                        // D[v][w]ֵ��Ϊ��Ӧ����Ȩֵ
            (*P)[v][w] = w;                                  // ��ʼ��P
        }
    }
    for (k = 0; k < G.numVertexes; ++k)
    {
        for (v = 0; v < G.numVertexes; ++v)
        {
            for (w = 0; w < G.numVertexes; ++w)
            {
                if ((*D)[v][w] > (*D)[v][k] + (*D)[k][w])
                {                                            // ��������±�Ϊk����·����ԭ�����·������
                    (*D)[v][w] = (*D)[v][k] + (*D)[k][w];    // ����ǰ�����Ȩֵ���Сһ��
                    (*P)[v][w] = (*P)[v][k];                 // ·������Ϊ�����±�Ϊk�Ķ���
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
    ShortPathTable_Floyd D;                                  // ��ĳ�㵽�����������·��

    printf("����������·������:\n");
    for (v = 0; v < G.numVertexes; ++v)
    {
        for (w = v + 1; w < G.numVertexes; w++)
        {
            printf("v%d-v%d weight: %d ", v, w, D[v][w]);
            k = P[v][w];                                     // ��õ�һ��·�������±�
            printf(" path: %d", v);                          // ��ӡԴ��
            while (k != w)                                   // ���·�������±겻���յ�
            {
                printf(" -> %d", k);                         // ��ӡ·������
                k = P[k][w];                                 // �����һ��·�������±�
            }
            printf(" -> %d\n", w);                           // ��ӡ�յ�
        }
        printf("\n");
    }
}
