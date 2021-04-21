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