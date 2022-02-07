#include <pthread.h>   // gcc编译器提供的多线程库
#include <threads.h>   // C11标准中提供的多线程库
#include <stdatomic.h> // C11标准中提供的原子操作库

#ifdef __STDC_NO_THREADS__
#error "Not support multi-threads"
#error "Cannot compile with -D_STDC_NO_THREADS"
#endif

#ifdef __STDC_NO_ATOMICS__
#error "Not support atomic facilities"
#error "Cannot compile with -D_STDC_NO_ATOMICS"
#endif