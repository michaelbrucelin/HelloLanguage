"""
1. 从命令行参数中获取地址，如果没有参数，就从剪切板中获取地址
2. 然后使用浏览器在google地图中打开指定的位置
"""

import sys
import webbrowser
import pyperclip

if len(sys.argv) > 1:
    # 从命令行参数中获取地址
    address = ' '.join(sys.argv[1:])
else:
    # 从剪切板中获取地址
    address = pyperclip.paste()

webbrowser.open("https://www.google.com/maps/place/"+address)
