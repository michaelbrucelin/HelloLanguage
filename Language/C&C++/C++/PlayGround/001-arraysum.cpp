#include <iostream>

using namespace std;

int addarray(int *array, int count);

int main(void)
{
    int data[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    int size = sizeof(data) / sizeof(data[0]);

    cout << "the result is: " << addarray(data, size) << endl;

    return (0);
}

int addarray(int *array, int count)
{
    int sum = 0;
    int i;

    for (i = 0; i < count; i++)
    {
        sum += *array++;
    }

    return sum;
}

//g++ /PATH/TO/FILE.cpp，使用g++，不能使用gcc