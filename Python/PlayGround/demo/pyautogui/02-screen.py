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
c = pyautogui.locateOnScreen('data/winclose.png')  # 获取屏幕上第一次出现winclose.png图片的位置
c  # Box(left=1483, top=122, width=43, height=26)
pyautogui.click(tuple(c))  # 鼠标点击获取到的位置
pyautogui.click('data/winclose.png')  # 也可以这样直接传递一个图片作为参数，moveTo()与dragTo()方法也可以直接接图片为参数

c = pyautogui.locateAllOnScreen('data/winclose.png')  # 这样可以获取屏幕上所有出现图片的位置

# 4. 获取窗口信息
# 使用上面的图像识别功能，实际效果并不是很好用，因为图像只要有一个像素不一致就无法识别
# 例如截图工具的截图有边框，又或者截图时窗口是有焦点的，而识别图像时窗口是没有焦点的导致图像有差异等等
# 获取活动窗口
aw = pyautogui.getActiveWindow()
aw  # Win32Window(hWnd=198004)
str(aw)
# '<Win32Window left="-7", top="0", width="814", height="877", title="Administrator: PowerShell">'
aw.title  # 'Administrator: PowerShell'
aw.size   # Size(width=814, height=877)
aw.left, aw.top, aw.right, aw.bottom  # (-7, 0, 807, 877)
aw.topleft  # Point(x=-7, y=0)
aw.area     # 713878

# 获取其他窗口
pyautogui.getAllWindows()  # 获取屏幕上所有可见的Windows窗口
pyautogui.getWindowsAt(100, 100)  # 返回所有包含点(100, 100)的可见的Windows窗口
pyautogui.getWindowsWithTitle("title")  # 返回所有标题栏包含字符串title的可见的Windows窗口
pyautogui.getActiveWindow()  # 返回当前获取焦点的Windows窗口
pyautogui.getAllTitles()  # 返回所有可见的Windows窗口的title

# 5. 操纵窗口
aw = pyautogui.getActiveWindow()
aw.width = 1024
aw.topleft = (100, 100)
aw.isMaximized
aw.isMinimized
aw.isActive
aw.maximize()
aw.restore()  # 将窗口还原为最大|小化之前的大小
aw.minimize()
