#include "fcgi_stdio.h"
#include <stdlib.h>

// 网上看到的，while (FCGI_Accept() >= 0) {}的功能是？

int main(void)
{
    int count = 0;

    while (FCGI_Accept() >= 0)
    {
        printf("Content-type: text/html\r\n"
               "\r\n"
               "<title>FastCGI Hello!</title>"
               "<h1>FastCGI Hello!</h1>"
               "Request number %d running on host <i>%s</i>\n",
               ++count, getenv("SERVER_NAME"));
    }

    return 0;
}

/*
3 apt-get install libfcgi-dev  # Debian10
# yum install fcgi-devel       # CentOS7

# gcc 01-fastcgi2.c -o fastcgi2.cgi -lfcgi

# curl http://127.0.0.1:80/cgi-bin/fastcgi2.cgi
<title>FastCGI Hello!</title><h1>FastCGI Hello!</h1>Request number 1 running on host <i>_</i>
*/
