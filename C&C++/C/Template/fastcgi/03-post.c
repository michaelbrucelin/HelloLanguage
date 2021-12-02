#include <stdio.h>
#include <stdlib.h>

// 获取POST方法的传参

int main()
{
    int length;
    char *lenstr, poststr[32];
    int m, n;
    printf("Content-Type: text/html\n\n");
    printf("<title>Mult-Post</title>");
    lenstr = getenv("CONTENT_LENGTH");
    if (NULL == lenstr)
        printf("Error: post args error.");
    else
    {
        length = atoi(lenstr);
        fgets(poststr, length + 1, stdin);
        if (sscanf(poststr, "m=%d&n=%d", &m, &n) != 2)
            printf("Error: Parameters are not right.");
        else
            // printf("%ld", m * n);
            printf("%d * %d = %d", m, n, m * n);
    }

    return 0;
}

/*
# gcc 03-post.c -o post.cgi

# curl -d 'm=2&n=3' http://127.0.0.1:80/cgi-bin/post.cgi
<title>Mult-Post</title>2 * 3 = 6
*/
