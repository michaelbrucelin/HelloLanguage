#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;
using std::fixed;
using std::scientific;
using std::setprecision;

//在程序中，不要依赖十进制的精确浮点数。
//接050，将float改为double，情况好了很多，但是仍然有问题

int main(void)
{
    double value1 = 0.1;
    double value2 = 2.1;
    value1 -= 0.09; // Should be 0.01
    value2 -= 2.09; // Should be 0.01

    //setprecision(N)设定表示浮点数的位数
    cout << setprecision(10) << "value1 = " << value1 << ", 准确结果应该为0.01" << endl;
    cout << setprecision(10) << "value2 = " << value2 << ", 准确结果应该为0.01" << endl;

    cout << setprecision(32) << fixed; // Change to fixed notation，浮点数形式显示
    cout << value1 - value2 << endl;   // Should output zero

    cout << setprecision(5) << scientific; // Set scientific notation，科学计数法形式显示
    cout << value1 - value2 << endl;       // Should output zero

    return (0);
}