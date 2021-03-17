#include <iostream>

using namespace std;

int main(void)
{
    char buffer[20]; //长度为19的字符串

    cin.ignore(7);           //忽略输入的前7个字符
    cin.getline(buffer, 10); //从第8个字符起，读取9个字符到buffer中

    cout << buffer << endl;

    return (0);
}