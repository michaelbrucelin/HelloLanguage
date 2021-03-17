#include <iostream>

int main(void)
{
    //华氏温度 = 摄氏温度 * 9.0 / 5.0 + 32
    const unsigned short ADD_SUBTRACT = 32;
    const double RATIO = 9.0 / 5.0;

    double tmpIn, tmpOut;
    char typeIn, typeOut;

    std::cout << "请以【xx.x C】或【xx.x F】的格式输入一个温度： ";
    std::cin >> tmpIn >> typeIn;
    std::cin.ignore(100, '\n');
    std::cout << "\n";

    switch (typeIn)
    {
    case 'C':
    case 'c':
        tmpOut = tmpIn * RATIO + ADD_SUBTRACT;
        typeOut = 'F';
        typeIn = 'C';
        break;
    case 'F':
    case 'f':
        tmpOut = (tmpIn - ADD_SUBTRACT) / RATIO;
        typeOut = 'C';
        typeIn = 'F';
        break;
    default:
        typeOut = 'E';
        break;
    }

    if (typeOut != 'E')
    {
        std::cout << tmpIn << typeIn << " = " << tmpOut << typeOut << "\n";
    }
    else
    {
        std::cout << "您输入的字符非法！！！"
                  << "\n";
    }

    std::cout << "请输入任何字符结束程序！"
              << "\n";
    std::cin.get();

    return (0);
}