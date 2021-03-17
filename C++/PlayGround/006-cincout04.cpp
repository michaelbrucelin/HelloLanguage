#include <iostream>
#include <math.h>

using namespace std;

int main(void)
{
    double result = sqrt(2.0);

    cout << "对2开方保留小数点的0~9位，结果如下：\n"
         << endl;

    for (size_t i = 0; i < 10; i++)
    {
        cout.precision(i); //设定小数位数
        cout << result << endl;
    }
    cout << "当前输出的精度为：" << cout.precision() << endl;

    return (0);
}