/*
使用数组模拟实现顺序存储结构的线性表
*/

#define MAXSIZE 20    //存储空间初始分配量
typedef int ElemType; //ElemType类型根据实际情况而定，这里假设为int
typedef struct
{
    ElemType data[MAXSIZE]; //数组存储数据元素，最大值为MAXSIZE
    int length;             //线性表当前长度
} SqList;
