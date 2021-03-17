#include <iostream>
#include <fstream>
#include <iomanip>

// 写入文件，将素数写入文件

int main()
{
    const int max = 100;
    long primes[max] = {2, 3, 5}; // 初始化前3个元素
    int count = 3;                // 初始化已有元素的数量
    long trial = 5;               // 从哪里开始查找素数
    bool isprime = true;

    do
    {
        trial += 2;
        int i = 0;

        do
        {
            isprime = trial % *(primes + i) > 0;
        } while (++i < count && isprime);

        if (isprime)
            *(primes + count++) = trial;
    } while (count < max);

    std::ofstream outFile("/tmp/primes.txt");

    for (int i = 0; i < max; i++)
    {
        if (i % 5 == 0)
            outFile << std::endl;
        outFile << std::setw(10) << *(primes + i);
    }

    return 0;
}