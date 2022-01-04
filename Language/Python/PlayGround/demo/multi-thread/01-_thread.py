import _thread
import time


def print_time(threadName, delay):
    """为线程定义一个函数"""
    count = 0
    while count < 5:
        time.sleep(delay)
        count += 1
        print("%s: %s" % (threadName, time.ctime(time.time())))


# 调用_thread模块中的start_new_thread()函数来产生新线程
# 创建两个线程
try:
    _thread.start_new_thread(print_time, ("Thread-1", 1,))
    _thread.start_new_thread(print_time, ("Thread-2", 2,))
except:
    print("Error: 无法启动线程")

while True:
    pass

# 执行后键入Ctrl+C停止程序
