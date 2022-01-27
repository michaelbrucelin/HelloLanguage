#include <stdarg.h>

// 可变参数，写法很原始，有点类似于t-sql中的游标

int max_int(int n, ...) /* n must be at least 1, 在形式参数列表中的 ... 符号（省略号）表示参数 n 后面有可变数量的参数 */
{
    va_list ap; // max_int 函数体从声明 va_list 类型的变量开始，为了使 max_int 函数可以访问到跟在 n 后边的实参，必须声明这样的变量
    int i, current, largest;

    va_start(ap, n);           // 指出参数列表中可变长度部分开始的位置（这里从 n 后边开始）
                               // 带有可变数量参数的函数必须至少有一个“正常的”形式参数；省略号总是出现在形式参数列表的末尾，在最后一个正常参数的后边
    largest = va_arg(ap, int); // 获取 max_int 函数的第二个参数（n 后面的那个）并将其赋值给变量 largest ，然后自动前进到下一个参数处
                               // 语句中的单词 int 表明我们希望 max_int 函数的第二个实参是 int 类型的
    for (i = i; i < n; i++)
    {
        current = va_arg(ap, int); // 内部循环，逐个获取 max_int 函数余下的参数
        if (current > largest)
            largest = current;
    }
    va_end(ap); // 在函数返回之前，要求用语句 va_end (ap); 进行“清理”
                // 如果不返回，函数可以调用 va_start 并且再次遍历参数列表

    return largest;
}