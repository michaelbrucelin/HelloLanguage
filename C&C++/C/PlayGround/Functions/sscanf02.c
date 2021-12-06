#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char dtm[100];

    int m, n;
    strcpy(dtm, "m=10&n=1024");
    printf("%s\n", dtm);
    sscanf(dtm, "m=%d&n=%d", &m, &n);
    printf("%d * %d = %d\n\n", m, n, m * n);

    int expire;
    char key[16];
    strcpy(dtm, "key=hello&expire=1024");
    printf("%s\n", dtm);
    sscanf(dtm, "key=%[^&]&expire=%d", key, &expire); // 如果使用"key=%s&expire=%d"，那个前面的%s就把整个字符串读取进去了
    printf("key: %s, expire: %d\n\n", key, expire);

    int expire2;
    char key2[16];
    strcpy(dtm, "key=hello&expire=1024");
    printf("%s\n", dtm);
    sscanf(dtm, "key=%s&expire=%d", key2, &expire2); // 这样key2就把整个字符串读取进去了，expire2的值就为0
    printf("key2: %s, expire2: %d\n\n", key2, expire2);

    // int expire3;
    // char *key3;
    // strcpy(dtm, "key=hello&expire=1234");
    // printf("%s\n", dtm);
    // sscanf(dtm, "key=%[^&]&expire=%d", key3, &expire3); //
    // printf("key3: %s, expire3: %d\n\n", key3, expire3);

    int expire4;
    char key4[16];
    strcpy(dtm, "expire=1024&key=hello");
    printf("%s\n", dtm);
    sscanf(dtm, "expire=%d&key=%s", &expire4, key4);
    printf("key4: %s, expire4: %d\n", key4, expire4);

    return (0);
}
