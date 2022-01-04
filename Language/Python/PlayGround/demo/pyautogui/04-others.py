import pyautogui

# 1. sleep()与countdown()
pyautogui.sleep(3)  # 与time.sleep()等效，就是让脚本不必import time
pyautogui.countdown(5)  # 输出倒计时的数字，提供一些视觉效果

print("Starting in ", end="")
pyautogui.countdown(3)

# 2. 现实消息框
pyautogui.alert("This is a message.", "Important")
pyautogui.confirm("Do you want to continue?")
pyautogui.prompt("What is your name?")
pyautogui.password("What is your password?")
