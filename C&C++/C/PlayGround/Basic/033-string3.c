#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>

#define BUFFER_LEN 100 //每个字符串的最大长度为99，\0会占用1个长度
#define NUM_P 100      //最多读取100个字符串

int main(void)
{
    char buffer[BUFFER_LEN];  //输入缓冲区，作为buffer从键盘读取字符串的字符数组
    char *pS[NUM_P] = {NULL}; //存储所有字符串的地址
    char *pTemp = NULL;       //临时指针
    int i = 0;                //循环计数器
    bool sorted = false;      //排序标识
    int last_string = 0;      //最后一个字符串的索引

    printf("\nEnter successive lines, pressing Enter at the end of each line.\nJust press Enter to end.\n\n");
    while ((*fgets(buffer, BUFFER_LEN, stdin) != '\n') && (i < NUM_P))
    {
        pS[i] = (char *)malloc(strlen(buffer) + 1);
        if (pS[i] == NULL) //动态申请内存失败
        {
            printf("Memory allocation failed. Program terminated.\n");
            return 1;
        }
        strcpy(pS[i++], buffer);
    }
    last_string = i; //最后一个字符串的索引

    //升序排序获取到的字符串，山寨版冒泡排序，每次都从头到尾检查相邻的两项，只要有顺序不对的，就再来一遍，比冒泡时间复杂度更高
    while (!sorted)
    {
        sorted = true;
        for (i = 0; i < last_string - 1; i++)
        {
            if (strcmp(pS[i], pS[i + 1]) > 0)
            {
                sorted = false; //表示此次有顺序不对的项，需要再进行一次从头到尾的排查
                pTemp = pS[i];
                pS[i] = pS[i + 1];
                pS[i + 1] = pTemp;
            }
        }
    }

    //打印输出
    printf("Your input sorted in order is:\n\n");
    for (i = 0; i < last_string; i++)
    {
        printf("%s\n", pS[i]);
        free(pS[i]);
        pS[i] = NULL;
    }

    return 0;
}