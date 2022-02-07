// tssdemo.c---2021
// 为线程分配专属储存空间的实例

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <threads.h>

tss_t key;

void destructor(void *data)
{
    free(data);
    printf("freed.\n");
}

void do_print(void)
{
    printf("%s.\n", (char *)tss_get(key));
    thrd_sleep(&(struct timespec){2, 0}, 0);
}

int thrd_proc(void *arg)
{
    tss_set(key, malloc(strlen((char *)arg) + 10));

    strcpy((char *)tss_get(key), "hello,");
    strcat((char *)tss_get(key), (char *)arg);

    do_print();

    return 0;
}

int main(void)
{
    tss_create(&key, destructor);

    thrd_t t0, t1;

    thrd_create(&t0, thrd_proc, "world");
    thrd_create(&t1, thrd_proc, "kitty");

    thrd_join(t0, &(int){0});
    thrd_join(t1, &(int){0});

    tss_delete(key);
}
