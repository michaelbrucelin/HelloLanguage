#include <iostream>

void swap0(int x, int y);  //普通的值传递
void swap(int *x, int *y); //C语言的地址传递
void swap(int &x, int &y); //C++的引用传递，就是个语法糖，其实还是地址传递，类似于C#的ref参数
//个人观点，直接使用C语言的传址的写法，而不使用C++的引用传递，因为直接看代码，而不看函数的定义的话，引用传递看不出到底是值传递还是引用传递，个人不喜欢“模糊”的东西
//这点在C#中感觉处理的比C++更好，因为C#中的引用传递必须加上ref关键字，虽然写法略有冗余，但是一目了然

int main(void)
{
    int x = 10, y = 20;

    int n;
    while (1)
    {
        x = 10, y = 20;
        std::cout << "1 --> void swap(int x, int y);\n"
                  << "2 --> void swap(int *x, int *y);\n"
                  << "3 --> void swap(int &x, int &y);\n"
                  << "0 --> exit\n"
                  << "input 1 or 2 or 3: ";
        while (!(std::cin >> n))
        {
            std::cout << "invalid input!!!!\n";
            std::cin.clear();
            std::cin.ignore(100, '\n');
            std::cout << "1 --> void swap(int x, int y);\n"
                      << "2 --> void swap(int *x, int *y);\n"
                      << "3 --> void swap(int &x, int &y);\n"
                      << "0 --> exit\n"
                      << "input 1 or 2 or 3: ";
        }

        if (n == 0)
            break;

        std::cout << "\nx = " << x << ", y = " << y << "\n";
        switch (n)
        {
        case 1:
            swap0(x, y);
            break;
        case 2:
            swap(&x, &y);
            break;
        case 3:
            swap(x, y);
            break;
        }
        std::cout << "x = " << x << ", y = " << y << "\n\n";
    }

    return (0);
}

void swap0(int x, int y)
{
    int tmp;
    tmp = x;
    x = y;
    y = tmp;
}

void swap(int *x, int *y)
{
    int tmp;
    tmp = *x;
    *x = *y;
    *y = tmp;
}

void swap(int &x, int &y)
{
    int tmp;
    tmp = x;
    x = y;
    y = tmp;
}