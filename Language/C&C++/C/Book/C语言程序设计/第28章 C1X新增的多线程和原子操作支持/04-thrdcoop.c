// thrdcoop.c---2021
// 线程间协作的实例

#include <stdio.h>
#include <threads.h>

int data1 = -1, data2 = -1;
mtx_t mtx;

int thrd_task1(void *arg)
{
    thrd_sleep(&(struct timespec){3, 0}, 0); // 线程挂起 3 second 0 nanoseconds
    data1 = 12000;

again:
    mtx_lock(&mtx);

    if (data2 != -1)
    {
        printf("%d\n", data1 + data2);
        mtx_unlock(&mtx);
        return 0;
    }

    mtx_unlock(&mtx);

    goto again;
}

int thrd_task2(void *arg)
{
    thrd_sleep(&(struct timespec){2, 0}, 0); // 线程挂起 2 second 0 nanoseconds
    data2 = 306;

again:
    mtx_lock(&mtx);

    if (data1 != -1)
    {
        printf("%d\n", data1 + data2);
        mtx_unlock(&mtx);
        return 0;
    }

    mtx_unlock(&mtx);

    goto again;
}

int main(void)
{
    thrd_t t0, t1;
    mtx_init(&mtx, mtx_plain);

    thrd_create(&t0, thrd_task1, 0);
    thrd_create(&t1, thrd_task2, 0);

    thrd_join(t0, &(int){0});
    thrd_join(t1, &(int){0});
}
