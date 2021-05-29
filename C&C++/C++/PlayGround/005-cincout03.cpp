#include <iostream>

using namespace std;

int main(void)
{
    const int SIZE = 20; //C++中推荐这样写，而不是宏定义的方式
    char buffer[SIZE];

    cout << "please input a string:\n";
    cin.read(buffer, 10); //读取10个字符到buffer中

    cout << "字符串收集到的字符数量为：" << cin.gcount() << endl; //获取读取到的字符数量

    cout << "输入的字符串为：";
    cout.write(buffer, 10); //输出
    cout << endl;

    return (0);
}