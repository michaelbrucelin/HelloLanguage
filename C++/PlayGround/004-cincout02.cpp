#include <iostream>

using namespace std;

int main(void)
{
    char p;
    cout << "please input a string:\n";

    while (cin.peek() != '\n') //peek()窥视一个字符，但没有读
    {
        cout << (p = cin.get()); //使用get()读取peek()窥视的字符
        //p=cin.get();
        //cout << p;
    }
    cout << endl;

    return (0);
}