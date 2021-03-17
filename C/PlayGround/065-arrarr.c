#include <stdio.h>

//尽管下面输出的3个值是一样的，但是其含义是不一样的

int main(void)
{
    char board[3][3] = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'}};

    printf("address of board        : %p\n", board);        //二维数组的地址，board[0]的地址
    printf("address of board[0][0]  : %p\n", &board[0][0]); //二维数组中第1个元素（数组）中的第1个元素的地址
    printf("but what is in board[0] : %p\n", board[0]);     //二维数组中第1个元素（数组）的值，由于其是一个一维数组，所以就是其地址

    return 0;
}