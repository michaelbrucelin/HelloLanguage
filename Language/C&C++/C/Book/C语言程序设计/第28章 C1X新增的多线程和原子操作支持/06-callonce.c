// callonce.c---2021
// 单次调用的实例

#include <stdio.h>
#include <threads.h>

int data1 = -1, data2 = -1;
mtx_t mtx;
cnd_t cnd;
once_flag flag_init = ONCE_FLAG_INIT, flag_print = ONCE_FLAG_INIT;

void do_init(void)
{
    mtx_init(&mtx, mtx_plain);
    cnd_init(&cnd);
    printf("Mutex and condition variable is created.\n");
}

void do_print(void)
{
    printf("The combined result is %d.\n", data1 + data2);
}

int thrd_task1(void *arg)
{
    call_once(&flag_init, do_init);

    thrd_sleep(&(struct timespec){3, 0}, 0);
    data1 = 12000;

    mtx_lock(&mtx);

    if (data2 != -1)
        cnd_signal(&cnd);
    else
        cnd_wait(&cnd, &mtx);
    call_once(&flag_print, do_print);

    mtx_unlock(&mtx);

    return 0;
}

int thrd_task2(void *arg)
{
    call_once(&flag_init, do_init);

    thrd_sleep(&(struct timespec){2, 0}, 0);
    data2 = 306;

    mtx_lock(&mtx);

    if (data1 != -1)
        cnd_signal(&cnd);
    else
        cnd_wait(&cnd, &mtx);
    call_once(&flag_print, do_print);

    mtx_unlock(&mtx);

    return 0;
}

int main(void)
{
    thrd_t t0, t1;

    thrd_create(&t0, thrd_task1, 0);
    thrd_create(&t1, thrd_task2, 0);

    thrd_join(t0, &(int){0});
    thrd_join(t1, &(int){0});
}
