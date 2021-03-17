#include <iostream>
#include <string>
#include <vector>

//向量，有点像C#中的List

int main(void)
{
    std::vector<std::string> names;

    names.push_back("tom");
    names.push_back("jim");
    names.push_back("bob");

    for (size_t i = 0; i < names.size(); i++)
        std::cout << names[i] << std::endl;

    return (0);
}