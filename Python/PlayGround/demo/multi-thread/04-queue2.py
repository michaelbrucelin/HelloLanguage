import time
# 使用 threading 模块创建线程
import threading
# 优先级队列模块
# 线程优先级队列(Queue)
import queue

exitFlag = 0


class myThread (threading.Thread):
    def __init__(self, threadID, name, q):
        threading.Thread.__init__(self)
        self.threadID = threadID
        self.name = name
        self.q = q

    def run(self):
        print("开启线程：" + self.name)
        process_data(self.threadID, self.name, self.q)
        print("退出线程：" + self.name)


def process_data(id, threadName, q):
    while not exitFlag:
        id += 1
        if id >= 4:
            data = q.get()
            print("%s processing %s" % (threadName, data))
        time.sleep(1)


threadList = ["Thread-1", "Thread-2", "Thread-3"]     # 工作线程
nameList = ["One", "Two", "Three", "Four", "Five"]    # 工作任务
workQueue = queue.Queue(10)
threads = []
threadID = 1
# 填充队列
for word in nameList:
    workQueue.put(word)
# 创建新线程
for tName in threadList:
    thread = myThread(threadID, tName, workQueue)
    thread.start()
    threads.append(thread)
    threadID += 1
# 等待队列清空
while not workQueue.empty():
    pass
# 通知线程是时候退出
exitFlag = 1
# 等待所有线程完成
for t in threads:
    t.join()
print("退出主线程")
