/*
题目：输出特殊图案，请在c环境中运行，看一看，Very Beautiful!

程序分析：字符共有256个。不同字符，图形不一样。
VC6.0下出现中文乱码(原因+解决方法):
176的16进制是B0，219的16进制是DB，0xB0DB是"佰"字的内码，所以输出的就是"佰"了。
主要原因是文件信息的代码页不同，我们所使用的操作系统中文状态下的代码页，要显示扩展的ASCII码需要在437 OEM-美国这个下面显示，这样就可以显示出你所希望的。具体修改控制台的默认代码页步骤如下：
1.点击运行界面左上角标题栏图标【c:\】，选择默认值一项
2.修改默认代码页，936（ANSI/OEM-简体中文GBK）为437 OEM-美国
3、关闭后重新运行一下即可
*/

#include <stdio.h>

int main(void)
{
    char a = 176, b = 219;
    printf("%c%c%c%c%c\n", b, a, a, a, b);
    printf("%c%c%c%c%c\n", a, b, a, b, a);
    printf("%c%c%c%c%c\n", a, a, b, a, a);
    printf("%c%c%c%c%c\n", a, b, a, b, a);
    printf("%c%c%c%c%c\n", b, a, a, a, b);

    return (0);
}