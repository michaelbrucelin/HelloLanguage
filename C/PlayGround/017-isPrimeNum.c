#include <stdio.h>
#include <math.h>
#include <stdbool.h>

void main()
{
    int num;
    bool rslt = true;
    printf("input a number\n");
    scanf("%d", &num);

    for (int i = 2; i <= sqrt(num); i++)
    {
        if (num % i == 0)
        {
            rslt = false;
            break;
        }
    }

    if (rslt)
        printf("%d is a prime number\n", num);
    else
        printf("%d is not a prime number\n", num);
}