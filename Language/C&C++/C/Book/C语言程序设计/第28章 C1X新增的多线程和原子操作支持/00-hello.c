#include <pthread.h> // gcc编译器提供的多线程库
#include <threads.h> // C11标准中提供的多线程库

# ifdef __STDC_NO_THREADS__
# error "Cannot compile with -D_STDC_NO_THREADS"
# endif