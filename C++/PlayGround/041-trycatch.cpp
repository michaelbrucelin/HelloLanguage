#include <iostream>
#include <climits>

unsigned long returnFactorial(unsigned short num) throw(const char *);

int main(void)
{
    unsigned short num = 0;

    std::cout << "请输入一个整数：";
    while (!(std::cin >> num) || (num < 1))
    {
        std::cin.clear();           //清除状态
        std::cin.ignore(100, '\n'); //清除缓冲区
        std::cout << "请输入一个整数：";
    }
    std::cin.ignore(100, '\n');

    try
    {
        unsigned long factorial = returnFactorial(num);
        std::cout << num << "的阶乘值是：" << factorial << std::endl;
    }
    catch (const char *e)
    {
        std::cout << e;
    }

    return (0);
}

unsigned long returnFactorial(unsigned short num) throw(const char *)
{
    unsigned long sum = 1;
    unsigned long max = ULONG_MAX;

    for (size_t i = 1; i < num; i++)
    {
        sum *= i;
        max /= i;
    }

    if (max < 1)
    {
        throw "悲催... ...该基数太大，无法在计算机上计算出阶乘值。\n";
    }
    else
    {
        return sum;
    }
}