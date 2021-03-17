#include <iostream>

using std::cout;
using std::endl;

/*
main函数参数：
argc，从命令行上输入的字符串的个数，包括程序名本身；
argv，数组，包含指向每个在命令行上输入的字符串的指针，包括程序名本身；
        数组argv的最后一个元素（即argv[argc]）总是0，argv中元素的个数是argc+1；
*/

int main(int argc, char *argv[])
{
    for (size_t i = 0; i < argc; i++)
        cout << endl
             << i << ":\t" << argv[i];

    cout << endl;

    return (0);
}