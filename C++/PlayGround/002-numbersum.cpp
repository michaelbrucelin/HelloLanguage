#include <iostream>

using namespace std;

int main(void)
{
    int sum = 0;
    cout << "输入多个数字，用空格间隔开，例如：11 22 33 44： ";

    int i;
    while (cin >> i)
    {
        sum += i;
        while (cin.peek() == ' ')
            cin.get();
        if (cin.peek() == '\n')
            break;
    }

    cout << "CPP结果为：" << sum << endl;

    return (0);
}