#include <iostream>
#include <string>
#include <vector>

//使用迭代器（iterator）遍历容器
//迭代器是个所谓的智能指针，具有遍历复杂数据结构的能力

int main(void)
{
    std::vector<std::string> names;

    names.push_back("tom");
    names.push_back("jim");
    names.push_back("bob");

    std::vector<std::string>::iterator iter = names.begin();
    while (iter != names.end())
    {
        std::cout << *iter << std::endl;
        ++iter;
    }

    return (0);
}