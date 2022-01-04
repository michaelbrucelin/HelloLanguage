#include <iostream>

int main(void)
{
    const unsigned short ITEM = 10;
    int num[ITEM];

    std::cout << "请输入" << ITEM << "个整形数据！\n";
    for (size_t i = 0; i < ITEM; i++)
    {
        std::cout << "请输入第" << i + 1 << "个数据： ";
        while (!(std::cin >> num[i]))
        {
            std::cin.clear();
            std::cin.ignore(100, '\n');
            std::cout << "请输入一个合法的值！";
        }
    }

    int total = 0;
    for (size_t i = 0; i < ITEM; i++)
        total += num[i];

    std::cout << "total = " << total << "\n";
    std::cout << "avg   = " << total * 1.0 / 10 << "\n";

    return (0);
}