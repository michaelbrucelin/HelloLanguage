// Exercise 10.4 More applications of preprocessor directives. Since val is going to be
// a string, then we have to use the # within the  using the #define macro as shown.
// The solution uses the files from Exercise 10.3, with the following amendments
// to main.cpp:

// main.cpp
#include "printthis.h"
#include "printthat.h"

//#define DO_THIS        // undelete to #define the token

#ifdef DO_THIS
#define PRINT(val) print_this(#val);
#else 
#define PRINT(val) print_that(#val);
#endif

int main() {
  PRINT(abc)
  return 0;
}