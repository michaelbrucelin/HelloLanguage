//#include "hiredis.h"
//#include <hiredis.h>
#include <hiredis/hiredis.h>

int main(void)
{
    redisContext *c = redisConnect("localhost", 6379);

    if (c != NULL && c->err)
    {
        printf("Error: %s\n", c->errstr);
        // handle error
    }
    else
    {
        printf("Connected to Redis\n");
    }

    redisReply *reply;
    reply = redisCommand(c, "AUTH password");
    freeReplyObject(reply);

    // do what you want to do.

    redisFree(c);

    return (0);
}

/*
apt-get install libhiredis-dev  # Debian 10
yum install hiredis-devel       # CentOS 7

https://docs.redis.com/6.0/rs/references/client_references/client_c/
// gcc 01-connect.c -I./deps/hiredis/ -L./deps/hiredis/ -lhiredis
gcc 01-connect.c -o test -lhiredis
*/
