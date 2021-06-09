import pyautogui

# 1. 获取屏幕快照
img = pyautogui.screenshot()

# 2. 分析屏幕快照
# 通常在自动化脚本的click()之前，可以比较一下当前的颜色是否正确，以免因为程序卡顿异常等问题单击了不应该单击的对象
pyautogui.pixel(0, 0)  # (55, 55, 55)  返回屏幕指定位置的颜色
pyautogui.pixel(50, 200)  # (12, 12, 12)
pyautogui.pixelMatchesColor(50, 200, (12, 12, 12))  # True  查看颜色是否匹配
pyautogui.pixelMatchesColor(50, 200, (12, 12, 18))  # False

# 3. 图像识别
c = pyautogui.locateOnScreen('data/close.png')
c
