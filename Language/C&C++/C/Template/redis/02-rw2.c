#include <hiredis/hiredis.h>
#include <unistd.h> // function sleep

int main(void)
{
    redisContext *c = redisConnect("localhost", 6379);

    if (c == NULL)
    {
        printf("Error: Connect Redis failed.");
        return (1);
    }
    else if (c->err)
    {
        printf("Error: %s\n", c->errstr);
        return (1);
    }
    else
    {
        redisReply *reply;

        reply = redisCommand(c, "SELECT 1");
        if (reply)
            freeReplyObject(reply);

        reply = redisCommand(c, "SETEX %s %d %s", "foo", 60, "bar");
        if (reply)
            freeReplyObject(reply);

        reply = redisCommand(c, "GET %s", "foo");
        printf("foo: %s\n", reply->str);
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
}
