/* 图的储存结构 */
typedef char VertexType;  // 顶点类型应由用户定义
typedef int EdgeType;     // 边上的权值类型应由用户定义

#define MAXVEX   100      // 最大顶点数，应由用户定义
#define MAXEDGE  100      // 最大边数，应由用户定义
#define INFINITY 65535    // 用65535来代表∞


/* 邻接矩阵表示法 */
// 邻接矩阵表示法结点结构定义
typedef struct
{
	VertexType vexs[MAXVEX];       // 顶点表
	EdgeType arc[MAXVEX][MAXVEX];  // 邻接矩阵，可看作边表
	int numNodes, numEdges;        // 图中当前的顶点数和边数
} MGraph;


/* 邻接表表示法 */
// 邻接表表示法结点结构定义
typedef struct EdgeNode            // 边表结点
{
	int adjvex;                    // 邻接点域,存储该顶点对应的下标
	EdgeType info;                 // 用于存储权值,对于非网图可以不需要
	struct EdgeNode* next;         // 链域,指向下一个邻接点
} EdgeNode;

typedef struct VertexNode          // 顶点表结点 */
{
	VertexType data;               // 顶点域,存储顶点信息
	EdgeNode* firstedge;           // 边表头指针
} VertexNode, AdjList[MAXVEX];

typedef struct
{
	AdjList adjList;
	int numNodes, numEdges;        // 图中当前顶点数和边数
} GraphAdjList;


/* 对边集数组Edge结构的定义 */
// 某些图论的算法，例如Kruskal（克鲁斯卡尔）算法就需要用此数据结构
typedef struct
{
	int begin;
	int end;
	int weight;
} Edge;
