#include <stdio.h>

int main()
{
    double input, misRange;

    printf("input a number to cal\n");
    scanf("%lf", &input);
    printf("input a number with misRange\n");
    scanf("%lf", &misRange);

    if (input < 0 || misRange < 0)
    {
        printf("%lf or %lf < 0", input, misRange);
        return 1;
    }

    double mysqrt(double input, double misRange);

    printf("%lf\n", mysqrt(input, misRange));
}

double mysqrt(double input, double misRange)
{
    double result, tmp;
    double a = 0.0, z = input;

    result = input / 2.0;
    while ((result * result - input) * (result * result - input) >= misRange * misRange)
    {
        if (result * result > input)
        {
            z = result;
        }
        else
        {
            a = result;
        }
        result = (z + a) / 2.0;
    }

    return result;
}