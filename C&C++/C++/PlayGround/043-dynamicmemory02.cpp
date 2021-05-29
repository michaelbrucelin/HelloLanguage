#include <iostream>
#include <string>

//动态数组

int main(void)
{
    unsigned int count = 0;

    std::cout << "请输入数组元素的个数：" << std::endl;
    std::cin >> count;

    int *x = new int[count]; //申请一个动态数组

    for (size_t i = 0; i < count; i++)
        x[i] = i;

    for (size_t i = 0; i < count; i++)
        std::cout << "x[" << i << "]的值是：" << x[i] << std::endl;

    delete[] x; //释放内存

    return (0);
}