/* ͼ�ı��� */
#include <stdbool.h>
#include "01ͼ�Ĵ洢�ṹ.c"
#include "my_macro.h"

bool visited[MAXVEX];                         // ���ʱ�־������

/* ������ȱ��� */
// �ڽӾ������ȱ�������
void DFSTraverse(MGraph G)
{
    int i;
    for (i = 0; i < G.numVertexes; i++)
        visited[i] = FALSE;                   // ��ʼ���ж���״̬����δ���ʹ�״̬
    for (i = 0; i < G.numVertexes; i++)
        if (!visited[i])                      // ��δ���ʹ��Ķ������DFS������ͨͼ��ִ��һ��
            DFS1(G, i);
}

// �ڽӾ����������ȵݹ��㷨
void DFS1(MGraph G, int i)
{
    int j;
    visited[i] = TRUE;
    printf("%c ", G.vexs[i]);                 // ��ӡ���㣬Ҳ������������
    for (j = 0; j < G.numVertexes; j++)
        if (G.arc[i][j] == 1 && !visited[j])
            DFS1(G, j);                       // ��Ϊ���ʵ��ڽӶ���ݹ����
}


/* �ڽӱ����ȱ������� */
void DFSTraverse(GraphAdjList GL)
{
    int i;
    for (i = 0; i < GL.numVertexes; i++)
        visited[i] = FALSE;                   // ��ʼ���ж���״̬����δ���ʹ�״̬
    for (i = 0; i < GL.numVertexes; i++)
        if (!visited[i])                      // ��δ���ʹ��Ķ������DFS,������ͨͼ,ֻ��ִ��һ��
            DFS2(GL, i);
}

/* �ڽӱ��������ȵݹ��㷨 */
void DFS2(GraphAdjList GL, int i)
{
    EdgeNode* p;
    visited[i] = TRUE;
    printf("%c ", GL.adjList[i].data);        // ��ӡ����,Ҳ������������
    p = GL.adjList[i].firstedge;
    while (p)
    {
        if (!visited[p->adjvex])
            DFS2(GL, p->adjvex);              // ��Ϊ���ʵ��ڽӶ���ݹ����
        p = p->next;
    }
}


/* ������ȱ��� */
/* �ڽӾ���Ĺ�ȱ����㷨 */
void BFSTraverse(MGraph G)
{
    int i, j;
    Queue Q;
    for (i = 0; i < G.numVertexes; i++)
        visited[i] = FALSE;
    InitQueue(&Q);                                                  // ��ʼ��һ�����õĶ���
    for (i = 0; i < G.numVertexes; i++)                             // ��ÿһ��������ѭ��
    {
        if (!visited[i])                                            // ����δ���ʹ��ʹ���
        {
            visited[i] = TRUE;                                      // ���õ�ǰ������ʹ�
            printf("%c ", G.vexs[i]);                               // ��ӡ���㣬Ҳ������������
            EnQueue(&Q, i);                                         // ���˶��������
            while (!QueueEmpty(Q))                                  // ����ǰ���в�Ϊ��
            {
                DeQueue(&Q, &i);                                    // ������Ԫ�س����У���ֵ��i
                for (j = 0; j < G.numVertexes; j++)
                {
                    // �ж������������뵱ǰ������ڱ���δ���ʹ�
                    if (G.arc[i][j] == 1 && !visited[j])
                    {
                        visited[j] = TRUE;                          // ���ҵ��Ĵ˶�����Ϊ�ѷ���
                        printf("%c ", G.vexs[j]);                   // ��ӡ����
                        EnQueue(&Q, j);                             // ���ҵ��Ĵ˶��������
                    }
                }
            }
        }
    }
}

/* �ڽӱ�Ĺ�ȱ����㷨 */
void BFSTraverse(GraphAdjList GL)
{
    int i;
    EdgeNode* p;
    Queue Q;
    for (i = 0; i < GL.numVertexes; i++)
        visited[i] = FALSE;
    InitQueue(&Q);
    for (i = 0; i < GL.numVertexes; i++)
    {
        if (!visited[i])
        {
            visited[i] = TRUE;
            printf("%c ", GL.adjList[i].data);                      // ��ӡ����,Ҳ������������
            EnQueue(&Q, i);
            while (!QueueEmpty(Q))
            {
                DeQueue(&Q, &i);
                p = GL.adjList[i].firstedge;                        // �ҵ���ǰ����ı߱�����ͷָ��
                while (p)
                {
                    if (!visited[p->adjvex])                        // ���˶���δ������
                    {
                        visited[p->adjvex] = TRUE;
                        printf("%c ", GL.adjList[p->adjvex].data);
                        EnQueue(&Q, p->adjvex);                     // ���˶��������
                    }
                    p = p->next;                                    // ָ��ָ����һ���ڽӵ�
                }
            }
        }
    }
}


/* ������ȱ����õ��Ķ��нṹ�뺯�� */
/* ѭ�����е�˳��洢�ṹ */
#define MAXSIZE 100

typedef struct
{
    int data[MAXSIZE];
    int front;                                // ͷָ��
    int rear;                                 // βָ�룬�����в��գ�ָ�����βԪ�ص���һ��λ��
} Queue;

/* ��ʼ��һ���ն���Q */
Status InitQueue(Queue* Q)
{
    Q->front = 0;
    Q->rear = 0;
    return OK;
}

/* ������QΪ�ն���,�򷵻�TRUE,���򷵻�FALSE */
Status QueueEmpty(Queue Q)
{
    if (Q.front == Q.rear)                    // ���пյı�־
        return TRUE;
    else
        return FALSE;
}

/* ������δ���������Ԫ��eΪQ�µĶ�βԪ�� */
Status EnQueue(Queue* Q, int e)
{
    if ((Q->rear + 1) % MAXSIZE == Q->front)  // ���������ж�
        return ERROR;
    Q->data[Q->rear] = e;                     // ��Ԫ��e��ֵ����β
    Q->rear = (Q->rear + 1) % MAXSIZE;        // rearָ�������һλ�ã����������ת������ͷ��
    return OK;
}

/* �����в��գ���ɾ��Q�ж�ͷԪ�أ���e������ֵ */
Status DeQueue(Queue* Q, int* e)
{
    if (Q->front == Q->rear)                  // ���пյ��ж�
        return ERROR;
    *e = Q->data[Q->front];                   // ����ͷԪ�ظ�ֵ��e
    Q->front = (Q->front + 1) % MAXSIZE;      // frontָ�������һλ�ã����������ת������ͷ��
    return OK;
}
