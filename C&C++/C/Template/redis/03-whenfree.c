#include <stdio.h>
#include <hiredis/hiredis.h>

int main(int argc, const char **argv)
{
    redisContext *c = redisConnect("127.0.0.1", 6379);
    redisReply *r;

    for (int i = 0; i < 100; i++)
    {
        redisReply *r = (redisReply *)redisCommand(c, "PING %d", i);
        if (r)
            freeReplyObject(r); // You need to call freeReplyObject each time you execute redisCommand
    }

    // freeReplyObject(r);  // 如果在这里释放，会造成内存泄漏，没有测试，只是github上有人这样说

    redisFree(c);
}

/*
https://docs.redis.com/6.0/rs/references/client_references/client_c/

https://github.com/redis/hiredis/issues/710
This program will leak memory:

int main(int argc, const char **argv) {
    redisContext *c = redisConnect("127.0.0.1", 6379);
    redisReply *r;

    for (int i = 0; i < 100; i++)
        redisReply *r = (redisReply*)redisCommand(c, "PING %d", i);

    freeReplyObject(r);
    redisFree(c);
}
You need to call freeReplyObject each time you execute redisCommand, so in this program you would do something like:

#include <stdio.h>
#include <hiredis/hiredis.h>

int main(int argc, const char **argv) {
    redisContext *c = redisConnect("127.0.0.1", 6379);
    redisReply *r;

    for (int i = 0; i < 100; i++) {
        redisReply *r = (redisReply*)redisCommand(c, "PING %d", i);
        if (r) freeReplyObject(r);
    }

    redisFree(c);
}
*/
