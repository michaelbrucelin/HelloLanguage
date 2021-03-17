#include <iostream>
using std::cout;
using std::endl;

//将函数指针作为函数的参数传递

double squared(double);
double cubed(double);
double sum_array(double array[], int len, double (*pfun)(double));

int main()
{
    double array[] = {1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5};
    int len = sizeof array / sizeof array[0];

    cout << endl
         << "Sum of squares = " << sum_array(array, len, squared) << endl;

    cout << "Sum of cubes = " << sum_array(array, len, cubed) << endl;

    return 0;
}

double squared(double x)
{
    return x * x;
}

double cubed(double x)
{
    return x * x * x;
}

//函数的参数是一个函数指针
double sum_array(double array[], int len, double (*pfun)(double))
{
    double total = 0.0;

    for (int i = 0; i < len; i++)
        total += pfun(array[i]);

    return total;
}