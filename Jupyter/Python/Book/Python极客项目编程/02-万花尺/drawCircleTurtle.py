import math
import turtle

def drawCircleTurtle(x, y, r):
    # move to the start of circle
    turtle.up()              # 提笔
    turtle.setpos(x + r, y)  # 将笔移到起点
    turtle.down()            # 落笔

    # draw the circle
    for i in range(0, 365, 5):  # 从技术上讲，产生的是 N（N=360/5） 边多边形，但因为用了很小的角度，N 将非常大，多边形看起来像一个圆
        a = math.radians(i)  # 转为弧度
        turtle.setpos(x + r*math.cos(a), y + r*math.sin(a))  # 笔尖移动，由于笔是turtle.down()状态，移动笔尖就会留下痕迹

drawCircleTurtle(100, 100, 50)
turtle.mainloop()            # 保持tkinter窗口打开，欣赏绘图（Tkinter是Python默认的GUI库）