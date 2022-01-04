#include <iostream>
#include <string>

int main(void)
{
    std::string str;
    std::cout << "please input a string: ";

    std::getline(std::cin, str); //std::cin >> str这样的话string中如果含有空格就会被空格割断
    std::cout << str << "\n";

    return (0);
}