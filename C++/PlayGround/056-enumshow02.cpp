#include <iostream>

using std::cout;
using std::endl;

int main(void)
{
    enum Level
    {
        A = 10,
        B = 20,
        C = 30,
        D = 100
    };

    Level level;

    level = static_cast<Level>(10);
    cout << "Current Level is " << level << endl;

    level = B;
    cout << "Current Level is " << level << endl;

    level = static_cast<Level>(level + 10);
    cout << "Current Level is " << level << endl;

    //枚举的值不一定必须是某个枚举项对应的值，只要处于枚举项对应值的最小值与最大值之间即可
    level = static_cast<Level>(64);
    cout << "Current Level is " << level << endl;

    return (0);
}