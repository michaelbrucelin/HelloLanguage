import pyautogui

# 1. 发送字符串
# 将终端放在屏幕的左边，在屏幕的右边打开一个txt
pyautogui.click(1280, 200)
pyautogui.write("Hello World.", 0.25)

# 2. 键名
pyautogui.click(1280, 200)
pyautogui.write(["a", "b", "left", "left", "X", "Y"])
# 上面输入的是 XYab，'left'表示左箭头的意思
# 还有其他的“键名”，例如'esc', 'backspace', 'home'等很多，具体的需要差说明文档

# 3. 按下和释放键盘按键
# 输入 $ 符号
pyautogui.click(1280, 200)
pyautogui.keyDown("shift")
pyautogui.press("4")
pyautogui.keyUp("shift")

# 4. 快捷键
# 复制粘贴全部文本
pyautogui.click(1280, 200)
pyautogui.hotkey("ctrl", "a")
pyautogui.hotkey("ctrl", "c")
pyautogui.hotkey("ctrl", "v")
