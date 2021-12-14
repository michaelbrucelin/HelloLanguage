#include <stdio.h>

int main(void)
{
    char board[3][3] = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        //{'4', 'X', '6'},
        {'7', '8', '9'}};

    //这里需要使用*board，而不能使用board
    //board的值是board[0]的地址，*board是board[0]的值，即board[0][0]的地址
    //也可以这样使用char *pboard = &board[0][0];
    char *pboard = *board;

    for (int i = 0; i < 9; i++)
        printf("[%d]: %c\t", i, *(pboard + i));
    printf("\n\n");

    return 0;
}