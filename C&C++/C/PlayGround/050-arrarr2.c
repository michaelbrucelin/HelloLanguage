#include <stdio.h>

//不同的方式获取二维数组“全部展开后”的第一个元素的值
//可以参考：PlayGround/033-erweiarr01.c

int main(void)
{
    char board[3][3] = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'}};

    printf("value of board[0][0] : %c\n", board[0][0]); //二维数组中第一个元素（数组）的第一个元素的值
    printf("value of *board[0]   : %c\n", *board[0]);   //二维数组的第一个元素的值就是第一个数组的地址，即该数组的第一个元素的地址，然后取值
    printf("value of **board     : %c\n", **board);     //二维数组的值是其第一个元素（数组）的地址，取值就是board[0]，再取值就和上面的一样了

    return 0;
}
