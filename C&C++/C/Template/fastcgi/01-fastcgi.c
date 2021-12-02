#include <stdio.h>

// 这个cgi直接输出静态结果，最简单的模型

int main(void)
{
    printf("Content-type: text/html\r\n"
           "\r\n"
           "<h1>hello, world!</h1>");

    return 0;
}

/*
gcc 01-fastcgi.c -o fastcgi.cgi

# curl http://127.0.0.1:80/cgi-bin/fastcgi.cgi
<h1>hello, world!</h1>
*/
