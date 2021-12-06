#include <hiredis/hiredis.h>
#include <unistd.h> // function sleep

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
    // reply = redisCommand(c, "AUTH password");
    // if(reply) freeReplyObject(reply);
    // 如果不每次都是释放redisCommand对象，可以吗？
    // https://github.com/redis/hiredis/issues/710，这里说，每次执行redisCommand都需要执行freeReplyObject

    reply = redisCommand(c, "SELECT 1");
    if (reply)
        freeReplyObject(reply);

    reply = redisCommand(c, "SET %s %s", "foo", "bar");
    if (reply)
        freeReplyObject(reply);

    reply = redisCommand(c, "GET %s", "foo");
    printf("foo: %s\n", reply->str);
    if (reply)
        freeReplyObject(reply);

    reply = redisCommand(c, "EXPIRE %s %d", "foo", 60);
    if (reply)
        freeReplyObject(reply);
    sleep(3);
    reply = redisCommand(c, "TTL %s", "foo");
    printf("foo ttl: %d\n", reply->integer);
    if (reply)
        freeReplyObject(reply);

    redisFree(c);

    return (0);
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
