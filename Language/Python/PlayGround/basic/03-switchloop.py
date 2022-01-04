# 1. if判断的表达式写法
age = 16
print("未满18岁禁止访问！") if age < 18 else print("欢迎访问本站点。")

a = 3
b = 5
min = a if a < b else b
print(min)

# 2. loop(while/for)中的else
# 在C#中，如果想判断一个循环是否被break，需要单独一个bool变量来记录状态
# 而在python中可以直接使用else来确认
day = 1
while day <= 7:
    answer = input("今天打卡了吗？")
    if answer.upper() != "Y":
        break
    day += 1
else:
    print("恭喜你连续学习了7天！")

# 3. for循环
for i in range(1, 10, 3):
    print(i)

# 4. 其他写法
if True:
    print("true")
elif True:
    print("elif true")
else:
    print("false")

for i in range(4):
    print(i, end="\t")  # 0       1       2       3
print()

for i in range(0, 10, 3):
    print(i, end="\t")  # 0       3       6       9
print()

for i in range(-10, -100, -30):
    print(i, end="\t")  # -10     -40     -70
print()

name = "mlin"
for c in name:
    print(c, end="\t")  # m       l       i       n
print()

arr = ["aa", "bb", "cc", "dd"]
for i in range(len(arr)):
    print(i, arr[i])
print()
# 0 aa
# 1 bb
# 2 cc
# 3 dd

arr = ["aa", "bb", "cc", "dd"]
for item in arr:
    print(item)
print()
# aa
# bb
# cc
# dd

arr = ["aa", "bb", "cc", "dd"]
for i, item in enumerate(arr):
    print(i, item)
print()
# 0 aa
# 1 bb
# 2 cc
# 3 dd

i = 0
while i < 4:
    print("i=%d" % i)
    i += 1
print()

count = 0
while count < 4:
    print(count, "<4")
    count += 1
else:
    print()
    print(count, ">=4")
print()

for m in range(1, 10, 1):
    for n in range(1, m+1, 1):
        print("%d * %d = %d" % (m, n, m*n), end="\t")
    print()
print()

p = 1
q = 1
while p < 10:
    q = 1
    while q <= p:
        print("%d * %d = %d" % (p, q, p*q), end="\t")
        q += 1
    print()
    p += 1
print()
