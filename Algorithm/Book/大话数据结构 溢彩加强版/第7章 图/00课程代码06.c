/* 邻接表的广度遍历算法 */
void BFSTraverse(GraphAdjList GL)
{
    int i;
    EdgeNode *p;
    Queue Q;
    for (i = 0; i < GL->numVertexes; i++)
        visited[i] = FALSE;
    InitQueue(&Q);
    for (i = 0; i < GL->numVertexes; i++)
    {
        if (!visited[i])
        {
            visited[i] = TRUE;
            printf("%c ", GL->adjList[i].data); /* 打印顶点,也可以其它操作 */
            EnQueue(&Q, i);
            while (!QueueEmpty(Q))
            {
                DeQueue(&Q, &i);
                p = GL->adjList[i].firstedge; /* 找到当前顶点的边表链表头指针 */
                while (p)
                {
                    if (!visited[p->adjvex]) /* 若此顶点未被访问 */
                    {
                        visited[p->adjvex] = TRUE;
                        printf("%c ", GL->adjList[p->adjvex].data);
                        EnQueue(&Q, p->adjvex); /* 将此顶点入队列 */
                    }
                    p = p->next; /* 指针指向下一个邻接点 */
                }
            }
        }
    }
}
