#define MAXSIZE 20    /* 存储空间初始分配量 */
typedef int ElemType; /* ElemType类型根据实际情况而定，这里为int */
typedef struct
{
    ElemType data[MAXSIZE]; /* 数组，存储数据元素 */
    int length;             /* 线性表当前长度 */
} SqList;

#define OK 1
#define ERROR 0
/* Status是函数的类型,其值是函数结果状态代码，如OK等 */
typedef int Status;

/*将所有的在线性表Lb中但不在La中的数据元素插入到La中*/
void unionL(SqList *La, SqList Lb)
{
    int La_len, Lb_len, i;
    ElemType e;               /*声明与La和Lb相同的数据元素e*/
    La_len = ListLength(*La); /*求线性表的长度 */
    Lb_len = ListLength(Lb);
    for (i = 1; i <= Lb_len; i++)
    {
        GetElem(Lb, i, &e);              /*取Lb中第i个数据元素赋给e*/
        if (!LocateElem(*La, e))         /*La中不存在和e相同数据元素*/
            ListInsert(La, ++La_len, e); /*插入*/
    }
}
