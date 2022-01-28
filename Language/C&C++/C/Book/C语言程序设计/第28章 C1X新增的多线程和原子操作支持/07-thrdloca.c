// thrdloca.c---2021

#include <stdio.h>
#include <threads.h>

_Thread_local int g;

void do_print(void *arg)
{
    printf("%s:%s\t%p.\n", (char *)arg, __func__, &g);
}

void do_calc(void *arg)
{
    printf("%s:%s\t%p.\n", (char *)arg, __func__, &g);
    do_print(arg);
}

int thrd_proc(void *arg)
{
    printf("%s:%s\t%p.\n", (char *)arg, __func__, &g);
    do_calc(arg);
    return 0;
}

int main(void)
{
    thrd_t t0, t1;

    thrd_create(&t0, thrd_proc, "A");
    thrd_create(&t1, thrd_proc, "B");

    printf("%s:%s\t%p.\n", "main", __func__, &g);
    do_calc("main");

    thrd_join(t0, &(int){0});
    thrd_join(t1, &(int){0});
}
