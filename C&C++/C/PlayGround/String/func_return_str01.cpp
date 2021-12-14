class Foo
{
    char _someData[12];

public:
    const char *someFunction() const
    { // The final 'const' is to let the compiler know that nothing is changed in the class when this function is called.
        return _someData;
    }
};

/*
函数返回字符串的使用方法
链接：https://stackoverflow.com/questions/1496313/returning-a-c-string-from-a-function

but it's probably easier to use helper classes, such as std::string, if you're writing the code for your own use (and not part of a library to be shared with others).
*/