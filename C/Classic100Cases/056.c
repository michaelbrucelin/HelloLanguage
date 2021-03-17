/*
题目：画图，学用circle画圆形。

程序分析：无。
*/

#include <graphics.h> //VC6.0中是不能运行的，要在Turbo2.0/3.0中

int main(void)
{
    int driver, mode, i;
    float j = 1, k = 1;
    driver = VGA;
    mode = VGAHI;
    initgraph(&driver, &mode, "");
    setbkcolor(YELLOW);
    for (i = 0; i <= 25; i++)
    {
        setcolor(8);
        circle(310, 250, k);
        k = k + j;
        j = j + 0.3;
    }

    return (0);
}