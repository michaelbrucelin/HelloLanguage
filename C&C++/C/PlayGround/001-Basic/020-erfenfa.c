#include <stdio.h>

void main()
{
    int arr[10] = {-12, 0, 6, 16, 23, 56, 80, 100, 110, 115};

    int input;
    printf("input a number\n");
    scanf("%d", &input);

    if (input < arr[0] || input > arr[9])
    {
        printf("%d is not in arr.\n", input);
        return;
    }

    int a = 0, z = 9, tmp, index = -1;
    while (1)
    {
        if (z == a)
        {
            if (arr[a] == input)
            {
                index = a;
            }
            break;
        }
        else if (z - a == 1)
        {
            if (arr[a] == input)
            {
                index = a;
            }
            else if (arr[z] == input)
            {
                index = z;
            }
            break;
        }
        else
        {
            tmp = (z - a) / 2 + a;
            if (arr[tmp] == input)
            {
                index = tmp;
                break;
            }
            else if (arr[tmp] > input)
            {
                z = tmp;
            }
            else
            {
                a = tmp;
            }
        }
    }

    if (index != -1)
    {
        printf("%d is at %d.\n", input, index);
    }
    else
    {
        printf("%d is not in arr.\n", input);
    }
}