f = open("demo09.txt", "w")  # 打开文件，w模式下，如果文件不存在就新建文件
for i in range(10):
    f.write("hello world 0%d\n" % i)
f.close()  # 关闭文件

f = open("demo09.txt", "r")
print(f.read(5))
print(f.read(5))
print(f.read(5))
print(f.read(5))
f.close()

f = open("demo09.txt", "r")
print(f.readline())
print(f.readline())
print(f.readline())
print(f.readline())
f.close()

f = open("demo09.txt", "r")
i = 1
for line in f.readlines():
    print("%d: %s" % (i, line))
    i += 1
f.close()
