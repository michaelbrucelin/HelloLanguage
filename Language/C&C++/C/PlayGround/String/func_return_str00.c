#include <stdio.h>

// 不推荐使用这种方法
const char *myFunction()
{
    return "my String";
}

int main()
{
    const char *szSomeString = myFunction(); // Fraught with problems
    printf("%s", szSomeString);
}

/*
函数返回字符串的使用方法
链接：https://stackoverflow.com/questions/1496313/returning-a-c-string-from-a-function

... will generally land you with random unhandled-exceptions/segment faults and the like, especially 'down the road'.
In short, although my answer is correct - 9 times out of 10 you'll end up with a program that crashes if you use it that way, especially if you think it's 'good practice' to do it that way. In short: It's generally not.
For example, imagine some time in the future, the string now needs to be manipulated in some way. Generally, a coder will 'take the easy path' and (try to) write code like this:

const char * myFunction(const char* name)
{
    char szBuffer[255];
    snprintf(szBuffer, sizeof(szBuffer), "Hi %s", name);
    return szBuffer;
}

That is, your program will crash because the compiler (may/may not) have released the memory used by szBuffer by the time the printf() in main() is called. (Your compiler should also warn you of such problems beforehand.)

There are two ways to return strings that won't barf so readily.

returning buffers (static or dynamically allocated) that live for a while. In C++ use 'helper classes' (for example, std::string) to handle the longevity of data (which requires changing the function's return value), or
pass a buffer to the function that gets filled in with information.
Note that it is impossible to use strings without using pointers in C. As I have shown, they are synonymous. Even in C++ with template classes, there are always buffers (that is, pointers) being used in the background.

So, to better answer the (now modified question). (There are sure to be a variety of 'other answers' that can be provided.)
*/