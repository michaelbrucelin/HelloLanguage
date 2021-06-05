# 使用python启动其他程序

import subprocess

# 1. 打开程序
subprocess.Popen(r'C:\Windows\System32\calc.exe')

paintProc = subprocess.Popen(r'C:\Windows\System32\mspaint.exe')
paintProc.poll() == None  # True 只要程序仍然在运行，返回值就是None
paintProc.wait()          # 0 只要程序仍然在允许，就一直阻塞，直到程序结束，返回值为程序的退出码
paintProc.poll() == None  # False 程序退出后，函数返回值为程序的退出码
paintProc.poll()          # 0

# 2. 传递参数
subprocess.Popen([r'C:\Windows\System32\notepad.exe', 'data\test.txt'])
subprocess.Popen([r'C:\Program Files\Python38\python.exe', 'hello.py'])

# 3. 使用Windows中已配置的默认程序打开文件
subprocess.Popen(['start', 'hello.txt'], shell=True)
