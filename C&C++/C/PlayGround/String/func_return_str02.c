#include <stdio.h>
#include <string.h>

void calculateMonth(int month, char *pszMonth, int buffersize)
{
    const char *months[] = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}; // Allocated dynamically during the function call. (Can be inefficient with a bad compiler)
    if (!pszMonth || buffersize < 1)
        return; // Bad input. Let junk deal with junk data.
    if (month < 1 || month > 12)
    {
        *pszMonth = '\0'; // Return an 'empty' string
        // OR: strncpy(pszMonth, "Bad Month", buffersize-1);
    }
    else
    {
        strncpy(pszMonth, months[month - 1], buffersize - 1);
    }
    pszMonth[buffersize - 1] = '\0'; // Ensure a valid terminating zero! Many people forget this!
}

int main()
{
    char month[16]; // 16 bytes allocated here on the stack.
    calculateMonth(3, month, sizeof(month));
    printf("%s", month); // Prints "Mar"
}

/*
函数返回字符串的使用方法
链接：https://stackoverflow.com/questions/1496313/returning-a-c-string-from-a-function

This is the more 'foolproof' way of passing strings around. The data returned isn't subject to manipulation by the calling party.
That is, example 1 can easily be abused by a calling party and expose you to application faults. This way, it's much safer (albeit uses more lines of code):

这是传递字符串的更“万无一失”的方式。 返回的数据不受调用方的操纵。 也就是说，示例 1 很容易被调用方滥用，并使您面临应用程序故障。 这样，它更安全（尽管使用了更多的代码行）：

There are lots of reasons why the second method is better, particularly if you're writing a library to be used by others
(you don't need to lock into a particular allocation/deallocation scheme, third parties can't break your code, and you don't need to link to a specific memory management library),
but like all code, it's up to you on what you like best. For that reason, most people opt for example 1 until they've been burnt so many times that they refuse to write it that way anymore ;)

第二种方法更好的原因有很多，特别是如果您正在编写供其他人使用的库（您不需要锁定特定的分配/释放方案，第三方无法破坏您的代码， 并且您不需要链接到特定的内存管理库），
但与所有代码一样，您最喜欢什么取决于您。 出于这个原因，大多数人选择示例 1，直到他们被烧毁了太多次以至于他们拒绝再这样写了 ;)
*/