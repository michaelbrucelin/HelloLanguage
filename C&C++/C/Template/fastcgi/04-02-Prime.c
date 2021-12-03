#include "fcgi_stdio.h"
#include <stdlib.h>
#include <string.h>

// Prime Number Generator
// 代码来自：http://www.chiark.greenend.org.uk/doc/libfcgi0ldbl/fastcgi-prog-guide/ch2c.htm

#define POTENTIALLY_PRIME 0
#define COMPOSITE 1
#define VALS_IN_SIEVE_TABLE 1000000
#define MAX_NUMBER_OF_PRIME_NUMBERS 78600

/* All initialized to POTENTIALLY_PRIME */
long int sieve_table[VALS_IN_SIEVE_TABLE];
long int prime_table[MAX_NUMBER_OF_PRIME_NUMBERS];
/* Use Sieve of Erastothenes method of building
   a prime number table. */
void initialize_prime_table(void)
{
    long int prime_counter = 1;
    long int current_prime = 2, c, d;

    prime_table[prime_counter] = current_prime;

    while (current_prime < VALS_IN_SIEVE_TABLE)
    {
        /* Mark off composite numbers. */
        for (c = current_prime; c <= VALS_IN_SIEVE_TABLE;
             c += current_prime)
        {
            sieve_table[c] = COMPOSITE;
        }

        /* Find the next prime number. */
        for (d = current_prime + 1; sieve_table[d] == COMPOSITE; d++)
            ;
        /* Put the new prime number into the table. */
        prime_table[++prime_counter] = d;
        current_prime = d;
    }
}

void main(void)
{
    char *query_string;
    long int n;

    initialize_prime_table();

    while (FCGI_Accept() >= 0)
    {
        /*
         * Produce the necessary HTTP header.
         */
        printf("Content-type: text/html\r\n"
               "\r\n");
        /*
         * Produce the constant part of the HTML document.
         */
        printf("<title>Prime FastCGI</title>\n"
               "<h1>Prime FastCGI</h1>\n");
        /*
         * Read the query string and produce the variable part
         * of the HTML document.
         */
        query_string = getenv("QUERY_STRING");
        if (query_string == NULL)
        {
            printf("Usage: Specify a positive number in the query string.\n");
        }
        else
        {
            query_string = strchr(query_string, '=') + 1;
            n = strtol(query_string);
            if (n < 1)
            {
                printf("The query string `%s' is not a positive number.\n",
                       query_string);
            }
            else if (n > MAX_NUMBER_OF_PRIME_NUMBERS)
            {
                printf("The number %d is too large for this program.\n", n);
            }
            else
                printf("The %ldth prime number is %ld.\n", n, prime_table[n]);
        }
    }
} /* while FCGI_Accept */
