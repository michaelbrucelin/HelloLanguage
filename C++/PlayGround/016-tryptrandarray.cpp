#include <iostream>

int main(void)
{
    const unsigned short ITEMS = 6;

    int intArr[ITEMS] = {1, 2, 3, 4, 5, 6};
    char charArr[ITEMS] = {'A', 'B', 'C', 'D', 'E', 'F'};

    int *intptr = intArr;
    char *charptr = charArr;

    std::cout << "整型数组输出：" << '\n';
    for (size_t i = 0; i < ITEMS; i++)
    {
        std::cout << *intptr << " at " << reinterpret_cast<unsigned long>(intptr) << '\n';
        intptr++;
    }

    std::cout << "字符数组输出：" << '\n';
    for (size_t i = 0; i < ITEMS; i++)
    {
        std::cout << *charptr << " at " << reinterpret_cast<unsigned long>(charptr) << '\n';
        charptr++;
    }

    return (0);
}