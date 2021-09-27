"""
spiro.py

A python program that simulates a Sprirograph.

Author: Mahesh Venkitachalam
Website: electronut.in
"""

import sys, random, argparse
import numpy as np
import math
import turtle
import random
from PIL import Image
from datetime import datetime    
# from fractions import gcd  # fractions.gcd() is deprecated. Use math.gcd() instead.

# Spiro 构造函数
# 首先，定义类Sipro，来绘制曲线。我们会用这个类一次画一条曲线
# A class that draws a spirograph
class Spiro:
    # constructor
    def __init__(self, xc, yc, col, R, r, l):
        # create own turtle
        self.t = turtle.Turtle()      # 创建一个新的turtle 对象，这将有助于我们同时绘制多条螺线
        # set cursor shape
        self.t.shape('turtle')        # 将光标的形状设置为海龟
        # set step in degrees
        self.step = 5                 # 将参数绘图角度的增量设置为5度
        # set drawing complete flag
        self.drawingComplete = False  # 设置了一个标志，将在动画中使用它，它会产生一组螺线

        # set parameters
        self.setparams(xc, yc, col, R, r, l)  # 调用设置函数
        # initiatize drawing
        self.restart()                        # 调用设置函数

    # 初始化 Spiro 对象
    # set parameters
    def setparams(self, xc, yc, col, R, r, l):
        # spirograph parameters
        self.xc = xc                  # 保存曲线中心的坐标
        self.yc = yc
        self.R = int(R)               # 将每个圆的半径（R和r）转换为整数并保存这些值
        self.r = int(r)
        self.l = l
        self.col = col
        # reduce r/R to smallest form by dividing with GCD
        gcdVal = math.gcd(self.r, self.R)  # 用 Python 模块 fractions 内置的gcd()方法来计算半径的GCD。我们将用这些信息来确定曲线的周期性
        self.nRot = self.r//gcdVal
        # get ratio of radii
        self.k = r/float(R)
        # set color
        self.t.color(*col)
        # current angle
        self.a = 0                    # 保存当前的角度，我们将用它来创建动画

    # 重置Spiro 对象的绘制参数，让它准备好重画
    # restart drawing
    def restart(self):
        # set flag
        self.drawingComplete = False      # 用了布尔标志drawingComplete，来确定绘图是否已经完成，初始化该标志
        # show turtle
        self.t.showturtle()               # 显示海龟光标，以防它被隐藏
        # go to first point
        self.t.up()                       # 提起笔
        R, k, l = self.R, self.k, self.l  # 使用了一些局部变量，以保持代码紧凑
        a = 0.0
        x = R*((1-k)*math.cos(a) + l*k*math.cos((1-k)*a/k))  # 计算角度a 设为0 时的x 和y 坐标，以获得曲线的起点
        y = R*((1-k)*math.sin(a) - l*k*math.sin((1-k)*a/k))
        self.t.setpos(self.xc + x, self.yc + y)              # 将笔移到起点
        self.t.down()                                        # 落笔              

    # 用连续的线段绘制该曲线
    # draw the whole thing
    def draw(self):
        # draw rest of points
        R, k, l = self.R, self.k, self.l
        for i in range(0, 360*self.nRot + 1, self.step):         # 迭代遍历参数i 的完整范围，它以度表示，是360 乘以nRot
            a = math.radians(i)
            x = R*((1-k)*math.cos(a) + l*k*math.cos((1-k)*a/k))  # 计算参数i 的每个值对应的X 和Y 坐标
            y = R*((1-k)*math.sin(a) - l*k*math.sin((1-k)*a/k))
            self.t.setpos(self.xc + x, self.yc + y)
        # done - hide turtle
        self.t.hideturtle()                                      # 隐藏光标，因为我们已完成绘制
    
    # 用了一段一段绘制曲线来创建动画时所使用的绘图方法
    # update by one step
    def update(self):
        # skip if done
        if self.drawingComplete:                                  # 检查drawingComplete 标志是否设置。如果没有设置，则继续执行代码其余的部分
            return
        # increment angle
        self.a += self.step                                       # 增加当前的角度
        # draw step
        R, k, l = self.R, self.k, self.l
        # set angle
        a = math.radians(self.a)                                  # 计算当前角度对应的（X，Y）位置并将海龟移到那里，在这个过程中画出线段
        x = self.R*((1-k)*math.cos(a) + l*k*math.cos((1-k)*a/k))
        y = self.R*((1-k)*math.sin(a) - l*k*math.sin((1-k)*a/k))
        self.t.setpos(self.xc + x, self.yc + y)
        # check if drawing is complete and set flag
        if self.a >= 360*self.nRot:                               # 检查角度是否达这条特定曲线计算的完整范围。如果是这样，就设置drawingComplete 标志，因为绘图完成了
            self.drawingComplete = True
            # done - hide turtle
            self.t.hideturtle()                                   # 隐藏海龟光标

    # clear everything
    def clear(self):
        self.t.clear()

# SpiroAnimator 类
# SpiroAnimator 类让我们同时绘制随机的螺线。该类使用一个计时器，每次绘制曲线的一段
# A class for animating spirographs
class SpiroAnimator:
    # constructor
    def __init__(self, N):
        # timer value in milliseconds
        self.deltaT = 10                          # 该SpiroAnimator 构造函数将DeltaT 设置为10，这是以毫秒为单位的时间间隔，将用于定时器
        # get window dimensions
        self.width = turtle.window_width()        # 保存海龟窗口的尺寸
        self.height = turtle.window_height()
        # create spiro objects
        self.spiros = []                          # 创建一个空数组，其中将填入一些Spiro 对象。这些封装的万花尺绘制，然后循环N 次（N 传入给构造函数SpiroAnimator）
        for i in range(N):
            # generate random parameters
            rparams = self.genRandomParams()      # 调用了一个辅助方法
            # set spiro params
            spiro = Spiro(*rparams)               # 创建一个新的Spiro 对象，并将它添加到Spiro对象的列表中
            self.spiros.append(spiro)
        # call timer
        turtle.ontimer(self.update, self.deltaT)  # 设置turtle.ontimer()方法每隔DeltaT 毫秒调用update()
    
    # 重新启动程序
    # 遍历所有的Spiro 对象，清除以前绘制的每条螺线，分配新的螺线参数，然后重新启动程序
    # restart sprio drawing
    def restart(self):
        for spiro in self.spiros:
            # clear
            spiro.clear()
            # generate random parameters
            rparams = self.genRandomParams()
            # set spiro params
            spiro.setparams(*rparams)
            # restart drawing
            spiro.restart()

    # 生成随机参数，在每个Spiro 对象创建时发送给它，来生成各种曲线
    # generate random parameters
    def genRandomParams(self):
        width, height = self.width, self.height
        R = random.randint(50, min(width, height)//2)  # 将R 设置为50 至窗口短边一半长度的随机整数
        r = random.randint(10, 9*R//10)                # 将r 设置为R 的10%至90%之间
        l = random.uniform(0.1, 0.9)                   # 将l 设置为0.1 至0.9 之间的随机小数
        xc = random.randint(-width//2, width//2)       # 在屏幕边界内随机选择x 和y 坐标，选择屏幕上的一个随机点作为螺线的中心
        yc = random.randint(-height//2, height//2)
        col = (random.random(),
               random.random(),
               random.random())                        # 随机设置为红、绿和蓝颜色的成分，为曲线指定随机的颜色
        return (xc, yc, col, R, r, l)                  # 所有计算的参数作为一个元组返回

    # 由定时器调用，以动画的形式更新所有的Spiro 对象
    def update(self):
        # update all spiros
        nComplete = 0
        for spiro in self.spiros:
            # update
            spiro.update()
            # count completed ones
            if spiro.drawingComplete:
                nComplete+= 1
        # if all spiros are complete, restart
        if nComplete == len(self.spiros):         # 检查计数器，看看是否所有对象都已画完
            self.restart()
        # call timer
        turtle.ontimer(self.update, self.deltaT)  # 调用计时器方法，它在DeltaT 毫秒后再次调用update()

    # 显示或隐藏光标
    # toggle turtle on/off
    def toggleTurtles(self):
        for spiro in self.spiros:
            if spiro.t.isvisible():
                spiro.t.hideturtle()
            else:
                spiro.t.showturtle()

# 保存曲线，将绘制保存为PNG 图像文件
# save spiros to image
def saveDrawing():
    # hide turtle
    turtle.hideturtle()                                   # 隐藏海龟光标，这样就不会在最后的图形中看到它
    # generate unique file name
    dateStr = (datetime.now()).strftime("%d%b%Y-%H%M%S")  # 生成图像文件的唯一名称
    fileName = 'spiro-' + dateStr 
    print('saving drawing to %s.eps/png' % fileName)
    # get tkinter canvas
    canvas = turtle.getcanvas()                           # 利用tkinter的canvas 对象，将窗口保存为嵌入式PostScript（EPS）文件格式。
    # save postscipt image
    canvas.postscript(file = fileName + '.eps')           # 由于EPS 是矢量格式，你可以用高分辨率打印它
    # use PIL to convert to PNG
    img = Image.open(fileName + '.eps')                   # 用Pillow 打开 EPS 文件
    img.save(fileName + '.png', 'png')                    # 将它保存为PNG 文件
    # show turtle
    turtle.showturtle()                                   # 取消隐藏海龟光标

# 解析命令行参数和初始化
# main() function
def main():
    # use sys.argv if needed
    print('generating spirograph...')
    # create parser
    descStr = """This program draws spirographs using the Turtle module. 
    When run with no arguments, this program draws random spirographs.
    
    Terminology:

    R: radius of outer circle.
    r: radius of inner circle.
    l: ratio of hole distance to r.
    """
    parser = argparse.ArgumentParser(description=descStr)  # 创建参数解析器对象
  
    # add expected arguments
    parser.add_argument('--sparams', nargs=3, dest='sparams', required=False, 
                        help="The three arguments in sparams: R, r, l.")       # 向解析器添加--sparams 可选参数
                        

    # parse args
    args = parser.parse_args()      # 调用函数进行实际的解析

    # set to 80% screen width
    turtle.setup(width=0.8)         # 用setup()将绘图窗口的宽度设置为80％的屏幕宽度

    # set cursor shape
    turtle.shape('turtle')          # 设置光标形状为海龟

    # set title
    turtle.title("Spirographs!")    # 设置程序窗口的标题为Spirographs！
    # add key handler for saving images
    turtle.onkey(saveDrawing, "s")  # 利用onkey()和saveDrawing，在按下S 时保存图画
    # start listening 
    turtle.listen()                 # 调用listen()让窗口监听用户事件

    # hide main turtle cursor
    turtle.hideturtle()             # 隐藏海龟光标

    # checks args and draw
    if args.sparams:                                # 首先检查是否有参数赋给--sparams
        params = [float(x) for x in args.sparams]
        # draw spirograph with given parameters
        # black by default
        col = (0.0, 0.0, 0.0)
        spiro = Spiro(0, 0, col, *params)           # 利用任何提取的参数来构造Spiro 对象
        spiro.draw()                                # 调用draw()，绘制螺线
    else:
        # create animator object
        spiroAnim = SpiroAnimator(4)                # 创建一个 SpiroAnimator 对象，向它传入参数4，告诉它创建4 幅图画
        # add key handler to toggle turtle cursor
        turtle.onkey(spiroAnim.toggleTurtles, "t")  # 利用onkey()来捕捉按键T，这样就可以用它来切换海龟光标（toggleTurtles）
        # add key handler to restart animation
        turtle.onkey(spiroAnim.restart, "space")    # 处理空格键（space），这样就可以用它在任何时候重新启动动画

    # start turtle main loop
    turtle.mainloop()                               # 调用mainloop()告诉tkinter 窗口保持打开，监听事件

# call main
if __name__ == '__main__':
    main()

    
# python spiro.py
# python spiro.py --sparams 300 100 0.9
