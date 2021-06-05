import threading
import time

# 1. 创建一个线程


def takeANap():
    time.sleep(5)
    print('Wake up!')


print('Start of program.')
threadObj = threading.Thread(target=takeANap)
threadObj.start()
print('End of program.')

# 2. 向线程中传入参数
threadObj = threading.Thread(
    target=print, args=['Cats', 'Dogs', 'Frogs'], kwargs={'sep': ' & '})
threadObj.start()
