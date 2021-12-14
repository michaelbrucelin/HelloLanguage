#include <stdio.h>

//示例中使用一个字符数组，记录了3个字符串，并使用一个长度为3的字符指针数组，引用了这3个字符串

const size_t BUFFER_LEN = 512; //全局变量，指定buffer数组的大小，必须使用const设定为常量，否则无法在声明数组时使用

int main(void)
{
    char buffer[BUFFER_LEN]; //储存3个字符串的字符数组
    char *pS[3] = {NULL};    //存储buffer数组中字符串的地址
    char *pbuffer = buffer;  //指定buffer的指针，稍后用来遍历
    size_t index = 0;        //buffer数组中当前未使用的元素的位置

    printf("please enter 3 messages that total less than %u characters.\n", BUFFER_LEN - 2);

    //接收键盘输入的字符串
    for (int i = 0; i < 3; i++)
    {
        printf("please enter %s message\n", i > 0 ? "another" : "a");
        pS[i] = &buffer[index]; //记录字符串的指针

        for (; index < BUFFER_LEN; index++)
        {
            if ((*(pbuffer + index) = getchar()) == '\n')
            {
                *(pbuffer + index++) = '\0'; //不保留\n，补充\0结束字符串，使用\0覆盖掉\n
                break;
            }
        }

        //检查字符串是否溢出字符数组
        if ((index == BUFFER_LEN) && ((*(pbuffer + index - 1) != '\0') || (i < 2)))
        {
            printf("You ran out of space in the buffer\n");
            return 1;
        }
    }

    printf("The strings you entered are:\n\n");
    for (int i = 0; i < 3; i++)
        printf("%s\n", pS[i]);

    printf("The buffer has %d characters unused.\n", BUFFER_LEN - index);

    return 0;
}