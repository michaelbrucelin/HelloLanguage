#include <iostream>
#include <iomanip>

// 使用静态变量防止死递归
// 目测无法应用到生产环境，但是有助于理解递归的执行过程

void myRecursion();

int main(void)
{
    myRecursion();

    return (0);
}

// 貌似生产环境不能这么用。。。
void myRecursion()
{
    static int recTimes = 0;

    recTimes++;
    std::cout << recTimes << std::left << std::setw(4) << ":";

    if (true && recTimes < 16)
        myRecursion();

    std::cout << recTimes << std::endl;
}

/* 执行结果
#./a.out 
1:   2:   3:   4:   5:   6:   7:   8:   9:   10:   11:   12:   13:   14:   15:   16:   16
16
16
16
16
16
16
16
16
16
16
16
16
16
16
16
*/