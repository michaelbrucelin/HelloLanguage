#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

//将容器中的元素排序

int main(void)
{
    std::vector<std::string> names;

    names.push_back("tom");
    names.push_back("jim");
    names.push_back("bob");

    std::sort(names.begin(), names.end());

    std::vector<std::string>::iterator iter = names.begin();
    while (iter != names.end())
    {
        std::cout << *iter << std::endl;
        ++iter;
    }

    return (0);
}