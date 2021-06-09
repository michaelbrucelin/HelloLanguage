# python可以使用第三方模块pyautogui来控制鼠标和键盘，实现gui自动化
# python.exe -m pip install pyautogui

import pyautogui, time

# 1. 获取屏幕大小
wh = pyautogui.size()
wh  # Size(width=1600, height=900)
wh[0]  # 1600
wh.width  # 1600

# 2. 移动鼠标指针
for i in range(10):
    pyautogui.moveTo(100, 100, duration=0.25)  # moveTo()移动到绝对位置
    pyautogui.moveTo(200, 100, duration=0.25)
    pyautogui.moveTo(200, 200, duration=0.25)
    pyautogui.moveTo(100, 200, duration=0.25)

for i in range(10):
    pyautogui.move(100, 0, duration=0.25)  # 右 move()移动到相对位置
    pyautogui.move(0, 100, duration=0.25)  # 下
    pyautogui.move(-100, 0, duration=0.25)  # 左
    pyautogui.move(0, -100, duration=0.25)  # 上

# 3. 获取鼠标位置
pyautogui.position()  # Point(x=743, y=545)
p = pyautogui.position()
p  # Point(x=743, y=545)
p[0]  # 743
p.x  # 743

# 4. 单击鼠标
pyautogui.click()  # 鼠标左键单击当前位置
pyautogui.click(1, pyautogui.size().height - 2)  # 单击指定位置，打开开始菜单
pyautogui.mouseDown()  # 鼠标左键按下鼠标，不松开
pyautogui.mouseUp()  # 鼠标左键松开
pyautogui.doubleClick()
pyautogui.rightClick()
pyautogui.middleClick()

# 5. 拖动鼠标
# dragTo()拖动到绝对位置，drag()拖动到相对位置
# 打开windows画图工具，占据屏幕的右半屏，打开终端，占据屏幕的左半屏执行代码，可以观察鼠标拖动的过程
time.sleep(5)  # 等待5s，这时可以选中铅笔或画笔工具
pyautogui.moveTo(int(pyautogui.size().width * 0.75 - 150), 300)  # 鼠标移动到画图工具上
pyautogui.click()  # 激活画图工具
distance = 300
change = 20
while distance > 0:
    pyautogui.drag(distance, 0, duration=0.2)  # 右
    distance -= change
    pyautogui.drag(0, distance, duration=0.2)  # 下
    pyautogui.drag(-distance, 0, duration=0.2)  # 左
    distance -= change
    pyautogui.drag(0, -distance, duration=0.2)  # 上

# 6. 滚动鼠标
pyautogui.scroll(100)

# 7. 规划鼠标运动
pyautogui.mouseInfo()  # 打开一个pyautogui内置的一个gui，获取鼠标的信息，有点excel录制宏或按键精灵的味道
