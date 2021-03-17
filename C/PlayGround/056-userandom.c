#include <time.h>
#include <stdlib.h>

int main(void)
{
    srand(time(NULL)); // Initialization, should only be called once.
    int r = rand();    // Returns a pseudo-random integer between 0 and RAND_MAX.

    int limit = 100.0;
    r = rand() % limit;

    return (0);
}