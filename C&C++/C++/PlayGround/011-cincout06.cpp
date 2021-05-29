#include <iostream>

int main(void)
{
    char answer;

    std::cout << "请问可以格式化您的硬盘吗？【Y/N】"
              << "\n"; //std:: 这样就不用在前面使用using引用命名空间了
    std::cin >> answer;

    switch (answer)
    {
    case 'Y':
    case 'y':
        std::cout << "随便格式化硬盘是不对的！！！"
                  << "\n";
        break;
    case 'N':
    case 'n':
        std::cout << "您的选择是明智的！！！"
                  << "\n";
        break;
    default:
        std::cout << "您的输入不合法！！！"
                  << "\n";
        break;
    }

    std::cin.ignore(100, '\n'); //忽略最多100个字符，直到遇到\n为止
    std::cout << "请输入任意字符推出程序。"
              << "\n";
    std::cin.get(); //相当于C#中的Console.ReadKey()

    return (0);
}