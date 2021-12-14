#include <stdio.h>

int main(void)
{
    int number = 0;      /* A variable of type int initialized to  0 */
    int *pointer = NULL; /* A pointer that can point to type int     */

    number = 10;
    printf("number's address:\t%p\n", &number); /* Output the address */
    printf("number's value:\t%d\n\n", number);  /* Output the value   */

    pointer = &number; /* Store the address of number in pointer   */

    printf("pointer's address:\t%p\n", &pointer);           /* Output the address */
    printf("pointer's size:\t%d bytes\n", sizeof(pointer)); /* Output the size   */
    printf("pointer's value:\t%p\n", pointer);              /* Output the value (an address) */
    printf("value pointed to:\t%d\n", *pointer);            /* Value at the address */

    return (0);
}