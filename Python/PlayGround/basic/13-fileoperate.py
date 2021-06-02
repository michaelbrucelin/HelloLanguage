# file operate

# 1. read
filename = '12-pi_digits.txt'
with open(filename) as file_object:  # with表示在不再需要访问文件后将其关闭，有点像C#中的using()
    contents = file_object.read()
print(contents.rstrip())

# 2. 逐行读取
with open(filename) as file_object:
    for line in file_object:
        print(line.rstrip())

# 3. 将读取到的内容放入列表
with open(filename) as file_object:
    lines = file_object.readlines()
for line in lines:
    print(line.rstrip())

# 4. 检查自己的生日是否在pi的前100W位中
filename = '12-pi_million_digits.txt'
with open(filename) as file_object:
    lines = file_object.readlines()
pi_string = ''
for line in lines:
    pi_string += line.strip()

print(len(pi_string))
print(f"{pi_string[:52]}... ...")

birthday = '19880808'
if birthday in pi_string:
    print("Your birthday appears in the first million digits of pi!")
else:
    print("Your birthday does not appear in the first million digits of pi.")

# 5. write
filename = '12-programming.txt'
with open(filename, 'w') as file_object:  # r(default), w, a, r+
    file_object.write("I love python.")

# 6. 手动挡（不使用with），更精细的操控
filename = '12-programming.txt'
f = open(filename, "w")
for i in range(10):
    f.write("hello world 0%d\n" % i)
f.close()

f = open(filename, "r")
for i in range(4):
    print(f.read(5))
f.close()

f = open(filename, "r")
for i in range(4):
    print(f.readline())
f.close()

f = open(filename, "r")
i = 1
for line in f.readlines():
    print("%d: %s" % (i, line))
    i += 1
f.close()
