#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//示例中使用一个字符数组作为buffer（中转），从键盘读取了n(n<=100)个字符串，并使用一个长度为n的字符指针数组，引用了这n个字符串
//这里约定当输入一个空行的时候，输入完毕

const size_t BUFFER_LEN = 256; //每个字符串的最大长度
const size_t NUM_P = 100;      //字符串的最大数量

int main(void)
{
    char buffer[BUFFER_LEN]; //输入缓冲区，作为buffer从键盘读取字符串的字符数组
    char *pS[NUM_P];         // = {NULL}; //存储所有字符串的地址，赋初值后编译不过去
    char *pbuffer = buffer;  //指定buffer的指针，稍后用来遍历
    int i = 0;               //字符串的数量

    printf("You can enter up to %u messages each up to %u characters.\n", NUM_P, BUFFER_LEN - 1);

    for (i = 0; i < NUM_P; i++)
    {
        pbuffer = buffer;
        printf("Enter %s message, or press Enter to end\n", i > 0 ? "another" : "a");

        //读取字符串，\n是字符串输入结束的标志（下面会覆盖为\0）
        while ((pbuffer - buffer < BUFFER_LEN - 1) && ((*pbuffer++ = getchar()) != '\n'))
            ;

        //空行，输入结束
        if ((pbuffer - buffer) < 2) //长度小于2，表示这样只有一个\n，即空行
            break;

        //字符串超长了
        if ((pbuffer - buffer) == BUFFER_LEN && *(pbuffer - 1) != '\n')
        {
            printf("String too long - maximum %d characters allowed.\n", BUFFER_LEN);
            i--;
            continue;
        }
        *(pbuffer - 1) = '\0'; //使用\0覆盖掉\n

        pS[i] = (char *)malloc(pbuffer - buffer); //动态申请内存，存放这次buffer中读取到的值
        if (pS[i] == NULL)                        //如果内存申请失败
        {
            printf("Out of memory - ending program.\n");
            return 1;
        }

        //复制字符串
        strcpy(pS[i], buffer);
    }

    //打印输出
    printf("In reverse order, the strings you entered are:\n");
    while (--i >= 0)
    {
        printf("%s\n", pS[i]); //从后向前输出
        free(pS[i]);           //输出完后，立即释放内存
        pS[i] = NULL;          //清空指针，更安全，最佳实践
    }

    return 0;
}