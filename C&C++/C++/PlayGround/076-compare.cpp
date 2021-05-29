// compare.cpp
#include "076-compare.h"

// Function to find the maximum
double compare::max(const double *data, int size)
{
    double result = data[0];
    for (int i = 1; i < size; i++)
        if (result < data[i])
            result = data[i];

    return result;
}

// Function to find the minimum
double compare::min(const double *data, int size)
{
    double result = data[0];
    for (int i = 1; i < size; i++)
        if (result > data[i])
            result = data[i];

    return result;
}
